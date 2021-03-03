using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
  public  class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2); //name mın2 karekter olmalı.
            RuleFor(p => p.UnitPrice).NotEmpty();   //unitprice boş olamaz.
            RuleFor(p => p.UnitPrice).GreaterThan(0); //unitprice 0 dan kucuk olamaz
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            
            //cat ıd 1 olan p için unitprice10dan az olamaz.

            RuleFor(p => p.ProductName).Must(StarWithA)
                .WithMessage("Ürünler A harfi ile başlamalı."); //ürün ismi a ile başlamalı kendimiz oluşturduk. hata mesajı olusturduk
        }

        private bool StarWithA(string arg) // arl= p.name
        {
            return arg.StartsWith("A"); // a ile başlarsa true döner baslamazsa false döner.
        }
    }
}
