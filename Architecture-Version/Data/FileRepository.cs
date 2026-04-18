using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using DecideWise.Models;

namespace DecideWise.Data
{
    public class FileRepository : IRepository<Option>
    {
        private readonly string _filePath;
        private List<Option> _options;

        public FileRepository(string filePath)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            _options = new List<Option>();

            LoadFromFile();
        }

        private void LoadFromFile()
        {
            if (!File.Exists(_filePath))
            {
                _options = new List<Option>();
                Save(); // krijon file automatikisht
                return;
            }

            try
            {
                var json = File.ReadAllText(_filePath);

                if (string.IsNullOrWhiteSpace(json))
                {
                    _options = new List<Option>();
                    return;
                }

                _options = JsonSerializer.Deserialize<List<Option>>(json)
                           ?? new List<Option>();
            }
            catch
            {
                // file corrupted → reset
                _options = new List<Option>();
                Save();
            }
        }

        public List<Option> GetAll()
        {
            return _options.ToList(); // avoid external modification
        }

        public Option? GetById(int id)
        {
            return _options.FirstOrDefault(o => o.Id == id);
        }

        public void Add(Option item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            item.Id = _options.Any() ? _options.Max(o => o.Id) + 1 : 1;

            _options.Add(item);
            Save();
        }

        public void Update(Option item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var index = _options.FindIndex(o => o.Id == item.Id);

            if (index == -1)
                throw new KeyNotFoundException($"Option me ID {item.Id} nuk ekziston.");

            _options[index] = item;
            Save();
        }

        public void Delete(int id)
        {
            var item = _options.FirstOrDefault(o => o.Id == id);

            if (item == null)
                throw new KeyNotFoundException($"Option me ID {id} nuk ekziston.");

            _options.Remove(item);
            Save();
        }

        private void Save()
        {
            var json = JsonSerializer.Serialize(_options, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_filePath, json);
        }
    }
}