using AskMeMobileApp.Database;
using AskMeMobileApp.Models;
using AskMeMobileApp.Repositories;
using AskMeMobileApp.Services;
using AskMeMobileApp.Utils;
using AskMeMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AskMeMobileApp.ViewModels
{
    public class WordsPageViewModel : PropertyChangedClass
    {
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }


        private ObservableCollection<string> _categories;
        public ObservableCollection<string> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                OnPropertyChanged("Categories");
            }
        }


        public ObservableCollection<Word> Words { get; set; }

        public SQLiteWordStore WordStore = new SQLiteWordStore(SQLConnector.CreateConnector());
        public List<Word> wordBook = new List<Word>();





        public WordsPageViewModel()
        {
            LoadData().Wait();
            SetCagetories();
            MessagingCenter.Subscribe<NewWordPage, Word>(this, "AddWord", async (obj, word) =>
            {
                var newWord = word as Word;
                wordBook.Add(newWord);
                await WordStore.AddWordAsync(newWord);
                SetCagetories();
            });

        }

        private ICommand _testCommand;
        public ICommand TestCommand => _testCommand ??
                                            (_testCommand = new RelayCommand(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new WordCategoryChooser(wordBook)))));

        public async Task LoadData()
        {
            try
            {
                var tempList = await WordStore.GetWordsAsync();

                foreach (var item in tempList)
                {
                    wordBook.Add(item);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void SetCagetories()
        {
            Categories = new ObservableCollection<string>();
            foreach (var item in wordBook)
            {
                if (Categories.Contains(item.Unit))
                    continue;
                else
                    Categories.Add(item.Unit);
            }
        }

    }
}
