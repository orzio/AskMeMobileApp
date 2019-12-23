using AskMeMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AskMeMobileApp.Services
{
    public interface IWordsStore
    {
        Task AddWordAsync(Word word);
        Task UpdateWordAsync(Word Word);
        Task DeleteWordAsync(int id);
        Task<Word> GetWordAsync(int id);
        Task<IEnumerable<Word>> GetWordsAsync();
    }
}
