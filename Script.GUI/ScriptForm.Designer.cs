namespace Script.GUI
{
    partial class ScriptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptForm));
            this.ScriptTextBox = new System.Windows.Forms.TextBox();
            this.RunButton = new System.Windows.Forms.Button();
            this.ConsoleTextBox = new System.Windows.Forms.TextBox();
            this.ConsoleLabel = new System.Windows.Forms.Label();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ScriptTextBox
            // 
            this.ScriptTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScriptTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScriptTextBox.Location = new System.Drawing.Point(12, 12);
            this.ScriptTextBox.Multiline = true;
            this.ScriptTextBox.Name = "ScriptTextBox";
            this.ScriptTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ScriptTextBox.Size = new System.Drawing.Size(637, 177);
            this.ScriptTextBox.TabIndex = 0;
            this.ScriptTextBox.Text = resources.GetString("ScriptTextBox.Text");
            // 
            // RunButton
            // 
            this.RunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RunButton.Location = new System.Drawing.Point(574, 195);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 1;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // ConsoleTextBox
            // 
            this.ConsoleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsoleTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleTextBox.Location = new System.Drawing.Point(12, 237);
            this.ConsoleTextBox.Multiline = true;
            this.ConsoleTextBox.Name = "ConsoleTextBox";
            this.ConsoleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConsoleTextBox.Size = new System.Drawing.Size(517, 96);
            this.ConsoleTextBox.TabIndex = 2;
            // 
            // ConsoleLabel
            // 
            this.ConsoleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ConsoleLabel.AutoSize = true;
            this.ConsoleLabel.Location = new System.Drawing.Point(12, 221);
            this.ConsoleLabel.Name = "ConsoleLabel";
            this.ConsoleLabel.Size = new System.Drawing.Size(45, 13);
            this.ConsoleLabel.TabIndex = 3;
            this.ConsoleLabel.Text = "Console";
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LogoPictureBox.BackgroundImage = global::Script.GUI.Properties.Resources.logo;
            this.LogoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogoPictureBox.Location = new System.Drawing.Point(549, 237);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(100, 96);
            this.LogoPictureBox.TabIndex = 4;
            this.LogoPictureBox.TabStop = false;
            // 
            // ScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 345);
            this.Controls.Add(this.LogoPictureBox);
            this.Controls.Add(this.ConsoleLabel);
            this.Controls.Add(this.ConsoleTextBox);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.ScriptTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScriptForm";
            this.Text = "Script GUI";
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ScriptTextBox;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.TextBox ConsoleTextBox;
        private System.Windows.Forms.Label ConsoleLabel;
        private System.Windows.Forms.PictureBox LogoPictureBox;
    }
}

