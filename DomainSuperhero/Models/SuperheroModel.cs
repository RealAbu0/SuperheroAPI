using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainSuperhero.Models
{
    public class SuperheroModel
    {
        public int SuperheroID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SuperheroName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}
