using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GirarPantalla
{
    public partial class MainPage : ContentPage
    {
        int estado = 1;
        string operador;
        double valor1, valor2;

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private double width = 0;
        private double height = 0;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height); //must be called
            if (this.width != width || this.height != height)
            {
                this.width = width;
                this.height = height;

                if (width > height)
                {

                    Navigation.PushModalAsync(new Page1());

                }
              //  DisplayAlert("Cambio", $"Ancho: {this.width} Alto: {this.height}","Cerrar");
            }
        }

        private void Valor_Seleccionado(object sender, EventArgs e)
        {
            Button boton = (Button)sender;


            string presionado = boton.Text;

            if (this.resultado.Text == "0" || estado < 0)
            {
                this.resultado.Text = "";

                if (estado < 0)
                    estado *= -1;
            }

            this.resultado.Text += presionado;

            double number;
            if (double.TryParse(this.resultado.Text, out number))
            {
                this.resultado.Text = number.ToString("N0");
                if (estado == 1)
                {
                    valor1 = number;
                }
                else
                {
                    valor2 = number;
                }
            }
        }
        private void Operador_Seleccionado(object sender, EventArgs e)
        {
            estado = -2;
            Button button = (Button)sender;
            string presionado = button.Text;
            operador = presionado;
            this.resultado.Text = presionado;
        }

        private void Borrado_Seleccionado(object sender, EventArgs e)
        {
            valor1 = 0;
            valor2 = 0;
            estado = 1;
            this.resultado.Text = "0";
        }

        double Operar(double valor1, double valor2, string operador)
        {
            double resultado = 0;
            switch (operador)
            {
                case "÷":
                    resultado = valor1 / valor2;
                    break;
                case "x":
                    resultado = valor1 * valor2;
                    break;
                case "+":
                    resultado = valor1 + valor2;
                    break;
                case "-":
                    resultado = valor1 - valor2;
                    break;
            }
            return resultado;
        }

        void Calcular(object sender, EventArgs e)
        {
            if (estado == 2)
            {
                var resultado = Operar(valor1, valor2, operador);

                this.resultado.Text = resultado.ToString();
                valor1 = resultado;
            }
        }

    }
}

