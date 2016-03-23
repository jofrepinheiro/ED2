using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED2_02
{
    class FileManager
    {

        String filePath;
        String fileContent;

        public FileManager(String filePath){
            this.filePath = filePath;
        }

        public String File {
            get {
                return fileContent; 
            }

            set {
                //Write to File TBD
                fileContent = value;
                writeToFile(fileContent);
            }
        }

        private void writeToFile(string fileContent)
        {
            System.IO.File.WriteAllText(filePath, fileContent);
        }
    }
}
