using System.Collections.Generic;
using IExp.LexicalAnalysis;
using IExp.AbstractSyntaxTree;

namespace IExp.SyntacticAnalysis
{
    /// <summary>
    /// It is the class performing the syntactic analysis,
    /// that is the process of analysing a string according to the rules of a formal grammar.
    /// </summary>
    public class Parser
    {
        #region MEMBER VARIABLES

        // It is a collection of Token that can be enumerated.
        private IEnumerator<Token> tokens;

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="Parser"/> class.
        /// </summary>
        /// <param name="text">The text to be parsed.</param>
        public Parser(string text)
        {
            // Initialize the Scanner.
            Scanner scanner = new Scanner(text);

            // Create the collection of Tokens.
            tokens = scanner.Tokenize().GetEnumerator();
            
            // Move to the first token.
            tokens.MoveNext();
        }

        #endregion

        #region PRIVATE METHODS

        #region MatchToken
        /// <summary>
        /// Try to see if the token found has the expected type we wanted. In the positive case, it move to the next Token.
        /// </summary>
        /// <param name="t">TokenType we expect at this point.</param>
        /// <returns><c>true</c> if the token is matched; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.ParserException">Thrown when the token found has not expected type we wanted.</exception>
        private bool MatchToken(TokenType t)
        {
            if (tokens.Current.Type == t)
            {
                tokens.MoveNext();
                return true;
            }
            else
                throw new System.ParserException("ParserException: " + tokens.Current + " found has not expected type " + t + ".");
        }
        #endregion

        #region Exp
        /// <summary>
        /// Constructs the abstract syntax tree for the Expression.
        /// </summary>
        /// <returns>The abstract syntax tree constructed analysing the Expression.</returns>
        private SyntacticNode Exp()
        {
            // Construct the expected tree derived from a Term
            SyntacticNode treeTerm = Term();

            // See if the expression contains more Terms (Term +/- Term +/- Term ...)
            SyntacticNode treeMoreTerms = MoreTerms(treeTerm);

            return treeMoreTerms;
        }
        #endregion

        #region MoreTerms
        /// <summary>
        /// Constructs the abstract syntax tree for this part of the Expression.
        /// </summary>
        /// <param name="n">The abstract syntax tree of the left part of the Expression.</param>
        /// <returns>The abstract syntax tree constructed analysing this part of the Expression.</returns>
        private SyntacticNode MoreTerms(SyntacticNode n)
        {
            if ((tokens.Current.Type == TokenType.PLUS) || (tokens.Current.Type == TokenType.MINUS))
            {
                // Convert the symbol +/- from TokenType to OperationType
                OperationType typeOp = OperationNode.ConvertType(tokens.Current.Type);

                // Read the next token
                tokens.MoveNext();

                // Construct the expected tree derived from a Term
                SyntacticNode treeTerm = Term();

                // Create a BinaryOperationNode with $n, the tree passed from to the function, as left child and $treeTerm as right child
                BinaryOperationNode opNode = new BinaryOperationNode(typeOp, n, treeTerm);

                // Recursive recall the function MoreTerms, to see if contains more Terms (Term +/- Term +/- Term ...)
                SyntacticNode treeMoreTerms = MoreTerms(opNode);

                return treeMoreTerms;
            }
            else return n;
        }
        #endregion

        #region Term
        /// <summary>
        /// Constructs the abstract syntax tree for the Term.
        /// </summary>
        /// <returns>The abstract syntax tree constructed analysing the Term.</returns>
        private SyntacticNode Term()
        {
            // Construct the expected tree derived from a Factor
            SyntacticNode treeFactor = Factor();

            // See if the expression contains more Factors (Factor */÷ Factor */÷ Factor ...)
            SyntacticNode treeMoreFactors = MoreFactors(treeFactor);

            return treeMoreFactors;
        }
        #endregion

        #region MoreFactors
        /// <summary>
        /// Constructs the abstract syntax tree for this part of the Term.
        /// </summary>
        /// <param name="n">The abstract syntax tree of the left part of the Term.</param>
        /// <returns>The abstract syntax tree constructed analysing this part of the Term.</returns>
        private SyntacticNode MoreFactors(SyntacticNode n)
        {
            if ((tokens.Current.Type == TokenType.MUL) || (tokens.Current.Type == TokenType.DIV))
            {
                // Convert the symbol */÷ from TokenType to OperationType
                OperationType typeOp = OperationNode.ConvertType(tokens.Current.Type);

                // Read the next token
                tokens.MoveNext();
                
                // Construct the expected tree derived from a Factor
                SyntacticNode treeFactor = Factor();
                
                // Create a BinaryOperationNode with $n, the tree passed from to the function, as left child and $treeFactor as right child
                BinaryOperationNode opNode = new BinaryOperationNode(typeOp, n, treeFactor);
                
                // Recursive recall the function MoreFactors, to see if contains more Factors (Factor */÷ Factor */÷ Factor ...)
                SyntacticNode treeMoreFactors = MoreFactors(opNode);
                
                return treeMoreFactors;
            }
            else return n;
        }
        #endregion

        #region Factor
        /// <summary>
        /// Constructs the abstract syntax tree for the Factor.
        /// </summary>
        /// <returns>The abstract syntax tree constructed analysing the Factor.</returns>
        private SyntacticNode Factor()
        {
            if (tokens.Current.Type == TokenType.MINUS)
            {
                // Read the next token
                tokens.MoveNext();

                // Construct the expected tree derived from a Factor
                SyntacticNode treeFactor = Factor();

                // Create a UnaryOperationNode with $treeFactor
                UnaryOperationNode opNode = new UnaryOperationNode(OperationType.MINUS, treeFactor);

                return opNode;
            }
            else
            {
                // Construct the expected tree derived from a Factor2
                SyntacticNode treeFactor = Factor2();

                return treeFactor;
            }
        }
        #endregion

        #region Factor2
        /// <summary>
        /// Constructs the abstract syntax tree for the Factor2.
        /// </summary>
        /// <returns>The abstract syntax tree constructed analysing the Factor2.</returns>
        private SyntacticNode Factor2()
        {
            // Switch on the current token type
            switch (tokens.Current.Type)
            {
                case TokenType.ROUNDBR_OPEN:
                    // Read the next token
                    tokens.MoveNext();

                    // Construct the expected tree derived from a Exp
                    SyntacticNode treeResult = Exp();

                    // We expect here the token ")"
                    this.MatchToken(TokenType.ROUNDBR_CLOSE);
                    
                    return treeResult;

                case TokenType.NUMBER:
                    // Create a ValueNode
                    ValueNode n = new ValueNode(tokens.Current.Value);

                    // Read the next token
                    tokens.MoveNext();
                    
                    return n;

                default:
                    throw new System.ParserException("ParserException: invalid factor, token: " + tokens.Current + ".");
            }
        }
        #endregion

        #endregion

        #region PUBLIC METHODS

        #region ParseTree
        /// <summary>
        /// Parse the source text and constructs an abstract syntax tree.
        /// </summary>
        /// <returns>An abstract syntax tree.</returns>
        public SyntacticNode ParseTree()
        {
            // Construct the expected tree derived from a Exp
            SyntacticNode treeExp = Exp();

            // We expect here the token EOF
            this.MatchToken(TokenType.EOF);
            
            return treeExp;
        }
        #endregion

        #endregion
    }
}
