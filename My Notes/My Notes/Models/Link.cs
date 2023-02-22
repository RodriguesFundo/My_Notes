using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Notes.Models
{
    [Table("Link")]
    public class Link
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get;  }
        public string URL { get; set; }

        public int NotaId { get; set; }
        [ManyToOne]
        public Nota Nota { get; set; }

        public Link( string uRL, int notaId, Nota nota)
        {
            URL = uRL;
            NotaId = notaId;
            Nota = nota;
        }

        public Link()
        {
        }
    }
}
