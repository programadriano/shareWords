﻿#pragma checksum "E:\Users\thiago\documents\visual studio 2012\Projects\wp7ShareWords\wp7ShareWords\DetailsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6ABECD3D597989565E8C5352B7B3DD0E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18046
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
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


namespace wp7ShareWords {
    
    
    public partial class DetailsPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock ContentText;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton email;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton fb;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton twitter;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/wp7ShareWords;component/DetailsPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.ContentText = ((System.Windows.Controls.TextBlock)(this.FindName("ContentText")));
            this.email = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("email")));
            this.fb = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("fb")));
            this.twitter = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("twitter")));
        }
    }
}

