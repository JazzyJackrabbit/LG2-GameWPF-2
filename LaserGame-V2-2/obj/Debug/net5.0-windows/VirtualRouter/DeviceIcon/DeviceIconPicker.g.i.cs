﻿#pragma checksum "..\..\..\..\..\VirtualRouter\DeviceIcon\DeviceIconPicker.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "099D0D63B013BF53698594DDC9CE6CD3F1B88E8A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using VirtualRouterClient;


namespace VirtualRouterClient {
    
    
    /// <summary>
    /// DeviceIconPicker
    /// </summary>
    public partial class DeviceIconPicker : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\..\VirtualRouter\DeviceIcon\DeviceIconPicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\..\VirtualRouter\DeviceIcon\DeviceIconPicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblInstructions;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\VirtualRouter\DeviceIcon\DeviceIconPicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle windowContent;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\VirtualRouter\DeviceIcon\DeviceIconPicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listIcons;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\VirtualRouter\DeviceIcon\DeviceIconPicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOK;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\VirtualRouter\DeviceIcon\DeviceIconPicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LaserGame-V2-2;V1.0.0.0;component/virtualrouter/deviceicon/deviceiconpicker.xaml" +
                    "", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\VirtualRouter\DeviceIcon\DeviceIconPicker.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lblInstructions = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.windowContent = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 4:
            this.listIcons = ((System.Windows.Controls.ListView)(target));
            
            #line 17 "..\..\..\..\..\VirtualRouter\DeviceIcon\DeviceIconPicker.xaml"
            this.listIcons.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.listIcons_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnOK = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\..\..\VirtualRouter\DeviceIcon\DeviceIconPicker.xaml"
            this.btnOK.Click += new System.Windows.RoutedEventHandler(this.btnOK_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

