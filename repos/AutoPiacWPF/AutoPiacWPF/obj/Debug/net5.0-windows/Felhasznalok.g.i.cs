﻿#pragma checksum "..\..\..\Felhasznalok.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0FB49A751E7027CED318C1959DBB775DFC7BF498"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FelhasznaloKarbantarto.Windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace FelhasznaloKarbantarto.Windows {
    
    
    /// <summary>
    /// Felhasznalok
    /// </summary>
    public partial class Felhasznalok : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\Felhasznalok.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid FelhasznalokGrid;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Felhasznalok.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Felhasznalok_adatai;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Felhasznalok.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txb_FelhasznaloNev;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Felhasznalok.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pwb_Password;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Felhasznalok.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txb_TeljesNev;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Felhasznalok.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txb_Email;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Felhasznalok.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmb_Jogosultsag;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Felhasznalok.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmb_Aktiv;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Felhasznalok.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Tarolas;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Felhasznalok.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Modositas;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Felhasznalok.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Torles;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AutoPiacWPF;V1.0.0.0;component/felhasznalok.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Felhasznalok.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.FelhasznalokGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Felhasznalok_adatai = ((System.Windows.Controls.DataGrid)(target));
            
            #line 13 "..\..\..\Felhasznalok.xaml"
            this.Felhasznalok_adatai.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Felhasznalok_adatai_Changed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txb_FelhasznaloNev = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.pwb_Password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 5:
            this.txb_TeljesNev = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txb_Email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.cmb_Jogosultsag = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.cmb_Aktiv = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.btn_Tarolas = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\Felhasznalok.xaml"
            this.btn_Tarolas.Click += new System.Windows.RoutedEventHandler(this.btn_Tarolas_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btn_Modositas = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Felhasznalok.xaml"
            this.btn_Modositas.Click += new System.Windows.RoutedEventHandler(this.btn_Modositas_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btn_Torles = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Felhasznalok.xaml"
            this.btn_Torles.Click += new System.Windows.RoutedEventHandler(this.btn_Torles_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

