#include "pch.h"
#include "SampleClass.h"

using namespace WinRTComponentCPP;
using namespace Platform;
using namespace Windows::UI::Popups;
using namespace Windows::Foundation;

SampleClass::SampleClass()
{
}


int SampleClass::CalcSum(int a, int b)
{
	return a + b;
}

IAsyncOperation<IUICommand^>^ SampleClass::ShowDialogAsync(Platform::String^ message)
{
	MessageDialog^ dialog = ref new MessageDialog(message);
	return dialog->ShowAsync();
}

void SampleClass::GoEvent()
{
	this->OnEvent();
}

