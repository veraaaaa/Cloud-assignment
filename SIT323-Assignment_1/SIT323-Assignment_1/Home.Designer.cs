namespace SIT323_Assignment_1
{
    partial class Home
    {
       
        private System.ComponentModel.IContainer components = null;

       
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_File_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_File_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTool_Validate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Validate_Allocations = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_View = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_View_Error = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Help_About = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_Valid = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_File,
            this.MenuTool_Validate,
            this.MenuItem_View,
            this.MenuItem_Help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(448, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItem_File
            // 
            this.MenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_File_Open,
            this.MenuItem_File_Exit});
            this.MenuItem_File.Name = "MenuItem_File";
            this.MenuItem_File.Size = new System.Drawing.Size(37, 20);
            this.MenuItem_File.Text = "File";
            // 
            // MenuItem_File_Open
            // 
            this.MenuItem_File_Open.Name = "MenuItem_File_Open";
            this.MenuItem_File_Open.Size = new System.Drawing.Size(150, 22);
            this.MenuItem_File_Open.Text = "Open TAN File";
            this.MenuItem_File_Open.Click += new System.EventHandler(this.MenuItem_File_Open_Click);
            // 
            // MenuItem_File_Exit
            // 
            this.MenuItem_File_Exit.Name = "MenuItem_File_Exit";
            this.MenuItem_File_Exit.Size = new System.Drawing.Size(150, 22);
            this.MenuItem_File_Exit.Text = "Exit";
            this.MenuItem_File_Exit.Click += new System.EventHandler(this.MenuItem_File_Exit_Click);
            // 
            // MenuTool_Validate
            // 
            this.MenuTool_Validate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Validate_Allocations});
            this.MenuTool_Validate.Name = "MenuTool_Validate";
            this.MenuTool_Validate.Size = new System.Drawing.Size(60, 20);
            this.MenuTool_Validate.Text = "Validate";
            // 
            // MenuItem_Validate_Allocations
            // 
            this.MenuItem_Validate_Allocations.Enabled = false;
            this.MenuItem_Validate_Allocations.Name = "MenuItem_Validate_Allocations";
            this.MenuItem_Validate_Allocations.Size = new System.Drawing.Size(133, 22);
            this.MenuItem_Validate_Allocations.Text = "Allocations";
            this.MenuItem_Validate_Allocations.Click += new System.EventHandler(this.MenuItem_Validate_Allocations_Click);
            // 
            // MenuItem_View
            // 
            this.MenuItem_View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_View_Error});
            this.MenuItem_View.Name = "MenuItem_View";
            this.MenuItem_View.Size = new System.Drawing.Size(44, 20);
            this.MenuItem_View.Text = "View";
            // 
            // MenuItem_View_Error
            // 
            this.MenuItem_View_Error.Name = "MenuItem_View_Error";
            this.MenuItem_View_Error.Size = new System.Drawing.Size(120, 22);
            this.MenuItem_View_Error.Text = "Error List";
            this.MenuItem_View_Error.Click += new System.EventHandler(this.MenuItem_View_Error_Click);
           
            // 
            // textBox_Valid
            // 
            this.textBox_Valid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Valid.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox_Valid.Location = new System.Drawing.Point(9, 40);
            this.textBox_Valid.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox_Valid.Multiline = true;
            this.textBox_Valid.Name = "textBox_Valid";
            this.textBox_Valid.ReadOnly = true;
            this.textBox_Valid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Valid.Size = new System.Drawing.Size(431, 465);
            this.textBox_Valid.TabIndex = 3;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 520);
            this.Controls.Add(this.textBox_Valid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Home";
            this.Text = "Allocations - Assessment Task 1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_File_Open;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_File_Exit;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_View;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_View_Error;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Help_About;
        public System.Windows.Forms.ToolStripMenuItem MenuTool_Validate;
        public System.Windows.Forms.ToolStripMenuItem MenuItem_Validate_Allocations;
        public System.Windows.Forms.TextBox textBox_Valid;
    }
}

