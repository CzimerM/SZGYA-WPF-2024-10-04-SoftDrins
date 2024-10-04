using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZGYA_WPF_2024_10_04_SoftDrins
{
    public class SoftDrink
    {
        public string Gyarto {  get; set; }
        public string Nev {  get; set; }
        public string EdesitoAnyag { get; set; }
        public int LiterAr {  get; set; }
        public string CsomagolasTipus { get; set; }
        public int GyumolcsTartalom { get; set; }
        public int EgysegPerCsomag {  get; set; }

        public string TeljesNev => $"{this.Gyarto} {this.Nev}";

        public SoftDrink(string sor) 
        {
            string[] adatok = sor.Split(';');
            this.Gyarto = adatok[0].Split(" ")[0];
            this.Nev = adatok[0].Replace(this.Gyarto, "").Trim();
            this.EdesitoAnyag = adatok[1];
            this.LiterAr = int.Parse(adatok[2]);
            this.CsomagolasTipus = adatok[3];
            this.GyumolcsTartalom = int.Parse(adatok[4]);
            this.EgysegPerCsomag = int.Parse(adatok[5]);
        }
    }
}
