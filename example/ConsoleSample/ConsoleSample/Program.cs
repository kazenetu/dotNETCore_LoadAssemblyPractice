﻿using Interface;
using System;
using System.IO;
using System.Reflection;
using System.Linq;

namespace LoadAssembly
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

      // インターフェースのメソッドを実行
      callInterfaceMethod(a);

      // dllアセンブリを解放
      alc.Unload();
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
    /// <param name="a">読み込んだアセンブリ</param>
    static void callInterfaceMethod(Assembly a)
    {
      // 対象クラスのインスタンス取得
      var instance = GetInterfaceInstance<ITestClass>(a);
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

    /// <summary>
    /// インターフェースインスタンス取得
    /// </summary>
    /// <typeparam name="T">インターフェース</typeparam>
    /// <param name="assembly">読み込んだアセンブリ</param>
    /// <returns>インターフェースインスタンスまたはnull</returns>
    static T GetInterfaceInstance<T>(Assembly assembly) where T : class
    {
      // 対象インターフェース名取得
      var typeName = typeof(T).FullName;

      // アセンブリからインターフェースを継承したクラスのTypeリストを取得
      var targets = assembly.GetTypes().Where(typeItem => typeItem.IsClass && typeItem.GetInterface(typeName) != null);
      if (!targets.Any())
      {
        return null;
      }

      // 最初のクラスTypeを取得
      var type = assembly.GetType(targets.First().FullName);
      if (type is null)
      {
        return null;

      }

      // インスタンスを返す
      return Activator.CreateInstance(type) as T;
    }
  }
}
