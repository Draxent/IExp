using IExp.GraphicTree;

namespace IExp.AbstractSyntaxTree
{
    /// <summary>
    /// Denote the generic node of the Abstract Syntax Tree.
    /// </summary>
    abstract public class SyntacticNode
    {
        #region MEMBER VARIABLES

        /// <summary>The node contain a pointer to its visual representation.</summary>
        public GTree<CircleNode> GraphicNode = new GTree<CircleNode>(new CircleNode(""));

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="SyntacticNode"/> class.
        /// </summary>
        public SyntacticNode()
        {
            // Give a pointer to itself to the $GraphicNode object, in this way they can refer each others.
            this.GraphicNode.SyntacticNode = this;
        }

        #endregion

        #region PUBLIC METHODS

        #region GetValue
        /// <summary>
        /// It is an abstract method to return the value of the node exploring the tree under it.
        /// </summary>
        /// <returns>An integer value representing the valuation of the expression contained in the tree of this node.</returns>
        abstract public int GetValue();
        #endregion

        #endregion
    }
}
