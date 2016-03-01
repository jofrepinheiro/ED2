using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED2_01
{
    class ListaPacientes
    {
        public string entrada = null;
        //o arquivo vai estar na pasta meus documentos
        public static String caminhoArquivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//ListaPacientes.txt";
        public static String[] cabecalho = { "Nome \t Matricula \t TipoSanguineo \t Genero \t Orgao" };
 
        static void Main(string[] args)
        {
            string entrada;
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("==================== MENU PRINCIPAL =========================");
                Console.WriteLine("Comandos: '1- limpar arquivo', '2- cadastrar', '3- convocar', '4- sair'");
                entrada = Console.ReadLine();

                switch(entrada){
                    case "1": inicializar();
                        break;
                    case "2": cadastrarPaciente();
                        break;
                    case "3":
                        convocarPaciente();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default: break;
                }
            }
        }

        private static void cadastrarPaciente()
        {
            ListaPacientes lista = new ListaPacientes();
            Paciente paciente = new Paciente();
            List<string> listaDeLinhas = new List<string>();

            while (true)
            {
                
                Console.WriteLine("Digite 'voltar' para voltar ao menu principal");
                Console.WriteLine("Ou insira o nome do(a) próximo(a) paciente");
                lista.entrada = Console.ReadLine();
                paciente.Nome = lista.entrada;
                if (lista.entrada == "voltar") break;

                Console.WriteLine("Insira a matrícula do SUS dele(a)");
                lista.entrada = Console.ReadLine();
                paciente.Matricula = lista.entrada;
                if (lista.entrada == "voltar") break;


                Console.WriteLine("Insira o tipo sanguineo dele(a)");
                lista.entrada = Console.ReadLine();
                paciente.TipoSanguineo = lista.entrada;
                if (lista.entrada == "voltar") break;


                Console.WriteLine("Insira o genero dele(a)");
                lista.entrada = Console.ReadLine();
                paciente.Genero = lista.entrada[0];
                if (lista.entrada == "voltar") break;

                Console.WriteLine("Insira o orgao desejado");
                lista.entrada = Console.ReadLine();
                paciente.Orgao = lista.entrada;
                if (lista.entrada == "voltar") break;

                listaDeLinhas.Add(paciente.Nome + "\t" + paciente.Matricula + "\t" + paciente.TipoSanguineo + "\t" + paciente.Genero + "\t" + paciente.Orgao);
            }

            string[] arrayDeLinhas = listaDeLinhas.ToArray();
            File.AppendAllLines(caminhoArquivo, arrayDeLinhas);
            Console.WriteLine("Pacientes cadastrados com sucesso! Voltando ao menu...");
        }

        private static void convocarPaciente() {
            string[] arrayArquivo = File.ReadAllLines(caminhoArquivo);
            List<string> listaArquivo = arrayArquivo.ToList();
            listaArquivo.RemoveAt(1);
            arrayArquivo = listaArquivo.ToArray();
            File.WriteAllLines(caminhoArquivo, arrayArquivo);
            Console.WriteLine("Paciente removido com sucesso! Voltando ao menu...");
        }


        private static void inicializar()
        {
            File.WriteAllLines(caminhoArquivo, cabecalho);
            Console.WriteLine("Arquivo inicializado com sucesso! Abrindo menu...");
        }

        public static void imprimir()
        {
            //fazer
        }
    }
}
