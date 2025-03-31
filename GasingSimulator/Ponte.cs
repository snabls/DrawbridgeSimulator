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
            CreateBridge();
        }

        public void AggiungiMacchinaSx()
        {
            MacchineSx.Add($"Macchina {NrMacchine++}");
        }

        public void AggiungiMacchinaDx()
        {
            MacchineDx.Add($"Macchina {NrMacchine++}");
        }

        static async Task PassaMacchinaSxDx(string macchina, int index)
        {
            await PonteLevatoio.WaitAsync();
            try
            {
                int corsia = index % 4;
                await AttraversamentoSxDx(macchina, corsia);
            }
            finally
            {
                PonteLevatoio.Release();
            }
        }

        static async Task PassaMacchinaDxSx(string macchina, int index)
        {
            await PonteLevatoio.WaitAsync();
            try
            {
                int corsia = index % 4;
                await AttraversamentoDxSx(macchina, corsia);
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
                tasks2[i] = PassaMacchinaDxSx(MacchineDx[i], i);

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
            sb.AppendLine("Le seguenti macchine sono in coda a destra");
            foreach (string macchina in MacchineDx)
            {
                sb.AppendLine(macchina.ToString());
            }
            return sb.ToString();
        }

        private static void CreateBridge()
        {
            Console.SetCursorPosition(0, 8);
            Console.WriteLine(new string('=', Console.WindowWidth) + "\n");

            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(10, 10 + i * 2);
                Console.WriteLine(new string('-', 40));
            }

            Console.SetCursorPosition(0, 0);
        }


        public static async Task AttraversamentoSxDx(string macchina, int corsia)
        {
            int startX = 12;
            int y = 8 + 1 + corsia * 2;

            for (int i = 0; i < 30; i += 5)
            {
                lock (Console.Out)
                {
                    Console.SetCursorPosition(startX + i, y);
                    Console.Write(macchina);
                }
                await Task.Delay(500);
                lock (Console.Out)
                {
                    Console.SetCursorPosition(startX + i, y);
                    Console.Write(new string(' ', macchina.Length));
                }
            }
        }

        public static async Task AttraversamentoDxSx(string macchina, int corsia)
        {
            int startX = 40;
            int y = 8 + 1 + corsia * 2;

            for (int i = 0; i < 30; i += 5)
            {
                lock (Console.Out)
                {
                    Console.SetCursorPosition(startX - i, y);
                    Console.Write(macchina);
                }
                await Task.Delay(500);
                lock (Console.Out)
                {
                    Console.SetCursorPosition(startX - i, y);
                    Console.Write(new string(' ', macchina.Length));
                }
            }
        }



    }
}
