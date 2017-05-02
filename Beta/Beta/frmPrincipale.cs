using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beta
{
    public partial class frmPrincipale : Form
    {
        private int _indexSelectionne;
        private List<clsTravail> _listeTravaux;
        public frmPrincipale()
        {
            InitializeComponent();
            ListeTravaux = new List<clsTravail>();
            CreerTravail("Vincent", "Vincent");
            MisAJourListeVue();
        }

        internal List<clsTravail> ListeTravaux
        {
            get
            {
                return _listeTravaux;
            }

            set
            {
                _listeTravaux = value;
            }
        }

        public int IndexSelectionne
        {
            get
            {
                return _indexSelectionne;
            }

            set
            {
                _indexSelectionne = value;
            }
        }


        /// <summary>
        /// Créer un nouveau travail et l'ajoute dans la liste
        /// </summary>
        /// <param name="paramTexte">Texte du travail</param>
        /// <param name="paramNom">Nom de l'élève</param>
        public void CreerTravail(string paramTexte, string paramNom)
        {
            clsTravail NouveauTravail = new clsTravail(paramTexte, paramNom);
            ListeTravaux.Add(NouveauTravail);
        }
        /// <summary>
        /// Mets à jours la liste coté vue
        /// </summary>
        public void MisAJourListeVue()
        {
            lsbListeTravaux.Items.Clear();
            foreach (clsTravail travail in this.ListeTravaux)
            {
                lsbListeTravaux.Items.Add(travail);
            }
        }
        /// <summary>
        /// Affiche le travail dans la page Travail
        /// </summary>
        /// <param name="index">index du travail que l'on veut afficher</param>
        private void SelectionnerTravail(int index)
        {
            IndexSelectionne = index;
            this.tbxExemple.Text = this.ListeTravaux[IndexSelectionne].TexteExemple;
            string TexteCopie = "";
            for (int i = 0; i < this.ListeTravaux[IndexSelectionne].Progression; i++)
            {
                TexteCopie += this.ListeTravaux[IndexSelectionne].TexteExemple[i];
            }
            this.tbxCopie.Text = TexteCopie;
            tbcPrincipale.SelectedIndex = 0;
        }

        private void tsiNouveau_Click(object sender, EventArgs e)
        {
            frmCreation Creation = new frmCreation();
            DialogResult DR = Creation.ShowDialog();
            if (DR == DialogResult.OK)
            {
                string Nom = Creation.retournerNom();
                string Texte = Creation.retournerTexte();
                this.CreerTravail(Texte, Nom);
                this.MisAJourListeVue();
            }
        }

        private void lsbListeTravaux_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            Brush FontBrush = Brushes.Black;
            Brush BackgroundBrush = Brushes.Black;
            switch (e.Index % 2)
            {
                case 0:
                    BackgroundBrush = Brushes.WhiteSmoke;
                    break;
                case 1:
                    BackgroundBrush = Brushes.White;
                    break;
            }
            e.Graphics.FillRectangle(BackgroundBrush, e.Bounds);
            // Define the default color of the brush as black.


            // Determine the color of the brush to draw each item based 
            // on the index of the item to draw.


            // Draw the current item text based on the current Font 
            // and the custom brush settings.
            e.Graphics.DrawString(ListeTravaux[e.Index].NomEleve,
                e.Font, FontBrush, 0, e.Bounds.Y + 2);
            e.Graphics.DrawString(ListeTravaux[e.Index].TexteExemple,
               e.Font, FontBrush, 250, e.Bounds.Y + 2);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        private void lsbListeTravaux_DoubleClick(object sender, EventArgs e)
        {
            int index = this.lsbListeTravaux.SelectedIndex;
            this.SelectionnerTravail(index);
        }

        private void tbxCopie_KeyPress(object sender, KeyPressEventArgs e)
        {
            int progression = this.ListeTravaux[this.IndexSelectionne].Progression;
            if (e.KeyChar != this.ListeTravaux[this.IndexSelectionne].TexteExemple[progression])
            {
                e.Handled = true;
            }
            else
            {
                this.ListeTravaux[this.IndexSelectionne].Progression += 1;
            }

            if (this.ListeTravaux[this.IndexSelectionne].Progression == this.ListeTravaux[this.IndexSelectionne].TotalCaractere)
            {
                MessageBox.Show("Félicitation vous avez fini ! ");
            }
        }
    }
}
