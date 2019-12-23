using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AskMeMobileApp.Database;
using AskMeMobileApp.Models;
using SQLite;

namespace AskMeMobileApp.Services
{
    public class SQLiteWordStore : IWordsStore
    {

        private SQLiteConnection _connection;
        public SQLiteWordStore(SQLConnector sqlConnector)
        {
                _connection = new SQLiteConnection(sqlConnector.GetConnection());
                _connection.CreateTable<Word>();
        }
        public async Task AddWordAsync(Word word)
        {
             _connection.Insert(word);
            await Task.CompletedTask;

        }

        public async Task DeleteWordAsync(int id)
        {
             _connection.Delete(id);
            await Task.CompletedTask;
        }

        public async Task<Word> GetWordAsync(int id)
        {
            return _connection.Find<Word>(id);
        }

        public async Task<IEnumerable<Word>> GetWordsAsync()
        {
            return  _connection.Table<Word>().ToList();
        }

        public async Task UpdateWordAsync(Word word)
        {
             _connection.Update(word);
        }
    }
}
