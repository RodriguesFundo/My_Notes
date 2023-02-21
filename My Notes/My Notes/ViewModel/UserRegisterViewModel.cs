using My_Notes.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Notes
{
    public class UserRegisterViewModel
    {
        SQLiteConnection sQLiteConnection;
        public string StatusBD { get; set; }
        public UserRegisterViewModel(string dbPath)
        {
            if (dbPath=="") dbPath=App.DBPath; //Se nao encontrar o local, atribua o valor da variavel global
            sQLiteConnection = new SQLiteConnection(dbPath); //Definicao da BD
            sQLiteConnection.CreateTable<User>();

        }

        //Insercao
        public void InserirUser(User user) {
            try {
                if (string.IsNullOrEmpty(user.Nome))
                    throw new Exception("Campo nome vazio");
                if (string.IsNullOrEmpty(user.Email))
                    throw new Exception("Campo email vazio");
                if (string.IsNullOrEmpty(user.Password))
                    throw new Exception("Campo senha vazio");

                var result = sQLiteConnection.Insert(user);
                if (result != 0) 
                {
                    this.StatusBD = $"Usuario {user.Nome} adicionado";
                }
                else
                {
                    this.StatusBD = $"Usuario nao adicionado";
                }

            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                sQLiteConnection.Close();
            }
        }

        //Metodo para listar todos os usaurios
        public List<User> ListarUsers() {
            List<User> users = new List<User>(); //Lista que recebe todos dados da BD

            try
            {
                users = sQLiteConnection.Table<User>().ToList();
                this.StatusBD = "Listagem de dados";
            }
            catch (Exception ex)
            {

                throw new Exception("Excessao: "+ ex.Message);
            }
            return users;
        }
    
        

    }
}
