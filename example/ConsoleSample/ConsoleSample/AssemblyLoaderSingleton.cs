using LoadAssembly;

namespace ConsoleSample
{
  /// <summary>
  /// コンソール用アセンブリローダー(シングルトン)
  /// </summary>
  public class AssemblyLoaderSingleton : AssemblyLoader
  {
    /// <summary>
    /// インスタンス
    /// </summary>
    private static AssemblyLoaderSingleton instance = new AssemblyLoaderSingleton();

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <remarks>シングルトンのためprivate</remarks>
    private AssemblyLoaderSingleton()
    {

    }

    /// <summary>
    /// インスタンス取得
    /// </summary>
    /// <returns>インスタンス</returns>
    public static AssemblyLoaderSingleton GetInstance()
    {
      return instance;
    }
  }
}
