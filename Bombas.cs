using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegLabEvaluado_BombasGas
{
    class Bombas
    {
        private GasRegular tanqueR = new GasRegular();
        private GasEspecial tanqueE = new GasEspecial();
        private Diesel tanqueD = new Diesel();
        public Bombas()
        {
        }

        public GasRegular TanqueR { get => tanqueR; set => tanqueR = value; }
        public GasEspecial TanqueE { get => tanqueE; set => tanqueE = value; }
        public Diesel TanqueD { get => tanqueD; set => tanqueD = value; }
        //Regular por galon
        public void DespacharGasolinaBomba(double p, TextBox txtGalonesPed, TextBox txtPago)
        {
            TanqueR.Des(p,txtGalonesPed,txtPago);
        }
        //Regular por dinero
        public void DespacharGasolinaBomba(TextBox txtGalonesPed, TextBox txtPago, double p)
        {
            TanqueR.Des( txtGalonesPed, txtPago, p);
        }
        //Especial por galon
        public void DespacharEspecialBomba(double p, TextBox txtGalonesPed, TextBox txtPago)
        {
            TanqueE.Des(p, txtGalonesPed, txtPago);
        }
        //Especial por dinero
        public void DespacharEspecialBomba(TextBox txtGalonesPed, TextBox txtPago, double p)
        {
            TanqueE.Des(txtGalonesPed, txtPago, p);
        }
        //Diesel por galon
        public void DespacharDieselBomba(double p, TextBox txtGalonesPed, TextBox txtPago)
        {
            TanqueD.Des(p, txtGalonesPed, txtPago);
        }
        //Diesel por Dinero
        public void DespacharDieselBomba(TextBox txtGalonesPed, TextBox txtPago, double p)
        {
            TanqueD.Des(txtGalonesPed, txtPago, p);
        }
    }
}
