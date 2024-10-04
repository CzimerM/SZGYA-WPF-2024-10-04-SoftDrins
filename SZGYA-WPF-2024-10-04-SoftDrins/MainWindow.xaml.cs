using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SZGYA_WPF_2024_10_04_SoftDrins
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var softDrinks = new List<SoftDrink>();
            var sr = new StreamReader("../../../src/softDrinks.txt", Encoding.UTF8);
            _ = sr.ReadLine();
            while(!sr.EndOfStream)
            {
                softDrinks.Add(new SoftDrink(sr.ReadLine()));
            }
            sr.Close();

            // 4.feladat
            lblAjanlat.Content = Ajanlat(softDrinks);

            // 5. feladat
            var legolcsobb = softDrinks.Where(s => s.GyumolcsTartalom == 0).MinBy(s => s.LiterAr);
            if (legolcsobb is not null) lblLegolcsobb.Content = $"{legolcsobb.TeljesNev} - {legolcsobb.LiterAr} Ft/l";

            // 6. feladat
            lblGyartoDb.Content = softDrinks.Select(s => s.Gyarto).Distinct().Count();

            // 7.feladat
            GyumolcsTartalomStatisztika(softDrinks);

            // 8.feladat
            EdesitoAnyagStatisztika(softDrinks);

        }

        public string Ajanlat(List<SoftDrink> softDrinks) // 4.feladat
        {
            Random rnd = new Random();
            var cukrosItalok = softDrinks.Where(s => s.EdesitoAnyag == "cukor").ToArray();
            return cukrosItalok[rnd.Next(cukrosItalok.Length)].TeljesNev;
        }

        public void GyumolcsTartalomStatisztika(List<SoftDrink> softDrinks) // 7. feladat
        {
            using var sw = new StreamWriter("../../../src/all.txt", false, Encoding.UTF8);
            softDrinks
                .GroupBy(s => s.TeljesNev)
                .Select(s => new {nev = s.Key, atlagGyumolcs = s.Average(sd => sd.GyumolcsTartalom)})
                .ToList()
                .ForEach(s => sw.WriteLine($"{s.nev} {Math.Round(s.atlagGyumolcs,2)}"));
        }

        public void EdesitoAnyagStatisztika(List<SoftDrink> softDrinks) // 8.feladat
        {
            using var sw = new StreamWriter("../../../src/sweetening.txt", false, Encoding.UTF8);
            softDrinks
                .GroupBy(s => s.EdesitoAnyag)
                .Select(s => new { anyag = s.Key, db = s.Count() })
                .ToList()
                .ForEach(s => sw.WriteLine($"{s.anyag}-{s.db}"));
        }

        private void btnArajanlatKeszites_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}