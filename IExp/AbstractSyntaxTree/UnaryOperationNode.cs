using IExp.LexicalAnalysis;

namespace IExp.AbstractSyntaxTree
{
    /// <summary>
    /// Denote a unary operation node of the Abstract Syntax Tree.
    /// </summary>
    public class UnaryOperationNode : OperationNode
    {
        #region MEMBER VARIABLES

        // Being a unary operation node, it has one child.
        private SyntacticNode node;

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="UnaryOperationNode"/> class.
        /// </summary>
        /// <param name="t">The type of operation that we want to execute.</param>
        /// <param name="n">The child.</param>
        public UnaryOperationNode(OperationType t, SyntacticNode n) : base(t)
        {
            this.node = n;

            // Add to the $GraphicNode the child
            this.GraphicNode.AddChild(this.node.GraphicNode);
        }

        #endregion

        #region PUBLIC METHODS

        #region GetValue
        /// <summary>
        /// The method takes the value of the child and executes the requested operation on it.
        /// </summary>
        /// <returns>
        /// The value of the executed operation.
        /// </returns>
        /// <exception cref="System.ParseTreeException">Thrown when the operation is is not supported.</exception>
        public override int GetValue()
        {
            // Recursively it takes the value from his child.
            int value = this.node.GetValue();

            // Depending of the operation type it executes the proper calculation.
            switch (this.type)
            {
                case OperationType.MINUS:
                    return -value;
                default:
                    throw new System.ParseTreeException("ParseTreeException: the operation is not supported.");
            }
        }
        #endregion

        #endregion
    }
}
