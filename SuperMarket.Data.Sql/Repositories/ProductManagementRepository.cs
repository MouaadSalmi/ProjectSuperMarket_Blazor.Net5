﻿using SuperMarket.Core;
using SuperMarket.Data.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Data.Sql.Repositories
{
    public class ProductManagementRepository : IProductManagementRepository
    {
        private readonly AppDbContext db;

        public ProductManagementRepository(AppDbContext _db)
        {
            db = _db;
        }
        public void AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = db.Products.Find(productId);
            if (product == null) return;

            db.Products.Remove(product);
            db.SaveChanges();
        }

        public Product GetProductById(int productId)
        {
            return db.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return db.Products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public void UpdateProduct(Product product)
        {
            var prod = db.Products.Find(product.ProductId);
            prod.CategoryId = product.CategoryId;
            prod.Name = product.Name;
            prod.Price = product.Price;
            prod.Quantity = product.Quantity;

            db.SaveChanges();
        }
    }
}

