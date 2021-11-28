using Newtonsoft.Json;
using dope_stats.DTOs;

namespace dope_item_metrics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var appPath = Path.GetDirectoryName(Environment.ProcessPath);
            var filePath = Path.Combine(appPath, "Outputs");

            var occurences = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText(Path.Combine(filePath, "occurences.json")));
            var items = JsonConvert.DeserializeObject<Items>(File.ReadAllText(Path.Combine(filePath, "items.json")));

            var itemOccurenceByAttribute = new ItemOccurence
            {
                clothes = ParseItems(occurences, items.clothes),
                foot = ParseItems(occurences, items.foot),
                hand = ParseItems(occurences, items.hand),
                drugs = ParseItems(occurences, items.drugs),
                neck = ParseItems(occurences, items.neck),
                ring = ParseItems(occurences, items.ring),
                waist = ParseItems(occurences, items.waist),
                weapon = ParseItems(occurences, items.weapon),
                vehicle = ParseItems(occurences, items.vehicle)
            };

            var serializedOccurence = JsonConvert.SerializeObject(itemOccurenceByAttribute, Formatting.Indented);
            File.WriteAllText("Outputs\\itemOccurenceByAttribute.json", serializedOccurence);
            Console.WriteLine("Wrote to itemOccurenceByAttribute.json!");

            /*
             * Not needed because we already have it in memory
            */
            //var itemOccurenceByAttribute = JsonConvert.DeserializeObject<ItemsGroupedWithValue>(File.ReadAllText(@"Outputs\ItemsGroupedByOccurence.json"));

            var itemRarityByAttribute = new ItemRarity
            {
                clothes = ParseItemsAddRarity(itemOccurenceByAttribute.clothes, items.clothes),
                foot = ParseItemsAddRarity(itemOccurenceByAttribute.foot, items.foot),
                drugs = ParseItemsAddRarity(itemOccurenceByAttribute.drugs, items.drugs),
                hand = ParseItemsAddRarity(itemOccurenceByAttribute.hand, items.hand),
                neck = ParseItemsAddRarity(itemOccurenceByAttribute.neck, items.neck),
                ring = ParseItemsAddRarity(itemOccurenceByAttribute.ring, items.ring),
                waist = ParseItemsAddRarity(itemOccurenceByAttribute.waist, items.waist),
                weapon = ParseItemsAddRarity(itemOccurenceByAttribute.weapon, items.weapon),
                vehicle = ParseItemsAddRarity(itemOccurenceByAttribute.vehicle, items.vehicle)
            };

            var serializedSorted = JsonConvert.SerializeObject(itemRarityByAttribute, Formatting.Indented);
            File.WriteAllText("Outputs\\itemRarityByAttribute.json", serializedSorted);
            Console.WriteLine("Wrote to itemRarityByAttribute.json");
        }

        public static Dictionary<string, int> ParseItems(Dictionary<string, int> occurences, List<string> items)
        {
            var dict = new Dictionary<string, int>();
            foreach (var item in items)
            {
                dict.Add(item, occurences[item]);
            }
            return dict;
        }

        public static Dictionary<string, double> ParseItemsAddRarity(Dictionary<string, int> occurences, List<string> items)
        {
            var dict = new Dictionary<string, double>();
            foreach (var item in items)
            {
                dict.Add(item, (double)occurences[item] / 8000);
            }
            var dictSortedDesc = dict.OrderBy(x => x.Value).ToDictionary(x => x.Key, y => y.Value);

            return dictSortedDesc;
        }
    }
}
