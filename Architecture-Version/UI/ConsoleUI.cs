using Architecture_Version.Models;
using Architecture_Version.Services;

namespace Architecture_Version.UI
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
                Console.WriteLine("9. Exit");

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
                    case "9": return;
                    default: Console.WriteLine("Invalid choice!"); break;
                }
            }
        }

        private void ListOptions()
        {
            var options = _service.GetAll();

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
                Console.WriteLine("Invalid price!");
                return;
            }

            var option = new Option
            {
                Name = name,
                Category = category,
                Price = price,
                Score = 0
            };

            _service.Add(option);
            Console.WriteLine("Added successfully!");
        }

        private void UpdateOption()
        {
            Console.Write("ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            Console.Write("New Name: ");
            var name = Console.ReadLine() ?? "";

            Console.Write("New Category: ");
            var category = Console.ReadLine() ?? "";

            Console.Write("New Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price)) return;

            var option = new Option
            {
                Id = id,
                Name = name,
                Category = category,
                Price = price
            };

            _service.Update(option);
            Console.WriteLine("Updated!");
        }

        private void DeleteOption()
        {
            Console.Write("ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            _service.Delete(id);
            Console.WriteLine("Deleted!");
        }

        private void FilterByCategory()
        {
            Console.Write("Category: ");
            var category = Console.ReadLine();

            var list = _service.GetAll(category);

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
                Console.WriteLine("No data!");
                return;
            }

            Console.WriteLine($"🏆 BEST: {best.Name} ({best.ValueScore:F2})");
        }

        private void Top3()
        {
            var list = _service.GetTop(3);

            foreach (var o in list)
            {
                Console.WriteLine($"🔥 {o.Name} ({o.ValueScore:F2})");
            }
        }

        private void AddScore()
        {
            Console.Write("ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            Console.Write("Score: ");
            if (!int.TryParse(Console.ReadLine(), out int score)) return;

            _service.AddScore(id, score);
            Console.WriteLine("Score added!");
        }
    }
}