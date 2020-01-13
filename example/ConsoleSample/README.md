# .NETCoreのdll動的読み込みの実装確認:コンソール
コンソールアプリケーションの実装確認  

## ビルド方法
本ディレクトリ(example/ConsoleSample)をカレントディレクトリとする。
* VisualStudio(2019以降)
   1. ConsoleSample.slnを開く
   1. 実行する

* dotnetコマンド(3.1以上)  
    ```sh
    dotnet run -p ConsoleSample/ConsoleSample.csproj
    ```

## dll読み込み実績の種類と詳細
※読み込んだdllを管理するクラスはシングルトンとした。
* クラスインスタンスのメソッド実行(**callClassMethodメソッド**)  
  クラスインスタンスを取得し  
  さらに実行対象メソッドのMethodInfoを取得。  
  MethodInfo＃Invokeメソッドで対象メソッドを利用する実装

* インターフェースインスタンスのメソッド実行(**callInterfaceMethodメソッド**)    
   クラスインスタンスを取得する段階でインターフェースにキャスト。  
   以降はインターフェースのメソッドを実行する実装


# 参考サイト
* [.NET Coreでアセンブリをアンロードする：AYU MAX(ayuma様)](https://www.ayumax.net/entry/2019/12/10/000000)
* [.NET Core でアセンブリのアンローダビリティを使用およびデバッグする方法](https://docs.microsoft.com/ja-jp/dotnet/standard/assembly/unloadability)
