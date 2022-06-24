namespace MVC2
{
    partial class PridajNehnutelnostView
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
            this.TextSupisneCislo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextPopis = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextSirka = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextDlzka = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ButtonPridaj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextSupisneCislo
            // 
            this.TextSupisneCislo.Location = new System.Drawing.Point(115, 64);
            this.TextSupisneCislo.Name = "TextSupisneCislo";
            this.TextSupisneCislo.Size = new System.Drawing.Size(125, 27);
            this.TextSupisneCislo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Supisne cislo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Zadajte parametre Nehnutelosti";
            // 
            // TextPopis
            // 
            this.TextPopis.Location = new System.Drawing.Point(115, 120);
            this.TextPopis.Multiline = true;
            this.TextPopis.Name = "TextPopis";
            this.TextPopis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextPopis.Size = new System.Drawing.Size(462, 71);
            this.TextPopis.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Popis :";
            // 
            // TextSirka
            // 
            this.TextSirka.Location = new System.Drawing.Point(115, 243);
            this.TextSirka.Name = "TextSirka";
            this.TextSirka.Size = new System.Drawing.Size(125, 27);
            this.TextSirka.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Sirka:";
            // 
            // TextDlzka
            // 
            this.TextDlzka.Location = new System.Drawing.Point(115, 289);
            this.TextDlzka.Name = "TextDlzka";
            this.TextDlzka.Size = new System.Drawing.Size(125, 27);
            this.TextDlzka.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Dlzka:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Geograficke suradnice:";
            // 
            // ButtonPridaj
            // 
            this.ButtonPridaj.Location = new System.Drawing.Point(343, 243);
            this.ButtonPridaj.Name = "ButtonPridaj";
            this.ButtonPridaj.Size = new System.Drawing.Size(196, 73);
            this.ButtonPridaj.TabIndex = 4;
            this.ButtonPridaj.Text = "Pridaj";
            this.ButtonPridaj.UseVisualStyleBackColor = true;
            this.ButtonPridaj.Click += new System.EventHandler(this.ButtonPridaj_Click);
            // 
            // PridajView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 394);
            this.Controls.Add(this.ButtonPridaj);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TextDlzka);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextSirka);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextPopis);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextSupisneCislo);
            this.Name = "PridajView";
            this.Text = "PridajView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextSupisneCislo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextPopis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextSirka;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextDlzka;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ButtonPridaj;
    }
}