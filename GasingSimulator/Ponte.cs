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
        public static List<string> MacchineSx{ get; set; } // TODO: dx e sx
        public static List<string> MacchineDx { get; set; }
        public int NrMacchine {  get; set; }
        public Ponte()
        {
            MacchineSx = new List<string>();
            MacchineDx = new List<string>();
            PonteLevatoio = new SemaphoreSlim(4);
            NrMacchine = 0;
        }

        public void AggiungiMacchinaSx()
        {
            MacchineSx.Add($"Macchina {NrMacchine++}");
        }

        public void AggiungiMacchinaDx()
        {
            MacchineDx.Add($"Macchina {NrMacchine++}");
        }

        static async Task PassaMacchinaSxDx(string macchina, int index)//TODO PassaMacchinaDxSx e PassaMacchinaSxDx
        {
            await PonteLevatoio.WaitAsync();
            try
            {
                Console.SetCursorPosition(0, index % 4 * 4);
                AttraversamentoSxDx(macchina);
            }
            finally
            {
                PonteLevatoio.Release();
            }
        }

        static async Task PassaMacchinaDxSx(string macchina, int index)//TODO PassaMacchinaDxSx e PassaMacchinaSxDx
        {
            await PonteLevatoio.WaitAsync();
            try
            {
                Console.SetCursorPosition(0, index % 4 * 4);
                AttraversamentoDxSx(macchina);
            }
            finally
            {
                PonteLevatoio.Release();
            }
        }

        public static async Task AttraversanoMacchine()
        {
            Task[] tasks1 = new Task[MacchineSx.Count];
            for (int i = 0; i < MacchineSx.Count; i++)
            {
                tasks1[i] = PassaMacchinaSxDx(MacchineSx[i], i);

            }
            await Task.WhenAll(tasks1);
            Task[] tasks2 = new Task[MacchineDx.Count];
            for (int i = 0; i < MacchineDx.Count; i++)
            {
                tasks2[i] = PassaMacchinaDxSx(MacchineSx[i], i);

            }
            await Task.WhenAll(tasks2);

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
            sb.AppendLine("Le seguenti macchine sono in coda a sinistra");
            foreach (string macchina in MacchineSx) 
            {
                sb.AppendLine(macchina.ToString());
            }
            StringBuilder sb2 = new StringBuilder();
            sb.AppendLine("Le seguenti macchine sono in coda a destra");
            foreach (string macchina in MacchineDx)
            {
                sb2.AppendLine(macchina.ToString());
            }
            return sb.ToString() + sb2.ToString();
        }

        public static void AttraversamentoSxDx(string macchina)
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
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("==============================================\n" +
                       $"                                     {macchina}\n" +
                       "==============================================");
        }

        public static void AttraversamentoDxSx(string macchina)
        {
            // TODO Gestire l'animazione dell'attraversamento con il SetCursor Position
            Console.WriteLine("==============================================\n" +
                       $"                                     {macchina}\n" +
                       "==============================================");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("==============================================\n" +
                       $"                              {macchina}       \n" +
                       "==============================================");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("==============================================\n" +
                       $"                     {macchina}                \n" +
                       "==============================================");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("==============================================\n" +
                       $"           {macchina}                          \n" +
                       "==============================================");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("==============================================\n" +
                       $" {macchina}                                   \n" +
                       "==============================================");
        }

    }
}
