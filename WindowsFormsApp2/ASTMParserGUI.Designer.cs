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
            this.bParse = new System.Windows.Forms.Button();
            this.astmData = new System.Windows.Forms.RichTextBox();
            this.messagesData = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // bParse
            // 
            this.bParse.Location = new System.Drawing.Point(742, 504);
            this.bParse.Margin = new System.Windows.Forms.Padding(4);
            this.bParse.Name = "bParse";
            this.bParse.Size = new System.Drawing.Size(100, 28);
            this.bParse.TabIndex = 9;
            this.bParse.Text = "Parse";
            this.bParse.UseVisualStyleBackColor = true;
            this.bParse.Click += new System.EventHandler(this.bParse_Click);
            // 
            // astmData
            // 
            this.astmData.Location = new System.Drawing.Point(731, 21);
            this.astmData.Margin = new System.Windows.Forms.Padding(4);
            this.astmData.Name = "astmData";
            this.astmData.Size = new System.Drawing.Size(622, 466);
            this.astmData.TabIndex = 8;
            this.astmData.Text = "";
            this.astmData.TextChanged += new System.EventHandler(this.astmData_TextChanged);
            // 
            // messagesData
            // 
            this.messagesData.Location = new System.Drawing.Point(11, 21);
            this.messagesData.Margin = new System.Windows.Forms.Padding(4);
            this.messagesData.Name = "messagesData";
            this.messagesData.Size = new System.Drawing.Size(697, 466);
            this.messagesData.TabIndex = 7;
            this.messagesData.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.messagesData_AfterSelect);
            // 
            // ASTMParserGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 552);
            this.Controls.Add(this.bParse);
            this.Controls.Add(this.astmData);
            this.Controls.Add(this.messagesData);
            this.Name = "ASTMParserGUI";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bParse;
        private System.Windows.Forms.RichTextBox astmData;
        private System.Windows.Forms.TreeView messagesData;
    }
}

