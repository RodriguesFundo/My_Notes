﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace My_Notes
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnCriarNota_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(state: "//login/mainPage/createNote");
        }
    }
}
