﻿using DM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DM.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class XF_LoginPage : ContentPage
    {
        private LoginViewModel loginViewModel = new LoginViewModel();
        public XF_LoginPage()
        {
            InitializeComponent();
            BindingContext = loginViewModel;
        }

    }
}