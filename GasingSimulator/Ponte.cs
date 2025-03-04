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
            Console.WriteLine($"{macchina} sta attendendo per passare");
            await PonteLevatoio.WaitAsync();
            try
            {
                Console.WriteLine($"{macchina} sta attraversando il ponte...");
                await Task.Delay(5000);
                Console.WriteLine($"{macchina} ha finito di attraversare il ponte...");

            }
            finally
            {
                PonteLevatoio.Release();
            }
        }

        static async Task AttraversanoMacchine()
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
                
            }
            return sb.ToString();
        }

    }
}
