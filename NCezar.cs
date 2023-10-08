namespace NCezar
{
    internal class NCezar
    {
        private string alphabet = "abcdefghijklmnopqrstuvwxyz";

        public void SetCustomAlphabet(string alphabet)
        {
            this.alphabet = alphabet;
        }

        public string Encrypt(string input, int n)
        {
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                int index = alphabet.IndexOf(Char.ToLower(input[i]));
                char currentChar = input[i];

                if (index != -1)
                {
                    currentChar = alphabet[(index + n) % alphabet.Length];

                    if (char.IsUpper(input[i])) currentChar = char.ToUpper(currentChar);
                }

                output += currentChar;
            }

            return output;
        }

        public string Decrypt(string input, int n)
        {
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                int index = alphabet.IndexOf(Char.ToLower(input[i]));
                char currentChar = input[i];

                if (index != -1)
                {
                    currentChar = alphabet[(index - n % alphabet.Length + alphabet.Length) % alphabet.Length];

                    if (char.IsUpper(input[i])) currentChar = char.ToUpper(currentChar);
                }

                output += currentChar;
            }

            return output;
        }

        public int Cryptanalisys(string input)
        {
            string Dictionary = File.ReadAllText(@"../../../dictionary.txt");

            for (int i = 0; i < 26; i++)
            {
                string test = Decrypt(input, i).ToLower();
                char[] separators = new char[] { ' ', '!', '.', ',', '?', ';' };
                string[] words = test.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                int count = 0;
                foreach(string word in words)
                {
                    
                    if(Dictionary.Contains(word)) count++;
                }

                float successRate = ((float)count / words.Length) * 100;

                if(successRate >= 80)
                {
                    return i;
                }
            }

            return 0;
        }

    }
}

// dictionary https://github.com/dwyl/english-words