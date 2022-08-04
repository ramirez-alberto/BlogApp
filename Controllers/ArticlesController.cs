using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogApp.Data;
using BlogApp.Models;

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

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ArticleID,Title,Body")] Article article)
    {
        if (ModelState.IsValid)
        {
            _context.Add(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        return View(article);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null || _context.Article is null)
        {
            return NotFound();
        }

        var article = await _context.Article.FindAsync(id);

        if (article is null)
        {
            return NotFound();
        }

        return View(article);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ArticleID,Title,Body")] Article article)
    {
        if (id != article.ArticleID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(article);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(article.ArticleID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }


        return View(article);
    }
    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null || _context.Article is null)
        {
            return NotFound();
        }

        var article = await _context.Article
            .FirstOrDefaultAsync(m => m.ArticleID == id);
        if (article is null)
        {
            return NotFound();
        }

        return View(article);
    }

    [HttpPost,ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Article is null)
        {
            return Problem("Entity set 'MvcArticleContext.Article'  is null.");
        }

        var article = await _context.Article.FindAsync(id);
        if (article is not null)
        {
            _context.Article.Remove(article);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }



    private bool ArticleExists(int id)
    {
        return (_context.Article?.Any(e => e.ArticleID == id)).GetValueOrDefault();
    }
}
