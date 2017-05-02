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
    public partial class frmCreation : Form
    {
        public frmCreation()
        {
            InitializeComponent();
        }
        public string retournerNom()
        {
            string Nom = this.tbxNom.Text;
            return Nom;
        }
        public string retournerTexte()
        {
            string Texte = this.tbxTexteExemple.Text;
            return Texte;
        }
    }
}
