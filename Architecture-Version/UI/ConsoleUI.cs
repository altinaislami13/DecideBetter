using System;
using System.Linq;
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
            ShowHeader();

            while (true)
            {
                ShowMenu();

                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1": ListOptions(); break;
                        case "2": AddOption(); break;
                        case "3": AddScore(); break;
                        case "4": SearchOption(); break;
                        case "5": FilterByCategory(); break;
                        case "6": BestOption(); break;
                        case "7": Top3(); break;
                        case "8": UpdateOption(); break;
                        case "9": DeleteOption(); break;
                        case "10": LoadDemoScenario(); break;
                        case "11": ShowSummary(); break;
                        case "0":
                            Console.WriteLine("\nThank you for using DecideWise!");
                            return;
                        default:
                            Console.WriteLine("\n[ERROR] Invalid selection.\n");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n[ERROR] {ex.Message}\n");
                }

                Pause();
            }
        }

        private void ShowHeader()
        {
            Console.Clear();
            Console.WriteLine("========================================================");
            Console.WriteLine("        DECIDEWISE - INTELLIGENT DECISION SYSTEM        ");
            Console.WriteLine("========================================================");
            Console.WriteLine(" Compare alternatives, score them and find the best.");
            Console.WriteLine(" Demo Presentation Version");
            Console.WriteLine("========================================================\n");
        }

        private void ShowMenu()
        {
            Console.WriteLine("\n---------------------- MAIN MENU -----------------------");
            Console.WriteLine("1. View All Options");
            Console.WriteLine("2. Add New Option");
            Console.WriteLine("3. Add Score to Option");
            Console.WriteLine("4. Search Option");
            Console.WriteLine("5. Filter by Category");
            Console.WriteLine("6. Show Best Recommended Option");
            Console.WriteLine("7. Show Top 3 Ranked Options");
            Console.WriteLine("8. Update Existing Option");
            Console.WriteLine("9. Delete Option");
            Console.WriteLine("10. Load Demo Scenario");
            Console.WriteLine("11. Show Decision Summary Report");
            Console.WriteLine("0. Exit");
            Console.WriteLine("--------------------------------------------------------");
        }

        private void ListOptions()
        {
            var options = _service.GetAll();

            if (!options.Any())
            {
                Console.WriteLine("\n[INFO] No options available.\n");
                return;
            }

            Console.WriteLine("\nID | NAME            | CATEGORY      | PRICE | SCORE | VALUE");
            Console.WriteLine("---------------------------------------------------------------");

            foreach (var o in options)
            {
                Console.WriteLine($"{o.Id,-3}| {o.Name,-15}| {o.Category,-13}| {o.Price,-6}€| {o.Score,-6}| {o.ValueScore:F2}");
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
            Console.WriteLine("\n[SUCCESS] Option added successfully.\n");
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
            Console.WriteLine("\n[SUCCESS] Option updated successfully.\n");
        }

        private void DeleteOption()
        {
            int id = ReadInt("ID");
            _service.DeleteOption(id);
            Console.WriteLine("\n[SUCCESS] Option deleted successfully.\n");
        }

        private void FilterByCategory()
        {
            Console.Write("Category: ");
            var category = Console.ReadLine();

            var list = _service.GetAll(category);

            if (!list.Any())
            {
                Console.WriteLine("\n[INFO] No matching category found.\n");
                return;
            }

            Console.WriteLine("\nFiltered Results:");
            foreach (var o in list)
            {
                Console.WriteLine($"- {o.Name} | {o.Price}€ | Score: {o.Score}");
            }
        }

        private void BestOption()
        {
            var best = _service.GetBestOption();

            if (best == null)
            {
                Console.WriteLine("\n[INFO] No data available.\n");
                return;
            }

            Console.WriteLine("\n=================================================");
            Console.WriteLine($" BEST RECOMMENDED OPTION: {best.Name}");
            Console.WriteLine($" FINAL VALUE SCORE: {best.ValueScore:F2}");
            Console.WriteLine("=================================================\n");
        }

        private void Top3()
        {
            var list = _service.GetTopOptions(3);

            if (!list.Any())
            {
                Console.WriteLine("\n[INFO] No data available.\n");
                return;
            }

            Console.WriteLine("\nTOP 3 RANKED OPTIONS");
            Console.WriteLine("--------------------");

            foreach (var o in list)
            {
                Console.WriteLine($"- {o.Name} ({o.ValueScore:F2})");
            }
        }

        private void AddScore()
        {
            int id = ReadInt("Option ID");
            int score = ReadInt("Score");

            _service.AddScore(id, score);
            Console.WriteLine("\n[SUCCESS] Score added successfully.\n");
        }

        private void SearchOption()
        {
            Console.Write("Enter name keyword: ");
            var input = Console.ReadLine() ?? "";

            var results = _service.SearchByName(input);

            if (!results.Any())
            {
                Console.WriteLine("\n[INFO] No search results found.\n");
                return;
            }

            Console.WriteLine("\nSearch Results:");
            foreach (var o in results)
            {
                Console.WriteLine($"- {o.Name} | {o.Category} | {o.Price}€");
            }
        }

        private void LoadDemoScenario()
        {
            var existing = _service.GetAll();

            if (existing.Any())
            {
                Console.WriteLine("\n[INFO] Demo data already exists. Skipping load.\n");
                return;
            }

            _service.AddOption(new Option { Name = "Dell XPS", Category = "Laptop", Price = 1200, Score = 85 });
            _service.AddOption(new Option { Name = "Lenovo ThinkPad", Category = "Laptop", Price = 1100, Score = 92 });
            _service.AddOption(new Option { Name = "HP Pavilion", Category = "Laptop", Price = 980, Score = 80 });

            Console.WriteLine("\n[SUCCESS] Demo scenario loaded successfully.\n");
        }

        private void ShowSummary()
        {
            var options = _service.GetAll();

            if (!options.Any())
            {
                Console.WriteLine("\n[INFO] No data available.\n");
                return;
            }

            var best = options.OrderByDescending(o => o.ValueScore).First();
            var cheapest = options.OrderBy(o => o.Price).First();
            var avgScore = options.Average(o => o.Score);

            Console.WriteLine("\n============= DECISION SUMMARY =============");
            Console.WriteLine($"Total Options: {options.Count}");
            Console.WriteLine($"Average Score: {avgScore:F2}");
            Console.WriteLine($"Cheapest Option: {cheapest.Name} ({cheapest.Price}€)");
            Console.WriteLine($"Best Option: {best.Name} ({best.ValueScore:F2})");
            Console.WriteLine("============================================\n");
        }

        private int ReadInt(string field)
        {
            Console.Write($"{field}: ");
            if (!int.TryParse(Console.ReadLine(), out int value))
                throw new ArgumentException($"{field} is invalid.");

            return value;
        }

        private decimal ReadDecimal(string field)
        {
            Console.Write($"{field}: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal value))
                throw new ArgumentException($"{field} is invalid.");

            return value;
        }

        private void Pause()
        {
            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadLine();
        }
    }
}