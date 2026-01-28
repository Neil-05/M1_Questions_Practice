namespace wordWand
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the string:");
            string x = Console.ReadLine();
            int wordCount = x.Split(new char[] { ' ', ',', '.', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            Console.WriteLine("The Word Count: " + wordCount);
            Console.WriteLine("The Result is:");
            if (!x.All(c => char.IsLetter(c) || c == ' '))
            {
                Console.WriteLine("Invalid Sentence");
            }
            else if (x.Length % 2 == 0)
            {
                Even(x);
            }
            else
            {
                Odd(x);
            }
        }
        public static void Even(string x)
        {
            string[] words = x.Split(' ');
            Array.Reverse(words);

            string y = string.Join(" ", words);
            Console.WriteLine(y);
        }
        public static void Odd(string x)
        {
            char[] z = x.ToCharArray();
            Array.Reverse(z);
            string y = new string(z);
            Console.WriteLine(y);
        }
    }
}
