using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abby.Data;
using Abby.Model;

namespace AbbyWeb.Pages.Categories;
[BindProperties]
public class EditModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ApplicationDbContext _db;
    public Category Category{ get; set; }

    public EditModel(ILogger<IndexModel> logger, ApplicationDbContext db)
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
        if (Category.Name == Category.DisplayOrder.ToString())
            ModelState.AddModelError("Category.Name", "The DisplayOrder can not be the same as Name");
        if (ModelState.IsValid)
        {
            _db.Categories.Update(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Successfully updated!";
            return RedirectToPage("Index");
        }
        return Page();
    }

}
