namespace GasingSimulator
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.Clear();
            Ponte ViadottoKennedy = new Ponte();
            string scelta = "";

            while (scelta != "E")
            {
                RedrawMenu();
                scelta = Console.ReadLine().ToUpper();

                switch (scelta)
                {
                    case "L":
                        ViadottoKennedy.AggiungiMacchinaSx();
                        break;
                    case "R":
                        ViadottoKennedy.AggiungiMacchinaDx();
                        break;
                    case "P":
                        await Ponte.AttraversanoMacchine();
                        break;
                }
            }
        }

        private static void RedrawMenu()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("=== Sistema di Attraversamento ===");
            Console.WriteLine("L. Aggiungi macchina a sinistra");
            Console.WriteLine("R. Aggiungi macchina a destra");
            Console.WriteLine("P. Avvia passaggio auto");
            Console.WriteLine("E. Esci");
            Console.WriteLine($"In coda: Sx={Ponte.MacchineSx.Count} Dx={Ponte.MacchineDx.Count}");
            Console.Write("Scelta: ");
        }
    }
}
