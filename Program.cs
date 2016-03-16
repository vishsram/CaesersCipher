using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    public class CaesarCipher
    {
        private static char[] alphabets = new char[26];
        private int offset;
        Dictionary<char, int> charIndexAlphabets = new Dictionary<char, int>();

               
    public CaesarCipher(char[] alphs)
        {
            CaesarCipher.alphabets = alphs;
            // store the index of each char in dictionary for later use
            for (int i = 0; i < alphs.Length; i++)
            {
                this.charIndexAlphabets.Add(alphs[i], i);
            }
        }

        /// <summary>
        /// Sets the required offset to shift characters
        /// </summary>
        /// <param name="n"></param>
        public void setOffset(int n)
        {
            this.offset = n;
        }

        /// <summary>
        /// gets a char array as input and replaces each char with the values of n chars away (offset) 
        /// </summary>
        /// <param name="inputText"></param>
        public void cipher(char[] inputText)
        {
            if (this.offset < 1)
            {
                return;
            }

            for (int i = 0; i < inputText.Length; i++)
            {
                int k = 0;
                if (this.charIndexAlphabets[inputText[i]] == alphabets.Length-1)
                {
                    inputText[i] = alphabets[this.offset-1];
                }
                else if (this.charIndexAlphabets[inputText[i]] + this.offset > alphabets.Length)
                {
                    
                    for (int j = this.charIndexAlphabets[inputText[i]]; j <= alphabets.Length; j++)
                    {

                        if (inputText[i] == alphabets[alphabets.Length - offset + k])
                        {
                            inputText[i++] = alphabets[k];
                        }
                        k++;
                    }
                }
                else
                {
                    inputText[i] = alphabets[this.charIndexAlphabets[inputText[i]] + this.offset];
                }
            }
        }

        public void decipher (char[] inputText)
        {
            if (this.offset < 1)
            {
                return;
            }

            for (int i = 0; i < inputText.Length; i++)
            {
                int k = 0;
                if (this.charIndexAlphabets[inputText[i]] == this.offset - 1)
                {
                    inputText[i] = alphabets[alphabets.Length - 1];
                }
                else if (this.charIndexAlphabets[inputText[i]] < this.offset - 1)
                {

                    for (int j = 0; j < this.offset-1; j++)
                    {

                        if (inputText[i] == alphabets[j])
                        {
                            inputText[i++] = alphabets[alphabets.Length - this.offset + j];
                        }
                        k++;
                    }
                }
                else
                {
                    inputText[i] = alphabets[this.charIndexAlphabets[inputText[i]] - this.offset];
                }
            }

        }

        static void Main(string[] args)
        {
            char[] t = { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o' };
            CaesarCipher CC = new CaesarCipher(t);
            CC.setOffset(2);
            char[] test = "hello leo".ToCharArray();
            Console.WriteLine("Original text: {0}", new string(test));
            CC.cipher(test);
            Console.WriteLine("Cipher: {0}", new string(test));
            CC.decipher(test);
            Console.WriteLine("Decipher: {0}", new string(test));
        }
    }
}
