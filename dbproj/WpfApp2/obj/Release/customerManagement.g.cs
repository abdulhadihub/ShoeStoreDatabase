﻿#pragma checksum "..\..\customerManagement.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CFAA12BF3CCA8C1169BE2085581167B1D11575AAEF3175DCC6088919364A6435"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfApp2;


namespace WpfApp2 {
    
    
    /// <summary>
    /// customerManagement
    /// </summary>
    public partial class customerManagement : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\customerManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox custname;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\customerManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox contname;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\customerManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox address;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\customerManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox city;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\customerManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox custid;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\customerManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnadd;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\customerManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnupdate;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\customerManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btndel;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\customerManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button load;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\customerManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button clear;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\customerManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox phone;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp2;component/customermanagement.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\customerManagement.xaml"
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
            this.custname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.contname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.address = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.city = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.custid = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btnadd = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\customerManagement.xaml"
            this.btnadd.Click += new System.Windows.RoutedEventHandler(this.btnadd_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnupdate = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\customerManagement.xaml"
            this.btnupdate.Click += new System.Windows.RoutedEventHandler(this.btnupdate_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btndel = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\customerManagement.xaml"
            this.btndel.Click += new System.Windows.RoutedEventHandler(this.btndel_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.load = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\customerManagement.xaml"
            this.load.Click += new System.Windows.RoutedEventHandler(this.load_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.clear = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\customerManagement.xaml"
            this.clear.Click += new System.Windows.RoutedEventHandler(this.clear_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.phone = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

