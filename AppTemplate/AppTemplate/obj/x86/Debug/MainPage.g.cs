﻿#pragma checksum "C:\Users\garicchi\Projects\Local\Windows\AppTemplate\AppTemplate\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "385F3C6A1107B5DDA861E0E97D6A5A77"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppTemplate
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    #line 8 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                    #line default
                }
                break;
            case 2:
                {
                    this.splitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 3:
                {
                    this.suggestBoxSearch = (global::Windows.UI.Xaml.Controls.AutoSuggestBox)(target);
                    #line 41 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.suggestBoxSearch).QuerySubmitted += this.suggestBoxSearch_QuerySubmitted;
                    #line default
                }
                break;
            case 4:
                {
                    this.appButtonSetting = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 35 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.appButtonSetting).Click += this.appButtonSetting_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.appButtonHome = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 28 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.appButtonHome).Click += this.appButtonHome_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.appButtonFavorite = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 29 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.appButtonFavorite).Click += this.appButtonFavorite_Click;
                    #line default
                }
                break;
            case 7:
                {
                    this.paneButton = (global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)(target);
                }
                break;
            case 8:
                {
                    this.frameContent = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
