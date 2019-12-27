using Interface;
using System.Collections.Generic;

namespace LoadTarget
{
  /// <summary>
  /// テストクラス
  /// </summary>
  public class TestClass : ITestClass
  {
    /// <summary>
    /// 文字列から数値型に変換する
    /// </summary>
    /// <param name="src">文字列</param>
    /// <returns>数値</returns>
    public string HelloWorld()
    {
      return "HelloWorld!!LoadTarget.TestClass!";
    }

    /// <summary>
    /// 文字列リストを取得する
    /// </summary>
    /// <returns>文字列リスト</returns>
    public decimal StringToInt(string src)
    {
      var result = decimal.MinValue;
      if (!decimal.TryParse(src,out result))
      {
        return decimal.MinValue;
      }
      return result;
    }

    /// <summary>
    /// helloworldを返す
    /// </summary>
    /// <returns>helloworld文字列</returns>
    public List<string> GetList()
    {
      return new List<string>
      {
        "LoadTarget.TestClass!",
        "TestClass!!"
      };
    }

  }
}
