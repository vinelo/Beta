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
        private List<clsTravail> _listeTravaux;
        public frmPrincipale()
        {
            InitializeComponent();
            ListeTravaux = new List<clsTravail>();
            CreerTravail("Vincent", "Vincent");
            UpdateListeView();
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

        public void CreerTravail(string paramTexte, string paramNom)
        {
            clsTravail NouveauTravail = new clsTravail(paramTexte, paramNom);
            ListeTravaux.Add(NouveauTravail);
        }
        public void UpdateListeView()
        {
            lsbListeTravaux.Items.Clear();
            foreach(clsTravail travail in this.ListeTravaux)
            {
                lsbListeTravaux.Items.Add(travail);
            }
        }
        private void tsiNouveau_Click(object sender, EventArgs e)
        {

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
                e.Font, FontBrush, 0,3);
            e.Graphics.DrawString(ListeTravaux[e.Index].TexteExemple,
               e.Font, FontBrush,250,3);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }
    }
}
