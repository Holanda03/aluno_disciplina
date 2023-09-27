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
        private static int matricula_default = 0;
        
        private string nome;
        private int matricula;
        private Dictionary<Disciplina, double> nota1;
        private Dictionary<Disciplina, double> nota2;
        private Dictionary<Disciplina, double> media;
        private Dictionary<Disciplina, int> faltas;
        private Dictionary<Disciplina, string> status;
        private bool isSemestreFinalizado;
        private Dictionary<int, Disciplina> disciplinas;

        public Aluno(string nome)
        {
            this.nome = nome;
            matricula = matricula_default++;
            nota1 = new Dictionary<Disciplina, double>();
            nota2 = new Dictionary<Disciplina, double>();
            media = new Dictionary<Disciplina, double>();
            faltas = new Dictionary<Disciplina, int>();
            status = new Dictionary<Disciplina, string>();
            isSemestreFinalizado = false;
            disciplinas = new Dictionary<int, Disciplina>();
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int Matricula
        {
            get { return matricula; }
        }

        public Dictionary<Disciplina, double> Nota1
        {
            get { return nota1; }
        }

        public Dictionary<Disciplina, double> Nota2
        {
            get { return nota2; }
        }

        public Dictionary<Disciplina, double> Media
        {
            get { return media; }
        }

        public Dictionary<Disciplina, int> Faltas
        {
            get { return faltas; }
        }

        public Dictionary<Disciplina, string> Status
        {
            get { return status; }
        }

        public bool IsSemestreFinalizado
        {
            get { return isSemestreFinalizado; }
        }

        public Dictionary<int, Disciplina> Disciplinas
        {
            get { return disciplinas; }
            set { disciplinas = value; }
        }

        public void AtribuirNota1(double nota, int codigoDisciplina)
        {
            if (nota < 0 || nota > 10)
            {
                throw new Exception("A nota não pode ser menor que zero ou maior que 10");
            } else
            {
                if (disciplinas.ContainsKey(codigoDisciplina))
                {
                    Disciplina disciplina = disciplinas[codigoDisciplina];
                    nota1.Add(disciplina, nota);
                    //nota1.Add(disciplinas[codigoDisciplina], nota);
                }
                else
                {
                    throw new Exception("O aluno não está matriculado nessa disciplina.");
                }
            }
        }

        public void AtribuirNota2(double nota, int codigoDisciplina)
        {
            if (nota < 0 || nota > 10)
            {
                throw new Exception("A nota não pode ser menor que zero ou maior que 10");
            }
            else
            {
                if (disciplinas.ContainsKey(codigoDisciplina))
                {
                    Disciplina disciplina = disciplinas[codigoDisciplina];
                    nota2.Add(disciplina, nota);
                    //nota2.Add(disciplinas[codigoDisciplina], nota);
                }
                else
                {
                    throw new Exception("O aluno não está matriculado nessa disciplina.");
                }
            }
        }

        public void CalcularMedia(int codigoDisciplina)
        {
            if (disciplinas.ContainsKey(codigoDisciplina))
            {
                Disciplina disciplina = disciplinas[codigoDisciplina];

                if (nota1.ContainsKey(disciplina) && nota2.ContainsKey(disciplina))
                {
                    double n1 = nota1[disciplina];
                    double n2 = nota2[disciplina];
                    double m = (n1 + n2) / 2;
                    media.Add(disciplina, m);
                } else
                {
                    throw new Exception("Não foi possível calcular a média pois o aluno não possui as duas notas.");
                }
            } else
            {
                throw new Exception("O aluno não está matriculado nessa disciplina.");
            }
        }

        public void AtribuirFalta(int codigoDisciplina)
        {
            if (disciplinas.ContainsKey(codigoDisciplina))
            {
                Disciplina disciplina = disciplinas[codigoDisciplina];

                if (faltas.ContainsKey(disciplina))
                {
                    faltas[disciplina]++;
                } else
                {
                    faltas[disciplina] = 1;
                }
            } else
            {
                throw new Exception("O aluno não está matriculado nessa disciplina.");
            }
        }

        public void AbonarFalta(int codigoDisciplina)
        {
            if (disciplinas.ContainsKey(codigoDisciplina))
            {
                Disciplina disciplina = disciplinas[codigoDisciplina];

                if (faltas.ContainsKey(disciplina))
                {
                    if (faltas[disciplina] == 0)
                    {
                        throw new Exception("O aluno não possui faltas.");
                    } else
                    {
                        faltas[disciplina]--;
                    }
                }
            } else
            {
                throw new Exception("O aluno não está matriculado nessa disciplina.");
            }
        }

        public string VerificarStatus(int codigoDisciplina)
        {
            if (disciplinas.ContainsKey(codigoDisciplina))
            {
                Disciplina disciplina = disciplinas[codigoDisciplina];

                var porcFaltas = faltas[disciplina] / disciplina.CargaHoraria;

                if (media[disciplina] >= 7 && porcFaltas <= 0.25)
                {
                    status[disciplina] = "aprovado";
                    //this.isSemestreFinalizado = true;
                }
                else if (media[disciplina] < 3 || porcFaltas > 0.25)
                {
                    status[disciplina] = "reprovado";
                    //this.isSemestreFinalizado = true;
                }

                var desc = "O aluno " + nome + " está " + status[disciplina];

                return desc;
            } else
            {
                throw new Exception("O aluno não está matriculado nessa disciplina.");
            }
        }
    }
}
