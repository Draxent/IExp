using IExp.LexicalAnalysis;

namespace IExp.AbstractSyntaxTree
{
    /// <summary>
    /// It is an enumeration type that reports all possible operations supported by the <see cref="OperationNode"/> class.
    /// </summary>
    public enum OperationType
    {
        /// <summary>"+" operation</summary>
        PLUS,

        /// <summary>"-" operation</summary>
        MINUS,

        /// <summary>"*" operation</summary>
        MUL,

        /// <summary>"÷" operation</summary>
        DIV,
    };

    /// <summary>
    /// Denote an node operational of the Abstract Syntax Tree.
    /// </summary>
    abstract public class OperationNode : SyntacticNode
    {
        #region MEMBER VARIABLES

        /// <summary>Represent the type of operation that we want to execute.</summary>
        protected OperationType type;

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationNode"/> class.
        /// </summary>
        /// <param name="t">The type of operation that we want to execute</param>
        public OperationNode(OperationType t) : base()
        {
            this.type = t;

            // Assign to the node's text the symbol of the chosen operation.
            this.GraphicNode.Node.Text = OperationType_ToString(t);
        }

        #endregion

        #region PUBLIC STATIC METHODS

        #region ConvertType
        /// <summary>
        /// Covert a TokenType into an OperationType.
        /// </summary>
        /// <param name="t">The TokenType t to convert.</param>
        /// <returns>The value of t of type OperationType.</returns>
        /// <exception cref="System.ParseTreeException">Thrown when it cannot do the conversion.</exception>
        public static OperationType ConvertType(TokenType t)
        {
            switch (t)
            {
                case TokenType.PLUS: return OperationType.PLUS;
                case TokenType.MINUS: return OperationType.MINUS;
                case TokenType.MUL: return OperationType.MUL;
                case TokenType.DIV: return OperationType.DIV;
                default:
                    throw new System.ParseTreeException("ParseTreeException: failed conversion.");
            }
        }
        #endregion

        #region OperationType_ToString
        /// <summary>
        /// Represent the OperationType <paramref name="t"/> in text format
        /// </summary>
        /// <param name="t">The OperationType t to trasform in text.</param>
        /// <returns>The value of t in text format.</returns>
        public static string OperationType_ToString(OperationType t)
        {
            switch (t)
            {
                case OperationType.PLUS: return "+";
                case OperationType.MINUS: return "-";
                case OperationType.MUL: return "*";
                case OperationType.DIV: return "÷";
                default: return "";
            }
        }
        #endregion

        #endregion
    }
}
