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
        public static string caminhoArquivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//ListaPacientes.txt";
        public static String[] cabecalho = { " " };

        public class Paciente
        {
            public String nome;
            public String tipoSanguineo;
        }

       
        static void Main(string[] args)
        {
            string entrada;
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("==================== MENU PRINCIPAL =========================");
                Console.WriteLine("Comandos: 'limpar arquivo', 'cadastrar', 'convocar', 'sair'");
                entrada = Console.ReadLine();

                if (entrada == "limpar arquivo") inicializar();
                if (entrada == "cadastrar") cadastrarPaciente();
                if (entrada == "convocar") convocarPaciente();
                if (entrada == "sair") break;
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
                paciente.nome = lista.entrada;
                if (lista.entrada == "voltar") break;

                Console.WriteLine("Insira o tipo sanguineo dele(a)");
                lista.entrada = Console.ReadLine();
                paciente.tipoSanguineo = lista.entrada;
                if (lista.entrada == "voltar") break;

                listaDeLinhas.Add(paciente.nome + "            " + paciente.tipoSanguineo);
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
