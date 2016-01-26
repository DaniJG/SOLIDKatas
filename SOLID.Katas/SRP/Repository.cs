using SOLID.Katas.SRP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Katas.SRP
{
    public class Repository<T> where T: Entity
    {
        private static Random IdGenerator = new Random();
        private static Dictionary<string, List<T>> Values = new Dictionary<string, List<T>>();

        public T Add(T entity)
        {            
            this.GetList().Add(entity);
            entity.Id = IdGenerator.Next();
            return entity;
        }

        public T GetById(int id)
        {
            return this.GetList().FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return this.GetList();
        }

        private List<T> GetList()
        {
            var key = typeof(T).Name;

            if(!Values.ContainsKey(key))
            {
                Values[key] = new List<T>();
            }
            return Values[key];
        }
    }
}
