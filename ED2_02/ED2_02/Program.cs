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

            file.addUser("05394853576", "password", "Jofre", "Pinheiro");
            file.addUser("05394853576", "password", "Jofre", "Pinheiro");


            Console.WriteLine(file.Content);
            
            Console.Read();
        }
    }
}
