﻿using System;
using System.IO;
using System.Reflection;

namespace LoadAssembly
{
  class Program
  {
    static void Main(string[] args)
    {
      // 読み込み対象のdllのフルパス設定
      var thisPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      var assemblyPath = Path.Combine(thisPath,"LoadTarget.dll");

      // dll読み込み
      var alc = new TestAssemblyLoadContext();
      Assembly a = alc.LoadFromAssemblyPath(assemblyPath);

      // 対象クラスのインスタンス生成
      var type = a.GetType("LoadTarget.Class1");
      var instance = Activator.CreateInstance(type);

      // 呼び出しメソッドを取得
      var testMethod = type.GetMethod("TestMethod");

      // メソッド呼び出し(戻り値 string)
      Console.WriteLine($"testMethod call:[{testMethod.Invoke(instance, null)}]");

      alc.Unload();
    }
  }
}