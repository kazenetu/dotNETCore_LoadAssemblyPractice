# dotNETCore_LoadAssemblyPractice
.NETCoreのdll動的読み込みの実装確認

## dll読み込み実績の種類と詳細
* クラスインスタンスのメソッド実行  
  クラスインスタンスを取得し  
  さらに実行対象メソッドのMethodInfoを取得。  
  MethodInfo＃Invokeメソッドで対象メソッドを利用する実装

* インターフェースインスタンスのメソッド実行  
   クラスインスタンスを取得する段階でインターフェースにキャスト。  
   以降はインターフェースのメソッドを実行する実装


# 参考サイト
* [.NET Coreでアセンブリをアンロードする：ayuma様](https://www.ayumax.net/entry/2019/12/10/000000)
* [.NET Core でアセンブリのアンローダビリティを使用およびデバッグする方法](https://docs.microsoft.com/ja-jp/dotnet/standard/assembly/unloadability)
