﻿#pragma checksum "..\..\..\Windows\LongScreenWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E9D5DF9D55E392F370D155D1A96B2C0270C1AC9EAFF41050E1A55A1B145FA31E"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using LoveScreen.Controls;
using LoveScreen.Controls.Converts;
using LoveScreen.Windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace LoveScreen.Windows {
    
    
    /// <summary>
    /// LongScreenWindow
    /// </summary>
    public partial class LongScreenWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 2 "..\..\..\Windows\LongScreenWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LoveScreen.Windows.LongScreenWindow window;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Windows\LongScreenWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle C_FrameRect;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Windows\LongScreenWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle C_SizeFrame;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LoveScreen;component/windows/longscreenwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\LongScreenWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.window = ((LoveScreen.Windows.LongScreenWindow)(target));
            return;
            case 2:
            this.C_FrameRect = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 3:
            
            #line 32 "..\..\..\Windows\LongScreenWindow.xaml"
            ((LoveScreen.Controls.TextBlockFrame)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.TextBlockFrame_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 35 "..\..\..\Windows\LongScreenWindow.xaml"
            ((LoveScreen.Controls.ImgButton)(target)).Click += new System.Windows.RoutedEventHandler(this.OkButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.C_SizeFrame = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 38 "..\..\..\Windows\LongScreenWindow.xaml"
            this.C_SizeFrame.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Path_MouseDown);
            
            #line default
            #line hidden
            
            #line 38 "..\..\..\Windows\LongScreenWindow.xaml"
            this.C_SizeFrame.MouseMove += new System.Windows.Input.MouseEventHandler(this.Path_MouseMove);
            
            #line default
            #line hidden
            
            #line 38 "..\..\..\Windows\LongScreenWindow.xaml"
            this.C_SizeFrame.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Path_MouseUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

