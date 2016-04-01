using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED2_02
{
    class FileManager
    {

        private String filePath;
        private String fileContent;
        

        public FileManager(String filePath)
        {
            this.filePath = filePath;
            header();
            Hash hash = new Hash(filePath);
        }

        public String Content
        {
            get
            {
                fileContent = System.IO.File.ReadAllText(filePath);
                return fileContent;
            }
        }

        private void writeToFile(String fileContent)
        {
            backup();
            System.IO.File.WriteAllText(filePath, fileContent);
        }

        private void appendToFile(String content)
        {
            backup();
            System.IO.File.AppendAllText(filePath, content);
        }

        private void backup()
        {
            String backupPath = filePath + ".backup";
            System.IO.File.WriteAllText(backupPath, System.IO.File.ReadAllText(filePath));
        }

        public void header()
        {
            String headerContent = "CPF\tSenha\tNome\tSobrenome\tAtivo\n";
            System.IO.File.WriteAllText(filePath, headerContent);
        }

        public void addUser(String cpf, String password, String nome, String sobrenome)
        {
            String text = System.IO.File.ReadAllText(filePath);
            bool existsInFile = text.Contains(cpf);

            //Checa se o usuário já existe
            if (existsInFile) Console.WriteLine("Usuário já existente.");
            //Se nao existe, concatena o usuario no arquivo e coloca como ativo
            else appendToFile(cpf + "\t" + password + "\t" + nome + "\t" + sobrenome + "\t" + "1" + "\n");
        }
    }
}
