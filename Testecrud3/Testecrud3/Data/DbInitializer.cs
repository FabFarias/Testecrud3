using Testecrud3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testecrud3.Data
{
    public class DbInitializer
    {
        public static void Initialize(Contexto context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Socios.Any())
            {
                return;   // DB has been seeded
            }

            var socios = new Socio[]
            {
            new Socio{Nome="Carson",Email="Alexander",InscriçãoDate=DateTime.Parse("2005-09-01")},
            new Socio{Nome="Meredith",Email="Alonso",InscriçãoDate=DateTime.Parse("2002-09-01")},
            new Socio{Nome="Arturo",Email="Anand",InscriçãoDate=DateTime.Parse("2003-09-01")},
            new Socio{Nome="Gytis",Email="Barzdukas",InscriçãoDate=DateTime.Parse("2002-09-01")},
            new Socio{Nome="Yan",Email="Li",InscriçãoDate=DateTime.Parse("2002-09-01")},
            new Socio{Nome="Peggy",Email="Justice",InscriçãoDate=DateTime.Parse("2001-09-01")},
            new Socio{Nome="Laura",Email="Norman",InscriçãoDate=DateTime.Parse("2003-09-01")},
            new Socio{Nome="Nino",Email="Olivetto",InscriçãoDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Socio s in socios)
            {
                context.Socios.Add(s);
            }
            context.SaveChanges();

            var cursos = new Curso[]
            {
            new Curso{CursoID=1050,Titulo="Chemistry",Creditos=3},
            new Curso{CursoID=4022,Titulo="Microeconomics",Creditos=3},
            new Curso{CursoID=4041,Titulo="Macroeconomics",Creditos=3},
            new Curso{CursoID=1045,Titulo="Calculus",Creditos=4},
            new Curso{CursoID=3141,Titulo="Trigonometry",Creditos=4},
            new Curso{CursoID=2021,Titulo="Composition",Creditos=3},
            new Curso{CursoID=2042,Titulo="Literature",Creditos=4}
            };
            foreach (Curso c in cursos)
            {
                context.Cursos.Add(c);
            }
            context.SaveChanges();

            var inscricoes = new Inscricao[]
            {
            new Inscricao{SocioID=1,CursoID=1050,Grade=Grade.A},
            new Inscricao{SocioID=1,CursoID=4022,Grade=Grade.C},
            new Inscricao{SocioID=1,CursoID=4041,Grade=Grade.B},
            new Inscricao{SocioID=2,CursoID=1045,Grade=Grade.B},
            new Inscricao{SocioID=2,CursoID=3141,Grade=Grade.F},
            new Inscricao{SocioID=2,CursoID=2021,Grade=Grade.F},
            new Inscricao{SocioID=3,CursoID=1050},
            new Inscricao{SocioID=4,CursoID=1050},
            new Inscricao{SocioID=4,CursoID=4022,Grade=Grade.F},
            new Inscricao{SocioID=5,CursoID=4041,Grade=Grade.C},
            new Inscricao{SocioID=6,CursoID=1045},
            new Inscricao{SocioID=7,CursoID=3141,Grade=Grade.A},
            };
            foreach (Inscricao e in inscricoes)
            {
                context.Inscrições.Add(e);
            }
            context.SaveChanges();
        }
    }
}
    

