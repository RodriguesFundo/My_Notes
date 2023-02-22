﻿using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Notes.Models
{
    [Table("Tag")]
    public class Tag
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; }
        [NotNull]
        public string NomeTag { get; set; }
        public int NotaId { get; set; }
        [ManyToOne]
        public Nota Nota { get; set; }
        public int UserId { get; set; }
        [ManyToOne]
        public User User { get; set; }

        public Tag( string nomeTag, int notaId, Nota nota, int userId, User user)
        {
            NomeTag = nomeTag;
            NotaId = notaId;
            Nota = nota;
            UserId = userId;
            User = user;
        }

        public Tag()
        {
        }
    }

}
