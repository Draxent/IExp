namespace IExp
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Execute = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Interpreter = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_QM = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Try = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_About = new System.Windows.Forms.ToolStripMenuItem();
            this.TxtBox_FileName = new System.Windows.Forms.TextBox();
            this.TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.TextArea = new System.Windows.Forms.TextBox();
            this.DrawingBox = new IExp.DrawingBox(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.MenuStrip.SuspendLayout();
            this.TableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_File,
            this.MenuItem_Execute,
            this.MenuItem_QM});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(584, 29);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // MenuItem_File
            // 
            this.MenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_OpenFile,
            this.MenuItem_Exit});
            this.MenuItem_File.Name = "MenuItem_File";
            this.MenuItem_File.Size = new System.Drawing.Size(50, 25);
            this.MenuItem_File.Text = "FILE";
            // 
            // MenuItem_OpenFile
            // 
            this.MenuItem_OpenFile.Name = "MenuItem_OpenFile";
            this.MenuItem_OpenFile.Size = new System.Drawing.Size(146, 26);
            this.MenuItem_OpenFile.Text = "Open File";
            this.MenuItem_OpenFile.Click += new System.EventHandler(this.MenuItem_OpenFile_Click);
            // 
            // MenuItem_Exit
            // 
            this.MenuItem_Exit.Name = "MenuItem_Exit";
            this.MenuItem_Exit.Size = new System.Drawing.Size(146, 26);
            this.MenuItem_Exit.Text = "Exit";
            this.MenuItem_Exit.Click += new System.EventHandler(this.MenuItem_Exit_Click);
            // 
            // MenuItem_Execute
            // 
            this.MenuItem_Execute.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Interpreter});
            this.MenuItem_Execute.Name = "MenuItem_Execute";
            this.MenuItem_Execute.Size = new System.Drawing.Size(84, 25);
            this.MenuItem_Execute.Text = "EXECUTE";
            // 
            // MenuItem_Interpreter
            // 
            this.MenuItem_Interpreter.Name = "MenuItem_Interpreter";
            this.MenuItem_Interpreter.Size = new System.Drawing.Size(154, 26);
            this.MenuItem_Interpreter.Text = "Interpreter";
            this.MenuItem_Interpreter.Click += new System.EventHandler(this.MenuItem_Interpreter_Click);
            // 
            // MenuItem_QM
            // 
            this.MenuItem_QM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Try,
            this.MenuItem_Help,
            this.MenuItem_About});
            this.MenuItem_QM.Name = "MenuItem_QM";
            this.MenuItem_QM.Size = new System.Drawing.Size(29, 25);
            this.MenuItem_QM.Text = "?";
            // 
            // MenuItem_Try
            // 
            this.MenuItem_Try.Name = "MenuItem_Try";
            this.MenuItem_Try.Size = new System.Drawing.Size(168, 26);
            this.MenuItem_Try.Text = "Lunch Try.txt";
            this.MenuItem_Try.Click += new System.EventHandler(this.MenuItem_Try_Click);
            // 
            // MenuItem_Help
            // 
            this.MenuItem_Help.Name = "MenuItem_Help";
            this.MenuItem_Help.Size = new System.Drawing.Size(168, 26);
            this.MenuItem_Help.Text = "Help";
            this.MenuItem_Help.Click += new System.EventHandler(this.MenuItem_Help_Click);
            // 
            // MenuItem_About
            // 
            this.MenuItem_About.Name = "MenuItem_About";
            this.MenuItem_About.Size = new System.Drawing.Size(168, 26);
            this.MenuItem_About.Text = "About";
            this.MenuItem_About.Click += new System.EventHandler(this.MenuItem_About_Click);
            // 
            // TxtBox_FileName
            // 
            this.TxtBox_FileName.BackColor = System.Drawing.Color.White;
            this.TxtBox_FileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBox_FileName.Cursor = System.Windows.Forms.Cursors.Default;
            this.TxtBox_FileName.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtBox_FileName.Enabled = false;
            this.TxtBox_FileName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBox_FileName.Location = new System.Drawing.Point(0, 29);
            this.TxtBox_FileName.Name = "TxtBox_FileName";
            this.TxtBox_FileName.ReadOnly = true;
            this.TxtBox_FileName.Size = new System.Drawing.Size(584, 26);
            this.TxtBox_FileName.TabIndex = 0;
            this.TxtBox_FileName.TabStop = false;
            this.TxtBox_FileName.Text = "No File Open";
            // 
            // TableLayout
            // 
            this.TableLayout.ColumnCount = 2;
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayout.Controls.Add(this.TextArea, 0, 0);
            this.TableLayout.Controls.Add(this.DrawingBox, 1, 0);
            this.TableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout.Location = new System.Drawing.Point(0, 55);
            this.TableLayout.Name = "TableLayout";
            this.TableLayout.RowCount = 1;
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout.Size = new System.Drawing.Size(584, 306);
            this.TableLayout.TabIndex = 2;
            // 
            // TextArea
            // 
            this.TextArea.BackColor = System.Drawing.Color.White;
            this.TextArea.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextArea.Location = new System.Drawing.Point(3, 3);
            this.TextArea.Multiline = true;
            this.TextArea.Name = "TextArea";
            this.TextArea.ReadOnly = true;
            this.TextArea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextArea.Size = new System.Drawing.Size(244, 300);
            this.TextArea.TabIndex = 0;
            this.TextArea.TabStop = false;
            // 
            // DrawingBox
            // 
            this.DrawingBox.AutoSize = true;
            this.DrawingBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawingBox.Location = new System.Drawing.Point(253, 3);
            this.DrawingBox.Name = "DrawingBox";
            this.DrawingBox.Size = new System.Drawing.Size(328, 300);
            this.DrawingBox.TabIndex = 1;
            this.DrawingBox.Click += new System.EventHandler(this.DrawingBox_Click);
            this.DrawingBox.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingBox_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.TableLayout);
            this.Controls.Add(this.TxtBox_FileName);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form1";
            this.Text = "Interpreter of Expressions";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.TableLayout.ResumeLayout(false);
            this.TableLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_OpenFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Exit;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Execute;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Interpreter;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_QM;
        private System.Windows.Forms.TextBox TxtBox_FileName;
        private System.Windows.Forms.TableLayoutPanel TableLayout;
        private System.Windows.Forms.TextBox TextArea;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DrawingBox DrawingBox;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_About;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Try;
    }
}

