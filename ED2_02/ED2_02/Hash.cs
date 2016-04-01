using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED2_02
{
    class Hash
    {
        //Variável de nome do arquivo da tabela Hash
        private String hashName;

        /*
        O ideal seria colocar um número primo de mais de 11 dígitos(para ficar maior que o cpf) para evitar colisões, 
        mas é só um exemplo e disperdiçaria muito espaço de armazenamento 
        */
        private long primeNumber = 53;

        private String[] hashTable;

        public Hash(String filePath)
        {
            String fileName = filePath.Split('.')[0];
            hashName = fileName + ".hashTable";
            createHashTable(hashName);
        }

        public Hash()
        {
            //Apenas para instância de objeto
        }

        public String[] HashTable { get { return hashTable; } }

        //Getter para o numero primo
        public int PrimeNumber { get { return Convert.ToInt32(primeNumber); } }

        //Calcula o índice na Hash de acordo com o índice do arquivo passado
        public int calculateHashIndex(String cpf)
        {
            try
            {
                long id = Convert.ToInt64(cpf);
                return Convert.ToInt32(id % primeNumber);
            }
            catch (Exception ex)
            {
                throw new InvalidCastException("A string não é um número.", ex);
            }
        }


        //Cria a tabela Hashr
        public void createHashTable(String hashName)
        {
            //Inicializa todos os campos com -
            hashTable = new String[PrimeNumber];
            for (int i = 0; i < PrimeNumber; i++)
            {
                hashTable[i] = "-";
            }
            System.IO.File.WriteAllLines(hashName, hashTable);
        }


        /* 
        Adiciona um novo endereço à tabela Hash
        Método de tratamento de Colisões: Encadeamento de Excedentes
        Quando houver colisões, adiciona "do lado" dos que já existem    
        */
        internal bool exists(string cpf, int hashIndex)
        {
            if (hashTable[hashIndex] == "-" || !(hashTable[hashIndex].Contains(cpf)))
            {
                return false;
            }
            return true;
        }

        internal bool isAvailable(int hashIndex)
        {
            throw new NotImplementedException();
        }

        internal void insertToHash(string cpf, int hashIndex, int address)
        {
            //Confere se o espaço tá vazio, se não está, concatena usando o separador >>>
            if (hashTable[hashIndex] == "-")
            {
                hashTable[hashIndex] = cpf + "\t" + (address + 1).ToString();
            }
            else {
                hashTable[hashIndex] += ">>>" + cpf + "\t" + (address + 1).ToString();
            }
            System.IO.File.WriteAllLines(hashName, hashTable);
        }
    }
}
