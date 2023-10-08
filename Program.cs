namespace NCezar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello World!";

            NCezar cezar = new NCezar();

            Console.WriteLine(text);

            string encr = cezar.Encrypt(text, 5);
            Console.WriteLine(encr);

            Console.WriteLine(cezar.Cryptanalisys(encr));
        }
    }
}