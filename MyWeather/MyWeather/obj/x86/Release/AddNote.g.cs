﻿#pragma checksum "C:\Users\Alan Doyle\Desktop\New folder\UWP_APP_DEV2\MyWeather\MyWeather\AddNote.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "98A5FFFCDA21CDAF18E2820C6059742F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyWeather
{
    partial class AddNote : 
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
                    this.Map = (global::Windows.UI.Xaml.Controls.Maps.MapControl)(target);
                }
                break;
            case 2:
                {
                    this.addBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 41 "..\..\..\AddNote.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.addBtn).Click += this.AddBtn_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.cancelBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 42 "..\..\..\AddNote.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.cancelBtn).Click += this.cancelBtn_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.titleTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5:
                {
                    this.noteTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6:
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element6 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    #line 24 "..\..\..\AddNote.xaml"
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element6).Tapped += this.MenuFlyoutItem_Tapped;
                    #line default
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

