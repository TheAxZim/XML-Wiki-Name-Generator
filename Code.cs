using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Linq;

// Author: Azeem Ilyas
//  Title: WIKIPEDIA DICTIONARY GENERATOR
// Descr.: Parses the Wikipedia articles xml file and generates a dictionary from the titles of the articles. 

namespace WikiXML
{
    class Program
    {
        const string filename = @"C:\Users\TheAxZim\Desktop\CodeBreaking\CompressedDictionaries\enwiki-20160113-articles.xml";
        static String outFile;

        static void Main(string[] args)
        {

            Console.WriteLine("\n\nScanning Wikipedia Articles, Please Wait...\n\n");

            outFile = args[0];
            String artTitle = "";
            TextWriter tw = new StreamWriter(outFile);
            int artCount = 0;

            // Create an XmlReader
            using (XmlTextReader reader = new XmlTextReader(filename))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element){
                        if ((reader.Name).Equals("title"))
                        {
                            artTitle = reader.ReadElementContentAsString();
                            tw.WriteLine(artTitle);
                            artCount++;
                            if (artCount % 100000 == 0) // Help us keep track of where we are...
                            {
                                Console.WriteLine("Read " + artCount + " Articles...");
                            }
                        }
                    }
                }
            }

            tw.Close();
            Console.WriteLine("\nTotal Articles: " + artCount + "\nComplete... Press Enter to Continue");
            Console.ReadLine();
        }

    }
}
