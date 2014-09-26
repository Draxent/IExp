using System;
using System.Drawing;

namespace IExp.GraphicTree
{
    /// <summary>
    /// A class to draw a circular node that follows the interface <see cref="IDrawable"/>.
    /// </summary>
    public class CircleNode : IDrawable
    {
        #region CONSTANTS

        // The margin space to leave on the left and right for the node label when measuring
        // the ellipse size, that is the node's border.
        private const int MARGIN = 10;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets the node's label.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the font of the node's label.
        /// </summary>
        public Font Font { get; set; }

        /// <summary>
        /// Gets or sets the pen used to draw the node's borders.
        /// </summary>
        public Pen Pen { get; set; }

        /// <summary>
        /// Gets or sets the brush used for the node's background.
        /// </summary>
        public Brush BgBrush { get; set; }

        /// <summary>
        /// Gets or sets the brush used to color the node's label.
        /// </summary>
        public Brush TextBrush { get; set; }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="CircleNode"/> class.
        /// </summary>
        /// <param name="newText">The text we want to assign to the node's label.</param>
        public CircleNode(string newText)
        {
            this.Text = newText;

            // Assign default values to the node's properties
            this.Font = new Font("Times New Roman", 12);
            this.Pen = Pens.Black;
            this.BgBrush = Brushes.White;
            this.TextBrush = Brushes.Black;
        }

        #endregion

        #region PUBLIC METHODS

        #region GetSize
        /// <summary>
        /// Return the size of the string plus a margin.
        /// </summary>
        /// <param name="g">The Graphics Context.</param>
        /// <returns>The calulated size.</returns>
        public SizeF GetSize(Graphics g)
        {
            return g.MeasureString(this.Text, this.Font) + new SizeF(MARGIN, MARGIN);
        }
        #endregion

        #region Draw
        /// <summary>
        /// Draw the node centered at (<paramref name="x"/>, <paramref name="y"/>)
        /// </summary>
        /// <param name="g">The Graphics Context.</param>
        /// <param name="x">The x-coordinate of the center.</param>
        /// <param name="y">The y-coordinate of the center.</param>
        public void Draw(Graphics g, float x, float y)
        {
            // Fill and draw an ellipse
            SizeF size = this.GetSize(g);
            RectangleF rect = new RectangleF(x - size.Width / 2, y - size.Height / 2, size.Width, size.Height);
            g.FillEllipse(this.BgBrush, rect);
            g.DrawEllipse(this.Pen, rect);

            // Draw the text
            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;
                g.DrawString(Text, this.Font, this.TextBrush, x, y, string_format);
            }
        }
        #endregion

        #region IsPointInside
        /// <summary>
        /// Return true if the <paramref name="target"/> point is inside this node
        /// </summary>
        /// <param name="g">The Graphics Context.</param>
        /// <param name="center">The center point.</param>
        /// <param name="target">The target point.</param>
        /// <returns><c>true</c> if the target point is inside this node; otherwise, <c>false</c>.</returns>
        public bool IsPointInside(Graphics g, PointF center, PointF target)
        {
            // Get the size of the node
            SizeF size = this.GetSize(g);

            // Translate so we can assume the ellipse is centered at the origin
            target.X -= center.X;
            target.Y -= center.Y;

            // Determine whether the $target point is inside the ellipse
            float w = size.Width / 2;
            float h = size.Height / 2;

            // The equation for the ellipse, that is the node's border, is [x^2/w^2 + y^2/h^2 = 1]
            return ((Math.Pow(target.X, 2) / Math.Pow(w, 2) + Math.Pow(target.Y, 2) / Math.Pow(h, 2)) <= 1);
        }
        #endregion

        #endregion
    }
}
