using System.Collections.Generic;
using System.Linq;
using DecideWise.Models;
using DecideWise.Data;
using DecideWise.Services;



namespace DecideWise.Tests
{
    public class FakeRepository : IRepository<Option>
    {
        private List<Option> _data = new List<Option>
        {
            new Option { Id = 1, Name = "Laptop", Category = "Tech", Price = 1000, Score = 5 },
            new Option { Id = 2, Name = "Telefon", Category = "Tech", Price = 500, Score = 3 }
        };

        public List<Option> GetAll() => _data;

        public Option? GetById(int id) => _data.FirstOrDefault(x => x.Id == id);

        public void Add(Option item) => _data.Add(item);

        public void Update(Option item)
        {
            var index = _data.FindIndex(x => x.Id == item.Id);
            if (index != -1) _data[index] = item;
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null) _data.Remove(item);
        }

        public void Save() { }
    }
}