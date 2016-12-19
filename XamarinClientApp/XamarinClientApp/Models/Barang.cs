using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace XamarinClientApp.Models
{
    public class Barang
    {
        public int IdBarang { get; set; }
        public string NamaBarang { get; set; }
        public int HargaBarang { get; set; }
        public int StokBarang { get; set; }
        public DateTime TglBeli { get; set; }
        public int IdKategori { get; set; }
        public int IdJenisMotor { get; set; }
    }
}
