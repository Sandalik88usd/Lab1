using System.Text.Json;

namespace LB1;

public class SameElementsByKey
{
    public Dictionary<int, string> dictionary { get; set; }
    private Dictionary<int, string> _fruits = new Dictionary<int, string>()
    {
        {1,"apple"},
        {2,"orange"},
        {3,"lemon"},
        {4,"apple"},
        {5,"orange"},
        {6,"banana"},
    };
    
    public void FindSameValues()
    {
        dictionary = new Dictionary<int, string>();
        foreach (var (fruitKey, fruitValue) in _fruits)
        {
            foreach (var (fruitKeyOfSameValue, fruitSameValue) in _fruits)
            {
                if (fruitKey == fruitKeyOfSameValue)
                {
                    break;
                }
                else if (fruitValue == fruitSameValue)
                {
                    Console.WriteLine($"Знайдено одинакові елементи за значеннями їх ключі:" +
                                      $"\nключ 1 - {fruitKeyOfSameValue}, ключ 2 - {fruitKey}, " +
                                      $"а значеня {fruitValue}");
                    dictionary.Add(fruitKey,fruitValue);
                    dictionary.Add(fruitKeyOfSameValue,fruitValue);
                    _fruits.Remove(fruitKeyOfSameValue);
                }
            }
            
        }
        //string json = JsonSerializer.Serialize(dictionary);
        //Console.WriteLine(json);
    }
}
