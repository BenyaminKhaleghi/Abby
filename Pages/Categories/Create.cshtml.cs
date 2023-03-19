using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abby.Data;
using Abby.Model;

namespace AbbyWeb.Pages.Categories;
[BindProperties]
public class CreateModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ApplicationDbContext _db;
    public Category Category{ get; set; }

    public CreateModel(ILogger<IndexModel> logger, ApplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if (Category.Name == Category.DisplayOrder.ToString())
            ModelState.AddModelError("Category.Name", "The DisplayOrder can not be the same as Name");
        if (ModelState.IsValid)
        {
            await _db.Categories.AddAsync(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Successfully created!";
            return RedirectToPage("Index");
        }
        return Page();
    }

}
