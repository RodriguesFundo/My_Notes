using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace My_Notes.Models
{
    internal class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Image { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public DateTime DataDeActualizacao { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Nota> Notas { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Tag> Tags { get; set; }

    }
}
