namespace Testecrud3.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class Inscricao
    {
        public int InscricaoID { get; set; }
        public int CursoID { get; set; }
        public int SocioID { get; set; }
        public Grade? Grade { get; set; }

        public Curso Curso { get; set; }
        public Socio Socio { get; set; }
    }
}