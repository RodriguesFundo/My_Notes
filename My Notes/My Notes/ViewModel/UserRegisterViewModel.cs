using My_Notes.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace My_Notes
{
    public class UserRegisterViewModel
    {
        SQLiteAsyncConnection sQLiteConnection;
        public string StatusBD { get; set; }
        public UserRegisterViewModel(string dbPath)
        {
            if (dbPath == "") dbPath = App.DBPath; //Se nao encontrar o local, atribua o valor da variavel global
            sQLiteConnection = new SQLiteAsyncConnection(dbPath); //Definicao da BD
            sQLiteConnection.CreateTableAsync<User>().Wait();
        }

        //Insercao
        public async Task InserirUser(User user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Nome))
                    throw new Exception("Campo nome vazio");
                if (string.IsNullOrEmpty(user.Email))
                    throw new Exception("Campo email vazio");
                if (string.IsNullOrEmpty(user.Password))
                    throw new Exception("Campo senha vazio");

                var result = await sQLiteConnection.InsertAsync(user);
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
        }


        //Verifica se um um determinado email ja existe na tabela
        public async Task<bool> EmailJaExiste(string email)
        {
            var user = await sQLiteConnection.Table<User>().FirstOrDefaultAsync(u => u.Email == email); //Retorna a
            return user != null;
        } //Retorna true se existir esse email


        //Metodo para listar todos os usaurios
        public async Task<List<User>> ListarUsers()
        {
            try
            {
                var users = await sQLiteConnection.Table<User>().ToListAsync();
                this.StatusBD = "Listagem de dados";
                return users;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //Listar user By (Modificacoes possiveis)
        public async Task<User> GetUserById(int id)
        {
            return await sQLiteConnection.Table<User>().FirstOrDefaultAsync(u => u.Id == id);
        }



        //Excluir usuario 1 
        public async Task ExcluirUser(User user)
        {
            try
            {
                var result = await sQLiteConnection.DeleteAsync(user);
                if (result != 0)
                {
                    this.StatusBD = $"Usuário {user.Nome} excluído";
                }
                else
                {
                    this.StatusBD = $"Usuário não excluído";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task ExcluirUser(int id)
        {
            try
            {
                var user = await sQLiteConnection.Table<User>().Where(u => u.Id == id).FirstOrDefaultAsync();
                if (user != null)
                {
                    var result = await sQLiteConnection.DeleteAsync(user);
                    if (result != 0)
                    {
                        this.StatusBD = $"Usuário {user.Nome} excluído";
                    }
                    else
                    {
                        this.StatusBD = $"Usuário não excluído";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<int> AtualizarUser(User user)
        {
            return await sQLiteConnection.UpdateAsync(user);
        }



    }
}
