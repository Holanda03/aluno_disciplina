using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlunoDisciplinaExtra.disciplina;

namespace AlunoDisciplinaExtra.aluno
{
    internal class Aluno
    {
        private string nome;
        private double nota1;
        private double nota2;
        private double media;
        private int faltas;
        private string status;
        private bool isSemestreFinalizado;
        private Dictionary<string, Disciplina> disciplinas;

        public Aluno(string nome)
        {
            this.nome = nome;
            nota1 = 0;
            nota2 = 0;
            media = 0;
            faltas = 0;
            status = "cursando";
            isSemestreFinalizado = false;
            disciplinas = new Dictionary<string, Disciplina>();
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public double Nota1
        {
            get { return nota1; }
        }

        public double Nota2
        {
            get { return nota2; }
        }

        public double Media
        {
            get { return media; }
        }

        public int Faltas
        {
            get { return faltas; }
        }

        public string Status
        {
            get { return status; }
        }

        public bool IsSemestreFinalizado
        {
            get { return isSemestreFinalizado; }
        }

        public Dictionary<string, Disciplina> Disciplinas
        {
            get { return disciplinas; }
            set { disciplinas = value; }
        }

        public void AtribuirNota1(double nota)
        {
            nota1 = nota;
        }

        public void AtribuirNota2(double nota)
        {
            nota2 = nota;
        }

        public void CalcularMedia()
        {
            media = (nota1 + nota2) / 2;
        }

        public void AtribuirFalta()
        {
            faltas++;
        }

        public void AbonarFalta()
        {
            faltas--;
        }

        public string VerificarStatus(string nomeDisciplina)
        {
            return status;
        }
    }
}
