﻿#pragma checksum "..\..\salesrep.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "38C877BE94254AA77936303BF75E008E303918083CF36DDEA14B390115ACBB8A"
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
    /// salesrep
    /// </summary>
    public partial class salesrep : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\salesrep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox proid;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\salesrep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox month;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\salesrep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox year;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\salesrep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sprod;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\salesrep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dprod;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\salesrep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button mprod;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\salesrep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button tprod;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\salesrep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagridsrep;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\salesrep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker startdate;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\salesrep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker enddate;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp2;component/salesrep.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\salesrep.xaml"
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
            this.proid = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.month = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.year = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.sprod = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\salesrep.xaml"
            this.sprod.Click += new System.Windows.RoutedEventHandler(this.sprod_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dprod = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\salesrep.xaml"
            this.dprod.Click += new System.Windows.RoutedEventHandler(this.dprod_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.mprod = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\salesrep.xaml"
            this.mprod.Click += new System.Windows.RoutedEventHandler(this.mprod_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tprod = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\salesrep.xaml"
            this.tprod.Click += new System.Windows.RoutedEventHandler(this.tprod_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.datagridsrep = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            this.startdate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 10:
            this.enddate = ((System.Windows.Controls.DatePicker)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

