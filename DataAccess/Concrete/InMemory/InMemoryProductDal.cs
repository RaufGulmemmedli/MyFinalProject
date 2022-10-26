using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{

    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId = 1, CatagoryId = 1, ProductName= "Bardak", UnitPrice = 15, UnitsInstock= 15},
                new Product{ProductId = 2, CatagoryId = 1, ProductName= "Kamera", UnitPrice = 500, UnitsInstock= 3},
                new Product{ProductId = 3, CatagoryId = 2, ProductName= "Telefon", UnitPrice = 1500, UnitsInstock= 2},
                new Product{ProductId = 4, CatagoryId = 2, ProductName= "Klavye", UnitPrice = 150, UnitsInstock= 65},
                new Product{ProductId = 5, CatagoryId = 2, ProductName= "Fare", UnitPrice = 85, UnitsInstock= 1}
            };
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CatagoryId == categoryId).ToList();
        }

        void IProductDal.Add(Product product)
        {
           _products.Add(product);
        }

        void IProductDal.Delete(Product product)
        {
            


            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        List<Product> IProductDal.GetAll()
        {
          return _products;
        }

        void IProductDal.Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.UnitsInstock = product.UnitsInstock;
        }
    }
}
