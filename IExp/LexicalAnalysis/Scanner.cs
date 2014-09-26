using System;
using System.Collections.Generic;

namespace IExp.LexicalAnalysis
{
    /// <summary>
    /// It is the class performing the lexical analysis,
    /// that is the process of converting a sequence of characters into a sequence of tokens.
    /// </summary>
    public class Scanner
    {
        #region MEMBER VARIABLES

        // The string to convert.
        private string source;

        // The index to the character that we are analysing.
        private int index = 0;

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="Scanner"/> class.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        public Scanner(string text)
        {
            this.source = text;
        }

        #endregion

        #region PRIVATE METHODS

        #region Skip_WhiteSpace
        /// <summary>
        /// Skips all whitespace characters to get to the meaningful text.
        /// </summary>
        /// <exception cref="System.LexicalException">Thrown when a newline is found.</exception>
        private void Skip_WhiteSpace()
        {
            // While the current character is a whitespace, skip it.
            while (Char.IsWhiteSpace(this.source[this.index]))
            {
                // If it is not a newline advance the $index.
                if ((this.source[this.index] == '\n') || (this.source[this.index] == '\r'))
                    throw new System.LexicalException("LexicalException: it is not allowed start a new line, pos " + this.index + ".");
                else
                    this.index++;
            }
        }
        #endregion

        #region ScanToken
        /// <summary>
        /// Analysing the current character, we try to recognize a token.
        /// </summary>
        /// <returns>The recognized token.</returns>
        /// <exception cref="System.LexicalException">Thrown when the current character cannot be recognized.</exception>
        private Token ScanToken()
        {
            // Creates a new empty token and set its index to the current index.
            Token t = new Token();
            t.Index = this.index;

            // Switch on the current character
            switch (this.source[this.index])
            {
                case '(': case ')': case '+': case '-': case '*': case '/':
                    // Convert the character into string
                    t.Value = this.source[this.index].ToString();

                    // Convert the character into TokenType
                    switch (this.source[this.index])
                    {
                        case '(': t.Type = TokenType.ROUNDBR_OPEN; break;
                        case ')': t.Type = TokenType.ROUNDBR_CLOSE; break;
                        case '+': t.Type = TokenType.PLUS; break;
                        case '-': t.Type = TokenType.MINUS; break;
                        case '*': t.Type = TokenType.MUL; break;
                        case '/': t.Type = TokenType.DIV; break;
                    }

                    // Advance the $index
                    this.index++;
                    break;

                default:
                    // If the current character is a digit than convert it into a number
                    if (Char.IsDigit(this.source[this.index]))
                    {
                        t.Type = TokenType.NUMBER;
                        t.Value = "";

                        // Until the string is not ended and the current character is a digit,
                        // we add the character to the property Value of the token.
                        while ((this.index < this.source.Length) && (Char.IsDigit(this.source[this.index])))
                        {
                            t.Value += this.source[this.index];
                            this.index++;
                        }
                    }
                    else
                        throw new System.LexicalException("LexicalException: undefined token in pos " + this.index + ".");
                    break;
            }
            return t;
        }
        #endregion

        #endregion

        #region PUBLIC METHODS

        #region Tokenize
        /// <summary>
        /// Tokenize the source text.
        /// </summary>
        /// <returns>A collection of Token that can be enumerated.</returns>
        public IEnumerable<Token> Tokenize()
        {
            // Start to the first character of the source string.
            this.index = 0;

            // While the string is not ended.
            while (this.index < this.source.Length)
            {
                // Skips all whitespace characters.
                Skip_WhiteSpace();

                // Returns each recognized token one at a time.
                yield return ScanToken();
            }

            // At the end returns the EOF Token.
            yield return new Token(TokenType.EOF, "EOF", index);
        }
        #endregion

        #endregion
    }
}
