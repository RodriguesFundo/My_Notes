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

        public LoginViewModel()
        {
            sQLiteConnection = new SQLiteConnection(App.DBPath);
        }

        public bool EmailJaExiste(string email)
        {
            var user = sQLiteConnection.Table<User>().FirstOrDefault(u => u.Email == email); //Retorna a
            return user != null;
        } //Retorna true se existir esse email

        public bool ValidarLogin(string email, string password) {
                try
                {
                    if (EmailJaExiste(email))// Verifica se o email existe
                    {
                        var user = sQLiteConnection.Table<User>().FirstOrDefault(u => u.Email == email);
                        if (user.Password.Equals(password))
                        {
                            return true;
                        }
                    }
                    return false;

            }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    sQLiteConnection.Close();
                }
        }

    }
}
