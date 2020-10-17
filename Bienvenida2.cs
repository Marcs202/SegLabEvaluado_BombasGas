using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegLabEvaluado_BombasGas
{
    public partial class Bienvenida2 : Form
    {
        public Bienvenida2()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 2000;           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.DialogResult = DialogResult.OK;
            Form1 form = new Form1();
            if (this.Visible == true)
            {
                form.Visible = true;
                this.Close();                
            }            
        }
    }
}
