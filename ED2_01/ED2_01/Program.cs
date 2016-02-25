using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED2_01
{
    class Program
    {
        public static int Main(string[] args)
        {

            
            string entrada = null;
            while (entrada != "exit"){
                Console.WriteLine("Insira os dados do próximo paciente:");
                entrada = Console.ReadLine();
            }
            return 0;
            
        }
    }
}
