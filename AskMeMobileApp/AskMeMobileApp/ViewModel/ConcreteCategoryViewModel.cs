using AskMeMobileApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AskMeMobileApp.ViewModel
{
    public class ConcreteCategoryViewModel
    {
        public ObservableCollection<Word> CategoryWordList { get; set; }
        public ConcreteCategoryViewModel(List<Word> categoryWordsList)
        {
            CategoryWordList = new ObservableCollection<Word>(categoryWordsList);
        }
    }
}
