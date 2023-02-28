using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;

namespace LB1
{
    internal class Program
    {
        static async Task  Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Parking parking = new Parking(Parking.CountOfPlaces);
            parking.StartWork();
            
            SameElementsByKey sameElements = new SameElementsByKey();
            sameElements.FindSameValues();
            
            using (FileStream file = new FileStream("fruits.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<SameElementsByKey>(file, sameElements);
                Console.WriteLine("Data has been saved to file\n");
            }
        
            using (FileStream file = new FileStream("fruits.json", FileMode.OpenOrCreate))
            {
                SameElementsByKey json = await JsonSerializer.DeserializeAsync<SameElementsByKey>(file);
                foreach (var (key, value) in json.dictionary)
                {
                    Console.WriteLine($"Fruit: {value}  Key: {key} ");
                }
            }
            
            Console.WriteLine();
            List<int> numbers = new List<int>()
            {
                4, 6, 7, 1, 17, 2, 7, 3, 9
            };
            var sorted = numbers.Where(n => n <= 15 && n >= 5).Average(n=>n);
            Console.WriteLine(sorted);
            Console.ReadKey();
            
        }
    }
}

