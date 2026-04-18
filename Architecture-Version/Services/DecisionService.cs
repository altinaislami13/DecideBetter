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
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public List<Option> GetAll(string? category = null)
        {
            var options = _repository.GetAll();

            if (!string.IsNullOrWhiteSpace(category))
            {
                options = options
                    .Where(o => o.Category != null &&
                                o.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return options;
        }

        public Option GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID duhet të jetë më i madh se 0");

            var option = _repository.GetById(id);

            if (option == null)
                throw new KeyNotFoundException($"Option me ID {id} nuk ekziston.");

            return option;
        }

        // ✅ Search improvement
        public List<Option> SearchByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return new List<Option>();

            return _repository.GetAll()
                .Where(o => !string.IsNullOrWhiteSpace(o.Name) &&
                            o.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public void AddOption(Option option)
        {
            Validate(option);
            _repository.Add(option);
        }

        public void UpdateOption(Option option)
        {
            Validate(option);

            var existing = _repository.GetById(option.Id);
            if (existing == null)
                throw new KeyNotFoundException($"Option me ID {option.Id} nuk ekziston.");

            _repository.Update(option);
        }

        public void DeleteOption(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID duhet të jetë më i madh se 0");

            var existing = _repository.GetById(id);
            if (existing == null)
                throw new KeyNotFoundException($"Option me ID {id} nuk ekziston.");

            _repository.Delete(id);
        }

        public Option? GetBestOption()
        {
            return _repository.GetAll()
                .OrderByDescending(o => o.ValueScore)
                .FirstOrDefault();
        }

        public List<Option> GetTopOptions(int count = 3)
        {
            if (count <= 0)
                throw new ArgumentException("Count duhet të jetë më i madh se 0");

            return _repository.GetAll()
                .OrderByDescending(o => o.ValueScore)
                .Take(count)
                .ToList();
        }

        public void AddScore(int id, int score)
        {
            if (score <= 0)
                throw new ArgumentException("Score duhet të jetë pozitiv");

            var option = _repository.GetById(id);

            if (option == null)
                throw new KeyNotFoundException($"Option me ID {id} nuk ekziston.");

            option.Score += score;
            _repository.Update(option);
        }

        private void Validate(Option option)
        {
            if (option == null)
                throw new ArgumentNullException(nameof(option));

            if (string.IsNullOrWhiteSpace(option.Name))
                throw new ArgumentException("Emri nuk mund të jetë bosh");

            if (option.Price <= 0)
                throw new ArgumentException("Çmimi duhet të jetë më i madh se 0");
        }
    }
}