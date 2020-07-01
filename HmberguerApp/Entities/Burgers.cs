using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HmberguerApp.Entities
{
    public class Burgers
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public string Raiting { get; set; }
        public string RaitingDetail { get; set; }
        public string Like { get; set; }
    }
}
