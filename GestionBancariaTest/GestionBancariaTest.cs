using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GestionBancariaAppNS;

namespace GestionBancariaTest
{
    [TestClass]
    public class GestionBancariaTest
    {
        [TestMethod]
        [DataRow(1000, 250 , 750)]
        public void ValidarReintegro (double saldoInicial, double reintegro,
            double saldoFinal) //MINB2324 método para comprobar el reintegro
        {

            GestionBancariaApp miApp = new
                GestionBancariaApp (saldoInicial);
          
                miApp.RealizarReintegro(reintegro);


            Assert.AreEqual(saldoFinal, miApp.ObtenerSaldo(), 0.001, "Se produjo un error al realizar " +
                "el reintegro, saldo incorrecto");
             
            }
        [TestMethod]
        [DataRow(1000, -250, 750)]
        [ExpectedException (typeof (ArgumentOutOfRangeException))]
        public void ValidarReintegroInsuficiente(double saldoInicial, double reintegro,
            double saldoFinal) //MINB2324 método para comprobar el reintegro
            {
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            
            miApp.RealizarReintegro(reintegro); //MINB2324

            Assert.AreEqual(saldoFinal, miApp.ObtenerSaldo(), 0.001, "Se produjo un error al realizar " +
                "el reintegro, saldo incorrecto");

            }

        [TestMethod]
        [DataRow(1000, 1250, 750)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidarReintegroSaldoInsuficiente(double saldoInicial, double reintegro,
            double saldoFinal) //MINB2324 método para comprobar el reintegro
            {

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
                miApp.RealizarReintegro(reintegro);

            Assert.AreEqual(saldoFinal, miApp.ObtenerSaldo(), 0.001, "Se produjo un error al realizar " +
            "el reintegro, saldo incorrecto");

            }

        [TestMethod]
        [DataRow (1000 ,250 ,1250)]
        public void ValidarIngreso(double saldoInicial , double ingreso,
            double saldoFinal) //MINB2324 método para comprobar el ingreso
        {

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
                miApp.RealizarIngreso(ingreso);

            Assert.AreEqual(saldoFinal, miApp.ObtenerSaldo(), 0.001, "Se produjo un error al realizar " +
            "el ingreso, saldo incorrecto");

            }
        [TestMethod]
        [DataRow(1000,-250,1250)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidarIngresoNegativo(double saldoInicial, double ingreso,
            double saldoFinal) //MINB2324 método para comprobar el ingreso
            { 

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            
                miApp.RealizarIngreso(ingreso);
            Assert.AreEqual(saldoFinal, miApp.ObtenerSaldo(), 0.001, "Se produjo un error al realizar " +
            "el ingreso, saldo incorrecto");
            }
        }
}
