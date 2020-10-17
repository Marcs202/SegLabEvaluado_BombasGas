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
    public partial class Form1 : Form
    {
        double PreRegular, PreEspecial, PreDiecel;
       
        Bombas Bomba1 = new Bombas();
        Bombas Bomba2 = new Bombas();
        Bombas Bomba3 = new Bombas();
        Bombas Bomba4 = new Bombas();
        Bombas Bomba5 = new Bombas();
        Bombas Bomba6 = new Bombas();

        Validaciones validar = new Validaciones();
        public Form1()
        {
            InitializeComponent();            
            PreRegular = Convert.ToDouble(labelRegular.Text);
            PreEspecial = Convert.ToDouble(labelEspecial.Text);
            PreDiecel = Convert.ToDouble(labelDiesel.Text);
            cmbBomba1.SelectedIndex = 0;
            cmbBomba2.SelectedIndex = 0;
        }
        private void cmbBomba1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambiarAlCambiarCmb(cmbBomba1,txtDolaresB1);
        }
        private void cmbBomba2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambiarAlCambiarCmb(cmbBomba2,txtDolareB2);
        }
        private void cmbBomba3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambiarAlCambiarCmb(cmbBomba3, txtDolareB3);
        }
        private void cmbBomba4_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambiarAlCambiarCmb(cmbBomba4, txtDolaresB4);
        }
        private void cmbBomba5_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambiarAlCambiarCmb(cmbBomba5, txtDolaresB5);
        }
        private void cmbBomba6_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambiarAlCambiarCmb(cmbBomba6, txtDolaresB6);
        }
        private void cambiarAlCambiarCmb(ComboBox cmbBomba,TextBox txtd)
        {
            if (cmbBomba.SelectedIndex == 0)
            {
                txtd.Text = PreRegular.ToString();
            }
            else if (cmbBomba.SelectedIndex == 1)
            {
                txtd.Text = PreEspecial.ToString();
            }
            else
            {
                txtd.Text = PreDiecel.ToString();
            }
        }
        private void btnLlenarBombas_Click(object sender, EventArgs e)
        {
            llenar(Bomba1, lblRegularB1,lblEspecialB1,lblDieselB1);
            llenar(Bomba2, lblRegularB2, lblEspecialB2, lblDieselB2);
            llenar(Bomba3, lblRegularB3, lblEspecialB3, lblDieselB3);
            llenar(Bomba4, lblRegularB4, lblEspecialB4, lblDieselB4);
            llenar(Bomba5, lblRegularB5, lblEspecialB5, lblDieselB5);
            llenar(Bomba6, lblRegularB6, lblEspecialB6, lblDieselB6);

        }
        private void llenar(Bombas bmb,Label lblR, Label lblE, Label lblD)
        {
            //metodo para llenar una bomba a sus capacidades maximas
            bmb.TanqueR.Galones = 800;
            lblR.Text = 800.ToString();
            bmb.TanqueE.Galones = 600;
            lblE.Text = 600.ToString();
            bmb.TanqueD.Galones = 800;
            lblD.Text = 800.ToString();
        }
        private void btmCambiarPrecio_Click(object sender, EventArgs e)
        {
            if (validar.ValidarCamposNumericos(txtPrecioGasolinaRegular) && validar.ValidarCamposNumericos(txtPrecioGasolinaRegular)
                && validar.ValidarCamposNumericos(txtPrecioDiesel))
            {
                PreRegular = Convert.ToDouble(txtPrecioGasolinaRegular.Text);
                PreEspecial = Convert.ToDouble(txtPrecioGasolinaEspecial.Text);
                PreDiecel = Convert.ToDouble(txtPrecioDiesel.Text);
                labelRegular.Text = PreRegular.ToString();
                labelEspecial.Text = PreEspecial.ToString();
                labelDiesel.Text = PreDiecel.ToString();
            }
            else
            {
                var mensaje = MessageBox.Show("Los datos ingresados para el cambio de precio no son admitidos, volveran al valor por defecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (mensaje == DialogResult.OK)
                {
                    txtPrecioGasolinaRegular.Text = "3.95";
                    txtPrecioGasolinaEspecial.Text = "4.45";
                    txtPrecioDiesel.Text = "4.25";
                }
            }
        }
        //Evento para cuando se haga el cambio de precio, se vea reflejado automaticamente en los combobox de las bombas
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Se cambian los item seleccionados ya que estan programados para cambiar de precio al cambiar de item
            cmbBomba1.SelectedIndex = 0;
            cmbBomba1.SelectedIndex = 1;
            cmbBomba1.SelectedIndex = 0;
            
            cmbBomba2.SelectedIndex = 0;
            cmbBomba2.SelectedIndex = 1;
            cmbBomba2.SelectedIndex = 0;

            cmbBomba3.SelectedIndex = 0;
            cmbBomba3.SelectedIndex = 1;
            cmbBomba3.SelectedIndex = 0;

            cmbBomba4.SelectedIndex = 0;
            cmbBomba4.SelectedIndex = 1;
            cmbBomba4.SelectedIndex = 0;

            cmbBomba5.SelectedIndex = 0;
            cmbBomba5.SelectedIndex = 1;
            cmbBomba5.SelectedIndex = 0;

            cmbBomba6.SelectedIndex = 0;
            cmbBomba6.SelectedIndex = 1;
            cmbBomba6.SelectedIndex = 0;
        }

        

       
        
        private void btnDespachar_Click(object sender, EventArgs e)
        {

            //para así hacer el proceso indicado dependiendo del caso
            venta(Bomba1, cmbBomba1, labelRegular, labelEspecial, labelDiesel,lblRegularB1,lblEspecialB1,lblDieselB1,txtGalonesB1,txtDolaresB1);
            /*if (cmbBomba1.SelectedIndex==0)
            {
                PreRegular = double.Parse(labelRegular.Text);
                int validado = validar.ValidarParaProceso(PreRegular, txtGalonesB1, txtDolaresB1);//verifica cual textbox se ingreso datos 
                if (validado == 1 || validado ==3)
                {
                    //Si si ingreso por dolares
                    
                    Bomba1.DespacharGasolinaBomba(PreRegular, txtGalonesB1, txtDolaresB1);
                    lblRegularB1.Text = Bomba1.TanqueR.Galones.ToString();
                }
                else if (validado == 2)
                {
                    //Si se ingreso por galones
                    Bomba1.DespacharGasolinaBomba( txtGalonesB1, txtDolaresB1, PreRegular);
                    lblRegularB1.Text = Bomba1.TanqueR.Galones.ToString();
                }
            }
            else if (cmbBomba1.SelectedIndex==1)
            {
                PreEspecial = double.Parse(labelEspecial.Text);
                int validado = validar.ValidarParaProceso(PreEspecial, txtGalonesB1, txtDolaresB1);//verifica cual textbox se ingreso datos 
                if (validado==1|| validado==3)
                {
                    Bomba1.DespacharEspecialBomba(PreEspecial, txtGalonesB1, txtDolaresB1);
                    lblEspecialB1.Text = Bomba1.TanqueE.Galones.ToString();
                }
                else if (validado == 2)
                {
                    Bomba1.DespacharEspecialBomba(txtGalonesB1, txtDolaresB1, PreEspecial);
                    lblEspecialB1.Text = Bomba1.TanqueE.Galones.ToString();
                }
            }
            else if (cmbBomba1.SelectedIndex == 2)
            {
                PreDiecel = double.Parse(labelDiesel.Text);
                int validado = validar.ValidarParaProceso(PreDiecel, txtGalonesB1, txtDolaresB1);//verifica cual textbox se ingreso datos 
                if (validado == 1 || validado == 3)
                {
                    Bomba1.DespacharDieselBomba(PreDiecel, txtGalonesB1, txtDolaresB1);
                    lblDieselB1.Text = Bomba1.TanqueD.Galones.ToString();
                }
                else if (validado == 2)
                {
                    Bomba1.DespacharDieselBomba(txtGalonesB1, txtDolaresB1, PreDiecel);
                    lblDieselB1.Text = Bomba1.TanqueD.Galones.ToString();
                }
            }*/

        }

        private void btnDespacharBomba3_Click(object sender, EventArgs e)
        {            
            venta(Bomba3, cmbBomba3, labelRegular, labelEspecial, labelDiesel, lblRegularB3, lblEspecialB3, lblDieselB2, txtGalonesB2, txtDolareB2);
        }

        private void btnDespacharBomba4_Click(object sender, EventArgs e)
        {
            venta(Bomba3, cmbBomba3, labelRegular, labelEspecial, labelDiesel, lblRegularB4, lblEspecialB4, lblDieselB4, txtGalonesB4, txtDolaresB4);
        }

        private void btnDespacharBomba5_Click(object sender, EventArgs e)
        {
            venta(Bomba3, cmbBomba3, labelRegular, labelEspecial, labelDiesel, lblRegularB5, lblEspecialB5, lblDieselB5, txtGalonesB5, txtDolaresB5);
        }

        private void btnDespacharBomba6_Click(object sender, EventArgs e)
        {
            venta(Bomba3, cmbBomba3, labelRegular, labelEspecial, labelDiesel, lblRegularB6, lblEspecialB6, lblDieselB6, txtGalonesB6, txtDolaresB6);   
        }

        private void btnDespacharBomba2_Click(object sender, EventArgs e)
        {
            
            venta(Bomba2,cmbBomba2,labelRegular,labelEspecial,labelDiesel,lblRegularB2,lblEspecialB2,lblDieselB2,txtGalonesB2,txtDolareB2);
            /*if (cmbBomba2.SelectedIndex == 0)
            {
                PreRegular = double.Parse(labelRegular.Text);
                int validado = validar.ValidarParaProceso(PreRegular, txtGalonesB1, txtDolaresB1);//verifica cual textbox se ingreso datos 
                if (validado == 1 || validado == 3)
                {
                    //Si si ingreso por dolares

                    Bomba2.DespacharGasolinaBomba(PreRegular, txtGalonesB1, txtDolaresB1);
                    lblRegularB2.Text = Bomba2.TanqueR.Galones.ToString();
                }
                else if (validado == 2)
                {
                    //Si se ingreso por galones
                    Bomba2.DespacharGasolinaBomba(txtGalonesB1, txtDolaresB1, PreRegular);
                    lblRegularB2.Text = Bomba2.TanqueR.Galones.ToString();
                }
            }
            else if (cmbBomba2.SelectedIndex == 1)
            {
                PreEspecial = double.Parse(labelEspecial.Text);
                int validado = validar.ValidarParaProceso(PreEspecial, txtGalonesB1, txtDolaresB1);//verifica cual textbox se ingreso datos 
                if (validado == 1 || validado == 3)
                {
                    Bomba2.DespacharEspecialBomba(PreEspecial, txtGalonesB1, txtDolaresB1);
                    lblEspecialB2.Text = Bomba2.TanqueE.Galones.ToString();
                }
                else if (validado == 2)
                {
                    Bomba2.DespacharEspecialBomba(txtGalonesB1, txtDolaresB1, PreEspecial);
                    lblEspecialB2.Text = Bomba2.TanqueE.Galones.ToString();
                }
            }
            else if (cmbBomba2.SelectedIndex == 2)
            {
                PreDiecel = double.Parse(labelDiesel.Text);
                int validado = validar.ValidarParaProceso(PreDiecel, txtGalonesB1, txtDolaresB1);//verifica cual textbox se ingreso datos 
                if (validado == 1 || validado == 3)
                {
                    Bomba2.DespacharDieselBomba(PreDiecel, txtGalonesB1, txtDolaresB1);
                    lblDieselB2.Text = Bomba2.TanqueD.Galones.ToString();
                }
                else if (validado == 2)
                {
                    Bomba2.DespacharDieselBomba(txtGalonesB1, txtDolaresB1, PreDiecel);
                    lblDieselB2.Text = Bomba2.TanqueD.Galones.ToString();
                }
            }*/
        }
        //pide la boma, el combobox de cada bomba,el label del precio(que se encuentra arriba en la visual), y los 3 label a editar del 
        //tabpage de adminstracion, captura ambos  textbox de la bomba
        private void venta(Bombas b, ComboBox cmb, Label lblR, Label lblE, Label lblD,Label lblRegularAdm,Label lblEspecialAdm,Label lblDieselAdm, TextBox txtGalon, TextBox txtDolar)
        {
            if (cmb.SelectedIndex == 0)
            {
                PreRegular = double.Parse(lblR.Text);
                int validado = validar.ValidarParaProceso(PreRegular, txtGalon, txtDolar);//verifica cual textbox se ingreso datos 
                if (validado == 1 || validado == 3)
                {
                    //Si si ingreso por dolares

                    b.DespacharGasolinaBomba(PreRegular, txtGalon, txtDolar);
                    lblRegularAdm.Text = b.TanqueR.Galones.ToString();
                }
                else if (validado == 2)
                {
                    //Si se ingreso por galones
                    b.DespacharGasolinaBomba(txtGalon, txtDolar, PreRegular);
                    lblRegularAdm.Text = b.TanqueR.Galones.ToString();
                }
            }
            else if (cmb.SelectedIndex == 1)
            {
                PreEspecial = double.Parse(lblE.Text);
                int validado = validar.ValidarParaProceso(PreEspecial, txtGalon, txtDolar);//verifica cual textbox se ingreso datos 
                if (validado == 1 || validado == 3)
                {
                    b.DespacharEspecialBomba(PreEspecial, txtGalon, txtDolar);
                    lblEspecialAdm.Text = b.TanqueE.Galones.ToString();
                }
                else if (validado == 2)
                {
                    b.DespacharEspecialBomba(txtGalon, txtDolar, PreEspecial);
                    lblEspecialAdm.Text = b.TanqueE.Galones.ToString();
                }
            }
            else if (cmb.SelectedIndex == 2)
            {
                PreDiecel = double.Parse(lblD.Text);
                int validado = validar.ValidarParaProceso(PreDiecel, txtGalon, txtDolar);//verifica cual textbox se ingreso datos 
                if (validado == 1 || validado == 3)
                {
                    b.DespacharDieselBomba(PreDiecel, txtGalon, txtDolar);
                    lblDieselAdm.Text = b.TanqueD.Galones.ToString();
                }
                else if (validado == 2)
                {
                    b.DespacharDieselBomba(txtGalon, txtDolar, PreDiecel);
                    lblDieselAdm.Text = b.TanqueD.Galones.ToString();
                }
            }
        }
    }
}
