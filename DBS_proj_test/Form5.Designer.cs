namespace DBS_proj_test
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchbar = new System.Windows.Forms.RichTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.search_b = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(572, 430);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // searchbar
            // 
            this.searchbar.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchbar.ForeColor = System.Drawing.Color.Black;
            this.searchbar.Location = new System.Drawing.Point(3, 3);
            this.searchbar.Margin = new System.Windows.Forms.Padding(5);
            this.searchbar.Multiline = false;
            this.searchbar.Name = "searchbar";
            this.searchbar.Size = new System.Drawing.Size(668, 27);
            this.searchbar.TabIndex = 2;
            this.searchbar.Text = "";
            this.searchbar.TextChanged += new System.EventHandler(this.searchbar_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Movies",
            "TV Shows",
            "Actor",
            "Director",
            "Writer"});
            this.comboBox1.Location = new System.Drawing.Point(681, 9);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(166, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "Movies";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // search_b
            // 
            this.search_b.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(197)))), ((int)(((byte)(24)))));
            this.search_b.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("search_b.BackgroundImage")));
            this.search_b.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.search_b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_b.Location = new System.Drawing.Point(857, 3);
            this.search_b.Margin = new System.Windows.Forms.Padding(5);
            this.search_b.Name = "search_b";
            this.search_b.Size = new System.Drawing.Size(65, 28);
            this.search_b.TabIndex = 4;
            this.search_b.UseVisualStyleBackColor = false;
            this.search_b.Click += new System.EventHandler(this.search_b_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 521);
            this.Controls.Add(this.search_b);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.searchbar);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(190, 41);
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox searchbar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button search_b;
    }
}