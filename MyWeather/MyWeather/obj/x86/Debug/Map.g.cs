﻿#pragma checksum "C:\Users\Alan Doyle\Documents\visual studio 2015\Projects\MyWeather\MyWeather\Map.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1803046A9B4BDB95767A72814780BC7B"
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
    partial class Map : 
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
                    this.myMap = (global::Windows.UI.Xaml.Controls.Maps.MapControl)(target);
                    #line 36 "..\..\..\Map.xaml"
                    ((global::Windows.UI.Xaml.Controls.Maps.MapControl)this.myMap).Loaded += this.myMap_Loaded;
                    #line 37 "..\..\..\Map.xaml"
                    ((global::Windows.UI.Xaml.Controls.Maps.MapControl)this.myMap).MapTapped += this.myMap_MapTapped;
                    #line default
                }
                break;
            case 2:
                {
                    this.zoomSlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element3 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    #line 24 "..\..\..\Map.xaml"
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element3).Tapped += this.MenuFlyoutItem_Tapped;
                    #line default
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element4 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    #line 25 "..\..\..\Map.xaml"
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element4).Tapped += this.MenuFlyoutItem_Tapped_1;
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

