using AskMeMobileApp.Database;
using AskMeMobileApp.Models;
using AskMeMobileApp.Repositories;
using AskMeMobileApp.Services;
using AskMeMobileApp.Utils;
using AskMeMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AskMeMobileApp.ViewModels
{
    public class WordsPageViewModel
    {
        public ObservableCollection<Word> Words { get; set; }
        public SQLiteWordStore WordStore = new SQLiteWordStore(SQLConnector.CreateConnector());
        public List<Word> wordBook = new List<Word>();

        



        public WordsPageViewModel()
        {
            LoadData().Wait();
            Words = new ObservableCollection<Word>(wordBook);

            MessagingCenter.Subscribe<NewWordPage, Word>(this, "AddWord", async (obj, word) =>
            {
                var newWord = word as Word;
                wordBook.Add(newWord);
                await WordStore.AddWordAsync(newWord);
            });

        }

        private ICommand _testCommand;
        public ICommand TestCommand => _testCommand ??
                                            (_testCommand = new RelayCommand(async() => await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new WordCategoryChooser(wordBook)))));

        public async Task LoadData()
        {
            try
            {
                var tempList = await WordStore.GetWordsAsync();

                foreach (var item in tempList)
                {
                    wordBook.Add(item);
                }

            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
