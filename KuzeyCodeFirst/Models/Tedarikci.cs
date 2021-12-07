using KuzeyCodeFirst.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuzeyCodeFirst.Models
{
    public class Tedarikci : BaseEntity, IKey<Guid>
    {
       [Key]
       public Guid Id { get; set; } =Guid.NewGuid();

       [Required, StringLength(20)]
       public string FirmaAdi { get; set; }
       [StringLength(11)]
       public string Telefon { get; set; }
        public ICollection<Urun> Urunler { get; set; }= new HashSet<Urun>();    
    }
}
