using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{ //Yazılıma yeni bir özellik ekliyorsan mevcut kodlara dokunamazsın. SOLİD'İN O'su Open Closed Principle


    class Program
    {
        static void Main(string[] args)
        {

            // Data Transformation Object =DTOS  taşınacak obje

             ProductTest();

            //CategoryTest();





            Console.ReadLine();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));

            var result = productManager.GetProductDetails();

            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);

                }
            }
            else

            {
                Console.WriteLine(result.Message);
            }
            

            //foreach (var product in productManager.GetProductDetails().Data)
            //{
            //    Console.WriteLine(product.ProductName + "/" + product.CategoryName); // ürün isimlerini listeler.
            //}
        }
    }
}
