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
            var options = _repository.GetAll();

            if (!string.IsNullOrWhiteSpace(category))
                options = options
                    .Where(o => o.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                    .ToList();

            return options;
        }

        // ✅ FIXED (nullable)
        public Option? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void AddOption(Option option)
        {
            Validate(option);
            _repository.Add(option);
            Log("Added option: " + option.Name);
        }

        public void UpdateOption(Option option)
        {
            Validate(option);
            _repository.Update(option);
            Log("Updated option ID: " + option.Id);
        }

        public void DeleteOption(int id)
        {
            _repository.Delete(id);
            Log("Deleted option ID: " + id);
        }

        // ✅ FIXED (nullable)
        public Option? GetBestOption()
        {
            return _repository.GetAll()
                .OrderByDescending(o => o.ValueScore)
                .FirstOrDefault();
        }

        public List<Option> GetTopOptions(int count = 3)
        {
            return _repository.GetAll()
                .OrderByDescending(o => o.ValueScore)
                .Take(count)
                .ToList();
        }

        public void AddScore(int id, int score)
        {
            var option = _repository.GetById(id);
            if (option == null) return;

            option.Score += score;
            _repository.Update(option);

            Log($"Score added to {option.Name}");
        }

        private void Validate(Option option)
        {
            if (string.IsNullOrWhiteSpace(option.Name))
                throw new ArgumentException("Name cannot be empty");

            if (option.Price <= 0)
                throw new ArgumentException("Price must be greater than 0");
        }

        private void Log(string message)
        {
            Console.WriteLine($"[LOG {DateTime.Now}] {message}");
        }
    }
}