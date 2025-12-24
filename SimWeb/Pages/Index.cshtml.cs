using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimWeb.Pages;

public class IndexModel : PageModel
{
    public string Moves { get; } = "dlrludluddlrulr";
    public void OnGet() { }
}
