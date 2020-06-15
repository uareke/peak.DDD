using System;
using System.Collections.Generic;
using System.Text;

namespace peak.DDD.Domain.Entities
{
    public class Calculo : EntityBase
    {
        public decimal Parcelas { get; set; }
        public decimal Valor { get; set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
