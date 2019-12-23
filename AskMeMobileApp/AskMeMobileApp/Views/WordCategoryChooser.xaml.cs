using AskMeMobileApp.Models;
using AskMeMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AskMeMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WordCategoryChooser : ContentPage
    {
        public WordCategoryChooser(IEnumerable<Word> words)
        {
            InitializeComponent();
            BindingContext = new CategoryViewModel(words);
        }

        async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }



    }
}