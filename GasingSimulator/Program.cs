namespace GasingSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ponte ViadottoKennedy = new Ponte();
            string scelta = "";
            while(scelta != "E")
            {
                Console.WriteLine("Benvenuto nel sistema di attraversamento macchine di Samuele Snabl");
                Console.WriteLine("Scegli un opzione:");
                Console.WriteLine("L. Aggiungi una macchina a sinistra");
                Console.WriteLine("R. Aggiungi una macchina a destra");
                Console.WriteLine("P. Avvia il passaggio delle auto");
                Console.WriteLine("E. Esci");
                scelta = Console.ReadLine().ToUpper();
                switch (scelta) 
                {
                    case "L":
                        ViadottoKennedy.AggiungiMacchinaSx();
                        Console.WriteLine(ViadottoKennedy.ToString());
                        break;
                    case "R":
                        ViadottoKennedy.AggiungiMacchinaDx();
                        Console.WriteLine(ViadottoKennedy.ToString());
                        break;
                    case "P":
                        Ponte.AttraversanoMacchine();
                        break;
                    
                }
            }
        }
    }
}
