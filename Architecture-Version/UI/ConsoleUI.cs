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
        }

        private void ListOptions()
        {
            var options = _service.GetAll();

            if (options.Count == 0)
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

            Console.Write("Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Ju lutem shkruani numër valid!");
                return;
            }

            var option = new Option
            {
                Name = name,
                Category = category,
                Price = price,
                Score = 0
            };

            _service.AddOption(option);
            Console.WriteLine("U shtua me sukses!");
        }

        private void UpdateOption()
        {
            Console.Write("ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID jo valid!");
                return;
            }

            Console.Write("New Name: ");
            var name = Console.ReadLine() ?? "";

            Console.Write("New Category: ");
            var category = Console.ReadLine() ?? "";

            Console.Write("New Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Çmimi jo valid!");
                return;
            }

            var option = new Option
            {
                Id = id,
                Name = name,
                Category = category,
                Price = price
            };

            _service.UpdateOption(option);
            Console.WriteLine("U përditësua!");
        }

        private void DeleteOption()
        {
            Console.Write("ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID jo valid!");
                return;
            }

            _service.DeleteOption(id);
            Console.WriteLine("U fshi!");
        }

        private void FilterByCategory()
        {
            Console.Write("Category: ");
            var category = Console.ReadLine();

            var list = _service.GetAll(category);

            if (list.Count == 0)
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

            if (list.Count == 0)
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
            Console.Write("ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID jo valid!");
                return;
            }

            Console.Write("Score: ");
            if (!int.TryParse(Console.ReadLine(), out int score))
            {
                Console.WriteLine("Score jo valid!");
                return;
            }

            _service.AddScore(id, score);
            Console.WriteLine("Score u shtua!");
        }

        // ✅ FEATURE: Search
        private void SearchOption()
        {
            Console.Write("Shkruaj emrin: ");
            var input = Console.ReadLine() ?? "";

            var results = _service.SearchByName(input);

            if (results.Count == 0)
            {
                Console.WriteLine("Nuk u gjet asnjë rezultat.");
                return;
            }

            foreach (var o in results)
            {
                Console.WriteLine($"{o.Name} - {o.Price}€");
            }
        }
    }
}