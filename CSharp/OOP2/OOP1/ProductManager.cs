﻿
namespace OOP1
{
    class ProductManager
    {     
        public void Add(Product product)//101
        {
            Console.WriteLine(product.ProductName + " eklendi.");
        }       
        
        public void Update(Product product)
        {
            Console.WriteLine(product.ProductName + " güncellendi.");
        }
    }
}
