using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testecrud3.Models
{
    public class Curso
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CursoID { get; set; }
        public string Titulo { get; set; }
        public int Creditos { get; set; }

        public ICollection<Inscricao> EIncrições { get; set; }

    }
}