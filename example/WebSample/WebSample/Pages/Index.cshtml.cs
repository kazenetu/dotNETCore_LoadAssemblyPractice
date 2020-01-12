using Infrastructures;
using Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebSample.Pages
{
  public class IndexModel : PageModel
  {
    private readonly ILogger<IndexModel> _logger;

    public ITestClass TestClass { private set; get; }

    public IndexModel(ILogger<IndexModel> logger, IDllLoader loader)
    {
      _logger = logger;
      TestClass = loader.GetInterfaceInstance<ITestClass>();
    }

    public void OnGet()
    {

    }
  }
}
