﻿#pragma checksum "D:\Programowanie\Projekty OAM\Projekt Windows Phone\Projekt\Autobusy.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B655F9246ACAA462ED5DDA242D01E1F9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Projekt {
    
    
    public partial class Autobusy : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.ListBox List;
        
        internal System.Windows.Controls.RadioButton rbOksywie;
        
        internal System.Windows.Controls.RadioButton rbObluze;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Projekt;component/Autobusy.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.List = ((System.Windows.Controls.ListBox)(this.FindName("List")));
            this.rbOksywie = ((System.Windows.Controls.RadioButton)(this.FindName("rbOksywie")));
            this.rbObluze = ((System.Windows.Controls.RadioButton)(this.FindName("rbObluze")));
        }
    }
}

