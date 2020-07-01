using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HmberguerApp.Entities
{
    [Table("BURGERS")]
    public class Burgers
    {
        [Key]
        public int Id { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public string Raiting { get; set; }
        public string RaitingDetail { get; set; }
        public string Like { get; set; }
    }
}
