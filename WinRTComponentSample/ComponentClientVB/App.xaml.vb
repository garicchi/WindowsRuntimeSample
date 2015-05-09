' 空のアプリケーション テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234227 を参照してください

''' <summary>
''' 既定の Application クラスに対してアプリケーション独自の動作を実装します。
''' </summary>
NotInheritable Class App
    Inherits Application

    ''' <summary>
    ''' アプリケーションがエンド ユーザーによって正常に起動されたときに呼び出されます。他のエントリ ポイントは、
    ''' アプリケーションが特定のファイルを開くために呼び出されたときに
    ''' 検索結果やその他の情報を表示するために使用されます。
    ''' </summary>
    ''' <param name="e">起動要求とプロセスの詳細を表示します。</param>
    Protected Overrides Sub OnLaunched(e As Windows.ApplicationModel.Activation.LaunchActivatedEventArgs)
#If DEBUG Then
        ' デバッグ中にグラフィックスのプロファイル情報を表示します。
        If System.Diagnostics.Debugger.IsAttached Then
            ' 現在のフレーム レート カウンターを表示します
            Me.DebugSettings.EnableFrameRateCounter = True
        End If
#End If

        Dim rootFrame As Frame = TryCast(Window.Current.Content, Frame)

        ' ウィンドウに既にコンテンツが表示されている場合は、アプリケーションの初期化を繰り返さずに、
        ' ウィンドウがアクティブであることだけを確認してください

        If rootFrame Is Nothing Then
            ' ナビゲーション コンテキストとして動作するフレームを作成し、最初のページに移動します
            rootFrame = New Frame()
            ' 既定の言語を設定します
            rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages(0)

            AddHandler rootFrame.NavigationFailed, AddressOf OnNavigationFailed

            If e.PreviousExecutionState = ApplicationExecutionState.Terminated Then
                'TODO: 以前中断したアプリケーションから状態を読み込みます。
            End If
            ' フレームを現在のウィンドウに配置します
            Window.Current.Content = rootFrame
        End If
        If rootFrame.Content Is Nothing Then
            ' ナビゲーションの履歴スタックが復元されていない場合、最初のページに移動します。
            ' このとき、必要な情報をナビゲーション パラメーターとして渡して、新しいページを
            ' 作成します
            rootFrame.Navigate(GetType(MainPage), e.Arguments)
        End If

        ' 現在のウィンドウがアクティブであることを確認します
        Window.Current.Activate()
    End Sub

    ''' <summary>
    ''' 特定のページへの移動が失敗したときに呼び出されます
    ''' </summary>
    ''' <param name="sender">移動に失敗したフレーム</param>
    ''' <param name="e">ナビゲーション エラーの詳細</param>
    Private Sub OnNavigationFailed(sender As Object, e As NavigationFailedEventArgs)
        Throw New Exception("Failed to load Page " + e.SourcePageType.FullName)
    End Sub

    ''' <summary>
    ''' アプリケーションの実行が中断されたときに呼び出されます。アプリケーションの状態は、
    ''' アプリケーションが終了されるのか、メモリの内容がそのままで再開されるのか
    ''' わからない状態で保存されます。
    ''' </summary>
    ''' <param name="sender">中断要求の送信元。</param>
    ''' <param name="e">中断要求の詳細。</param>
    Private Sub OnSuspending(sender As Object, e As SuspendingEventArgs) Handles Me.Suspending
        Dim deferral As SuspendingDeferral = e.SuspendingOperation.GetDeferral()
        ' TODO: アプリケーションの状態を保存してバックグラウンドの動作があれば停止します
        deferral.Complete()
    End Sub

End Class
