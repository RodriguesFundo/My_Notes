using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace My_Notes.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Nome { get; set; }
        [NotNull]
        public string Email { get; set; }
        [NotNull]
        public string Password { get; set; }
        public byte[] Image { get; set; }
        [NotNull]
        public DateTime DataDeCriacao { get; set; }
        public DateTime DataDeActualizacao { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Nota> Notas { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Tag> Tags { get; set; }
        

        public User(int id, string nome, string email, string password, byte[] image, DateTime dataDeCriacao, DateTime dataDeActualizacao, List<Nota> notas, List<Tag> tags)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Password = password;
            Image = image;
            DataDeCriacao = dataDeCriacao;
            DataDeActualizacao = dataDeActualizacao;
            Notas = notas;
            Tags = tags;
        }

        public User()
        {
        }
    }
}
