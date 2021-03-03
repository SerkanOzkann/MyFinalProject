using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Entities.Concrete;

namespace Business.Constants
{
    public  static class Messages  // new'lelemek için static yapıyoruz.
    {
        public static string ProductAdded = "Ürün eklendi.";

        public static string ProductNameInvalid = "Ürün ismi geçersiz."; //invalid=geçersiz.
        public static string MaintenanceTime = "Sistem bakımda.";
        public static string ProductListed = "Ürünler listelendi.";
        public static string ProductCountOfCategoryError = "En fazla Kategori ekleme sınırına ulaştınız.";
        public static string ProductNameAlreadyExists="Bu isimde bir ürün mevcut.";
        public static string CategoryLimitExceded="Kategori Limiti Aşıldı.";

        public static string AuthorizationDenied = "Yetkiniz yok.";
    }
}
