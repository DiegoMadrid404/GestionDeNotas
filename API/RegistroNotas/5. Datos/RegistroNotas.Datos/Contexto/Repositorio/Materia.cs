﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RegistroNotas.Datos
{
    public partial class Materia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Codigo { get; set; }
        [Required]
        [StringLength(240)]
        public string Nombre { get; set; }
    }
}