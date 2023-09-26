using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlunoDisciplinaExtra.aluno;

namespace AlunoDisciplinaExtra.disciplina
{
    internal abstract class Disciplina
    {
        protected string nomeDisciplina;
        protected int cargaHoraria;
        protected List<Aluno> listaAlunos;
        protected bool isOfertada;

        public Disciplina(string nomeDisciplina, int cargaHoraria)
        {
            this.nomeDisciplina = nomeDisciplina;
            this.cargaHoraria = cargaHoraria;
            listaAlunos = new List<Aluno>();
            isOfertada = false;
        }

        public int CargaHoraria
        {
            get { return cargaHoraria; }
            set { cargaHoraria = value; }
        }

        public int checarQtdAlunos()
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
    }
}
