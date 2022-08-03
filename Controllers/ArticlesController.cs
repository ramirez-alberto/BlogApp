using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogApp.Data;

namespace BlogApp.Controllers;

public class ArticlesController : Controller
{
    private readonly MvcArticleContext _context;

    public ArticlesController(MvcArticleContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Article.ToListAsync());
    }

    public async Task<IActionResult> Show(int? id)
    {
        if (id == null || _context.Article == null)
        {
            return NotFound();
        }

        var article = await _context.Article
            .FirstOrDefaultAsync(m => m.ArticleID == id);
        if (article == null)
            return NotFound();

        return View(article);
    }
}
