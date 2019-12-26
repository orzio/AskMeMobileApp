using AskMeMobileApp.Models;
using AskMeMobileApp.ViewModel;
using AskMeMobileApp.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AskMeMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WordsPage : ContentPage
    {
        WordsPageViewModel wordsPageViewModel;
        public WordsPage()
        {
            InitializeComponent();
            wordsPageViewModel = new WordsPageViewModel();

        }

        //async void Test_Clicked(object sender, EventArgs e)
        //{
        //    //await Navigation.PushModalAsync(new NavigationPage(new TestPage()));
        //}


        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            Console.WriteLine(e.Item);
            //await DisplayAlert("Item Tapped", "An item was tapped.", "OK");
            await Navigation.PushModalAsync(new ConcreteCategoryPage(wordsPageViewModel.wordBook
                          .Where(n => n.Unit == e.Item.ToString()).ToList()));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        async void AddUnit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewWordPage()));
        }

    }
}