using My_Notes.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace My_Notes
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        SQLiteConnection sQLiteConnection;

        public bool EmailJaExiste(string email)
        {
            var user = sQLiteConnection.Table<User>().FirstOrDefault(u => u.Email == email); //Retorna a
            return user != null;
        } //Retorna true se existir esse email

        public void ValidarLogin(string email, string password) {
            using (var conn = new SQLiteConnection(App.DBPath))
            {
                try
                {
                    if (EmailJaExiste(email)) { 
                        var senha = sQLiteConnection.Table<User>().Select(x=>x.Password).Where(x=>x.Equals(email)).ToString();
                        if (senha.Equals(password))
                        {
                            throw new Exception("Certo");
                        }
                    }
                    else
                    {
                        throw new Exception("Conta nao existe");
                    }
                    
                }
                catch (Exception)
                {

                    throw ;
                }
            }
        }

    }
}
