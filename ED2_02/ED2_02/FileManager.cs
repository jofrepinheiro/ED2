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
        private Hash hash;

        public FileManager(String filePath)
        {
            this.filePath = filePath;
            System.IO.File.WriteAllText(filePath, "");
            header();
            hash = new Hash(filePath);
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

            //Calcula o index por CPF
            int hashIndex = hash.calculateHashIndex(cpf);

            //Evita duplicatas
            if (!hash.exists(cpf, hashIndex))
            {
                //Calcula o endereço do novo usuário e adiciona ao arquivo
                int address = (System.IO.File.ReadLines(filePath).Count()) - 1;

                System.IO.File.AppendAllText(filePath, cpf + "\t" + password + "\t" + nome + "\t" + sobrenome + "\t" + "1\n");

                //Insere na Hash
                hash.insertToHash(cpf, hashIndex, address);
            }
            //String[] temp = System.IO.File.ReadAllLines(filePath);
            //temp[hashIndex + 1] = cpf + "\t" + password + "\t" + nome + "\t" + sobrenome + "\t" + "1";

            //System.IO.File.WriteAllLines(filePath, temp);
        }

        internal String listUsers()
        {
            String result = "";

            String[] temp = System.IO.File.ReadAllLines(filePath);

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] != "-") result += i + ": " + temp[i] + "\n";
            }

            return result;
        }

        internal void checkPassword(string cpf, string senha)
        {
            int hashIndex = hash.calculateHashIndex(cpf);

            if (!hash.exists(cpf, hashIndex))
            {
                Console.WriteLine("Usuário não existe.");
            }
            else {
                String data = hash.HashTable[hashIndex];

                String[] temp = System.IO.File.ReadAllLines(filePath);
                int index = -1;

                if (!(data.Contains(">"))){ 
                    index = Convert.ToInt32(data.Split('\t')[1]);
                }
                else {
                    String[] elements = data.Split('>');
                    foreach (String element in elements)
                    {
                        index = Convert.ToInt32(element.Split('\t')[1]);
                    }
                }
                if (temp[index].Contains(senha))
                {
                    Console.WriteLine("Senha confirmada.");
                }
                else {
                    Console.WriteLine("Senha Incorreta.");
                }

            }
        }


        public String lookUpUser(String cpf)
        {
            //Calcula o index por CPF
            int hashIndex = hash.calculateHashIndex(cpf);
            return hash.HashTable[hashIndex];
        }

        internal void removeUser(string cpf, string senha)
        {
            String hashTableField = lookUpUser(cpf);
            if (hashTableField == "-")
            {
                Console.WriteLine("Usuário não existe.");
            }
            else {
                String[] temp = System.IO.File.ReadAllLines(filePath);

                //Se contém mais de um usuário
                if (hashTableField.Contains(">"))
                {
                    foreach (String element in hashTableField.Split('>'))
                    {
                        String fileKey = element.Split('\t')[0];
                        int fileAddress = Convert.ToInt32(element.Split('\t')[1]);

                        if (fileKey == (cpf))
                        {
                            hashTableField = element;
                            hash.remove(cpf);

                            temp[fileAddress] = temp[fileAddress].Remove(temp[fileAddress].Length - 1, 1) + "0";
                        }
                    }
                }
                else {
                    int fileAddress = Convert.ToInt32(hashTableField.Split('\t')[1]);
                    hash.remove(cpf);
                    temp[fileAddress] = temp[fileAddress].Remove(temp[fileAddress].Length - 1, 1) + "0";
                }

                //Substitui o Arquivo com o temp
                System.IO.File.WriteAllLines(filePath, temp);


            }
        }
    }
}
