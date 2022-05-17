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
        private Cuadrado[,] cuadradosDelTablero = new Cuadrado[4, 4];
        FrmTablero frm;

        public Tablero(FrmTablero form)
        {
            frm = form;
            this.generarTableroNuevo(form);

        }


        /// <summary>
        /// Devuelve el Cuadrado ubicado en la posición i, j del Array cuadradosDelTablero.
        /// </summary>
        public Cuadrado getCuadradoTablero(int i, int j)
        {
            return cuadradosDelTablero[i, j];
        }

        /// <summary>
        /// Obtiene el Array de Cuadrado del tablero.
        /// </summary>
        public Cuadrado[,] getArrayCuadradosDelTablero()
        {
            return cuadradosDelTablero;
        }

        /// <summary>
        /// Guarda el Array de Cuadrado del tablero.
        /// </summary>
        public void setArrayCuadradosDelTablero(Cuadrado[,] cuadrados)
        {
            cuadradosDelTablero = cuadrados;
        }

        /// <summary>
        /// Fija la posición del Cuadrado en la posición posX, posY del frmTablero.
        /// </summary>
        public void setPosicionCuadrado(int i, int j, int posX, int posY)
        {
            this.getCuadradoTablero(i, j).Location = new Point(posX, posY);
        }

        /// <summary>
        /// Modifica el valor del Cuadrado ubicado en la posición i, j del Array cuadradosDelTablero.
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
            int[] val = { 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048 };
            Random rand = new Random();
            this.setValorCuadrado(rand.Next(0, 4), rand.Next(0, 4), val[rand.Next(0, hasta)]);
        }

        /// <summary>
        /// Modifica el valor con un numero por parametro de un Cuadrado ubicado en una posición aleatorea del Array.
        /// </summary>
        public void setValorAzarCuadradoAzarSiValorEs0(int hasta)
        {
            if (hasta>10) {
                hasta = 10;
            }
            int[] val = { 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048 };
            Random rand = new Random();
            bool encontro = false;
            int i;
            int j;
            int valor;
            do {
                i = rand.Next(0, 4);
                j = rand.Next(0, 4);
                valor = val[rand.Next(0, hasta)];
                if (cuadradosDelTablero[i, j].getValor() == 0)
                {
                    this.setValorCuadrado(i, j, valor);
                    frm.setCuadradosEnCero(frm.getCuadradosEnCero() - 1);
                    encontro = true;
                }
            } while ((frm.getCuadradosEnCero() > 0)&&(encontro == false));
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
        public void generarTableroNuevo(FrmTablero form)
        {
            int posX = 3;
            int posY = 3;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    cuadradosDelTablero[i, j] = new Cuadrado(0);
                    form.getPnlCuadrados().Controls.Add(this.getCuadradoTablero(i, j));
                    this.setPosicionCuadrado(i, j, posX, posY);
                    posX += 93;
                }
                posY += 93;
                posX = 3;
            }
            this.setValorAzarCuadradoAzarSiValorEs0(1);
            this.setValorAzarCuadradoAzarSiValorEs0(1);
        }
        /// <summary>
        /// Genera un tablero nuevo poblado con todos numeros al azar para poder hacer testing.
        /// </summary>
        /// <param name="form"></param>
        public void generarTableroNuevoTesting(FrmTablero form)
        {
            int posX = 3;
            int posY = 3;
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    cuadradosDelTablero[i, j] = new Cuadrado(rand.Next(2, 100));
                    form.getPnlCuadrados().Controls.Add(this.getCuadradoTablero(i, j));
                    this.setPosicionCuadrado(i, j, posX, posY);
                    posX += 93;
                }
                posY += 93;
                posX = 3;
            }
            this.setValorAzarCuadradoAzarSiValorEs0(1);
            this.setValorAzarCuadradoAzarSiValorEs0(1);
        }

        /// <summary>
        /// Pinta todos los cuadrados en el tablero.
        /// </summary>
        /// <param name="form"></param>
        public void refrescarTablero(FrmTablero form)
        {
            form.getPnlCuadrados().Controls.Clear();
            int posX = 3;
            int posY = 3;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    form.getPnlCuadrados().Controls.Add(this.getCuadradoTablero(i, j));
                    this.setPosicionCuadrado(i, j, posX, posY);
                    posX += 93;
                }
                posY += 93;
                posX = 3;
            }
        }

        

        /// <summary>
        /// Rota el tablero 90° y repite las veces que se pasen por parametro.
        /// </summary>
        public void rotarTablero90DerechaXVeces(int veces)
        {
            for (int x=0; x <veces; x++) 
            {
                Cuadrado[,] arrTemp = new Cuadrado[4, 4];
                int n = 4;
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        arrTemp[i, j] = cuadradosDelTablero[n - j - 1, i];
                    }
                }
                cuadradosDelTablero = arrTemp;
            }
            
        }
    }
}
