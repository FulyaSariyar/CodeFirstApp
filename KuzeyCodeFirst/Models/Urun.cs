using System.ComponentModel.DataAnnotations;
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

        [ForeignKey (nameof(KategorId))] // nameof en garanti yöntem yanlis yazimi önler.
        public Kategori Kategori { get; set; }  
        [Range(0,10000)]
        public int StokMiktari { get; set; }
        public ICollection<SiparisDetay> siparisDetaylari { get; set; } = new HashSet<SiparisDetay>();


    }
}
