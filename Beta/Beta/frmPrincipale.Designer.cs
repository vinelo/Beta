namespace Beta
{
    partial class frmPrincipale
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbcPrincipale = new System.Windows.Forms.TabControl();
            this.tbpTravail = new System.Windows.Forms.TabPage();
            this.tbxExemple = new System.Windows.Forms.TextBox();
            this.tbxCopie = new System.Windows.Forms.TextBox();
            this.tbpTravaux = new System.Windows.Forms.TabPage();
            this.lsbListeTravaux = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmFichier = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiNouveau = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSerialiser = new System.Windows.Forms.Button();
            this.btnDeserialiser = new System.Windows.Forms.Button();
            this.ofdDeserialisation = new System.Windows.Forms.OpenFileDialog();
            this.tbcPrincipale.SuspendLayout();
            this.tbpTravail.SuspendLayout();
            this.tbpTravaux.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcPrincipale
            // 
            this.tbcPrincipale.Controls.Add(this.tbpTravail);
            this.tbcPrincipale.Controls.Add(this.tbpTravaux);
            this.tbcPrincipale.Location = new System.Drawing.Point(13, 27);
            this.tbcPrincipale.Name = "tbcPrincipale";
            this.tbcPrincipale.SelectedIndex = 0;
            this.tbcPrincipale.Size = new System.Drawing.Size(576, 277);
            this.tbcPrincipale.TabIndex = 0;
            // 
            // tbpTravail
            // 
            this.tbpTravail.Controls.Add(this.btnDeserialiser);
            this.tbpTravail.Controls.Add(this.btnSerialiser);
            this.tbpTravail.Controls.Add(this.tbxExemple);
            this.tbpTravail.Controls.Add(this.tbxCopie);
            this.tbpTravail.Location = new System.Drawing.Point(4, 22);
            this.tbpTravail.Name = "tbpTravail";
            this.tbpTravail.Padding = new System.Windows.Forms.Padding(3);
            this.tbpTravail.Size = new System.Drawing.Size(568, 251);
            this.tbpTravail.TabIndex = 0;
            this.tbpTravail.Text = "Travail";
            this.tbpTravail.UseVisualStyleBackColor = true;
            // 
            // tbxExemple
            // 
            this.tbxExemple.Location = new System.Drawing.Point(6, 6);
            this.tbxExemple.Name = "tbxExemple";
            this.tbxExemple.ReadOnly = true;
            this.tbxExemple.Size = new System.Drawing.Size(555, 20);
            this.tbxExemple.TabIndex = 1;
            // 
            // tbxCopie
            // 
            this.tbxCopie.Location = new System.Drawing.Point(6, 154);
            this.tbxCopie.Name = "tbxCopie";
            this.tbxCopie.Size = new System.Drawing.Size(555, 20);
            this.tbxCopie.TabIndex = 0;
            this.tbxCopie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCopie_KeyPress);
            // 
            // tbpTravaux
            // 
            this.tbpTravaux.Controls.Add(this.lsbListeTravaux);
            this.tbpTravaux.Location = new System.Drawing.Point(4, 22);
            this.tbpTravaux.Name = "tbpTravaux";
            this.tbpTravaux.Padding = new System.Windows.Forms.Padding(3);
            this.tbpTravaux.Size = new System.Drawing.Size(568, 251);
            this.tbpTravaux.TabIndex = 1;
            this.tbpTravaux.Text = "Travaux";
            this.tbpTravaux.UseVisualStyleBackColor = true;
            // 
            // lsbListeTravaux
            // 
            this.lsbListeTravaux.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lsbListeTravaux.FormattingEnabled = true;
            this.lsbListeTravaux.ItemHeight = 20;
            this.lsbListeTravaux.Location = new System.Drawing.Point(6, 6);
            this.lsbListeTravaux.Name = "lsbListeTravaux";
            this.lsbListeTravaux.Size = new System.Drawing.Size(556, 184);
            this.lsbListeTravaux.TabIndex = 0;
            this.lsbListeTravaux.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lsbListeTravaux_DrawItem);
            this.lsbListeTravaux.DoubleClick += new System.EventHandler(this.lsbListeTravaux_DoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFichier});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(601, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmFichier
            // 
            this.tsmFichier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiNouveau});
            this.tsmFichier.Name = "tsmFichier";
            this.tsmFichier.Size = new System.Drawing.Size(54, 20);
            this.tsmFichier.Text = "Fichier";
            // 
            // tsiNouveau
            // 
            this.tsiNouveau.Name = "tsiNouveau";
            this.tsiNouveau.Size = new System.Drawing.Size(122, 22);
            this.tsiNouveau.Text = "Nouveau";
            this.tsiNouveau.Click += new System.EventHandler(this.tsiNouveau_Click);
            // 
            // btnSerialiser
            // 
            this.btnSerialiser.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSerialiser.Location = new System.Drawing.Point(197, 210);
            this.btnSerialiser.Name = "btnSerialiser";
            this.btnSerialiser.Size = new System.Drawing.Size(158, 35);
            this.btnSerialiser.TabIndex = 5;
            this.btnSerialiser.Text = "Serialiser";
            this.btnSerialiser.UseVisualStyleBackColor = true;
            this.btnSerialiser.Click += new System.EventHandler(this.btnSerialiser_Click);
            // 
            // btnDeserialiser
            // 
            this.btnDeserialiser.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDeserialiser.Location = new System.Drawing.Point(361, 210);
            this.btnDeserialiser.Name = "btnDeserialiser";
            this.btnDeserialiser.Size = new System.Drawing.Size(158, 35);
            this.btnDeserialiser.TabIndex = 6;
            this.btnDeserialiser.Text = "Deserialiser";
            this.btnDeserialiser.UseVisualStyleBackColor = true;
            this.btnDeserialiser.Click += new System.EventHandler(this.btnDeserialiser_Click);
            // 
            // ofdDeserialisation
            // 
            this.ofdDeserialisation.FileName = "openFileDialog1";
            // 
            // frmPrincipale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 316);
            this.Controls.Add(this.tbcPrincipale);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmPrincipale";
            this.Text = "Travaux disciplinaires";
            this.tbcPrincipale.ResumeLayout(false);
            this.tbpTravail.ResumeLayout(false);
            this.tbpTravail.PerformLayout();
            this.tbpTravaux.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tbcPrincipale;
        private System.Windows.Forms.TabPage tbpTravail;
        private System.Windows.Forms.TextBox tbxExemple;
        private System.Windows.Forms.TextBox tbxCopie;
        private System.Windows.Forms.TabPage tbpTravaux;
        private System.Windows.Forms.ListBox lsbListeTravaux;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmFichier;
        private System.Windows.Forms.ToolStripMenuItem tsiNouveau;
        private System.Windows.Forms.Button btnSerialiser;
        private System.Windows.Forms.Button btnDeserialiser;
        private System.Windows.Forms.OpenFileDialog ofdDeserialisation;
    }
}

