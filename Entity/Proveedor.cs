using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Proveedor : Persona
    {
        [Key]
        public string NIT { get; set; }

    }
}
