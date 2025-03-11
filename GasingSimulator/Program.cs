namespace GasingSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ponte ViadottoKennedy = new Ponte();
            int scelta = 0;
            while(scelta != 3)
            {
                Console.WriteLine("Benvenuto nel sistema di attraversamento macchine di Samuele Snabl");
                Console.WriteLine("Scegli un opzione:");
                Console.WriteLine("1. Aggiungi una macchina");
                Console.WriteLine("2. Fai partire il ponte");
                Console.WriteLine("3. Esci");
                scelta = int.Parse(Console.ReadLine());
                switch (scelta) 
                {
                    case 1:
                        ViadottoKennedy.AggiungiMacchina();
                        Console.WriteLine(ViadottoKennedy.ToString());
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(ViadottoKennedy.ToString());
                        Console.WriteLine(Ponte.AttraversanoMacchine());
                        scelta = 3;
                        break;
                    case 3:
                        break;

                }
            }
        }
    }
}
