using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Text;

namespace BuscaTextoPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            if(ProcuraPalavra("", @""))
            {
                Console.WriteLine("'Tem");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Nao tem");
            }

        }
        public static bool ProcuraPalavra(string busca, string local)
        {
            PdfReader reader = new PdfReader(local);
            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                string[] linhas = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy()).Split('\n');
                for (int j = 0; j < linhas.Length; j++)
                {
                    if (Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(linhas[j])).Contains(busca))
                        return true;                        
                }
            }
            return false;
        }
    }
}
