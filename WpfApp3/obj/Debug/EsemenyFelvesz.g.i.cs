﻿#pragma checksum "..\..\EsemenyFelvesz.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "830A533E6D76E9007A3D31A4511645612E62AD15"
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
using WpfApp3;


namespace WpfApp3 {
    
    
    /// <summary>
    /// EsemenyFelvesz
    /// </summary>
    public partial class EsemenyFelvesz : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\EsemenyFelvesz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datum;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\EsemenyFelvesz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ido;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\EsemenyFelvesz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox megnevezes;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\EsemenyFelvesz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox helyszin;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\EsemenyFelvesz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox kontakt;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\EsemenyFelvesz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button felvetel;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\EsemenyFelvesz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox idozito;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\EsemenyFelvesz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox idozitoIdo;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\EsemenyFelvesz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button mod;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\EsemenyFelvesz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox felhasznaloi;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp3;component/esemenyfelvesz.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EsemenyFelvesz.xaml"
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
            this.datum = ((System.Windows.Controls.DatePicker)(target));
            
            #line 14 "..\..\EsemenyFelvesz.xaml"
            this.datum.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.datum_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ido = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\EsemenyFelvesz.xaml"
            this.ido.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.megnevezes = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\EsemenyFelvesz.xaml"
            this.megnevezes.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.megnevezes_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.helyszin = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\EsemenyFelvesz.xaml"
            this.helyszin.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.helyszin_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.kontakt = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\EsemenyFelvesz.xaml"
            this.kontakt.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.kontakt_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.felvetel = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\EsemenyFelvesz.xaml"
            this.felvetel.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.idozito = ((System.Windows.Controls.CheckBox)(target));
            
            #line 26 "..\..\EsemenyFelvesz.xaml"
            this.idozito.Checked += new System.Windows.RoutedEventHandler(this.idozito_Checked);
            
            #line default
            #line hidden
            
            #line 26 "..\..\EsemenyFelvesz.xaml"
            this.idozito.Unchecked += new System.Windows.RoutedEventHandler(this.idozito_Unchecked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.idozitoIdo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 28 "..\..\EsemenyFelvesz.xaml"
            this.idozitoIdo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.idozitoIdo_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 29 "..\..\EsemenyFelvesz.xaml"
            ((System.Windows.Controls.ComboBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.ComboBoxItem_Selected);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 30 "..\..\EsemenyFelvesz.xaml"
            ((System.Windows.Controls.ComboBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.ComboBoxItem_Selected_1);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 31 "..\..\EsemenyFelvesz.xaml"
            ((System.Windows.Controls.ComboBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.ComboBoxItem_Selected_2);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 35 "..\..\EsemenyFelvesz.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 13:
            this.mod = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\EsemenyFelvesz.xaml"
            this.mod.Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 14:
            this.felhasznaloi = ((System.Windows.Controls.CheckBox)(target));
            
            #line 38 "..\..\EsemenyFelvesz.xaml"
            this.felhasznaloi.Checked += new System.Windows.RoutedEventHandler(this.felhasznaloi_Checked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

