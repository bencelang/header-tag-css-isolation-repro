using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace header_tag_css_isolation_repro.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [Display(Name = "This label does not work")]
    public string SomeProperty { get; set; } = "This input does not work";

    public string ThisDoesNotWorkEither { get; set; } = "Neither does this input filed";

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
