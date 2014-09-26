using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using IExp.GraphicTree;
using IExp.LexicalAnalysis;
using IExp.AbstractSyntaxTree;
using IExp.SyntacticAnalysis;

namespace IExp
{
    /// <summary>
    /// The Window component.
    /// </summary>
    public partial class Form1 : Form
    {
        #region VARIABLES

        // The content of the opened file.
        string fileContent;

        // True if the opened file is correct.
        bool correctFile;

        // True if the Graphic Tree is been arranged.
        bool arranged = false;

        // The root of the Abstract Syntax Tree.
        SyntacticNode root;

        #endregion

        #region PUBLIC METHODS

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region PRIVATE METHODS

        #region MenuItem_OpenFile_Click
        /// <summary>
        /// Handles the Click event of the MenuItem_OpenFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MenuItem_OpenFile_Click(object sender, System.EventArgs e)
        {
            // Open the File Dialog.
            OpenFileDialog ofd = new OpenFileDialog();

            // If the file is selected correctly.
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Get the Full Path of the file and put its value on the TextBox.
                    string fullPath = System.IO.Path.GetFullPath(ofd.FileName);
                    TxtBox_FileName.Text = fullPath;
                    TextArea.Text += "The file loaded is valid!\r\n\r\n";

                    // Read the entire file and write its content on the TextArea.
                    fileContent = System.IO.File.ReadAllText(fullPath);
                    TextArea.Text += "Content of file:\r\n";
                    TextArea.Text += fileContent;
                    TextArea.Text += "\r\n\r\n";

                    correctFile = true;
                }
                catch{
                    // Write an error on the TextArea if it could not read the content of the file.
                    TextArea.Text += "Not valid path inserted!\r\n\r\n";
                    correctFile = false;
                }
            }
        }
        #endregion

        #region Interpreter
        /// <summary>
        /// Interpreters the fileContent.
        /// </summary>
        private void Interpreter()
        {
            // Initialize the Scanner.
            Scanner scanner = new Scanner(fileContent);

            try
            {
                // Create the collection of Token that can be enumerated.
                IEnumerable<Token> tokens = scanner.Tokenize();

                // Write the collection on the TextArea.
                TextArea.Text += "Tokenize:\r\n";
                foreach (var token in tokens)
                    TextArea.Text += "   -   " + token + "\r\n";
                TextArea.Text += "\r\n\r\n";
            }
            catch (System.LexicalException ex)
            {
                // Write the LexicalException on the TextArea.
                TextArea.Text += ex.Message + "\r\n";
            }

            try
            {
                // Initialize the Parser.
                Parser parser = new Parser(fileContent);

                // Create the Abstract Syntax Tree.
                root = parser.ParseTree();

                // Get the result of visiting the Abstract Syntax Tree and write it on the TextArea.
                int result = root.GetValue();
                TextArea.Text += "Il risultato dell'espressione = " + result + "\r\n";

                // The structured of the Graphic Tree is changed so it has to be arranged and draw it on the DrawingBox.
                arranged = false;
                DrawingBox.Invalidate();
            }
            catch (System.Exception ex)
            {
                // Write the LexicalException/ParserException/ParseTreeException on the TextArea.
                TextArea.Text += ex.Message + "\r\n";
                root.GraphicNode = null;
            }
        }
        #endregion

        #region MenuItem_Interpreter_Click
        /// <summary>
        /// Handles the Click event of the MenuItem_Interpreter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MenuItem_Interpreter_Click(object sender, System.EventArgs e)
        {
            if (correctFile)
            {
                Interpreter();
            }
            else
            {
                // Write the error on the TextArea.
                TextArea.Text += "You have to open a valid file text, first!\r\n\r\n";
            }
        }
        #endregion

        #region DrawingBox_Paint
        /// <summary>
        /// Handles the Paint event of the DrawingBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void DrawingBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            e.Graphics.TranslateTransform(DrawingBox.AutoScrollPosition.X, DrawingBox.AutoScrollPosition.Y);

            if (root != null)
            {
                if (!arranged)
                {
                    // Arrange the Graphic Tree.
                    root.GraphicNode.Arrange(g);

                    // Set the AutoScrollMinSize property of the DrawingBox to the size of the Graphic Tree.
                    DrawingBox.AutoScrollMinSize = Size.Round(root.GraphicNode.TreeArea.Size);

                    // Set arranged to true in a way to not rearrange again.
                    arranged = true;
                }

                // Draw the Graphic Tree.
                root.GraphicNode.Draw(g);
            }
        }
        #endregion

        #region DrawingBox_Click
        /// <summary>
        /// Handles the Click event of the DrawingBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DrawingBox_Click(object sender, System.EventArgs e)
        {
            // Take the mouse position relative to the DrawingBox.
            PointF p = DrawingBox.PointToClient(Cursor.Position);

            // Calculate the $target point adding the scrolling values.
            PointF target = new PointF(p.X + DrawingBox.HorizontalScroll.Value, p.Y + DrawingBox.VerticalScroll.Value);
            
            GTree<CircleNode> selectedNode;

            // Select the node that contain the $target point.
            using (Graphics g = DrawingBox.CreateGraphics())
            {
                selectedNode = root.GraphicNode.NodeAtPoint(g, target);
            }

            if (selectedNode != null)
            {
                // If the node has his subtree hidden.
                if (selectedNode.HiddenSubTree)
                {
                    // Set HiddenSubTree to false in order to show again its subtree.
                    selectedNode.HiddenSubTree = false;

                    // Reset the background color of its node and the original node's label.
                    selectedNode.Node.BgBrush = Brushes.White;
                    selectedNode.Node.Text = selectedNode.OldTextNode;
                }
                // Otherwise
                else
                {
                    // Hidden the subtree.
                    selectedNode.HiddenSubTree = true;

                    // Highlight the node.
                    selectedNode.Node.BgBrush = Brushes.Yellow;

                    // Save the original node's label into OldTextNode property of the GTree.
                    selectedNode.OldTextNode = selectedNode.Node.Text;

                    // Set the node's label with the result text obtained visiting the subtree under it.
                    selectedNode.Node.Text = selectedNode.SyntacticNode.GetValue().ToString();
                }

                // Draw again the Graphic Tree on the DrawingBox
                DrawingBox.Invalidate();
            }
            else System.Console.Write("Null");
        }
        #endregion

        #region MenuItem_Exit_Click
        /// <summary>
        /// Handles the Click event of the MenuItem_Exit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MenuItem_Exit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region MenuItem_Help_Click
        /// <summary>
        /// Handles the Click event of the MenuItem_Help control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MenuItem_Help_Click(object sender, System.EventArgs e)
        {
            string text = "";
            text += "In order to have you expression file interpeter, do the following steps:\n\n";
            text += "1) Click on File -> Open File.\n";
            text += "2) Select a text file with the same format of try.txt.\n";
            text += "3) Click on Execute -> Iterpreter.\n";
            text += "4) See the result on the TextArea.\n";
            text += "5) Try to click on the nodes of the tree.\n";
            MessageBox.Show(text, "About");
        }
        #endregion

        #region MenuItem_About_Click
        /// <summary>
        /// Handles the Click event of the MenuItem_About control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MenuItem_About_Click(object sender, System.EventArgs e)
        {
            string text = "";
            text += "Program written by Federico Conte.\n";
            text += "Info: fconte90@gmail.com\n";
            text += "Date: 25/09/2014 \tRelease 1.0";
            MessageBox.Show(text, "About");
        }
        #endregion

        #region MenuItem_Try_Click
        /// <summary>
        /// Handles the Click event of the MenuItem_Try control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MenuItem_Try_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Get the Full Path of the file and put its value on the TextBox.
                string fullPath = System.IO.Path.GetFullPath("../../../try.txt");
                TxtBox_FileName.Text = fullPath;
                TextArea.Text += "The file loaded is valid!\r\n\r\n";

                // Read the entire file and write its content on the TextArea.
                fileContent = System.IO.File.ReadAllText(fullPath);
                TextArea.Text += "Content of file:\r\n";
                TextArea.Text += fileContent;
                TextArea.Text += "\r\n\r\n";

                Interpreter();

            }
            catch (System.IO.FileNotFoundException)
            {
                // Write the error on the TextArea.
                TextArea.Text += "Impossible to find try.txt, the file has been removed from its original location!\r\n\r\n";
            }
        }
        #endregion
    }

    #endregion
}
