using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otro2048_Csharp.clases
{
    internal class ProcesaCuadrados
    {
        FrmTablero frm;
        bool agregaCuadrado;

        public ProcesaCuadrados(FrmTablero form)
        {
            frm = form;
        }



        /// <summary>
        /// Sube todos los cuadrados con valor mayor a cero hacia arriba. Retorna true si efectuó alguna modificación en el Array de cuadradosDelTablero.
        /// </summary>
        /// <param name="cuadrados"></param>
        public void sumarNumeros(Cuadrado[,] cuadrados)
        {
            int[] cant0PorCol = contarCerosYSubirNumeros(frm);
            bool multiplico = false;
            for (int i = 0; i < 4; i++)
            {
                int valCua0i = cuadrados[0, i].getValor();
                int valCua1i = cuadrados[1, i].getValor();
                int valCua2i = cuadrados[2, i].getValor();
                int valCua3i = cuadrados[3, i].getValor();
                switch (cant0PorCol[i])
                {
                    case 0:
                        if ((valCua0i == valCua1i) && (valCua2i == valCua3i))
                        {
                            cuadrados[0, i].setValor(valCua0i * 2);
                            cuadrados[1, i].setValor(valCua2i*2);
                            cuadrados[2, i].setValor(0);
                            cuadrados[3, i].setValor(0);
                            frm.setCuadradosEnCero(frm.getCuadradosEnCero() - 1);
                            multiplico = true;
                            frm.setPuntos(valCua0i * 2 * 2);
                        }
                        else if (valCua0i == valCua1i)
                        {
                            cuadrados[0, i].setValor(valCua0i * 2);
                            cuadrados[1, i].setValor(valCua2i);
                            cuadrados[2, i].setValor(valCua3i);
                            cuadrados[3, i].setValor(0);
                            multiplico = true;
                            frm.setPuntos(valCua0i * 2);
                        }
                        else if (valCua1i == valCua2i)
                        {
                            cuadrados[1, i].setValor(valCua2i * 2);
                            cuadrados[2, i].setValor(valCua2i);
                            cuadrados[3, i].setValor(0);
                            multiplico = true;
                            frm.setPuntos(valCua2i * 2);
                        }
                        else if (valCua2i == valCua3i)
                        {
                            cuadrados[2, i].setValor(valCua2i * 2);
                            cuadrados[3, i].setValor(0);
                            multiplico = true;
                            frm.setPuntos(valCua2i * 2);
                        }
                        break;
                    case 1:
                        if (valCua0i == valCua1i)
                        {
                            cuadrados[0, i].setValor(valCua0i * 2);
                            cuadrados[1, i].setValor(valCua2i);
                            cuadrados[2, i].setValor(0);
                            multiplico = true;
                            frm.setPuntos(valCua0i * 2);
                        }
                        else if (valCua1i == valCua2i)
                        {
                            cuadrados[1, i].setValor(valCua1i * 2);
                            cuadrados[2, i].setValor(0);
                            multiplico = true;
                            frm.setPuntos(valCua1i * 2);
                        }
                        break;
                    case 2:
                        if (valCua0i == valCua1i)
                        {
                            cuadrados[0, i].setValor(valCua0i * 2);
                            cuadrados[1, i].setValor(0);
                            multiplico = true;
                            frm.setPuntos(valCua0i * 2);
                        }
                        break;
                }
            }
            if ((multiplico == true) && (agregaCuadrado == false))
            {
                frm.getTablero().setValorAzarCuadradoAzarSiValorEs0(1);
                frm.setCuadradosEnCero(frm.getCuadradosEnCero() + 1);
            }
        }

        /// <summary>
        /// Verifica si se puede sumar cuadrados hacia las cuatro direcciones del tablero. Returna true si perdió, osea que no hay más posibilidad de mover.
        /// </summary>
        /// <returns></returns>
        public bool verificaSiPerdio()
        {
            bool[] pruebas = new bool[4];
            for (int i = 0; i < 4; i++)
            {
                pruebas[i] = verificaSumaCuadrado(frm.getTablero().getArrayCuadradosDelTablero());
                frm.getTablero().rotarTablero90DerechaXVeces(1);
            }
            MessageBox.Show("" + pruebas[0] + pruebas[1] + pruebas[2] + pruebas[3]);
            if (pruebas[0] || pruebas[1] || pruebas[2] || pruebas[3])
            {
                return false;
            }
            else
            {
                MessageBox.Show("PERDISTE WACHINNNNNNNNNNNNNNN!");
                return true;
            }
        }

        /// <summary>
        /// Verifica la posibilidad de sumar cuadrados en el tablero y retorna true en el caso de ser posible. No modifica nada en el tablero.
        /// </summary>
        /// <param name="cuadrados"></param>
        /// <returns></returns>
        public bool verificaSumaCuadrado(Cuadrado[,] cuadrados)
        {
            int[] cant0PorCol = soloContarCeros(frm);
            bool multiplico = false;
            for (int i = 0; i < 4; i++)
            {
                int valCua0i = cuadrados[0, i].getValor();
                int valCua1i = cuadrados[1, i].getValor();
                int valCua2i = cuadrados[2, i].getValor();
                int valCua3i = cuadrados[3, i].getValor();
                switch (cant0PorCol[i])
                {
                    case 0:
                        if ((valCua0i == valCua1i) && (valCua2i == valCua3i) && (valCua0i != 0 && valCua1i != 0 && valCua2i != 0 && valCua3i != 0))
                        {
                            multiplico = true;
                        }
                        else if ((valCua0i == valCua1i) && (valCua0i != 0 && valCua1i != 0))
                        {
                            multiplico = true;
                        }
                        else if ((valCua1i == valCua2i) && (valCua1i != 0 && valCua2i != 0))
                        {
                            multiplico = true;
                        }
                        else if ((valCua2i == valCua3i) && (valCua2i != 0 && valCua3i != 0))
                        {
                            multiplico = true;
                        }
                        break;
                    case 1:
                        if ((valCua0i == valCua1i) && (valCua0i != 0 && valCua1i != 0))
                        {
                            multiplico = true;
                        }
                        else if ((valCua1i == valCua2i) && (valCua1i != 0 && valCua2i != 0))
                        {
                            multiplico = true;
                        }
                        break;
                    case 2:
                        if ((valCua0i == valCua1i) && (valCua0i != 0 && valCua1i != 0))
                        {
                            multiplico = true;
                        }
                        break;
                }

            }
            //MessageBox.Show("Puede sumar: " + multiplico);
            return multiplico;
        }

        /// <summary>
        /// Cuenta los ceros que hay en cada columna j del Array de cuadradosDelTablero y devuelve un array con la cantidad de ceros por columna. También sube todos los números diferentes de cero hacia arriba sin dejar ceros entre números mayores que cero.
        /// </summary>
        /// <param name="cuadrados"></param>
        /// <returns></returns>
        public int[] contarCerosYSubirNumeros(FrmTablero tablero)
        {
            agregaCuadrado = false;
            Cuadrado[,] cuadrados = tablero.getTablero().getArrayCuadradosDelTablero();
            int[] result = new int[4];
            int cont = 0;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (cuadrados[i, j].getValor() == 0)
                    {

                        if ((i == 0) && cuadrados[i + 1, j].getValor() != 0)
                        {
                            cuadrados[i, j].setValor(cuadrados[i + 1, j].getValor());
                            cuadrados[i + 1, j].setValor(0);
                            cont--;
                            agregaCuadrado = true;
                        }
                        else if ((i == 1) && cuadrados[i + 1, j].getValor() != 0)
                        {
                            if (cuadrados[i - 1, j].getValor() == 0)
                            {
                                cuadrados[i - 1, j].setValor(cuadrados[i + 1, j].getValor());
                                cuadrados[i + 1, j].setValor(0);
                                agregaCuadrado = true;
                                cont--;
                            }
                            else
                            {
                                cuadrados[i, j].setValor(cuadrados[i + 1, j].getValor());
                                cuadrados[i + 1, j].setValor(0);
                                agregaCuadrado = true;
                                cont--;
                            }

                        }
                        else if ((i == 2) && cuadrados[i + 1, j].getValor() != 0)
                        {
                            if (cuadrados[i - 2, j].getValor() == 0)
                            {
                                cuadrados[i - 2, j].setValor(cuadrados[i + 1, j].getValor());
                                cuadrados[i + 1, j].setValor(0);
                                agregaCuadrado = true;
                                cont--;
                            }
                            else if (cuadrados[i - 1, j].getValor() == 0)
                            {
                                cuadrados[i - 1, j].setValor(cuadrados[i + 1, j].getValor());
                                cuadrados[i + 1, j].setValor(0);
                                agregaCuadrado = true;
                                cont--;
                            }
                            else
                            {
                                cuadrados[i, j].setValor(cuadrados[i + 1, j].getValor());
                                cuadrados[i + 1, j].setValor(0);
                                agregaCuadrado = true;
                                cont--;
                            }
                        }
                        ++cont;
                    }
                }
                result[j] = cont;
                cont = 0;
            }

            if (agregaCuadrado)
            {
                tablero.setCuadradosEnCero(result[0] + result[1] + result[2] + result[3]);
                frm.getTablero().setValorAzarCuadradoAzarSiValorEs0(1);
            }
            else
            {
                tablero.setCuadradosEnCero(result[0] + result[1] + result[2] + result[3]);
            }
            return result;
        }

        /// <summary>
        /// Solo cuenta los ceros y retorna el array con los ceros de cada columna, no sube los números.
        /// </summary>
        /// <param name="tablero"></param>
        /// <returns></returns>
        public int[] soloContarCeros(FrmTablero tablero)
        {
            Cuadrado[,] cuadrados = tablero.getTablero().getArrayCuadradosDelTablero();
            int[] result = new int[4];
            int cont = 0;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (cuadrados[i, j].getValor() == 0)
                    {

                        if ((i == 0) && cuadrados[i + 1, j].getValor() != 0)
                        {
                            cont--;
                        }
                        else if ((i == 1) && cuadrados[i + 1, j].getValor() != 0)
                        {
                            if (cuadrados[i - 1, j].getValor() == 0)
                            {
                                cont--;
                            }
                            else
                            {
                                cont--;
                            }

                        }
                        else if ((i == 2) && cuadrados[i + 1, j].getValor() != 0)
                        {
                            if (cuadrados[i - 2, j].getValor() == 0)
                            {
                                cont--;
                            }
                            else if (cuadrados[i - 1, j].getValor() == 0)
                            {
                                cont--;
                            }
                            else
                            {
                                cont--;
                            }
                        }
                        ++cont;
                    }
                }
                result[j] = cont;
                cont = 0;
            }
            //MessageBox.Show("Ceros: " + result[0] + result[1] + result[2] + result[3]);
            return result;
        }
    }
}
