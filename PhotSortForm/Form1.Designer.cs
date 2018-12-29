namespace ExifLibInAction
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
            this.btnSetFolder = new System.Windows.Forms.Button();
            this.txtImageDir = new System.Windows.Forms.TextBox();
            this.btnSortImages = new System.Windows.Forms.Button();
            this.txtSortResult = new System.Windows.Forms.TextBox();
            this.txtSeq = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSetFolder
            // 
            this.btnSetFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetFolder.Location = new System.Drawing.Point(641, 25);
            this.btnSetFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetFolder.Name = "btnSetFolder";
            this.btnSetFolder.Size = new System.Drawing.Size(172, 34);
            this.btnSetFolder.TabIndex = 0;
            this.btnSetFolder.Text = "Set Folder";
            this.btnSetFolder.UseVisualStyleBackColor = true;
            this.btnSetFolder.Click += new System.EventHandler(this.btnSetFolder_Click);
            // 
            // txtImageDir
            // 
            this.txtImageDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImageDir.Location = new System.Drawing.Point(204, 25);
            this.txtImageDir.Margin = new System.Windows.Forms.Padding(4);
            this.txtImageDir.Name = "txtImageDir";
            this.txtImageDir.Size = new System.Drawing.Size(391, 30);
            this.txtImageDir.TabIndex = 1;
            // 
            // btnSortImages
            // 
            this.btnSortImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSortImages.Location = new System.Drawing.Point(328, 366);
            this.btnSortImages.Margin = new System.Windows.Forms.Padding(4);
            this.btnSortImages.Name = "btnSortImages";
            this.btnSortImages.Size = new System.Drawing.Size(144, 40);
            this.btnSortImages.TabIndex = 2;
            this.btnSortImages.Text = "Sort Images";
            this.btnSortImages.UseVisualStyleBackColor = true;
            this.btnSortImages.Click += new System.EventHandler(this.btnSortImages_Click);
            // 
            // txtSortResult
            // 
            this.txtSortResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSortResult.Location = new System.Drawing.Point(204, 425);
            this.txtSortResult.Margin = new System.Windows.Forms.Padding(4);
            this.txtSortResult.Multiline = true;
            this.txtSortResult.Name = "txtSortResult";
            this.txtSortResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSortResult.Size = new System.Drawing.Size(391, 238);
            this.txtSortResult.TabIndex = 3;
            // 
            // txtSeq
            // 
            this.txtSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeq.Location = new System.Drawing.Point(204, 111);
            this.txtSeq.Multiline = true;
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSeq.Size = new System.Drawing.Size(391, 219);
            this.txtSeq.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Picture folder: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sequence: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 425);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Result: ";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(641, 296);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(174, 34);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 716);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSeq);
            this.Controls.Add(this.txtSortResult);
            this.Controls.Add(this.btnSortImages);
            this.Controls.Add(this.txtImageDir);
            this.Controls.Add(this.btnSetFolder);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSetFolder;
        private System.Windows.Forms.TextBox txtImageDir;
        private System.Windows.Forms.Button btnSortImages;
        private System.Windows.Forms.TextBox txtSortResult;
        private System.Windows.Forms.TextBox txtSeq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReset;
    }
}

