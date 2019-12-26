using AskMeMobileApp.Models;
using AskMeMobileApp.Utils;
using AskMeMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AskMeMobileApp.ViewModels
{
    public class CategoryViewModel : PropertyChangedClass
    {
        private IEnumerable<Word> _words { get; }

        public List<String> CategoryList { get; set; }


        private RelayCommand _startTestCommand=null;
        public RelayCommand StartTestCommand => _startTestCommand ??
                                            (_startTestCommand = new RelayCommand
            (async () => await Application
                               .Current
                               .MainPage
                               .Navigation
                               .PushModalAsync(new NavigationPage(new TestPage(
                                                _words.Where(n=>n.Unit == _selectedCategory).ToList()))), ()=> SelectedCategory!=null) );

        public CategoryViewModel(IEnumerable<Word> words)
        {
            _words = words;
            CategoryList = new List<string>();
            foreach (var item in _words)
            {
                if (CategoryList.Contains(item.Unit))
                    continue;
                else
                    CategoryList.Add(item.Unit);
            }
            //CategoryList = new List<string>(_words.Select(n => n.Unit).ToList());
        }

        private string _selectedCategory;
        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (_selectedCategory == value)
                    return;
                _selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
               StartTestCommand.RaiseCanExecuteChanged();
            }
        }
        public string Category { get; set; }
    }
}

