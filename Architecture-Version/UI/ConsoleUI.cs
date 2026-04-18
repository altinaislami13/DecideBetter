using System;
using DecideWise.Models;
using DecideWise.Services;

namespace DecideWise.UI
{
    public class ConsoleUI
    {
        private readonly DecisionService _service;

        public ConsoleUI(DecisionService service)
        {
            _service = service;
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("\n=== MENU PREMIUM ===");
                Console.WriteLine("1. List Options");
                Console.WriteLine("2. Add Option");
                Console.WriteLine("3. Update Option");
                Console.WriteLine("4. Delete Option");
                Console.WriteLine("5. Filter by Category");
                Console.WriteLine("6. Best Option ⭐");
                Console.WriteLine("7. Top 3 Options 🔥");
                Console.WriteLine("8. Add Score");
                Console.WriteLine("9. Search Option 🔍");
                Console.WriteLine("0. Exit");

                Console.Write("Choose: ");
                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1": ListOptions(); break;
                        case "2": AddOption(); break;
                        case "3": UpdateOption(); break;
                        case "4": DeleteOption(); break;
                        case "5": FilterByCategory(); break;
                        case "6": BestOption(); break;
                        case "7": Top3(); break;
                        case "8": AddScore(); break;
                        case "9": SearchOption(); break;
                        case "0": return;
                        default: Console.WriteLine("Zgjedhje e pavlefshme!"); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error: {ex.Message}");
                }
            }
        }

        private void ListOptions()
        {
            var options = _service.GetAll();

            if (!options.Any())
            {
                Console.WriteLine("Nuk ka të dhëna.");
                return;
            }

            foreach (var o in options)
            {
                Console.WriteLine($"{o.Id} | {o.Name} | {o.Category} | {o.Price}€ | Score: {o.Score} | Value: {o.ValueScore:F2}");
            }
        }

        private void AddOption()
        {
            Console.Write("Name: ");
            var name = Console.ReadLine() ?? "";

            Console.Write("Category: ");
            var category = Console.ReadLine() ?? "";

            decimal price = ReadDecimal("Price");

            var option = new Option
            {
                Name = name,
                Category = category,
                Price = price,
                Score = 0
            };

            _service.AddOption(option);
            Console.WriteLine("✅ U shtua me sukses!");
        }

        private void UpdateOption()
        {
            int id = ReadInt("ID");

            Console.Write("New Name: ");
            var name = Console.ReadLine() ?? "";

            Console.Write("New Category: ");
            var category = Console.ReadLine() ?? "";

            decimal price = ReadDecimal("New Price");

            var option = new Option
            {
                Id = id,
                Name = name,
                Category = category,
                Price = price
            };

            _service.UpdateOption(option);
            Console.WriteLine("✅ U përditësua!");
        }

        private void DeleteOption()
        {
            int id = ReadInt("ID");
            _service.DeleteOption(id);
            Console.WriteLine("✅ U fshi!");
        }

        private void FilterByCategory()
        {
            Console.Write("Category: ");
            var category = Console.ReadLine();

            var list = _service.GetAll(category);

            if (!list.Any())
            {
                Console.WriteLine("Nuk u gjet asnjë rezultat.");
                return;
            }

            foreach (var o in list)
            {
                Console.WriteLine($"{o.Name} - {o.Price}€");
            }
        }

        private void BestOption()
        {
            var best = _service.GetBestOption();

            if (best == null)
            {
                Console.WriteLine("Nuk ka të dhëna!");
                return;
            }

            Console.WriteLine($"🏆 BEST: {best.Name} ({best.ValueScore:F2})");
        }

        private void Top3()
        {
            var list = _service.GetTopOptions(3);

            if (!list.Any())
            {
                Console.WriteLine("Nuk ka të dhëna!");
                return;
            }

            foreach (var o in list)
            {
                Console.WriteLine($"🔥 {o.Name} ({o.ValueScore:F2})");
            }
        }

        private void AddScore()
        {
            int id = ReadInt("ID");
            int score = ReadInt("Score");

            _service.AddScore(id, score);
            Console.WriteLine("✅ Score u shtua!");
        }

        private void SearchOption()
        {
            Console.Write("Shkruaj emrin: ");
            var input = Console.ReadLine() ?? "";

            var results = _service.SearchByName(input);

            if (!results.Any())
            {
                Console.WriteLine("Nuk u gjet asnjë rezultat.");
                return;
            }

            foreach (var o in results)
            {
                Console.WriteLine($"{o.Name} - {o.Price}€");
            }
        }

        // 🔧 Helper methods
        private int ReadInt(string field)
        {
            Console.Write($"{field}: ");
            if (!int.TryParse(Console.ReadLine(), out int value))
                throw new ArgumentException($"{field} jo valid!");

            return value;
        }

        private decimal ReadDecimal(string field)
        {
            Console.Write($"{field}: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal value))
                throw new ArgumentException($"{field} jo valid!");

            return value;
        }
    }
}