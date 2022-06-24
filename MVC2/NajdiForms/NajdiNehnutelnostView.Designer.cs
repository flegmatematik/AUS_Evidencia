namespace MVC2
{
    partial class NajdiNehnutelnostView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextSirka = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextDlzka = new System.Windows.Forms.TextBox();
            this.ButtonNajdi = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Popis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sirka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dlzka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ButtonVymaz = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zadajte parametre na najdenie objektu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sirka:";
            // 
            // TextSirka
            // 
            this.TextSirka.Location = new System.Drawing.Point(100, 46);
            this.TextSirka.Name = "TextSirka";
            this.TextSirka.Size = new System.Drawing.Size(125, 27);
            this.TextSirka.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Dlzka:";
            // 
            // TextDlzka
            // 
            this.TextDlzka.Location = new System.Drawing.Point(99, 103);
            this.TextDlzka.Name = "TextDlzka";
            this.TextDlzka.Size = new System.Drawing.Size(125, 27);
            this.TextDlzka.TabIndex = 2;
            // 
            // ButtonNajdi
            // 
            this.ButtonNajdi.Location = new System.Drawing.Point(405, 28);
            this.ButtonNajdi.Name = "ButtonNajdi";
            this.ButtonNajdi.Size = new System.Drawing.Size(164, 38);
            this.ButtonNajdi.TabIndex = 5;
            this.ButtonNajdi.Text = "Najdi";
            this.ButtonNajdi.UseVisualStyleBackColor = true;
            this.ButtonNajdi.Click += new System.EventHandler(this.ButtonNajdi_Click);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.Width = 125;
            // 
            // Popis
            // 
            this.Popis.HeaderText = "Popis";
            this.Popis.MinimumWidth = 6;
            this.Popis.Name = "Popis";
            this.Popis.Width = 125;
            // 
            // Sirka
            // 
            this.Sirka.HeaderText = "Sirka";
            this.Sirka.MinimumWidth = 6;
            this.Sirka.Name = "Sirka";
            this.Sirka.Width = 125;
            // 
            // Dlzka
            // 
            this.Dlzka.HeaderText = "Dlzka";
            this.Dlzka.MinimumWidth = 6;
            this.Dlzka.Name = "Dlzka";
            this.Dlzka.Width = 125;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Popis,
            this.Sirka,
            this.Dlzka});
            this.dataGridView.Location = new System.Drawing.Point(13, 169);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(556, 188);
            this.dataGridView.TabIndex = 7;
            this.dataGridView.Text = "dataGridView1";
            // 
            // ButtonVymaz
            // 
            this.ButtonVymaz.Location = new System.Drawing.Point(405, 100);
            this.ButtonVymaz.Name = "ButtonVymaz";
            this.ButtonVymaz.Size = new System.Drawing.Size(164, 37);
            this.ButtonVymaz.TabIndex = 8;
            this.ButtonVymaz.Text = "Vymaz";
            this.ButtonVymaz.UseVisualStyleBackColor = true;
            this.ButtonVymaz.Click += new System.EventHandler(this.ButtonVymaz_Click);
            // 
            // NajdiNehnutelnostView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 386);
            this.Controls.Add(this.ButtonVymaz);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.ButtonNajdi);
            this.Controls.Add(this.TextDlzka);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextSirka);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NajdiNehnutelnostView";
            this.Text = "NajdiNehnutelostView";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextSirka;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextDlzka;
        private System.Windows.Forms.Button ButtonNajdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Popis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sirka;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dlzka;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button ButtonVymaz;
    }
}