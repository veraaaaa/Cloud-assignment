namespace _1
{
    partial class ErrorList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextDisplay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextDisplay
            // 
            this.TextDisplay.Location = new System.Drawing.Point(13, 13);
            this.TextDisplay.Multiline = true;
            this.TextDisplay.Name = "TextDisplay";
            this.TextDisplay.Size = new System.Drawing.Size(716, 374);
            this.TextDisplay.TabIndex = 0;
            // 
            // ErrorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 399);
            this.Controls.Add(this.TextDisplay);
            this.Name = "ErrorList";
            this.Text = "ErrorList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextDisplay;
    }
}