﻿using AskMeMobileApp.Models;
using AskMeMobileApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AskMeMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConcreteCategoryPage : ContentPage
    {

        public ConcreteCategoryPage(List<Word> words)
        {
            InitializeComponent();
            BindingContext=new ConcreteCategoryViewModel(words);
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
        async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

    }
}
