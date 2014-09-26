namespace IExp.LexicalAnalysis
{
    /// <summary>
    /// It is an enumeration type that reports all possible tokens supported by the <see cref="Token"/> class.
    /// </summary>
    public enum TokenType
    {
        /// <summary>"(" symbol</summary>
        ROUNDBR_OPEN,

        /// <summary>")" symbol</summary>
        ROUNDBR_CLOSE,

        /// <summary>Any integer number</summary>
        NUMBER,

        /// <summary>"+" operation</summary>
        PLUS,

        /// <summary>"-" operation</summary>
        MINUS,

        /// <summary>"*" operation</summary>
        MUL, // "*"

        /// <summary>"÷" operation</summary>
        DIV,

        /// <summary>Token not recognized</summary>
        UNKNOWN,

        /// <summary>End of file</summary>
        EOF
    };

    /// <summary>
    /// The class constructs a Token, that is a single atomic unit of the language.
    /// </summary>
    public class Token
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets the type of token that we want to create.
        /// </summary>
        public TokenType Type { get; set; }

        /// <summary>
        /// Gets or sets the text value of this token.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the position inside the source text where this token was found.
        /// </summary>
        public int Index { get; set; }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="Token"/> class.
        /// </summary>
        public Token()
        {
            this.Type = TokenType.UNKNOWN;
            this.Value = "";
            this.Index = -1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Token"/> class.
        /// </summary>
        /// <param name="type">The type of the Token.</param>
        /// <param name="value">The text value.</param>
        /// <param name="index">The position where it was found.</param>
        public Token(TokenType type, string value, int index)
        {
            this.Type = type;
            this.Value = value;
            this.Index = index;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return ("[" + this.Type + ", " + this.Value + ", (pos "+this.Index+")]");
        }

        #endregion
    }
}
