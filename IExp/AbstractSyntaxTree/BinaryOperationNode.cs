using IExp.LexicalAnalysis;

namespace IExp.AbstractSyntaxTree
{
    /// <summary>
    /// Denote a binary operation node of the Abstract Syntax Tree.
    /// </summary>
    public class BinaryOperationNode : OperationNode
    {
        #region MEMBER VARIABLES

        // Being a binary operation node, it has two children: one on left and one on right.
        private SyntacticNode leftNode;
        private SyntacticNode rightNode;

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryOperationNode"/> class.
        /// </summary>
        /// <param name="t">The type of operation that we want to execute.</param>
        /// <param name="l">The left child.</param>
        /// <param name="r">The right child.</param>
        public BinaryOperationNode(OperationType t, SyntacticNode l, SyntacticNode r) : base(t)
        {
            this.leftNode = l;
            this.rightNode = r;

            // Add to the $GraphicNode the two children.
            this.GraphicNode.AddChild(this.leftNode.GraphicNode);
            this.GraphicNode.AddChild(this.rightNode.GraphicNode);
        }

        #endregion

        #region PUBLIC METHODS

        #region GetValue
        /// <summary>
        /// The method takes the value of the left child and of the right child and executes the requested operation on them.
        /// </summary>
        /// <returns>
        /// The value of the executed operation.
        /// </returns>
        /// <exception cref="System.ParseTreeException">Thrown when the operation is is not supported.</exception>
        public override int GetValue()
        {
            // Recursively it takes the value from the left child.
            int leftValue = this.leftNode.GetValue();

            // Recursively it takes the value from the right child.
            int rightValue = this.rightNode.GetValue();

            // Depending of the operation type it executes the proper calculation.
            switch (this.type)
            {
                case OperationType.PLUS:
                    return leftValue + rightValue;
                case OperationType.MINUS:
                    return leftValue - rightValue;
                case OperationType.MUL:
                    return leftValue * rightValue;
                case OperationType.DIV:
                    try
                    {
                        return leftValue / rightValue;
                    }
                    catch (System.DivideByZeroException)
                    {
                        throw new System.ParseTreeException("ParseTreeException: you're trying to divide by zero, you cannot do that.");
                    }
                default:
                    throw new System.ParseTreeException("ParseTreeException: the operation is not supported.");
            }
        }
        #endregion

        #endregion
    }
}
