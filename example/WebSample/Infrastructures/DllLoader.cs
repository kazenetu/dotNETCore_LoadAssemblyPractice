using LoadAssembly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Infrastructures
{
  /// <summary>
  /// コンストラクタ付きアセンブリ管理クラス
  /// </summary>
  public class DllLoader: AssemblyLoader
  {
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public DllLoader()
    {
      // 読み込み対象のdllのフルパス設定
      var thisPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      var assemblyPath = Path.Combine(thisPath, "LoadTarget.dll");

      Load(assemblyPath);
    }
  }
}
