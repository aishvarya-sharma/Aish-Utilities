using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var consoleLogger = new ConsoleTraceListener();
                Trace.Listeners.Add(consoleLogger);

                if (args.Count() < 2)
                {
                    printUsage();
                    return;
                }

                PdfMerger.MergePDFs("output.pdf", args);

            }
            catch (Exception e)
            {
                Trace.TraceError(e.Message);
            }
            finally
            {
                Trace.WriteLine("");
                Trace.WriteLine("Thanks for using Pdgmerger.exe");
                Trace.WriteLine("https://github.com/aishvarya-sharma/Aish-Utilities");
            }
        }

        static void printUsage()
        {
            Trace.WriteLine("Merges PDFs locally. PDFs are NOT uploaded to Internet and data remains private.");
            Trace.WriteLine("Usage: Pdfmerge.exe <outputfile.pdf> <file1> <file2> ...");
        }

        static void doFileCheck(IEnumerable<string> files)
        {
            foreach (var file in files)
            {
                if (!File.Exists(file))
                {
                    throw new FileNotFoundException(file);
                }
            }
        }

    }
}
