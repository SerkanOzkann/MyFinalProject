using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //global değişken olduğu için _ ile ifade edilir.

        public InMemoryProductDal()  //ctor = Constructor olusturmadır. bellekte referans aldıgı zaman calısıcak olan bloktur.
        {
            _products = new List<Product>  //içinde ürünler bulundurna liste  =AS Database
            {
                new Product{  ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
                new Product { ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3 },
                new Product { ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2 },
                new Product { ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65 },
                new Product { ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1 }
             };

            //LİNQ SORGULARI

           var result= _products.Any(p => p.ProductName == "Kamera");  // Any== liste içinde o aranan ürün var mı onu sorgular. 
            Console.WriteLine(result);  //Sonuç true/false olarak döner.

           var result2=  _products.Find(p =>p.ProductId==3);  // Find= Bir ürünün detayına gitmek için kullanılır.
            Console.WriteLine(result2);

           var result3 = _products.FindAll(p => p.ProductName.Contains("Telefon"));
            Console.WriteLine(result3); //Çıktı:System.Collections.Generic.List`1[Entities.Concrete.Product]

           var result4= _products.Where(p => p.ProductName.Contains("ar")); // içinde ar olanları listeler.
            Console.WriteLine(result4);
            foreach (var item in result4)
            {
                Console.WriteLine(item.ProductName);
            }



        }


        public void Add(Product product)
        {
            _products.Add(product); // YENİ BİR ÜRÜN GELDİĞİNDE EKLEME YAPAR.
        }

        public void Delete(Product product)
        {
            //LINQ = Language Integrated Query , Dil ile tümleşik sorgu
            // sorgu yeteneklerinin doğrudan C# dilinde tümleştirilmesini temel alan bir teknoloji kümesinin adıdır.

            //Product productToDelete = null;   NORMAL KULLANIM

            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }

            //}


            // with LINQ
            //(p TAKMA İSİM =>ŞART DURUMU  p.ProductId == product.ProductId);   SingleOrDefault== METHOD

            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId); //Bu kod foreach görevi görür. tek bir eleman bulmaya yarar.

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()  // datayı business'a ver.
        {
            return _products;
        }

        public void Update(Product product) // gelen data 
        {
            //WİTH LINQ Görderdiğim ürün idsine sahip olan listedeki ürünü bul ve güncelle.

            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = productToUpdate.UnitPrice;
            productToUpdate.UnitsInStock = productToUpdate.UnitsInStock;

                
        }

        

        public List<Product> GetAllByCategory(int categoryId)
        {
           
            //Where= içindeki şarta uyan bütün elemanları yeni bir liste haline getirir ve orda durur.
           return  _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
