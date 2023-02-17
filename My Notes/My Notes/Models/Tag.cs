using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Notes.Models
{
    internal class Tag
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NomeTag { get; set; }
        public int NotaId { get; set; }
        [ManyToOne]
        public Nota Nota { get; set; }
        public int UserId { get; set; }
        [ManyToOne]
        public User User { get; set; }

    }

}
