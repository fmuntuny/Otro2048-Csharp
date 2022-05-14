using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otro2048_Csharp.clases
{
    internal class Tablero
    {
        private Cuadrado[,] cuadradosDelTablero = new Cuadrado[4,4];
        private Form frmTablero;


        public Tablero(Form form) 
        {
            frmTablero = form;
            this.generarTablero(frmTablero);
            
        }

        /// <summary>
        /// Devuelve el Cuadrado ubicado en la posición i, j del Array.
        /// </summary>
        public Cuadrado getCuadradoTablero(int i, int j) 
        {
            return cuadradosDelTablero[i, j];
        }

        /// <summary>
        /// Fija la posición del Cuadrado en la posición posX, posY del frmTablero.
        /// </summary>
        public void setPosicionCuadrado(int i, int j, int posX, int posY ) 
        {
            this.getCuadradoTablero(i,j).Location = new Point(posX, posY);
        }

        /// <summary>
        /// Modifica el valor del Cuadrado ubicado en la posición i, j del Array.
        /// </summary>
        public void setValorCuadrado(int i, int j, int valor) 
        {
            cuadradosDelTablero[i, j].setValor(valor);
        }

        /// <summary>
        /// Modifica el valor con un numero al azar (potencias de 2 indicado por parametro de 0 a 10) de un Cuadrado ubicado en una posición aleatorea del Array.
        /// </summary>
        public void setValorAzarCuadradoAzar(int hasta) 
        {
            int[] val = { 2, 4, 8, 16, 32,64,128,256,512,1024,2048};
            Random rand = new Random();
            this.setValorCuadrado(rand.Next(0, 4), rand.Next(0, 4), val[rand.Next(0, 10)]);
        }

        /// <summary>
        /// Modifica el valor con un numero por parametro de un Cuadrado ubicado en una posición aleatorea del Array.
        /// </summary>
        public void setValorCuadradoAzar(int valor)
        {
            Random rand = new Random();
            this.setValorCuadrado(rand.Next(0, 4), rand.Next(0, 4), valor);
        }

        /// <summary>
        /// Crea un tablero nuevo.
        /// </summary>
        public void generarTablero(Form frmTablero) 
        {
            int posX = 3;
            int posY = 3;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    cuadradosDelTablero[i, j] = new Cuadrado(0);
                    frmTablero.Controls.Add(this.getCuadradoTablero(i,j));
                    this.setPosicionCuadrado(i, j, posX, posY);
                    posX += 93;
                }
                posY += 93;
                posX = 3;
            }
            this.setValorCuadradoAzar(2);
            this.setValorCuadradoAzar(4);
        }

    }
}
