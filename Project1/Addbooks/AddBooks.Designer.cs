namespace Project1.Addbooks
{
    partial class AddBooks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBooks));
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Cover1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fbDes = new Project1.Addbooks.fieldbox();
            this.fbStock = new Project1.Addbooks.fieldbox();
            this.fbPrice = new Project1.Addbooks.fieldbox();
            this.fbISBN = new Project1.Addbooks.fieldbox();
            this.fbAuthor = new Project1.Addbooks.fieldbox();
            this.fbTitle = new Project1.Addbooks.fieldbox();
            this.fbBookID = new Project1.Addbooks.fieldbox();
            ((System.ComponentModel.ISupportInitialize)(this.Cover1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "人文社科",
            "經典文學"});
            this.cbCategory.Location = new System.Drawing.Point(118, 283);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(171, 20);
            this.cbCategory.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(114, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "類別";
            // 
            // Cover1
            // 
            this.Cover1.Location = new System.Drawing.Point(612, 25);
            this.Cover1.Name = "Cover1";
            this.Cover1.Size = new System.Drawing.Size(132, 161);
            this.Cover1.TabIndex = 4;
            this.Cover1.TabStop = false;
            this.Cover1.Click += new System.EventHandler(this.Cover1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(646, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "書籍封面";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Bisque;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(469, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "新增";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Bisque;
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(632, 385);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 31);
            this.button2.TabIndex = 7;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(115, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "*全部必填";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fbDes
            // 
            this.fbDes.BackColor = System.Drawing.Color.Transparent;
            this.fbDes.fieldName = "介紹";
            this.fbDes.fieldValue = "";
            this.fbDes.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.fbDes.Location = new System.Drawing.Point(357, 309);
            this.fbDes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fbDes.Name = "fbDes";
            this.fbDes.Size = new System.Drawing.Size(198, 53);
            this.fbDes.TabIndex = 1;
            // 
            // fbStock
            // 
            this.fbStock.BackColor = System.Drawing.Color.Transparent;
            this.fbStock.fieldName = "數量";
            this.fbStock.fieldValue = "";
            this.fbStock.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.fbStock.Location = new System.Drawing.Point(357, 248);
            this.fbStock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fbStock.Name = "fbStock";
            this.fbStock.Size = new System.Drawing.Size(198, 55);
            this.fbStock.TabIndex = 1;
            // 
            // fbPrice
            // 
            this.fbPrice.BackColor = System.Drawing.Color.Transparent;
            this.fbPrice.fieldName = "價格";
            this.fbPrice.fieldValue = "";
            this.fbPrice.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.fbPrice.Location = new System.Drawing.Point(357, 192);
            this.fbPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fbPrice.Name = "fbPrice";
            this.fbPrice.Size = new System.Drawing.Size(163, 60);
            this.fbPrice.TabIndex = 1;
            // 
            // fbISBN
            // 
            this.fbISBN.BackColor = System.Drawing.Color.Transparent;
            this.fbISBN.fieldName = "ISBN";
            this.fbISBN.fieldValue = "";
            this.fbISBN.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fbISBN.Location = new System.Drawing.Point(357, 136);
            this.fbISBN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fbISBN.Name = "fbISBN";
            this.fbISBN.Size = new System.Drawing.Size(198, 60);
            this.fbISBN.TabIndex = 1;
            // 
            // fbAuthor
            // 
            this.fbAuthor.BackColor = System.Drawing.Color.Transparent;
            this.fbAuthor.fieldName = "作者";
            this.fbAuthor.fieldValue = "";
            this.fbAuthor.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.fbAuthor.Location = new System.Drawing.Point(118, 193);
            this.fbAuthor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fbAuthor.Name = "fbAuthor";
            this.fbAuthor.Size = new System.Drawing.Size(171, 59);
            this.fbAuthor.TabIndex = 1;
            // 
            // fbTitle
            // 
            this.fbTitle.BackColor = System.Drawing.Color.Transparent;
            this.fbTitle.fieldName = "書名";
            this.fbTitle.fieldValue = "";
            this.fbTitle.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.fbTitle.Location = new System.Drawing.Point(118, 136);
            this.fbTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fbTitle.Name = "fbTitle";
            this.fbTitle.Size = new System.Drawing.Size(171, 50);
            this.fbTitle.TabIndex = 1;
            // 
            // fbBookID
            // 
            this.fbBookID.BackColor = System.Drawing.Color.Transparent;
            this.fbBookID.fieldName = "BookID";
            this.fbBookID.fieldValue = "0";
            this.fbBookID.Location = new System.Drawing.Point(21, 12);
            this.fbBookID.Name = "fbBookID";
            this.fbBookID.Size = new System.Drawing.Size(94, 45);
            this.fbBookID.TabIndex = 0;
            this.fbBookID.Visible = false;
            // 
            // AddBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Cover1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.fbDes);
            this.Controls.Add(this.fbStock);
            this.Controls.Add(this.fbPrice);
            this.Controls.Add(this.fbISBN);
            this.Controls.Add(this.fbAuthor);
            this.Controls.Add(this.fbTitle);
            this.Controls.Add(this.fbBookID);
            this.DoubleBuffered = true;
            this.Name = "AddBooks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddBooks";
            this.Load += new System.EventHandler(this.AddBooks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Cover1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private fieldbox fbBookID;
        private fieldbox fbTitle;
        private fieldbox fbAuthor;
        private fieldbox fbISBN;
        private fieldbox fbPrice;
        private fieldbox fbStock;
        private fieldbox fbDes;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Cover1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}