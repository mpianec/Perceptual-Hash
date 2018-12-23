namespace PerceptualHashing
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.btnPrvaSlika = new System.Windows.Forms.Button();
            this.btnDrugaSlika = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnaHash = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btndHash = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(61, 119);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(409, 247);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(564, 119);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(409, 247);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // btnPrvaSlika
            // 
            this.btnPrvaSlika.Location = new System.Drawing.Point(61, 74);
            this.btnPrvaSlika.Name = "btnPrvaSlika";
            this.btnPrvaSlika.Size = new System.Drawing.Size(136, 39);
            this.btnPrvaSlika.TabIndex = 2;
            this.btnPrvaSlika.Text = "Otvori prvu sliku";
            this.btnPrvaSlika.UseVisualStyleBackColor = true;
            this.btnPrvaSlika.Click += new System.EventHandler(this.btnPrvaSlika_Click);
            // 
            // btnDrugaSlika
            // 
            this.btnDrugaSlika.Location = new System.Drawing.Point(564, 74);
            this.btnDrugaSlika.Name = "btnDrugaSlika";
            this.btnDrugaSlika.Size = new System.Drawing.Size(132, 39);
            this.btnDrugaSlika.TabIndex = 3;
            this.btnDrugaSlika.Text = "Otvori drugu sliku";
            this.btnDrugaSlika.UseVisualStyleBackColor = true;
            this.btnDrugaSlika.Click += new System.EventHandler(this.btnDrugaSlika_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // btnaHash
            // 
            this.btnaHash.Location = new System.Drawing.Point(383, 372);
            this.btnaHash.Name = "btnaHash";
            this.btnaHash.Size = new System.Drawing.Size(87, 29);
            this.btnaHash.TabIndex = 5;
            this.btnaHash.Text = "aHash";
            this.btnaHash.UseVisualStyleBackColor = true;
            this.btnaHash.Click += new System.EventHandler(this.btnaHash_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 461);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 487);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 513);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 539);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 434);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Hash prve slike: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(58, 461);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Hash druge slike:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 487);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Isti bitovi: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(58, 513);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 17);
            this.label9.TabIndex = 13;
            this.label9.Text = "Različiti bitovi:";
            // 
            // btndHash
            // 
            this.btndHash.Location = new System.Drawing.Point(476, 372);
            this.btndHash.Name = "btndHash";
            this.btndHash.Size = new System.Drawing.Size(87, 29);
            this.btndHash.TabIndex = 14;
            this.btndHash.Text = "dHash";
            this.btndHash.UseVisualStyleBackColor = true;
            this.btndHash.Click += new System.EventHandler(this.btndHash_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 594);
            this.Controls.Add(this.btndHash);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnaHash);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDrugaSlika);
            this.Controls.Add(this.btnPrvaSlika);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Perceptual Hashing";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button btnPrvaSlika;
        private System.Windows.Forms.Button btnDrugaSlika;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnaHash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btndHash;
    }
}

