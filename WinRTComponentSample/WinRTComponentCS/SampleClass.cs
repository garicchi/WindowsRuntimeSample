using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Popups;

namespace WinRTComponentCS
{
    public delegate void SampleEventHandler();
    public sealed class SampleClass
    {
        //プリミティブ型を扱うメソッド
        public int CalcSum(int a, int b)
        {
            return a + b;
        }

        //非同期メソッド
        public IAsyncOperation<IUICommand> ShowDialogAsync(string message)
        {
            var dialog = new MessageDialog(message);
            return dialog.ShowAsync();
        }

        //イベント
        public event SampleEventHandler OnEvent;
        
        //イベント発火用メソッド
        public void GoEvent()
        {
            OnEvent();
        }
    }
}
