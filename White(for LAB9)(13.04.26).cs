namespace Lab9.White
{
    public abstract class White
    {
        protected string _input;

        protected char[] _ends = new char[] { '.', '?', '!' };

        protected char[] _punctuation = new char[] { '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };

        public string Input => _input;

        protected White(string input)
        {
            _input = input;

        }
        public abstract void Review();

        public virtual void ChangeText(string text)
        {
            _input = text;
            Review();
        }
        protected string[] SplitToSentenses()
        {
            return _input.Split(_ends, StringSplitOptions.RemoveEmptyEntries);
        }
        protected string[] SplitToWords()
        {
            var rawWords = _input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var words = new string[rawWords.Length];
            for (int i = 0; i < rawWords.Length; i++)
            {
                words[i] = rawWords[i].Trim(_punctuation);
            }
            var count = 0;// -1 2015 16th
            for (int i = 0; i < words.Length; i++)
            {
                if (string.IsNullOrEmpty(words[i]) || Char.IsDigit(words[i][0]))
                {
                    count++;
                }
            }
            var result = new string[words.Length - count];
            count = 0;
            for (int i = 0, j = 0; i < words.Length; i++)
            {
                if (string.IsNullOrEmpty(words[i]) || Char.IsDigit(words[i][0]))

                {

                    count++;
                }
                else
                {
                    result[j] = words[i];
                    j++;
                }
            }
            var res = words.Where(word => !string.IsNullOrEmpty(word) && Char.IsLetter(word[0])).ToArray();
            return res;
        }

    }

}
