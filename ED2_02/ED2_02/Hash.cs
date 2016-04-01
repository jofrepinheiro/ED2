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


        public Hash(String filePath)
        {
            String fileName = filePath.Split('.')[0];
            hashName = fileName + ".hashTable";
            createHashTable(hashName);
        }


        //Calcula o índice na Hash de acordo com o índice do arquivo passado
        public int calculateHashIndex(String cpf)
        {
            try
            {
                long id = Convert.ToInt32(cpf);
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
            System.IO.File.WriteAllText(hashName, "");

        }


        /* 
        Adiciona um novo endereço à tabela Hash
        Método de tratamento de Colisões: Encadeamento de Excedentes
        Quando houver colisões, adiciona "do lado" dos que já existem    
        */
        public void addToHT(String cpf)
        {
            int hashIndex = calculateHashIndex(cpf);
        }

    }
}
