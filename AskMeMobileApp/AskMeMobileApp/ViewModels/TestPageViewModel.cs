using AskMeMobileApp.Models;
using AskMeMobileApp.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AskMeMobileApp.ViewModels
{
    public class TestPageViewModel : PropertyChangedClass
    {
        public TestPageViewModel(List<Word> words)
        {
            _words = words;
            CreateWordList();
            LoadWord();
        }


        private List<Word> _words;
        private List<WordWrapper> _testingList;
        private string _userAnswer;
        private string _feedBack = "Your Answer";

        private WordWrapper _PieckedWord;

        public WordWrapper PickedWord
        {
            get { return _PieckedWord; }
            set { _PieckedWord = value; }
        }

        public string FeedBack
        {
            get { return _feedBack; }
            set
            {
                _feedBack = value;
                OnPropertyChanged("FeedBack");
            }
        }

        private string _correctAnswer;

        public string CorrectAnswer
        {
            get { return _correctAnswer; }
            set
            {
                _correctAnswer = value;
                OnPropertyChanged("CorrectAnswer");
            }
        }


        public string UserAnswer
        {
            get { return _userAnswer; }
            set
            {
                _userAnswer = value;
                OnPropertyChanged("UserAnswer");
            }
        }

        private string _polishWord;
        public string PolishWord
        {
            get { return _polishWord; }
            set
            {
                _polishWord = value;
                OnPropertyChanged("PolishWord");
            }
        }

        public void CreateWordList()
        {
            if (_words.Count == 0)
                return;
            _testingList = new List<WordWrapper>();
            foreach (var item in _words)
            {
                _testingList.Add(new WordWrapper()
                {
                    PolishMeaning = item.PolishMeaning,
                    EnglishMeaning = item.EnglishMeaning,
                    CorrectAnswers = 0
                }); ;
            }
        }

        private ICommand _submitCommand;
        public ICommand SubmitCommand => _submitCommand ?? (_submitCommand = new RelayCommand(() =>
        {
            if (UserAnswer == CorrectAnswer)
            {
                FeedBack = "GOOD";
                PickedWord.CorrectAnswers++;
                PolishWord = "";
                LoadWord();
            }
            else
            {
                FeedBack = "WRONG!";
                PolishWord = "";
                LoadWord();
            }
        }));


        public void LoadWord()
        {
            var random = new Random();
            int index;
            do
            {
                index = random.Next(0, _testingList.Count);
            } while (_testingList[index].CorrectAnswers >= 3);

            PickedWord = _testingList[index];
            PolishWord = PickedWord.PolishMeaning;
            CorrectAnswer = PickedWord.EnglishMeaning;
        }



    }
}
