#pragma checksum "..\..\wndCalculateDayMenu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "901BCACCE8999BE273F7471DC0B66D29544271455022E4D10A8BBC2D748BB9C9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using NewFoodCount;
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


namespace NewFoodCount
{


    /// <summary>
    /// wndCalculateDayMenu
    /// </summary>
    public partial class wndCalculateDayMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/NewFoodCount;component/wndcalculatedaymenu.xaml", System.UriKind.Relative);

#line 1 "..\..\wndCalculateDayMenu.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Grid grdUser;
        internal System.Windows.Controls.ComboBox cmbUser;
        internal System.Windows.Controls.Grid grdUserInfo;
        internal System.Windows.Controls.TextBlock tbCarbons;
        internal System.Windows.Controls.TextBlock tbProts;
        internal System.Windows.Controls.TextBlock tbFats;
        internal System.Windows.Controls.TextBlock tbCalorific;
        internal System.Windows.Controls.ListBox lbCarbons;
        internal System.Windows.Controls.ListBox lbProts;
        internal System.Windows.Controls.ListBox lbFats;
        internal System.Windows.Controls.Button btnAddCarbon;
        internal System.Windows.Controls.Button btnAddProt;
        internal System.Windows.Controls.Button btnAddFat;
    }
}

