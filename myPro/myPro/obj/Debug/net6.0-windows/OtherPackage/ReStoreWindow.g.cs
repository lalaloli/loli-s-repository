#pragma checksum "..\..\..\..\OtherPackage\ReStoreWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D2BC793C754BBE0E9329D56A136D3E09C5D300AE"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using MyPro;
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


namespace MyPro {
    
    
    /// <summary>
    /// ReStoreWindow
    /// </summary>
    public partial class ReStoreWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\OtherPackage\ReStoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GNumber;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\OtherPackage\ReStoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GoodsName;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\OtherPackage\ReStoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GoodsCount;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\OtherPackage\ReStoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image GoodsPic;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\OtherPackage\ReStoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CB;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\OtherPackage\ReStoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StorageGoodsCount;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MyPro;component/otherpackage/restorewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\OtherPackage\ReStoreWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\..\OtherPackage\ReStoreWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnAddPic_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.GoodsName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.GoodsCount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.GoodsPic = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            
            #line 38 "..\..\..\..\OtherPackage\ReStoreWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CB = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\OtherPackage\ReStoreWindow.xaml"
            this.CB.Click += new System.Windows.RoutedEventHandler(this.Change_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.StorageGoodsCount = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

