using AskMeMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AskMeMobileApp.Repositories
{
    public class WordsRepository
    {
        public List<Word> words { get; set; }

        public WordsRepository()
        {
           words = new List<Word>() {
                new Word { Id = 1, PolishMeaning = "Mama", EnglishMeaning = "Mother" },
                new Word { Id = 2, PolishMeaning = "Tata",EnglishMeaning = "Father" },
                new Word { Id = 3, PolishMeaning = "Brat", EnglishMeaning = "Brother" },
                new Word { Id = 4, PolishMeaning = "Siostra",EnglishMeaning = "Sister" },
                new Word { Id = 5, PolishMeaning = "Samochód", EnglishMeaning = "Car" },
                new Word { Id = 6, PolishMeaning = "Wiosna", EnglishMeaning = "Spring" }
            };
        }

        public List<Word> GetAll()
        {
            return words;
        }
    }
}
