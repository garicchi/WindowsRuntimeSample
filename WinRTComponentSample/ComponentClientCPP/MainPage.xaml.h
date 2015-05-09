//
// MainPage.xaml.h
// MainPage クラスの宣言。
//

#pragma once

#include "MainPage.g.h"


namespace ComponentClientCPP
{
	/// <summary>
	/// Frame 内へナビゲートするために利用する空欄ページ。
	/// </summary>
	public ref class MainPage sealed
	{
	public:
		MainPage();

	private:
		WinRTComponentCS::SampleClass^ _sampleCs;

		void btn_calcSum_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
		void btn_showDialog_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
		void btn_goEvent_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
	};
}
