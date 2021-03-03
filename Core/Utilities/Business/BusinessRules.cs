using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
   public class BusinessRules
    {                                                        // logics= iş kuralı
        public static  IResult Run(params IResult[] logics) // params istenildiği kadar parametre kullanılabilir.
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }

            }
            return null;
        }
    }
}
