namespace SearchFromReport
{
    partial class MainForm
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
            this.labelFilePath = new System.Windows.Forms.Label();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelChunkSize = new System.Windows.Forms.Label();
            this.textBoxChunkSize = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.labelNameConvenstion = new System.Windows.Forms.Label();
            this.textBoxNameConvention = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelFilePath
            // 
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.Location = new System.Drawing.Point(13, 22);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(48, 13);
            this.labelFilePath.TabIndex = 0;
            this.labelFilePath.Text = "&File Path";
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(108, 19);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(375, 20);
            this.textBoxFilePath.TabIndex = 1;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(486, 19);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "&Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // labelChunkSize
            // 
            this.labelChunkSize.AutoSize = true;
            this.labelChunkSize.Location = new System.Drawing.Point(13, 48);
            this.labelChunkSize.Name = "labelChunkSize";
            this.labelChunkSize.Size = new System.Drawing.Size(61, 13);
            this.labelChunkSize.TabIndex = 3;
            this.labelChunkSize.Text = "Chunk &Size";
            // 
            // textBoxChunkSize
            // 
            this.textBoxChunkSize.Location = new System.Drawing.Point(108, 45);
            this.textBoxChunkSize.Name = "textBoxChunkSize";
            this.textBoxChunkSize.Size = new System.Drawing.Size(375, 20);
            this.textBoxChunkSize.TabIndex = 4;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(486, 68);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 7;
            this.buttonCreate.Text = "&Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // labelNameConvenstion
            // 
            this.labelNameConvenstion.AutoSize = true;
            this.labelNameConvenstion.Location = new System.Drawing.Point(13, 74);
            this.labelNameConvenstion.Name = "labelNameConvenstion";
            this.labelNameConvenstion.Size = new System.Drawing.Size(94, 13);
            this.labelNameConvenstion.TabIndex = 5;
            this.labelNameConvenstion.Text = "&Name Convension";
            // 
            // textBoxNameConvention
            // 
            this.textBoxNameConvention.Location = new System.Drawing.Point(108, 71);
            this.textBoxNameConvention.Name = "textBoxNameConvention";
            this.textBoxNameConvention.Size = new System.Drawing.Size(375, 20);
            this.textBoxNameConvention.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 110);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxNameConvention);
            this.Controls.Add(this.labelNameConvenstion);
            this.Controls.Add(this.textBoxChunkSize);
            this.Controls.Add(this.labelChunkSize);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.labelFilePath);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Create Chunk";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFilePath;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label labelChunkSize;
        private System.Windows.Forms.TextBox textBoxChunkSize;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Label labelNameConvenstion;
        private System.Windows.Forms.TextBox textBoxNameConvention;
    }
}

