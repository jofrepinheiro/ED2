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
       6. "Fulano de Tal",AB,8
       7. "Cicrano",B,9
       8. "Ronaldo",AB,11
       9. "Rivaldo",B,10
       10. "Gaucho",B,null
       11. "Roberto",AB,null      
*/

namespace ED2_01
{
    class ListaPacientes
    {
        public string entrada = null;
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
            inicializar();
            ListaPacientes lista = new ListaPacientes();
            Paciente paciente = new Paciente();
            while (true)
            {
                Console.WriteLine("Insira o nome do(a) próximo(a) paciente");
                lista.entrada = Console.ReadLine();
                paciente.nome = lista.entrada;

                Console.WriteLine("Insira o tipo sanguineo dele(a)");
                lista.entrada = Console.ReadLine();
                paciente.tipoSanguineo = lista.entrada;

                string[] linha = { paciente.nome + "," + paciente.tipoSanguineo };
                File.AppendAllLines(caminhoArquivo, linha);


            }
            


        }

        private static void inicializar()
        {
            File.WriteAllLines(caminhoArquivo, cabecalho);
        }
    }
}
