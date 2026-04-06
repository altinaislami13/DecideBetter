using System;
using System.Collections.Generic;
using System.Linq;
using DecideWise.Models;
using DecideWise.Data;

namespace DecideWise.Services
{
    public class DecisionService
    {
        private readonly IRepository<Option> _repository;

        public DecisionService(IRepository<Option> repository)
        {
            _repository = repository;
        }

        public List<Option> GetAll(string? category = null)
        {
            try
            {
                var options = _repository.GetAll();

                if (!string.IsNullOrWhiteSpace(category))
                {
                    options = options
                        .Where(o => o.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }

                return options;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim gjatë marrjes së të dhënave: {ex.Message}");
                return new List<Option>();
            }
        }

        public Option? GetById(int id)
        {
            try
            {
                var option = _repository.GetById(id);

                if (option == null)
                {
                    Console.WriteLine("Itemi nuk u gjet.");
                }

                return option;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim gjatë kërkimit: {ex.Message}");
                return null;
            }
        }

        // ✅ FEATURE: Search
        public List<Option> SearchByName(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    return new List<Option>();

                return _repository.GetAll()
                    .Where(o => o.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim gjatë kërkimit: {ex.Message}");
                return new List<Option>();
            }
        }

        public void AddOption(Option option)
        {
            try
            {
                Validate(option);
                _repository.Add(option);
                Log("Added option: " + option.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim: {ex.Message}");
            }
        }

        public void UpdateOption(Option option)
        {
            try
            {
                Validate(option);
                _repository.Update(option);
                Log("Updated option ID: " + option.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim: {ex.Message}");
            }
        }

        public void DeleteOption(int id)
        {
            try
            {
                _repository.Delete(id);
                Log("Deleted option ID: " + id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim gjatë fshirjes: {ex.Message}");
            }
        }

        public Option? GetBestOption()
        {
            try
            {
                return _repository.GetAll()
                    .OrderByDescending(o => o.ValueScore)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim gjatë llogaritjes: {ex.Message}");
                return null;
            }
        }

        public List<Option> GetTopOptions(int count = 3)
        {
            try
            {
                return _repository.GetAll()
                    .OrderByDescending(o => o.ValueScore)
                    .Take(count)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim gjatë renditjes: {ex.Message}");
                return new List<Option>();
            }
        }

        public void AddScore(int id, int score)
        {
            try
            {
                var option = _repository.GetById(id);

                if (option == null)
                {
                    Console.WriteLine("Itemi nuk u gjet.");
                    return;
                }

                option.Score += score;
                _repository.Update(option);

                Log($"Score added to {option.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim gjatë shtimit të pikëve: {ex.Message}");
            }
        }

        private void Validate(Option option)
        {
            if (string.IsNullOrWhiteSpace(option.Name))
                throw new ArgumentException("Emri nuk mund të jetë bosh");

            if (option.Price <= 0)
                throw new ArgumentException("Çmimi duhet të jetë më i madh se 0");
        }

        private void Log(string message)
        {
            Console.WriteLine($"[LOG {DateTime.Now}] {message}");
        }
    }
}