using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED2_02
{
    class Program
    {
        static void Main(string[] args)
        {
            FileManager file = new FileManager("arquivoTeste.txt");
            Console.WriteLine("Bem-vindo ao gerenciador de senhas 2016.");
            while (true)
            {
                Console.WriteLine("Digite o número correspondente à operação que deseja realizar.");
                Console.WriteLine("'1': Inserir novo usuário. -- '2': Checar senha de usuário. -- '3': Listar Usuários -- '4': Remover Usuário -- '5': Sair");
                String opCode = Console.ReadLine();
                Console.Write("Operação escolhida: " + opCode);

                switch (opCode)
                {
                    case "1":
                        Console.WriteLine("- Inserir Usuário");

                        Console.Write("CPF: ");
                        String cpf = Console.ReadLine();

                        Console.Write("Senha: ");
                        String senha = Console.ReadLine();

                        Console.Write("Nome: ");
                        String nome = Console.ReadLine();

                        Console.Write("Sobrenome: ");
                        String sobrenome = Console.ReadLine();

                        file.addUser(cpf, senha, nome, sobrenome);
                        break;

                    case "2":
                        Console.WriteLine("- Checar Senha");

                        Console.Write("CPF: ");
                        String cpf2 = Console.ReadLine();

                        Console.Write("Senha: ");
                        String senha2 = Console.ReadLine();

                        file.checkPassword(cpf2, senha2);

                        break;
                    case "3":
                        Console.WriteLine("- Listar Usuários");
                        Console.WriteLine(file.listUsers());

                        break;
                    case "4":
                        Console.WriteLine("- Remover Usuário");

                        Console.Write("CPF do usuário: ");
                        String cpf3 = Console.ReadLine();

                        Console.Write("Por favor, digite a senha: ");
                        String senha3 = Console.ReadLine();

                        file.removeUser(cpf3, senha3);

                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(": Inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}
