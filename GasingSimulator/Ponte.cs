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
        public static List<string> Macchine{ get; set; } // TODO: dx e sx
        public Ponte()
        {
            Macchine = new List<string>();
            PonteLevatoio = new SemaphoreSlim(4);
        }

        public void AggiungiMacchina()
        {
            Macchine.Add($"Macchina {Macchine.Count}");
        }

        static async Task PassaMacchina(string macchina)//TODO PassaMacchinaDxSx e PassaMacchinaSxDx
        {
            await PonteLevatoio.WaitAsync();
            try
            {
                Attraversamento(macchina);
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


        //public static async Task AttraversanoMacchine() 2 (Perplexity)
        //{
        //    Task[] tasks = new Task[Macchine.Count];
        //    for (int i = 0; i < Macchine.Count; i++)
        //    {
        //        tasks[i] = PassaMacchina(Macchine[i]);
        //    }

        //    await Task.WhenAll(tasks);
        //    Console.WriteLine("Tutte le macchine hanno attraversato");
        //}

        //private static async Task PassaMacchina(string macchina) Perplexity
        //{
        //    await PonteLevatoio.WaitAsync();
        //    try
        //    {
        //        string[] animazioni = Attraversamento(macchina);
        //        for (int i = 0; i < animazioni.Length; i++)
        //        {
        //            Console.WriteLine(animazioni[i]);
        //            Thread.Sleep(1000); // Simula il tempo di attraversamento
        //        }
        //        Console.Clear();
        //        Console.WriteLine($"{macchina} ha finito di attraversare il ponte...");
        //    }
        //    finally
        //    {
        //        PonteLevatoio.Release();
        //    }
        //}

        //private static async Task PassaMacchina(string macchina) 2 (Perplexity)
        //{
        //    await PonteLevatoio.WaitAsync();
        //    try
        //    {
        //        string[] animazioni = Attraversamento(macchina);
        //        for (int i = 0; i < animazioni.Length; i++)
        //        {
        //            lock (Console.Out) // Per evitare conflitti tra thread
        //            {
        //                Console.SetCursorPosition(0, i); // Posiziona il cursore per mantenere le linee ordinate
        //                Console.WriteLine(animazioni[i]);
        //            }
        //            Thread.Sleep(1000);
        //        }
        //        Console.WriteLine($"{macchina} ha finito di attraversare il ponte...");
        //    }
        //    finally
        //    {
        //        PonteLevatoio.Release();
        //    }
        //}





        //////////private static async Task PassaMacchina(string macchina, int posizione)
        //////////{
        //////////    await PonteLevatoio.WaitAsync();
        //////////    try
        //////////    {
        //////////        string[] animazioni = Attraversamento(macchina);
        //////////        for (int i = 0; i < animazioni.Length; i++)
        //////////        {
        //////////            lock (Console.Out) // Sincronizza l'accesso alla console
        //////////            {
        //////////                Console.SetCursorPosition(0, posizione); // Posiziona il cursore sulla riga corrispondente alla macchina
        //////////                Console.WriteLine(animazioni[i].PadRight(Console.WindowWidth)); // Scrivi l'animazione
        //////////            }
        //////////            Thread.Sleep(1000); // Simula il tempo di attraversamento
        //////////        }
        //////////        lock (Console.Out)
        //////////        {
        //////////            Console.SetCursorPosition(0, posizione);
        //////////            Console.WriteLine($"{macchina} ha finito di attraversare il ponte...".PadRight(Console.WindowWidth));
        //////////        }
        //////////    }
        //////////    finally
        //////////    {
        //////////        PonteLevatoio.Release();
        //////////    }
        //////////}

        //////////public static async Task AttraversanoMacchine()
        //////////{
        //////////    Task[] tasks = new Task[Macchine.Count];
        //////////    for (int i = 0; i < Macchine.Count; i++)
        //////////    {
        //////////        int posizione = i * 2; // Ogni macchina avrà una riga separata (spaziata di 2 righe)
        //////////        tasks[i] = PassaMacchina(Macchine[i], posizione);
        //////////    }

        //////////    await Task.WhenAll(tasks);
        //////////    Console.WriteLine("Tutte le macchine hanno attraversato");
        //////////}







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

        public static void Attraversamento(string macchina)
        {
            // TODO Gestire l'animazione dell'attraversamento con il SetCursor Position
            Console.WriteLine("==============================================\n" +
                       $" {macchina}                                   \n" +
                       "==============================================");
            Thread.Sleep(1000);
            Console.Clear(); 
            Console.WriteLine("==============================================\n" +
                       $"           {macchina}                          \n" +
                       "==============================================");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("==============================================\n" +
                       $"                     {macchina}                \n" +
                       "==============================================");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("==============================================\n" +
                       $"                              {macchina}       \n" +
                       "==============================================");
        }

    }
}
