using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBancariaAppNS
{
    public partial class GestionBancariaApp : Form
    {
        private double saldo;  
        public const string ERR_CANTIDAD_NO_VALIDA = "Cantidad no válida"; //MINB2324 
        public const string ERR_SALDO_INSUFICIENTE = "Saldo insuficiente";

        public GestionBancariaApp(double saldo = 0)
        {
            InitializeComponent();
            if (saldo > 0)
                this.saldo = saldo;
            else
                this.saldo = 0;
            txtSaldo.Text = ObtenerSaldo().ToString();
            txtCantidad.Text = "0";
        }

        public double ObtenerSaldo() { return saldo; }

        public int RealizarReintegro(double cantidad) 
        {
            if (cantidad <= 0)
                throw new ArgumentOutOfRangeException(ERR_CANTIDAD_NO_VALIDA); // MINB2324
            if (saldo < cantidad)
                throw new ArgumentOutOfRangeException(ERR_SALDO_INSUFICIENTE);
            saldo -= cantidad;
            return 0;
        }

        public int RealizarIngreso(double cantidad) {
            if (cantidad < 0)
                throw new ArgumentOutOfRangeException(ERR_CANTIDAD_NO_VALIDA);
            saldo += cantidad; // MINB2424 se ha corregido el codigo
            return 0;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidad = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (rbReintegro.Checked)
                {
                try
                    {
                    RealizarReintegro(cantidad);
                    MessageBox.Show("Transacción realizada"); //MINB2324
                    }
                catch (Exception error) {
                    if (error.Message.Contains(ERR_SALDO_INSUFICIENTE))
                        MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
                    else
                    if (error.Message.Contains(ERR_CANTIDAD_NO_VALIDA))
                        MessageBox.Show("Cantidad no válida, sólo se admiten cantidades positivas.");
                    }
                }
            else
                {
                try
                    {
                    RealizarIngreso(cantidad);
                    MessageBox.Show("Transacción realizada");
                    }
                catch (Exception error)
                    {
                    if (error.Message.Contains(ERR_CANTIDAD_NO_VALIDA))
                        MessageBox.Show("Cantidad no válida, sólo se admiten cantidades positivas.");

                    }
            }
           txtSaldo.Text = ObtenerSaldo().ToString();
        }
    }
}
