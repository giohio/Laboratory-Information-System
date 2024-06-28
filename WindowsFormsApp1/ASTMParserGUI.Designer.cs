namespace ASTMViewer
{
    partial class ASTMParserGUI
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
            this.astmData = new System.Windows.Forms.RichTextBox();
            this.messagesData = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // astmData
            // 
            this.astmData.Location = new System.Drawing.Point(729, 17);
            this.astmData.Margin = new System.Windows.Forms.Padding(4);
            this.astmData.Name = "astmData";
            this.astmData.Size = new System.Drawing.Size(622, 466);
            this.astmData.TabIndex = 11;
            this.astmData.Text = "";
            this.astmData.TextChanged += new System.EventHandler(this.astmData_TextChanged_1);
            // 
            // messagesData
            // 
            this.messagesData.Location = new System.Drawing.Point(9, 17);
            this.messagesData.Margin = new System.Windows.Forms.Padding(4);
            this.messagesData.Name = "messagesData";
            this.messagesData.Size = new System.Drawing.Size(697, 466);
            this.messagesData.TabIndex = 10;
            // 
            // ASTMParserGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 544);
            this.Controls.Add(this.astmData);
            this.Controls.Add(this.messagesData);
            this.Name = "ASTMParserGUI";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.ASTMParserGUI_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox astmData;
        private System.Windows.Forms.TreeView messagesData;
    }
}