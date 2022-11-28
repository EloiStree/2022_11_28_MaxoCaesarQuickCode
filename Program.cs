class TestClass
{
    static void Main(string[] args)
    {

        while (true) {

            Console.WriteLine("Text>Cesar TC || Cesar>Text CT ?");
            string switchOption = Console.ReadLine();
            if (switchOption.ToLower() == "tc")
            {

                Console.WriteLine("Enter number of decalage:");
                string decalage = Console.ReadLine();
                Console.WriteLine("Enter phrase you want:");
                string phrase = Console.ReadLine();
                Console.WriteLine("Result:");
                Console.WriteLine("In:" + phrase);
                int.TryParse(decalage, out int decalageInt);
                Console.WriteLine("Out:" + Encipher(phrase, decalageInt));
            }
            if (switchOption.ToLower() == "ct")
            {

                Console.WriteLine("Enter number of decalage:");
                string decalage = Console.ReadLine();
                Console.WriteLine("Enter cesar text you want:");
                string phrase = Console.ReadLine();
                Console.WriteLine("Result:");
                Console.WriteLine("In:" + phrase);
                int.TryParse(decalage, out int decalageInt);
                Console.WriteLine("Out:" + Decipher(phrase, decalageInt));
            }
        }


    }
    public static char cipher(char ch, int key)
    {
        if (!char.IsLetter(ch))
        {

            return ch;
        }

        char d = char.IsUpper(ch) ? 'A' : 'a';
        return (char)((((ch + key) - d) % 26) + d);


    }


    public static string Encipher(string input, int key)
    {
        string output = string.Empty;

        foreach (char ch in input)
            output += cipher(ch, key);

        return output;
    }

    public static string Decipher(string input, int key)
    {
        return Encipher(input, 26 - key);
    }

    public static string Cesar(string mot, int decalage)
    {
        Func<int, int, int> mod = (val, m) => val % m + (val < 0 ? m : 0);

        Func<char, char, int, char> decal =
            (c, offset, m) => (char)(offset + mod(c - offset + decalage, m));

        Func<char, char> cesar =
         c => ('a' <= c && c <= 'z') ? decal(c, 'a', 26)
            : ('A' <= c && c <= 'Z') ? decal(c, 'A', 26)
            : ('0' <= c && c <= '9') ? decal(c, '0', 10)
            : c;
        return new string(mot.Select(cesar).ToArray());
    }
}