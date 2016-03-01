using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED2_01
{
    class Paciente
    {
        private String nome;
        private String matricula;
        private String tipoSanguineo;
        private String orgao;
        private char genero;


        public String Nome{
            get
            {
                return nome;
            }
            set
            {
                nome = value;
            }
        }

        public String Matricula {
            get {
                return matricula;
            }
            set {
                matricula = value;
            }
        }

        public String TipoSanguineo
        {
            get
            {
                return tipoSanguineo;
            }
            set
            {
                tipoSanguineo = value;
            }
        }

        public char Genero
        {
            get
            {
                return genero;
            }
            set
            {
                genero = value;
            }
        }

        public String Orgao
        {
            get
            {
                return orgao;
            }
            set
            {
                orgao = value;
            }
        }

    }
}
