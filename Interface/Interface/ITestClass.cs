using System.Collections.Generic;

namespace Interface
{
  /// <summary>
  /// テストクラス用インターフェース
  /// </summary>
  public interface ITestClass
  {
    /// <summary>
    /// helloworldを返す
    /// </summary>
    /// <returns>helloworld文字列</returns>
    public string HelloWorld();

    /// <summary>
    /// 文字列から数値型に変換する
    /// </summary>
    /// <param name="src">文字列</param>
    /// <returns>数値</returns>
    public decimal StringToInt(string src);

    /// <summary>
    /// 文字列リストを取得する
    /// </summary>
    /// <returns>文字列リスト</returns>
    public List<string> GetList();
  }
}
