﻿#pragma checksum "..\..\..\Views\TransactionAddWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0CEB3D821099309C7CF290175C56F0232BBE6F7405DBD9E2774DD65D6741E46B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using Project_TAB.Views;
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


namespace Project_TAB.Views {
    
    
    /// <summary>
    /// TransactionAddWindow
    /// </summary>
    public partial class TransactionAddWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\Views\TransactionAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameInput;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Views\TransactionAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AmountInput;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Views\TransactionAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker TransactionDatePicker;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Views\TransactionAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox AccountsComboBox;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Views\TransactionAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CategoriesComboBox;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Views\TransactionAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox IncomeCheckBox;
        
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
            System.Uri resourceLocater = new System.Uri("/Project_TAB;component/views/transactionaddwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\TransactionAddWindow.xaml"
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
            
            #line 11 "..\..\..\Views\TransactionAddWindow.xaml"
            ((Project_TAB.Views.TransactionAddWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.TransactionAddWindow_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NameInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.AmountInput = ((System.Windows.Controls.TextBox)(target));
            
            #line 51 "..\..\..\Views\TransactionAddWindow.xaml"
            this.AmountInput.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TransactionDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.AccountsComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.CategoriesComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.IncomeCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 8:
            
            #line 110 "..\..\..\Views\TransactionAddWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddTransactionButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

