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
        public static List<string> MacchineSx{ get; set; }
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
                Console.SetCursorPosition(10, index % 4 * 4);
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
                Console.SetCursorPosition(10, index % 4 * 4);
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

        private static void CreateBridge()
        {
            Console.Clear();
            Console.SetCursorPosition(10, 20);
            Console.WriteLine("==============================================\n");
            Console.SetCursorPosition(10, 40);
            Console.WriteLine("==============================================\n");
        }

        public static void AttraversamentoSxDx(string macchina)
        {
            for(int i = 0;i < 100; i+=10)
            {
                CreateBridge();
                Console.SetCursorPosition(10 + i, 30);
                Console.WriteLine(macchina);
                Thread.Sleep(1000);
            }
           

            // TODO Gestire l'animazione dell'attraversamento con il SetCursor Position


            //Console.WriteLine("==============================================\n" +
            //           $" {macchina}                                   \n" +
            //           "==============================================");
            //Thread.Sleep(1000);
            //Console.Clear(); 
            //Console.WriteLine("==============================================\n" +
            //           $"           {macchina}                          \n" +
            //           "==============================================");
            //Thread.Sleep(1000);
            //Console.Clear();
            //Console.WriteLine("==============================================\n" +
            //           $"                     {macchina}                \n" +
            //           "==============================================");
            //Thread.Sleep(1000);
            //Console.Clear();
            //Console.WriteLine("==============================================\n" +
            //           $"                              {macchina}       \n" +
            //           "==============================================");
            //Thread.Sleep(1000);
            //Console.Clear();
            //Console.WriteLine("==============================================\n" +
            //           $"                                     {macchina}\n" +
            //           "==============================================");
        }

        public static void AttraversamentoDxSx(string macchina)
        {
            // TODO Gestire l'animazione dell'attraversamento con il SetCursor Position

           // Console.WriteLine("==============================================\n");

           // Console.WriteLine("==============================================\n");

           // /**/

           //Console.WriteLine("==============================================\n" +
           //            $"                                     {macchina}\n" +
           //            "==============================================");
           // Thread.Sleep(1000);
           // Console.Clear();
           // Console.WriteLine("==============================================\n" +
           //            $"                              {macchina}       \n" +
           //            "==============================================");
           // Thread.Sleep(1000);
           // Console.Clear();
           // Console.WriteLine("==============================================\n" +
           //            $"                     {macchina}                \n" +
           //            "==============================================");
           // Thread.Sleep(1000);
           // Console.Clear();
           // Console.WriteLine("==============================================\n" +
           //            $"           {macchina}                          \n" +
           //            "==============================================");
           // Thread.Sleep(1000);
           // Console.Clear();
           // Console.WriteLine("==============================================\n" +
           //            $" {macchina}                                   \n" +
           //            "==============================================");
        }

    }
}
