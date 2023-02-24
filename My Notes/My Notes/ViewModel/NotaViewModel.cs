using My_Notes.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Notes
{
    public class NotaViewModel
    {
        SQLiteAsyncConnection sQLiteConnection;
        public void InserirNota(string dbPath) {
            if (dbPath == "") dbPath = App.DBPath; //Se nao encontrar o local, atribua o valor da variavel global
            sQLiteConnection = new SQLiteAsyncConnection(dbPath);
            sQLiteConnection.CreateTableAsync<Nota>().Wait();
            
        }
    }
}
