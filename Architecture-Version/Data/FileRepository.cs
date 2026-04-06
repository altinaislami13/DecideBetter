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
            _filePath = filePath;
            _options = new List<Option>();

            LoadFromFile();
        }

        private void LoadFromFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    Console.WriteLine("File nuk u gjet, po krijoj file të ri...");
                    File.WriteAllText(_filePath, "[]");
                    _options = new List<Option>();
                    return;
                }

                var json = File.ReadAllText(_filePath);

                _options = JsonSerializer.Deserialize<List<Option>>(json)
                           ?? new List<Option>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim gjatë leximit të file: {ex.Message}");
                _options = new List<Option>();
            }
        }

        public List<Option> GetAll()
        {
            return _options;
        }

        public Option? GetById(int id)
        {
            return _options.FirstOrDefault(o => o.Id == id);
        }

        public void Add(Option item)
        {
            try
            {
                item.Id = _options.Any() ? _options.Max(o => o.Id) + 1 : 1;
                _options.Add(item);
                Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim gjatë shtimit: {ex.Message}");
            }
        }

        public void Update(Option item)
        {
            try
            {
                var index = _options.FindIndex(o => o.Id == item.Id);

                if (index == -1)
                {
                    Console.WriteLine("Itemi nuk u gjet për update.");
                    return;
                }

                _options[index] = item;
                Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim gjatë update: {ex.Message}");
            }
        }

        public void Delete(int id)
        {
            try
            {
                var item = _options.FirstOrDefault(o => o.Id == id);

                if (item == null)
                {
                    Console.WriteLine("Itemi nuk u gjet për fshirje.");
                    return;
                }

                _options.Remove(item);
                Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim gjatë fshirjes: {ex.Message}");
            }
        }

        public void Save()
        {
            try
            {
                var json = JsonSerializer.Serialize(_options, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim gjatë ruajtjes në file: {ex.Message}");
            }
        }
    }
}