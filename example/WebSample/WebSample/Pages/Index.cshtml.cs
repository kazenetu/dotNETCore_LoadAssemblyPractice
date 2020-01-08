using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interface;
using LoadAssembly;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebSample.Pages
{
  public class IndexModel : PageModel
  {
    private readonly ILogger<IndexModel> _logger;

    public ITestClass TestClass { private set; get; }

    public IndexModel(ILogger<IndexModel> logger, IAssemblyLoader loader)
    {
      _logger = logger;
      TestClass = loader.GetInterfaceInstance<ITestClass>();
    }

    public void OnGet()
    {

    }
  }
}
