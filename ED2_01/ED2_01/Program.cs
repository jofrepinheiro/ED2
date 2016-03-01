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
                Console.WriteLine("Comandos: '1': Limpeza de Arquivo, '2': Cadastro, '3': Convocação, '4': Consulta, '5': Impressao, '6': Sair");
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
                        consultaPaciente();
                        break;
                    case "5":
                        imprimir();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default: break;
                }
            }
        }

        public static void cadastrarPaciente()
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

        public static void convocarPaciente() {
            Console.WriteLine("Digite o orgao a ser doado");
            String orgao = Console.ReadLine();

            System.IO.StreamReader file = new System.IO.StreamReader(caminhoArquivo);

            String[] arrayArquivo = File.ReadAllLines(caminhoArquivo);
            int numberLines = arrayArquivo.Length;

            for (int i = 0; i < numberLines; i++)
            {
                if (file.ReadLine().Contains(orgao)) {
                    List<string> listaArquivo = arrayArquivo.ToList();
                    listaArquivo.RemoveAt(i);
                    arrayArquivo = listaArquivo.ToArray();
                    break;
                }
            }
            file.Close();
            File.WriteAllLines(caminhoArquivo, arrayArquivo);
            Console.WriteLine("Paciente removido com sucesso! Voltando ao menu...");
        }


        public static void inicializar()
        {
            File.WriteAllLines(caminhoArquivo, cabecalho);
            Console.WriteLine("Arquivo inicializado com sucesso! Abrindo menu...");
        }

        public static void consultaPaciente(){
            Console.WriteLine("Por favor, insira o numero de matricula do paciente desejado");
            String matricula = Console.ReadLine();

            System.IO.StreamReader file = new System.IO.StreamReader(caminhoArquivo);

            String line;

            while ((line = file.ReadLine()) != null) {
                if (line.Contains(matricula)) {
                    String[] dados = line.Split('\t');
                    Console.WriteLine("Nome:"+dados[0]+"\nMatricula: "+dados[1]+"\nTipo: "+dados[2]+"\nGenero: "+dados[3]+"\nOrgao: "+dados[4]);
                    break;
                }
            }
            file.Close();
        }

        public static void imprimir()
        {
            Console.WriteLine("Digite a quantidade de pacientes a serem impressos.");
            System.IO.StreamReader file = new System.IO.StreamReader(caminhoArquivo);
            int numeroLinhas = Int16.Parse(Console.ReadLine());
            file.ReadLine();
            for (int i = 0; i < numeroLinhas; i++)
            {
                String line = file.ReadLine();
                if (line == null)
                {
                    break;
                }
                String[] dados = line.Split('\t');
                Console.WriteLine("Nome:" + dados[0] + "\nMatricula: " + dados[1] + "\nTipo: " + dados[2] + "\nGenero: " + dados[3] + "\nOrgao: " + dados[4]);
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                
            }
            file.Close();
        }
    }
}
