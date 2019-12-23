using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AskMeMobileApp.Models
{
   public class Word
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string PolishMeaning { get; set; }
        [MaxLength(255)]
        public string EnglishMeaning { get; set; }
        [MaxLength(255)]
        public string Unit { get; set; }
    }
}
