using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace ComponentClientCS
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //C++で記述されたWindowsRuntimeコンポーネントクラス
        WinRTComponentCPP.SampleClass _sampleCpp;
        public MainPage()
        {
            this.InitializeComponent();
            
            this._sampleCpp = new WinRTComponentCPP.SampleClass();
            //イベントを登録
            this._sampleCpp.OnEvent += () =>
            {
                this.text_goEvent.Text = "イベントを受け取りました";
            };
        }

        private void btn_calcSum_Click(object sender, RoutedEventArgs e)
        {
            //プリミティブ型を使うメソッド呼び出し
            var result = _sampleCpp.CalcSum(10,20);
            this.text_calcSum.Text = result.ToString();
        }

        private async void btn_showDialog_Click(object sender, RoutedEventArgs e)
        {
            //非同期メソッドの呼び出し
            await this._sampleCpp.ShowDialogAsync("非同期で呼び出しています");
        }

        private void btn_goEvent_Click(object sender, RoutedEventArgs e)
        {
            //イベントを発火するメソッドを呼び出し
            this._sampleCpp.GoEvent();
        }
    }
}
