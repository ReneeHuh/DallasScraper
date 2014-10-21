namespace DallasScraper
{
    partial class FormMain
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
            this.tbStreetNumber = new System.Windows.Forms.TextBox();
            this.lblStreetNumber = new System.Windows.Forms.Label();
            this.lblStreetName = new System.Windows.Forms.Label();
            this.tbStreetName = new System.Windows.Forms.TextBox();
            this.btStart = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // tbStreetNumber
            // 
            this.tbStreetNumber.Location = new System.Drawing.Point(146, 23);
            this.tbStreetNumber.Name = "tbStreetNumber";
            this.tbStreetNumber.Size = new System.Drawing.Size(139, 27);
            this.tbStreetNumber.TabIndex = 0;
            this.tbStreetNumber.Text = "1309";
            // 
            // lblStreetNumber
            // 
            this.lblStreetNumber.AutoSize = true;
            this.lblStreetNumber.Location = new System.Drawing.Point(13, 26);
            this.lblStreetNumber.Name = "lblStreetNumber";
            this.lblStreetNumber.Size = new System.Drawing.Size(127, 18);
            this.lblStreetNumber.TabIndex = 1;
            this.lblStreetNumber.Text = "Street Number";
            // 
            // lblStreetName
            // 
            this.lblStreetName.AutoSize = true;
            this.lblStreetName.Location = new System.Drawing.Point(13, 60);
            this.lblStreetName.Name = "lblStreetName";
            this.lblStreetName.Size = new System.Drawing.Size(111, 18);
            this.lblStreetName.TabIndex = 3;
            this.lblStreetName.Text = "Street Name";
            // 
            // tbStreetName
            // 
            this.tbStreetName.Location = new System.Drawing.Point(146, 57);
            this.tbStreetName.Name = "tbStreetName";
            this.tbStreetName.Size = new System.Drawing.Size(139, 27);
            this.tbStreetName.TabIndex = 2;
            this.tbStreetName.Text = "Main St";
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(146, 103);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(139, 37);
            this.btStart.TabIndex = 4;
            this.btStart.Text = "Search";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(13, 145);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1078, 310);
            this.listBox1.TabIndex = 5;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 469);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.lblStreetName);
            this.Controls.Add(this.tbStreetName);
            this.Controls.Add(this.lblStreetNumber);
            this.Controls.Add(this.tbStreetNumber);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FormMain";
            this.Text = "Dallas Scraper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbStreetNumber;
        private System.Windows.Forms.Label lblStreetNumber;
        private System.Windows.Forms.Label lblStreetName;
        private System.Windows.Forms.TextBox tbStreetName;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.ListBox listBox1;
    }
}

