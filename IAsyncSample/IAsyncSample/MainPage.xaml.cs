using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

namespace IAsyncSample
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        IAsyncInfo currentAsyncTask;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void button_iasyncaction_Click(object sender, RoutedEventArgs e)
        {
            this.text_status.Text = "開始";
            var asyncTask = StartAsyncActionAsync();
            currentAsyncTask =asyncTask;

            await asyncTask;
            this.text_status.Text = "完了！";
        }

        private async void button_iasyncactionwithprogress_Click(object sender, RoutedEventArgs e)
        {
            var asyncTask = StartAsyncActionWithProgress();
            asyncTask.Progress = new AsyncActionProgressHandler<int>((asyncInfo, progress) =>
            {
                //Progress.Reportが呼ばれた時
                this.text_status.Text = "進捗" + progress;
            });

            currentAsyncTask = asyncTask;

            await asyncTask;

            this.text_status.Text = "完了！";
        }

        private async void button_iasyncoperation_Click(object sender, RoutedEventArgs e)
        {
            this.text_status.Text = "開始";
            var asyncTask = StartAsyncOperationAsync();
            currentAsyncTask = asyncTask;

            var result = await asyncTask;
            this.text_status.Text = result;
        }

        private async void button_iasyncoperationwidhprogress_Click(object sender, RoutedEventArgs e)
        {
            var asyncTask = StartAsyncOperationWithProgress();
            asyncTask.Progress = new AsyncOperationProgressHandler<string,int>((asyncInfo, progress) =>
            {
                //Progress.Reportが呼ばれた時
                this.text_status.Text = "進捗" + progress;
            });

            currentAsyncTask = asyncTask;

            var result = await asyncTask;

            this.text_status.Text = result;
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            //現在実行中のタスクをキャンセル
            currentAsyncTask.Cancel();
        }

        /// 返却値なし、進捗報告なし非同期メソッド(IAsyncAction)
        private IAsyncAction StartAsyncActionAsync()
        {
            return AsyncInfo.Run((token) =>
            {
                return Task.Run(() =>
                {
                    //すごく重い処理
                    for (int i = 0; i < 20; i++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            return;
                        }
                        else
                        {
                            var client = new HttpClient();
                            client.GetStringAsync("http://google.co.jp").Wait();
                        }
                    }
                    
                });
            });
        }

        /// 返却値なし、進捗報告あり非同期メソッド(IAsyncActionWithProgress)
        private IAsyncActionWithProgress<int> StartAsyncActionWithProgress()
        {
            return AsyncInfo.Run<int>((token,progress) =>
            {
                return Task.Run(() =>
                {
                    //すごく重い処理
                    for (int i = 0; i < 20; i++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            return;
                        }
                        else
                        {
                            var client = new HttpClient();
                            client.GetStringAsync("http://google.co.jp").Wait();
                            //進捗報告
                            progress.Report(i);
                        }
                    }
                    
                });
            });
        }

        /// 返却値あり、進捗報告なし非同期メソッド(IAsyncOperation)
        private IAsyncOperation<string> StartAsyncOperationAsync()
        {
            return AsyncInfo.Run<string>((token) =>
            {
                return Task.Run<string>(() =>
                {
                    //すごく重い処理
                    for (int i = 0; i < 20; i++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            return "キャンセルされました";
                        }
                        else
                        {
                            var client = new HttpClient();
                            client.GetStringAsync("http://google.co.jp").Wait();
                        }
                    }
                    return "返却値";
                });
            });
        }

        /// 返却値あり、進捗報告あり非同期メソッド(IAsyncOperationWithProgress)
        private IAsyncOperationWithProgress<string,int> StartAsyncOperationWithProgress()
        {
            return AsyncInfo.Run<string,int>((token, progress) =>
            {
                return Task.Run<string>(() =>
                {
                    //すごく重い処理
                    for (int i = 0; i < 20; i++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            return "キャンセルされました";
                        }
                        else
                        {
                            var client = new HttpClient();
                            client.GetStringAsync("http://google.co.jp").Wait();
                            //進捗報告
                            progress.Report(i);
                        }
                    }
                    return "返却値";
                });
            });
        }


    }
}
