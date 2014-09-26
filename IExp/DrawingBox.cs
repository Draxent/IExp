using System.ComponentModel;
using System.Windows.Forms;

namespace IExp
{
    /// <summary>
    /// An exstension component of the Panel component.
    /// </summary>
    public partial class DrawingBox : Panel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DrawingBox"/> class.
        /// </summary>
        public DrawingBox()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawingBox"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public DrawingBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
