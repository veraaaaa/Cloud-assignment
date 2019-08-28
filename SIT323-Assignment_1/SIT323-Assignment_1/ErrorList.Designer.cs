namespace SIT323_Assignment_1
{
    partial class ErrorList
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
            this.textBoxForm2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxForm2
            // 
            this.textBoxForm2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxForm2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxForm2.Location = new System.Drawing.Point(9, 24);
            this.textBoxForm2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxForm2.Multiline = true;
            this.textBoxForm2.Name = "textBoxForm2";
            this.textBoxForm2.ReadOnly = true;
            this.textBoxForm2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxForm2.Size = new System.Drawing.Size(690, 433);
            this.textBoxForm2.TabIndex = 0;
            // 
            // ErrorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(707, 467);
            this.Controls.Add(this.textBoxForm2);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "ErrorList";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public System.Windows.Forms.TextBox textBoxForm2;
    }
}