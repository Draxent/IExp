﻿using System.Drawing;

namespace IExp.GraphicTree
{
    /// <summary>
    /// Interface that a node must have in order to be drawn it.
    /// </summary>
    public interface IDrawable
    {

        #region PROPERTIES

        /// <summary>
        /// Gets or sets the node's label.
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Gets or sets the font of the node's label.
        /// </summary>
        Font Font { get; set; }

        /// <summary>
        /// Gets or sets the pen used to draw the node's borders.
        /// </summary>
        Pen Pen { get; set; }

        /// <summary>
        /// Gets or sets the brush used for the node's background.
        /// </summary>
        Brush BgBrush { get; set; }

        /// <summary>
        /// Gets or sets the brush used to color the node's label.
        /// </summary>
        Brush TextBrush { get; set; }

        #endregion

        #region METHODS

        #region GetSize
        /// <summary>
        /// Return the object's needed size.
        /// </summary>
        /// <param name="g">The Graphics Context.</param>
        /// <returns>The calulated size.</returns>
        SizeF GetSize(Graphics g);
        #endregion

        #region Draw
        /// <summary>
        /// Draw the node centered at (<paramref name="x"/>, <paramref name="y"/>)
        /// </summary>
        /// <param name="g">The Graphics Context.</param>
        /// <param name="x">The x-coordinate of the center.</param>
        /// <param name="y">The y-coordinate of the center.</param>
        void Draw(Graphics g, float x, float y);
        #endregion

        #region IsPointInside
        /// <summary>
        /// Return true if the <paramref name="target"/> point is inside this node
        /// </summary>
        /// <param name="g">The Graphics Context.</param>
        /// <param name="center">The center point.</param>
        /// <param name="target">The target point.</param>
        /// <returns><c>true</c> if the target point is inside this node; otherwise, <c>false</c>.</returns>
        bool IsPointInside(Graphics g, PointF center, PointF target);
        #endregion

        #endregion
    }
}
