using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GasingSimulator
{
    public class Ponte
    {
        static SemaphoreSlim PonteLevatoio {  get; set; }
        public static List<string> Macchine{ get; set; }
        public Ponte()
        {
            Macchine = new List<string>();
            PonteLevatoio = new SemaphoreSlim(4);
        }

        public void AggiungiMacchina()
        {
            Macchine.Add($"Macchina {Macchine.Count}");
        }

        static async Task PassaMacchina(string macchina)
        {
            string[] animazioni;
            await PonteLevatoio.WaitAsync();
            try
            {
                animazioni = Attraversamento(macchina);
                for (int i = 0; i < 4; i++)
                {

                    Console.WriteLine(animazioni[i]);
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                Console.WriteLine($"{macchina} ha finito di attraversare il ponte...");
            }
            finally
            {
                PonteLevatoio.Release();
            }
        }

        public static async Task AttraversanoMacchine()
        {
            Task[] tasks = new Task[Macchine.Count];
            for (int i = 0; i < Macchine.Count; i++)
            {
                tasks[i] = PassaMacchina(Macchine[i]);
            }

            await Task.WhenAll(tasks);
            Console.WriteLine("Tutte le macchine hanno attraversato");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Le seguenti macchine sono in coda");
            foreach (string macchina in Macchine) 
            {
                sb.AppendLine(macchina.ToString());
            }
            return sb.ToString();
        }

        public static string[] Attraversamento(string macchina)
        {
            string[] figure = new string[4];
            figure[0]= "==============================================\n" + 
                       $" {macchina}                                   \n" +
                       "==============================================";
            figure[1] = "==============================================\n" +
                       $"           {macchina}                          \n" +
                       "==============================================";
            figure[2] = "==============================================\n" +
                       $"                     {macchina}                \n" +
                       "==============================================";
            figure[3] = "==============================================\n" +
                       $"                              {macchina}       \n" +
                       "==============================================";
            return figure;
        }

    }
}
