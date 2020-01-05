using Interface;
using System;
using System.IO;
using System.Reflection;
using System.Linq;
using LoadAssembly;

namespace ConsoleSample
{
  class Program
  {
    static void Main(string[] args)
    {
      // 読み込み対象のdllのフルパス設定
      var thisPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      var assemblyPath = Path.Combine(thisPath, "LoadTarget.dll");

      // dll読み込み
      var alc = new TestAssemblyLoadContext();
      Assembly a = alc.LoadFromAssemblyPath(assemblyPath);

      // クラスインスタンスのメソッド呼び出し
      callClassMethod(a);

      // dllアセンブリを解放
      alc.Unload();

      // インターフェースのメソッドを実行
      callInterfaceMethod(assemblyPath);

    }

    /// <summary>
    /// クラスインスタンスのメソッドを実行
    /// </summary>
    /// <param name="a">読み込んだアセンブリ</param>
    static void callClassMethod(Assembly a)
    {

      // 対象クラスのインスタンス生成
      var type = a.GetType("LoadTarget.Class1");
      var instance = Activator.CreateInstance(type);

      // 呼び出しメソッドを取得
      var testMethod = type.GetMethod("TestMethod");

      // メソッド呼び出し(戻り値 string)
      Console.WriteLine($"testMethod call:[{testMethod.Invoke(instance, null)}]");

    }

    /// <summary>
    /// インターフェースのメソッドを実行
    /// </summary>
    /// <param name="filePath">アセンブリのファイルパス</param>
    static void callInterfaceMethod(string filePath)
    {

      // アセンブリローダーのインスタンス取得
      var loader = new AssemblyLoader();

      // アセンブリ読み込み
      loader.Load(filePath);

      // 対象クラスのインスタンス取得
      var instance = loader.GetInterfaceInstance<ITestClass>();
      if (instance is null)
      {
        // 取得できない場合は終了
        Console.WriteLine($"callInterfaceMethod:[noclass:TestClass]");
        return;
      }

      // メソッド呼び出し(戻り値 string)
      Console.WriteLine($"HelloWorld call:[{instance.HelloWorld()}]");

      // リスト系メソッド呼び出し(戻り値 string)
      Console.WriteLine($"GetList call:[{string.Join(" , ", instance.GetList())}]");

    }

  }
}
