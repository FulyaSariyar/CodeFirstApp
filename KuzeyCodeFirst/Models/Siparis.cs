using KuzeyCodeFirst.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuzeyCodeFirst.Models
{

    [Table(name:"Siparisler")]
    public class Siparis : BaseEntity,IKey<int>
    {
        [Key]
        public int Id { get; set; }
        public DateTime SiparisTarihi { get; set; } = DateTime.Now;
        [Column(TypeName ="smalldatetime")]

        public DateTime? UlasmaTarhi { get; set; }

        public ICollection<SiparisDetay> siparisDetaylari { get; set; }= new HashSet<SiparisDetay>();

    }
}
