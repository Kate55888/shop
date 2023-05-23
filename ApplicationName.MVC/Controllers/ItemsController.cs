using ApplicationName.Domain.Models;
using ApplicationName.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationName.MVC.Controllers;

[DisableCors]
[Authorize(Roles = "Administrator")]
public class ItemsController : Controller
{
    private readonly ApplicationDbContext? _db;

    public ItemsController(ApplicationDbContext? db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var objBookList = _db?.Items.ToList();
        return View(objBookList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Item obj)
    {
        _db?.Items.Add(obj);
        _db?.SaveChanges();
        return RedirectToAction("Index");
    }
    
    public IActionResult Delete(Guid? id)
    {
        var bookFromDb = _db.Items.Find(id);

        if (bookFromDb == null) return NotFound();

        return View(bookFromDb);
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(Guid? id)
    {
        var obj = _db.Items.Find(id);
        if (obj == null) return NotFound();

        _db.Items.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "Book deleted successfully";
        return RedirectToAction("Index");
    }
}
