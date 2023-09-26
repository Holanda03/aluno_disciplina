using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using AlunoDisciplinaExtra.aluno;

namespace AlunoDisciplinaExtra.disciplina
{
    internal abstract class Disciplina
    {
        protected static int codigo_default = 0;
        
        protected string nomeDisciplina;
        protected int codigo;
        protected int cargaHoraria;
        protected Dictionary<int, Aluno> listaAlunos;
        protected bool isOfertada;

        public Disciplina(string nomeDisciplina, int cargaHoraria)
        {
            this.nomeDisciplina = nomeDisciplina;
            this.cargaHoraria = cargaHoraria;
            codigo = codigo_default++;
            listaAlunos = new Dictionary<int, Aluno>();
            isOfertada = false;
        }

        public int CargaHoraria
        {
            get { return cargaHoraria; }
            set { cargaHoraria = value; }
        }

        public string NomeDisciplina
        {
            get { return nomeDisciplina; }
            set { nomeDisciplina = value; }
        }

        public Dictionary<int, Aluno> ListaAlunos
        {
            get { return  listaAlunos; }
            set {  listaAlunos = value; }
        }

        public int ChecarQtdAlunos()
        {
            var qtdAlunos = listaAlunos.Count;

            if (qtdAlunos >= 12)
            {
                isOfertada = true;
            }
            else
            {
                isOfertada = false;
            }

            return qtdAlunos;
        }

        public void AddAluno(Aluno aluno)
        {
            if (listaAlunos.ContainsValue(aluno))
            {
                throw new Exception("O aluno " + aluno.Nome + " já está matriculado na disciplina.");
            }
            
            listaAlunos.Add(aluno.Matricula, aluno);
            Console.WriteLine("O aluno de matricula " + aluno.Matricula + " foi adicionado com sucesso.");
        }

        public void RemoverAluno(int matricula)
        {
            if (listaAlunos.ContainsKey(matricula) == false)
            {
                throw new Exception("Aluno não existente na disciplina.");
            }

            listaAlunos.Remove(matricula);
            Console.WriteLine("Aluno removido.");
        }
    }
}
