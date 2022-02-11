using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQTeknolojisi
{
    public class Musteri
    {
        public int id { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string ulke { get; set; }
        public DateTime dogumtarihi { get; set; }
        public string email { get; set; }
        public string tel { get; set; }

        public override string ToString()
        {
            return ad+' '+soyad+ '-'+dogumtarihi;
        }
    }
}
