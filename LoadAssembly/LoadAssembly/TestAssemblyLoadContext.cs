using System.Reflection;
using System.Runtime.Loader;

namespace LoadAssembly
{
  public class TestAssemblyLoadContext : AssemblyLoadContext
  {
    public TestAssemblyLoadContext() : base(isCollectible: true)
    {
    }

    protected override Assembly Load(AssemblyName name)
    {
      return null;
    }
  }
}
