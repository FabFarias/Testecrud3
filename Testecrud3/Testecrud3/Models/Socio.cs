using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Testecrud3.Models
{
    public class Socio
    {
        public int SocioID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime InscriçãoDate { get; set; }
        public ICollection<Inscricao> Inscrições { get; set; }
    }
}
