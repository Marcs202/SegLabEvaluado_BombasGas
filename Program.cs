using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegLabEvaluado_BombasGas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bienvenida Primera = new Bienvenida();
            if (Primera.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Bienvenida2());                
            }            
        }
    }
}
