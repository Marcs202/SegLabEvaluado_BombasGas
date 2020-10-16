using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegLabEvaluado_BombasGas
{
    class Diesel:Combustible
    {
        private double galones = 800;

        public double Galones { get => galones; set => galones = value; }

        public double Des(double p, TextBox txtGalonesPed, TextBox txtPago)
        {
            //Metodo para despachar por galon 
            precio = p;
            galonPedido = Convert.ToDouble(txtGalonesPed.Text);
            if (galones < galonPedido && galones > 0)
            {
                despacho = galones * precio;
                var msg = MessageBox.Show("No se pudieron dispensar los galones de diesel solicitados ya que no" +
                    " hay mas en el tanque, los galones dispensados son: " + galones.ToString() + " \n a un precio de: " + despacho.ToString(), "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Cuando el usario de click al boton de ok del programa, este volvera a los valores por defecto
                if (msg == DialogResult.OK)
                {
                    txtPago.Text = Convert.ToString(precio);
                    txtGalonesPed.Text = "1";
                }
                galones = 0;

                return despacho;
                // Se retorna la cantidad de dinero a pagar por la cantidad de combustible disponible
            }
            else if (galones >= galonPedido || galones == galonPedido)
            {
                despacho = galonPedido * precio;
                galones = galones - galonPedido;
                var msg = MessageBox.Show("Los galones de diesel dispensados son: " + galonPedido.ToString() + " \n a un precio de: " + despacho.ToString(), "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (msg == DialogResult.OK)
                {
                    txtPago.Text = Convert.ToString(precio);
                    txtGalonesPed.Text = "1";
                }
                return despacho;
                //Si los galones de la bomba son mayores a los solicitados en tonces el combustible se despacha 
                //con normalidad devolviendo el precio total
            }
            else
            {
                MessageBox.Show("Tanque de la bomba agotado, no se hará la venta ", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                despacho = 0;
                return despacho; //si no hay galones a despachar el cobro es 0
            }

        }
        public double Des(TextBox txtGalonesPed, TextBox txtPago, double p)
        {//Para despachar por dinero
            precio = p;
            dinero = Convert.ToDouble(txtPago.Text);
            galonPedido = dinero / precio;
            if (galones < galonPedido && galones > 0)
            {
                double pagoreal = galones * precio;
                despacho = galones;
                galones = galones - despacho;
                var msg = MessageBox.Show("No se pudieron dispensar los galones de diesel solicitados ya que no" +
                    " hay mas en el tanque, los galones dispensados son: " + despacho.ToString() +
                    " \n a un precio de: " + pagoreal.ToString(), "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (msg == DialogResult.OK)
                {
                    txtPago.Text = Convert.ToString(precio);
                    txtGalonesPed.Text = "1";
                }
                return despacho;// Se retorna la cantidad de galones dispensados
            }
            else if (galones > galonPedido || galones == galonPedido)
            {
                despacho = galonPedido;
                galones = galones - despacho;
                var msg = MessageBox.Show("Los galones de diesel dispensados son: " + despacho.ToString() + " \n a un precio de: " + dinero.ToString(), "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (msg == DialogResult.OK)
                {
                    txtPago.Text = Convert.ToString(precio);
                    txtGalonesPed.Text = "1";
                }
                return despacho;
                //Si los galones de la bomba son mayores a los solicitados en tonces el combustible se despacha 
                //con normalidad y devuelve el valor en galones
            }
            else
            {
                MessageBox.Show("Tanque de la bomba agotado, no se hará la venta ", "Precaucion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                despacho = 0;
                return 0; //si no hay galones a despachar el cobro es 0
            }
        }
    }
}
