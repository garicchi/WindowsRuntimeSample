// 空白のテンプレートの概要については、次のドキュメントを参照してください:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    //WindowsRuntimeコンポーネントのオブジェクト
    var sampleCS = new WinRTComponentCS.SampleClass();
    var sampleCPP = new WinRTComponentCPP.SampleClass();

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                // TODO: このアプリケーションは新しく起動しました。ここでアプリケーションを
                // 初期化します。
            } else {
                // TODO: このアプリケーションは中断状態から再度アクティブ化されました。
                // ここでアプリケーションの状態を復元します。
            }
            args.setPromise(WinJS.UI.processAll());


            
            btn_calcSum_cs.addEventListener("click", function (e) {
                //C# WindowsRuntime Component呼び出し
                text_calcSum_cs.innerText = sampleCS.calcSum(10, 20);
            });
            btn_calcSum_cpp.addEventListener("click", function (e) {
                //C++ WindowsRuntime Component呼び出し
                text_calcSum_cpp.innerText = sampleCPP.calcSum(10, 20);
            });

            btn_showDialog_cs.addEventListener("click", function (e) {
                //C# WindowsRuntime Component呼び出し
                sampleCS.showDialogAsync("非同期で実行しています")
            });
            btn_showDialog_cpp.addEventListener("click", function (e) {
                //C++ WindowsRuntime Component呼び出し
                sampleCPP.showDialogAsync("非同期で実行しています");
            });

            //C# WindowsRuntime Componentイベント登録
            sampleCS.addEventListener("onevent", function (e) {
                text_goEvent_cs.innerText = "イベントが発生しました";
            });

            //C++ WindowsRuntime Componentイベント登録
            sampleCPP.addEventListener("onevent", function (e) {
                text_goEvent_cpp.innerText = "イベントが発生しました";
            });

            btn_goEvent_cs.addEventListener("click", function (e) {
                //C# WindowsRuntime Component呼び出し
                sampleCS.goEvent();
            });
            btn_goEvent_cpp.addEventListener("click", function (e) {
                //C++ WindowsRuntime Component呼び出し
                sampleCPP.goEvent();
            });
        }
    };
    
    app.oncheckpoint = function (args) {
        // TODO: このアプリケーションは中断しようとしています。ここで中断中に
        // 維持する必要のある状態を保存します。中断中に自動的に保存され、
        // 復元される WinJS.Application.sessionState オブジェクトを使用
        // できます。アプリケーションを中断する前に
        // 非同期操作を完了する必要がある場合は、
        // args.setPromise() を呼び出してください。
    };

    
    

    app.start();
})();
