﻿using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Notes.Models
{
    internal class Nota
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [NotNull]
    public string Titulo { get; set; }
    public string Descricao { get; set; }

    public int UserId { get; set; }
    [ManyToOne]
    public User User { get; set; }

    public DateTime DataDeCriacao { get; set; }
    public DateTime DataDeActualizacao { get; set; }

    [OneToMany(CascadeOperations = CascadeOperation.All)]
    public List<Tag> Tags { get; set; }

    [OneToMany(CascadeOperations = CascadeOperation.All)]
    public List<Link> Links { get; set; }
}

}
