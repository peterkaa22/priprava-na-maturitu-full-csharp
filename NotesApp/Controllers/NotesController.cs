using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesApp.Data;
using NotesApp.Models;
using NotesApp.Models.ViewModels;

namespace NotesApp.Controllers;

[Authorize]
public class NotesController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<ApplicationUser> _userManager;

    public NotesController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index(bool importantOnly = false)
    {
        var userId = _userManager.GetUserId(User);
        if (string.IsNullOrWhiteSpace(userId))
        {
            return Challenge();
        }

        var notesQuery = _dbContext.Notes.Where(n => n.UserId == userId);
        if (importantOnly)
        {
            notesQuery = notesQuery.Where(n => n.IsImportant);
        }

        var notes = await notesQuery
            .OrderByDescending(n => n.CreatedAtUtc)
            .ToListAsync();

        var viewModel = new NotesIndexViewModel
        {
            Notes = notes,
            ShowImportantOnly = importantOnly
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(NotesIndexViewModel model)
    {
        var userId = _userManager.GetUserId(User);
        if (string.IsNullOrWhiteSpace(userId))
        {
            return Challenge();
        }

        if (!ModelState.IsValid)
        {
            var notesQuery = _dbContext.Notes.Where(n => n.UserId == userId);
            if (model.ShowImportantOnly)
            {
                notesQuery = notesQuery.Where(n => n.IsImportant);
            }

            model.Notes = await notesQuery
                .OrderByDescending(n => n.CreatedAtUtc)
                .ToListAsync();
            return View("Index", model);
        }

        var note = new Note
        {
            Title = model.NewNote.Title.Trim(),
            Content = model.NewNote.Content.Trim(),
            CreatedAtUtc = DateTime.UtcNow,
            UserId = userId
        };

        _dbContext.Notes.Add(note);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index), new { importantOnly = model.ShowImportantOnly });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, bool importantOnly = false)
    {
        var userId = _userManager.GetUserId(User);
        if (string.IsNullOrWhiteSpace(userId))
        {
            return Challenge();
        }

        var note = await _dbContext.Notes.FirstOrDefaultAsync(n => n.Id == id && n.UserId == userId);
        if (note is null)
        {
            return NotFound();
        }

        _dbContext.Notes.Remove(note);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index), new { importantOnly });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleImportant(int id, bool importantOnly = false)
    {
        var userId = _userManager.GetUserId(User);
        if (string.IsNullOrWhiteSpace(userId))
        {
            return Challenge();
        }

        var note = await _dbContext.Notes.FirstOrDefaultAsync(n => n.Id == id && n.UserId == userId);
        if (note is null)
        {
            return NotFound();
        }

        note.IsImportant = !note.IsImportant;
        await _dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index), new { importantOnly });
    }
}