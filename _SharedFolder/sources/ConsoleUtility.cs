namespace Utilities.Lib
{

    public static class ConsoleUtility
    {
        public static void Display(string x = "-", int anzahl = 50)
        {
            if ((x == "-") && (anzahl > 0))
            {
                Console.WriteLine();
                for (int i = 0; i < anzahl; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
            }
            else if (!String.IsNullOrEmpty(x))
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine(x);
            }
            else if (String.IsNullOrEmpty(x))
            {
                throw new ArgumentNullException("Sie haben keine Daten eingegeben!");

            }

        }

        public static string Input(string prompt = "")
        {
            if (!String.IsNullOrEmpty(prompt))
            {
                Display(prompt);
                string? eingabe = Console.ReadLine();
                return eingabe;
            }
            else
            {
                Console.ReadKey();
                return "";
            }
        }
    }
}