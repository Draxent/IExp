namespace IExp.AbstractSyntaxTree
{
    /// <summary>
    /// Denote a node of the Abstract Syntax Tree that contain an integer value.
    /// </summary>
    public class ValueNode : SyntacticNode
    {
        #region MEMBER VARIABLES

        // The value contained in the node.
        private int value;

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueNode"/> class.
        /// </summary>
        /// <param name="text">Take the value in text format.</param>
        public ValueNode(string text) : base()
        {
            // Convert the text in integer and assign it to the node and the $GraphicNode
            this.value = System.Convert.ToInt32(text);
            this.GraphicNode.Node.Text = text;
        }

        #endregion

        #region PUBLIC METHODS

        #region GetValue
        /// <summary>
        /// Return the value of the node.
        /// </summary>
        /// <returns>
        /// The value of the node.
        /// </returns>
        public override int GetValue()
        {
            return this.value;
        }
        #endregion

        #endregion

    }
}
