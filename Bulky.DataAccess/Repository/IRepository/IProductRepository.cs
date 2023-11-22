using Bulky.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IProductRepository: IRepository<Product>
    {
        public void Save();
        public void Update(Product product);
    }
}
