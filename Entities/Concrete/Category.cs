


using Core.DataAccess;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
        // çıplak Class kalmasın!!!!!

    public class Category: IEntity
    {
        //Category classında categroyy özelliklerini belirledik.

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
