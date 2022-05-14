﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otro2048_Csharp.clases
{
    
internal class Cuadrado : Label
    {
        private int valor;
        private Color colorFondo;
        /*
         */
        public Cuadrado(int val)
        {
            this.valor = val;
            this.Text = this.valor.ToString();
            this.Font = new Font("Papyrus", 30, FontStyle.Bold);
            this.BorderStyle = BorderStyle.Fixed3D;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.setColorFondo();
            this.Size = new Size(90,90);
            this.Visible = true;
        }

        public Cuadrado()
        {
            this.valor = val;
            this.Text = this.valor.ToString();
            this.Font = new Font("Papyrus", 30, FontStyle.Bold);
            this.BorderStyle = BorderStyle.Fixed3D;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.setColorFondo();
            this.Size = new Size(90, 90);
            this.Visible = true;
        }


        public void setValor(int valor) 
        {
            this.valor = valor;
        }
        public int getValor()
        {
            return this.valor;
        }
        public Color getColorFondo() 
        {
            return this.BackColor;
        }
        public void setColorFondo() 
        {
                switch (this.getValor())
                {
                    case 0:
                        this.BackColor = Color.FromArgb(224, 224, 224);
                        break;
                    case 2:
                        this.BackColor = Color.FromArgb(224, 224, 224);
                        break;
                    case 4:
                        this.BackColor = Color.Silver;
                        break;
                    case 8:
                        this.BackColor = Color.FromArgb(255, 255, 192);
                        break;
                    case 16:
                        this.BackColor = Color.Yellow;
                        break;
                    case 32:
                        this.BackColor = Color.FromArgb(255, 128, 128);
                        break;
                    case 64:
                        this.BackColor = Color.Red;
                        break;
                    case 128:
                        this.BackColor = Color.Red;
                        break;
                    case 256:
                        this.BackColor = Color.Red;
                        break;
                    case 512:
                        this.BackColor = Color.FromArgb(192, 192, 255);
                        break;
                    case 1024:
                        this.BackColor = Color.FromArgb(192, 192, 255);
                        break;
                    case 2048:
                        this.BackColor = Color.Blue;
                        break;
                    default:
                        break;
                }
            
        }

        public void dibujarTablero() 
        {
            int posX = 0;
            int posY = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Cuadrado cuadrado = new Cuadrado(0);
                    this.Controls.Add(cuadrado);
                    cuadrado.Location = new Point(posX, posY);
                    posX += 93;
                }
                posY += 93;
                posX = 0;
            }
        }

    }
}
