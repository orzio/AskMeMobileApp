using AskMeMobileApp.Models;
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
    public partial class NewWordPage : ContentPage
    {
        public Word Word { get; set; }
        public NewWordPage()
        {
            InitializeComponent();
            Word = new Word
            {
                PolishMeaning = "",
                EnglishMeaning = "",
                Unit = ""
            };
            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddWord", Word);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

    }
}