#pragma once

namespace WinRTComponentCPP
{
	//voidを返す関数のデリゲート
	public delegate void SampleEventHandler();

    public ref class SampleClass sealed
    {
    public:
        SampleClass();
		
		//プリミティブ型を受け取って足し算してプリミティブ型を返すメソッド
		int CalcSum(int a, int b);

		//Platform::String型を受け取ってIAsyncOperationを返す非同期メソッド
		Windows::Foundation::IAsyncOperation<Windows::UI::Popups::IUICommand^>^ ShowDialogAsync(Platform::String^ message);

		//イベントを発生させるメソッド
		void GoEvent();

		//ダイアログが閉じられたときのイベント
		event SampleEventHandler^ OnEvent;

		
    };
}