using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegLabEvaluado_BombasGas
{
    class Combustible
    {
        protected double precio;//
        protected double dinero;//
        protected double galonPedido;//
        protected double despacho;//

        public double Precio { get => precio; set => precio = value; }
        public double Despacho { get => despacho; set => despacho = value; }
        public double Dinero { get => dinero; set => dinero = value; }
        public double GalonPedido { get => galonPedido; set => galonPedido = value; }
       
    }
}
