using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abby.Data;
using Abby.Model;

namespace AbbyWeb.Pages.Categories;
[BindProperties]
public class DeleteModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ApplicationDbContext _db;
    public Category Category{ get; set; }

    public DeleteModel(ILogger<IndexModel> logger, ApplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public void OnGet(int id)
    {
        if (id > 0)
            Category = _db.Categories.Find(id);
    }

    public async Task<IActionResult> OnPost()
    {
        var categoryFromDb = _db.Categories.Find(Category.Id);
        if (categoryFromDb != null)
        {
            _db.Categories.Remove(categoryFromDb);
            await _db.SaveChangesAsync();
            TempData["success"] = "Successfully deleted!";
            return RedirectToPage("Index");
        }
        return Page();
    }

}
