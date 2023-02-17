using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Notes.Models
{
    internal class Link
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string URL { get; set; }

        public int NotaId { get; set; }
        [ManyToOne]
        public Nota Nota { get; set; }
    }
}
