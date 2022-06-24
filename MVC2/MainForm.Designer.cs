namespace MVC2
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuPridaj = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemPridajNehnutelnost = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemPridajParcelu = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuVymaz = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemVymazNehnutelnost = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemVymazParcelu = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNajdi = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemNajdiNehnutelnost = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemNajdiParcelu = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemNajdiVsetkyObjekty = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonPopulujEvidenciu = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuPridaj,
            this.MenuVymaz,
            this.MenuNajdi});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(376, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuPridaj
            // 
            this.MenuPridaj.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemPridajNehnutelnost,
            this.MenuItemPridajParcelu});
            this.MenuPridaj.Name = "MenuPridaj";
            this.MenuPridaj.Size = new System.Drawing.Size(61, 24);
            this.MenuPridaj.Text = "Pridaj";
            // 
            // MenuItemPridajNehnutelnost
            // 
            this.MenuItemPridajNehnutelnost.Name = "MenuItemPridajNehnutelnost";
            this.MenuItemPridajNehnutelnost.Size = new System.Drawing.Size(180, 26);
            this.MenuItemPridajNehnutelnost.Text = "Nehnutelnost";
            this.MenuItemPridajNehnutelnost.Click += new System.EventHandler(this.MenuItemPridajNehnutelnost_Click);
            // 
            // MenuItemPridajParcelu
            // 
            this.MenuItemPridajParcelu.Name = "MenuItemPridajParcelu";
            this.MenuItemPridajParcelu.Size = new System.Drawing.Size(180, 26);
            this.MenuItemPridajParcelu.Text = "Parcelu";
            // 
            // MenuVymaz
            // 
            this.MenuVymaz.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemVymazNehnutelnost,
            this.MenuItemVymazParcelu});
            this.MenuVymaz.Name = "MenuVymaz";
            this.MenuVymaz.Size = new System.Drawing.Size(67, 24);
            this.MenuVymaz.Text = "Vymaz";
            // 
            // MenuItemVymazNehnutelnost
            // 
            this.MenuItemVymazNehnutelnost.Name = "MenuItemVymazNehnutelnost";
            this.MenuItemVymazNehnutelnost.Size = new System.Drawing.Size(180, 26);
            this.MenuItemVymazNehnutelnost.Text = "Nehnutelnost";
            // 
            // MenuItemVymazParcelu
            // 
            this.MenuItemVymazParcelu.Name = "MenuItemVymazParcelu";
            this.MenuItemVymazParcelu.Size = new System.Drawing.Size(180, 26);
            this.MenuItemVymazParcelu.Text = "Parcelu";
            // 
            // MenuNajdi
            // 
            this.MenuNajdi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemNajdiNehnutelnost,
            this.MenuItemNajdiParcelu,
            this.MenuItemNajdiVsetkyObjekty});
            this.MenuNajdi.Name = "MenuNajdi";
            this.MenuNajdi.Size = new System.Drawing.Size(59, 24);
            this.MenuNajdi.Text = "Najdi";
            // 
            // MenuItemNajdiNehnutelnost
            // 
            this.MenuItemNajdiNehnutelnost.Name = "MenuItemNajdiNehnutelnost";
            this.MenuItemNajdiNehnutelnost.Size = new System.Drawing.Size(187, 26);
            this.MenuItemNajdiNehnutelnost.Text = "Nehnutelnost";
            this.MenuItemNajdiNehnutelnost.Click += new System.EventHandler(this.MenuItemNajdiNehnutelnost_Click);
            // 
            // MenuItemNajdiParcelu
            // 
            this.MenuItemNajdiParcelu.Name = "MenuItemNajdiParcelu";
            this.MenuItemNajdiParcelu.Size = new System.Drawing.Size(187, 26);
            this.MenuItemNajdiParcelu.Text = "Parcelu";
            // 
            // MenuItemNajdiVsetkyObjekty
            // 
            this.MenuItemNajdiVsetkyObjekty.Name = "MenuItemNajdiVsetkyObjekty";
            this.MenuItemNajdiVsetkyObjekty.Size = new System.Drawing.Size(187, 26);
            this.MenuItemNajdiVsetkyObjekty.Text = "Vsetky objekty";
            this.MenuItemNajdiVsetkyObjekty.Click += new System.EventHandler(this.MenuItemNajdiVsetkyObjekty_Click);
            // 
            // ButtonPopulujEvidenciu
            // 
            this.ButtonPopulujEvidenciu.Location = new System.Drawing.Point(12, 167);
            this.ButtonPopulujEvidenciu.Name = "ButtonPopulujEvidenciu";
            this.ButtonPopulujEvidenciu.Size = new System.Drawing.Size(352, 66);
            this.ButtonPopulujEvidenciu.TabIndex = 1;
            this.ButtonPopulujEvidenciu.Text = "Populuj Evidenciu";
            this.ButtonPopulujEvidenciu.UseVisualStyleBackColor = true;
            this.ButtonPopulujEvidenciu.Click += new System.EventHandler(this.ButtonPopulujEvidenciu_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 245);
            this.Controls.Add(this.ButtonPopulujEvidenciu);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Evidencia ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuPridaj;
        private System.Windows.Forms.ToolStripMenuItem MenuVymaz;
        private System.Windows.Forms.ToolStripMenuItem MenuNajdi;
        private System.Windows.Forms.ToolStripMenuItem MenuItemPridajNehnutelnost;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemPridajParcelu;
        private System.Windows.Forms.ToolStripMenuItem MenuItemVymazNehnutelnost;
        private System.Windows.Forms.ToolStripMenuItem MenuItemVymazParcelu;
        private System.Windows.Forms.ToolStripMenuItem MenuItemNajdiNehnutelnost;
        private System.Windows.Forms.ToolStripMenuItem MenuItemNajdiParcelu;
        private System.Windows.Forms.ToolStripMenuItem MenuItemNajdiVsetkyObjekty;
        private System.Windows.Forms.Button ButtonPopulujEvidenciu;
    }
}

