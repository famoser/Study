﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Famoser.Study.Business.Models;
using Famoser.Study.View.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Famoser.Study.Presentation.Universal.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private MainViewModel ViewModel => DataContext as MainViewModel;

        private static bool _firstTime = true;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (!_firstTime)
                return;

            _firstTime = false;
            if (ViewModel.RefreshCommand.CanExecute(null))
                ViewModel.RefreshCommand.Execute(null);
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var obj = e.ClickedItem as Course;
            if (ViewModel.SelectCourseCommand.CanExecute(obj))
                ViewModel.SelectCourseCommand.Execute(obj);
        }

        private void UIElement_OnTapped(object sender = null, TappedRoutedEventArgs e = null)
        {
            LocationSplitView.IsPaneOpen = !LocationSplitView.IsPaneOpen;
        }

        private void ListViewBase_OnItemClick(object sender, ItemClickEventArgs e)
        {
            UIElement_OnTapped();
        }
    }
}
