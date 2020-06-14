using Newtonsoft.Json;
using peak.DDD.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace peak.DDD.Domain.Entities
{
    public class Clientes : EntityBase
    {
        [Required(ErrorMessage ="Campo nome é obrigatorio")]
        public string nome { get; set; }
       [Required(ErrorMessage = "Campo CPF é obrigatorio")]
        public string cpf { get; set; }


        public DateTime created { get; set; }
        public DateTime modified { get; set; }

        public Clientes()
        {
            this.created = DateTime.UtcNow;
            this.modified = DateTime.UtcNow;
        }

        public override void Validar()
        {

        }
    }
}
