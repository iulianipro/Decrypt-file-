namespace WindowsFormsApp1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.txtKeyFile = new System.Windows.Forms.TextBox();
            this.txtSelectedFile = new System.Windows.Forms.TextBox();
            this.btnSelectKeyFile = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnBatchDecrypt = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();

            // Form settings
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 353);
            this.Name = "Form1";
            this.Text = "File Decryption Utility";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // Labels
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Key File:";

            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 90);
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "File to Decrypt:";

            // TextBoxes
            this.txtKeyFile.Location = new System.Drawing.Point(20, 45);
            this.txtKeyFile.Size = new System.Drawing.Size(350, 22);
            this.txtKeyFile.ReadOnly = true;

            this.txtSelectedFile.Location = new System.Drawing.Point(20, 115);
            this.txtSelectedFile.Size = new System.Drawing.Size(350, 22);
            this.txtSelectedFile.ReadOnly = true;

            // Buttons
            this.btnSelectKeyFile.Location = new System.Drawing.Point(380, 44);
            this.btnSelectKeyFile.Size = new System.Drawing.Size(80, 25);
            this.btnSelectKeyFile.Text = "Browse";
            this.btnSelectKeyFile.Click += new System.EventHandler(this.btnSelectKeyFile_Click);

            this.btnSelectFile.Location = new System.Drawing.Point(380, 114);
            this.btnSelectFile.Size = new System.Drawing.Size(80, 25);
            this.btnSelectFile.Text = "Browse";
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);

            // Progress Bar
            this.progressBar1.Location = new System.Drawing.Point(20, 180);
            this.progressBar1.Size = new System.Drawing.Size(440, 25);

            // Status Label
            this.lblStatus.Location = new System.Drawing.Point(20, 210);
            this.lblStatus.Size = new System.Drawing.Size(440, 25);
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Decrypt Buttons
            this.btnDecrypt.Location = new System.Drawing.Point(120, 260);
            this.btnDecrypt.Size = new System.Drawing.Size(120, 40);
            this.btnDecrypt.Text = "Decrypt File";
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);

            this.btnBatchDecrypt.Location = new System.Drawing.Point(250, 260);
            this.btnBatchDecrypt.Size = new System.Drawing.Size(120, 40);
            this.btnBatchDecrypt.Text = "Batch Decrypt";
            this.btnBatchDecrypt.Click += new System.EventHandler(this.btnBatchDecrypt_Click);

            // Add all controls to form
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.label1,
                this.label2,
                this.txtKeyFile,
                this.txtSelectedFile,
                this.btnSelectKeyFile,
                this.btnSelectFile,
                this.progressBar1,
                this.lblStatus,
                this.btnDecrypt,
                this.btnBatchDecrypt
            });

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtKeyFile;
        private System.Windows.Forms.TextBox txtSelectedFile;
        private System.Windows.Forms.Button btnSelectKeyFile;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnBatchDecrypt;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}