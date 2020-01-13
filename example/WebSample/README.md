# .NETCoreのdll動的読み込みの実装確認:Web
Webアプリケーションの実装確認  

## ビルド方法
本ディレクトリ(example/WebSample)をカレントディレクトリとする。
* VisualStudio(2019以降)
   1. WebSample.slnを開く
   1. 実行する

* dotnetコマンド(3.1以上)  
    ```sh
    dotnet run -p WebSample/WebSample.csproj
    ```
    【実行結果】(Ctrl+Cで終了)  
    ```
    info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000        
    info: Microsoft.Hosting.Lifetime[0]
         Application started. Press Ctrl+C to shut down.
    info: Microsoft.Hosting.Lifetime[0]
    ```

## dll読み込み実績の詳細
※シングルトンとしてDIを設定。  
* dll動的読み込み管理クラスをスーパークラスとした「コンストラクタを追加したサブクラス」を追加  
  コンストラクタで特定のdllを読み込む処理を実装

* サブクラス用インターフェースを追加  
  「コンストラクタを追加したサブクラス」に本インターフェースの継承を追加

*  利用側はサブクラス用インターフェース経由でインスタンスを取得


# 参考サイト
* [.NET Coreでアセンブリをアンロードする：AYU MAX(ayuma様)](https://www.ayumax.net/entry/2019/12/10/000000)
* [.NET Core でアセンブリのアンローダビリティを使用およびデバッグする方法](https://docs.microsoft.com/ja-jp/dotnet/standard/assembly/unloadability)
