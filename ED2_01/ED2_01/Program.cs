using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
       Rascunho da estrutura do Arquivo:
       #  TIPO_SANGUINEO   PRIMEIRA_POSIÇÃO    ULTIMO_INSERIDO
       1. "Tipo A",null,null          
       2. "Tipo B",7,10
       3. "Tipo AB",6,11
       4. "Tipo O",null,null       
       # NOME_PACIENTE    TIPO_SANGUINEO  PROXIMA_POSIÇÃO
       6. "Fulano de Tal"  AB              8
       7. "Cicrano"        B               9
       8. "Ronaldo"        AB              11
       9. "Rivaldo"        B               10
       10. "Gaucho"        B               null
       11. "Roberto"       AB              null      
*/

namespace ED2_01
{
    class Program
    {
        public static string caminhoArquivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//ListaPacientes.txt";
        public static String[] cabecalho = { "Tipo A,null,null",
                                    "Tipo B,null,null",
                                    "Tipo AB,null,null",
                                    "Tipo O,null,null" };

        public class Paciente
        {
            public String nome;
            public String tipoSanguineo;
            public int proximo;
        }

       
        static void Main(string[] args)
        {
            Paciente paciente = new Paciente();
            inicializar();
            //TERMINAR!!!
        }

        private static void inicializar()
        {
            System.IO.File.WriteAllLines(caminhoArquivo, cabecalho);
        }
    }
}
