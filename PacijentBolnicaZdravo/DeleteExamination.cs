using MahApps.Metro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacijentBolnicaZdravo
{
    public partial class DeleteExamination : Form
    {
        public DeleteExamination(String label, String button1, String button2, String naslov, int i)
        {
            InitializeComponent();
            this.button1.Text = button1;
            this.button2.Text = button2;
            this.label1.Text = label;
            this.CenterToParent();
            this.Text = naslov;
            this.Name = naslov;
            if(i == 0)
            {
                this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            }else
            {
                this.BackColor = System.Drawing.SystemColors.WindowFrame;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
