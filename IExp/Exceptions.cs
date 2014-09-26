namespace System
{
    #region LexicalException
    /// <summary>
    /// Exception class for Lexical Analysis.
    /// </summary>
    public class LexicalException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LexicalException"/> class.
        /// </summary>
        public LexicalException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LexicalException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public LexicalException(string message) : base(message) { }


        /// <summary>
        /// Initializes a new instance of the <see cref="LexicalException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The inner.</param>
        public LexicalException(string message, Exception inner) : base(message, inner) { }
    }
    #endregion

    #region ParseTreeException
    /// <summary>
    /// Exception class for Abstract Syntax Tree constuction.
    /// </summary>
    public class ParseTreeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParseTreeException"/> class.
        /// </summary>
        public ParseTreeException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParseTreeException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// 
        public ParseTreeException(string message) : base(message) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ParseTreeException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The inner.</param>
        public ParseTreeException(string message, Exception inner) : base(message, inner) { }
    }
    #endregion

    #region ParserException
    /// <summary>
    /// Exception class for Syntactic Analysis.
    /// </summary>
    public class ParserException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParserException"/> class.
        /// </summary>
        public ParserException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParserException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ParserException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParserException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The inner.</param>
        public ParserException(string message, Exception inner) : base(message, inner) { }
    }
    #endregion
}