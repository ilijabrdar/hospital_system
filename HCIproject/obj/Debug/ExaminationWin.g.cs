﻿#pragma checksum "..\..\ExaminationWin.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6CD81681A1E29CAFAEC98D1E4EAFF0F2E3258EAEDDAE6F1BDC84B67D0E694BF7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HCIproject;
using HCIproject.Validation;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace HCIproject {
    
    
    /// <summary>
    /// ExaminationWin
    /// </summary>
    public partial class ExaminationWin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\ExaminationWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer examScrool;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\ExaminationWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox anamnezaTxt;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\ExaminationWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox simptomiCombo;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\ExaminationWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox diagnosisCombo;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\ExaminationWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelOperacija;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\ExaminationWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonOperacija;
        
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
            System.Uri resourceLocater = new System.Uri("/HCIproject;component/examinationwin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ExaminationWin.xaml"
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
            
            #line 15 "..\..\ExaminationWin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_7);
            
            #line default
            #line hidden
            return;
            case 2:
            this.examScrool = ((System.Windows.Controls.ScrollViewer)(target));
            
            #line 18 "..\..\ExaminationWin.xaml"
            this.examScrool.SizeChanged += new System.Windows.SizeChangedEventHandler(this.examScrool_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.anamnezaTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.simptomiCombo = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.diagnosisCombo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 48 "..\..\ExaminationWin.xaml"
            this.diagnosisCombo.GotFocus += new System.Windows.RoutedEventHandler(this.diagnosisCombo_GotFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 53 "..\..\ExaminationWin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 60 "..\..\ExaminationWin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_3);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 68 "..\..\ExaminationWin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_4);
            
            #line default
            #line hidden
            return;
            case 9:
            this.labelOperacija = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.buttonOperacija = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\ExaminationWin.xaml"
            this.buttonOperacija.Click += new System.Windows.RoutedEventHandler(this.Button_Click_6);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 90 "..\..\ExaminationWin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_5);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 100 "..\..\ExaminationWin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
