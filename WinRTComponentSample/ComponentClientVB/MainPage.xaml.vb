' 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

''' <summary>
''' それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Private _sampleCpp As WinRTComponentCPP.SampleClass
    Public Sub New()
        Me._sampleCpp = New WinRTComponentCPP.SampleClass()
        AddHandler Me._sampleCpp.OnEvent, Function()
                                              Me.text_goEvent.Text = "イベントを受け取りました"

                                          End Function
        Me.InitializeComponent()
    End Sub


    Private Sub btn_calcSum_Click(sender As Object, e As RoutedEventArgs) Handles btn_calcSum.Click
        Dim result = Me._sampleCpp.CalcSum(10, 20)
        Me.text_calcSum.Text = result.ToString()
    End Sub

    Private Async Sub btn_showDialog_Click(sender As Object, e As RoutedEventArgs) Handles btn_showDialog.Click
        Await Me._sampleCpp.ShowDialogAsync("非同期で実行中です")
    End Sub

    Private Sub btn_goEvent_Click(sender As Object, e As RoutedEventArgs) Handles btn_goEvent.Click
        Me._sampleCpp.GoEvent()
    End Sub
End Class
