using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otro2048_Csharp.clases
{
    internal class ProcesaCuadrados
    {

        /// <summary>
        /// Sube todos los cuadrados con valor mayor a cero hacia arriba dejando los ceros abajo. Retorna true si efectuó alguna modificación en el Array de cuadradosDelTablero.
        /// </summary>
        /// <param name="cuadrados"></param>
        public bool limpiarCeros(Cuadrado[,] cuadrados)
        {
            bool result = false;
            int[] cant0PorCol = contarCeros(cuadrados);
            for (int i=0; i< 4; i++)
            {
                switch (cant0PorCol[i])
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        if (cuadrados[1, i].getValor()!=0)
                        {
                            cuadrados[0, i].setValor(cuadrados[1, i].getValor());
                            cuadrados[1, i].setValor(0);
                            result = true;

                        }
                        else if (cuadrados[2, 1].getValor() != 0)
                        {
                            cuadrados[0, i].setValor(cuadrados[2, i].getValor());
                            cuadrados[2, 1].setValor(0);
                            result = true;
                        }
                        else if (cuadrados[3, i].getValor() != 0)
                        {
                            cuadrados[0, i].setValor(cuadrados[3, i].getValor());
                            cuadrados[3, i].setValor(0);
                            result = true;
                        }
                        break;

                }
            }
            return result;
        }

        public int[] contarCeros(Cuadrado[,] cuadrados)
        {
            int[] result= new int[4];
            int cont = 0;
            for (int j=0;j<4;j++)
            {
                for (int i=0; i<4;i++)
                {
                    if (cuadrados[i, j].getValor() == 0)
                    {
                        cont++;
                    }
                }
                result[j] = cont;
                cont = 0;
            }
            return result;
        }

        



        //detectarConsecutivos


    }
}
