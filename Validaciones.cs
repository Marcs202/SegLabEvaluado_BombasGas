using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegLabEvaluado_BombasGas
{
    class Validaciones
    {
        public Validaciones()
        {

        }
        public bool ValidarCamposNumericos(TextBox txt)
        {
            bool ok = true;
            double numero;
            if (double.TryParse(txt.Text, out numero))
            {
                ok = true;
            }
            else
            {
                ok = false;
            }
            return ok;
        } 
        public  int ValidarParaProceso(double PreRegular, TextBox txtGalonPedido, TextBox txtPago)
        {
            // si clickea un textbox los demas se desactivan porque una bomba solo puede despachar un combustible a la vez
            if (ValidarCamposNumericos(txtGalonPedido) && ValidarCamposNumericos(txtPago))
            {
                if (Convert.ToDouble(txtGalonPedido.Text) != 1 && Convert.ToDouble(txtPago.Text) != PreRegular)
                {
                    var mensaje = MessageBox.Show("Ha cambiado el valor en ambos campos por favor solo cambie el valor en 1 de los 2 campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (mensaje == DialogResult.OK)
                    {
                        txtGalonPedido.Text = "1";
                        txtPago.Text  = PreRegular.ToString();
                        
                    }
                    return 0;
                }
                else if (Convert.ToDouble(txtGalonPedido.Text) != 1 && txtGalonPedido.Text != "")
                {
                    //se envia el 1 en caso que se vaya a realizar el pedido por galon
                    return 1;
                }
                else if (Convert.ToDouble(txtPago.Text) != PreRegular && txtPago.Text != "")
                {
                    //se envia 2 en caso que se vaya a a realizar el pedido por dinero
                    return 2;
                }
                else
                {
                    //El caso que no haya cambiado los datos
                    return 3;
                }
            }
            else
            {
                MessageBox.Show("Ingreso un tipo de dato no permitido, por favor ingrese numeros en los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPago.Text = PreRegular.ToString(); ;
                txtGalonPedido.Text = "1";
                return 0;
            }
        }
    }
}
