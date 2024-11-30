using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace Bugalter
{
    public partial class Production : Window
    {
        public ObservableCollection<ProductionItem> Productions { get; set; }
        public ObservableCollection<RawMaterial> RawMaterials { get; set; }

        private string FilePath = "D:\\Desktop\\File.sql"; 

        public Production()
        {
            InitializeComponent();

            Productions = new ObservableCollection<ProductionItem>();
            RawMaterials = new ObservableCollection<RawMaterial>();

            //!ERROR: НЕ РАБОТАЕТ LoadDataFromFile();
            DataContext = this;
        }
        /*                                                                      PROBLEM
        private void LoadDataFromFile() //!ERROR: НЕ РАБОТАЕТ
        {
            var lines = File.ReadAllLines(FilePath);

            foreach (var line in lines)
            {
                if (line.StartsWith("INSERT INTO Details"))
                {
                    var data = ParseValues(line);
                    Productions.Add(new ProductionItem
                    {
                        DetailName = data[0],
                        QuantityProduced = 100,
                        QuantityDefective = 5, 
                        DetailPrice = decimal.Parse(data[4])
                    });
                }
            }
        }

        private string[] ParseValues(string line)
        {
            var valuesPart = line.Substring(line.IndexOf("VALUES") + 6).Trim(' ', '(', ')', ';');
            var values = valuesPart.Split(',');

            return values.Select(v => v.Trim().Trim('\'')).ToArray();
        }

        public decimal TotalProductionValue => Productions.Sum(p => p.TotalCost);
        public decimal TotalRawMaterialValue => RawMaterials.Sum(r => r.TotalValue);
        */
    }
}

public class ProductionItem
{
    public string DetailName { get; set; }
    public int QuantityProduced { get; set; }
    public int QuantityDefective { get; set; }
    public decimal DetailPrice { get; set; }
    public decimal TotalCost => (QuantityProduced - QuantityDefective) * DetailPrice;
}

public class RawMaterial
{
    public string Name { get; set; }
    public decimal QuantityAvailable { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalValue => QuantityAvailable * UnitPrice;
}