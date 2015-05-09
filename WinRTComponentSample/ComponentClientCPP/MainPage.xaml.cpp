//
// MainPage.xaml.cpp
// MainPage クラスの実装。
//

#include "pch.h"
#include "MainPage.xaml.h"

using namespace ComponentClientCPP;

using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

MainPage::MainPage()
{
	this->_sampleCs = ref new WinRTComponentCS::SampleClass();
	this->_sampleCs->OnEvent += ref new WinRTComponentCS::SampleEventHandler([&]()
	{
		this->text_goEvent->Text = "イベントを受け取りました";
	});
	InitializeComponent();
}


void ComponentClientCPP::MainPage::btn_calcSum_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	int result = this->_sampleCs->CalcSum(10,20);
	this->text_calcSum->Text = result.ToString();
}


void ComponentClientCPP::MainPage::btn_showDialog_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	auto asyncMethod = this->_sampleCs->ShowDialogAsync("非同期で呼び出しています");
	concurrency::create_task(asyncMethod).then([](Windows::UI::Popups::IUICommand^ command)
	{
		//非同期処理完了後の処理
	});
	
}


void ComponentClientCPP::MainPage::btn_goEvent_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	this->_sampleCs->GoEvent();
}
