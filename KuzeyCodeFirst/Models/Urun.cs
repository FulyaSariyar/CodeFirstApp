﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KuzeyCodeFirst.Models
{
    [Table (name: "Urunler")]
    public class Urun
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Ad { get; set; }
        public decimal Fiyat { get; set; } = 0;
        public int KategorId { get; set; } 

        [ForeignKey (nameof(KategorId))] // nameof en garanti yöntem yanliş yazimi önler.
        public Kategori Kategori { get; set; }  


    }
}