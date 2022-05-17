using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otro2048_Csharp.clases
{

    internal class FrmTablero : Form
    {
        private Cuadrado cuadrado = new();
        private Tablero tablero;
        private Button BtnArriba;
        private Button BtnIzquierda;
        private Button BtnAbajo;
        private Button BtnDerecha;
        private Label LblPuntos;
        private Label LblMovidas;
        private GroupBox groupBox1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button BtnReiniciar;
        private Panel PnlCuadrados;
        private int cuadradosEnCero=16;
        private ProcesaCuadrados procCuadrado;
        private Label label1;
        private int puntos;
        public FrmTablero()
        {
            InitializeComponent();
            Size = new Size(600, 413);
            Text = "Otro 2048 C# version";
            tablero = new Tablero(this);
            procCuadrado = new ProcesaCuadrados(this);
        }


        //ESTO ESTA MODIFICADO PARA QUE MUESTRE LOS CEROS QUE QUEDAN, CAMBIARLO PARA QUE MUESTRE LOS PUNTOS
        public void setPuntos(int puntosGanados)
        {
            puntos += puntosGanados;
            LblPuntos.Text = "puntos: " + puntos;
        }
        public void setCuadradosEnCero(int cuadrados)
        {
            cuadradosEnCero = cuadrados;
        }

        public int getCuadradosEnCero()
        {
            return cuadradosEnCero;
        }

        public Panel getPnlCuadrados()
        {
            return PnlCuadrados;
        }

        public Tablero getTablero()
        {
            return tablero;
        }

        public void setTablero(Tablero tab)
        {
            tablero = tab;
        }

        private void InitializeComponent()
        {
            this.PnlCuadrados = new System.Windows.Forms.Panel();
            this.BtnArriba = new System.Windows.Forms.Button();
            this.BtnIzquierda = new System.Windows.Forms.Button();
            this.BtnAbajo = new System.Windows.Forms.Button();
            this.BtnDerecha = new System.Windows.Forms.Button();
            this.LblPuntos = new System.Windows.Forms.Label();
            this.LblMovidas = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.BtnReiniciar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlCuadrados
            // 
            this.PnlCuadrados.Location = new System.Drawing.Point(0, 0);
            this.PnlCuadrados.Name = "PnlCuadrados";
            this.PnlCuadrados.Size = new System.Drawing.Size(393, 413);
            this.PnlCuadrados.TabIndex = 0;
            // 
            // BtnArriba
            // 
            this.BtnArriba.Location = new System.Drawing.Point(436, 271);
            this.BtnArriba.Name = "BtnArriba";
            this.BtnArriba.Size = new System.Drawing.Size(48, 23);
            this.BtnArriba.TabIndex = 1;
            this.BtnArriba.TabStop = false;
            this.BtnArriba.Text = "Arriba";
            this.BtnArriba.UseVisualStyleBackColor = true;
            this.BtnArriba.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // BtnIzquierda
            // 
            this.BtnIzquierda.Location = new System.Drawing.Point(399, 300);
            this.BtnIzquierda.Name = "BtnIzquierda";
            this.BtnIzquierda.Size = new System.Drawing.Size(48, 23);
            this.BtnIzquierda.TabIndex = 2;
            this.BtnIzquierda.TabStop = false;
            this.BtnIzquierda.Text = "Izq";
            this.BtnIzquierda.UseVisualStyleBackColor = true;
            this.BtnIzquierda.Click += new System.EventHandler(this.BtnIzquierda_Click);
            // 
            // BtnAbajo
            // 
            this.BtnAbajo.Location = new System.Drawing.Point(436, 329);
            this.BtnAbajo.Name = "BtnAbajo";
            this.BtnAbajo.Size = new System.Drawing.Size(48, 23);
            this.BtnAbajo.TabIndex = 3;
            this.BtnAbajo.TabStop = false;
            this.BtnAbajo.Text = "Abajo";
            this.BtnAbajo.UseVisualStyleBackColor = true;
            this.BtnAbajo.Click += new System.EventHandler(this.BtnAbajo_Click);
            // 
            // BtnDerecha
            // 
            this.BtnDerecha.Location = new System.Drawing.Point(471, 300);
            this.BtnDerecha.Name = "BtnDerecha";
            this.BtnDerecha.Size = new System.Drawing.Size(48, 23);
            this.BtnDerecha.TabIndex = 4;
            this.BtnDerecha.TabStop = false;
            this.BtnDerecha.Text = "Der";
            this.BtnDerecha.UseVisualStyleBackColor = true;
            this.BtnDerecha.Click += new System.EventHandler(this.BtnDerecha_Click);
            // 
            // LblPuntos
            // 
            this.LblPuntos.AutoSize = true;
            this.LblPuntos.Location = new System.Drawing.Point(400, 6);
            this.LblPuntos.Name = "LblPuntos";
            this.LblPuntos.Size = new System.Drawing.Size(47, 15);
            this.LblPuntos.TabIndex = 5;
            this.LblPuntos.Text = "Puntos:";
            // 
            // LblMovidas
            // 
            this.LblMovidas.AutoSize = true;
            this.LblMovidas.Location = new System.Drawing.Point(400, 42);
            this.LblMovidas.Name = "LblMovidas";
            this.LblMovidas.Size = new System.Drawing.Size(55, 15);
            this.LblMovidas.TabIndex = 6;
            this.LblMovidas.Text = "Movidas:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(400, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 104);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dificultad:";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(8, 79);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(55, 19);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Dificil";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(8, 54);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Medio";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(8, 29);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(49, 19);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Facil";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // BtnReiniciar
            // 
            this.BtnReiniciar.Location = new System.Drawing.Point(400, 188);
            this.BtnReiniciar.Name = "BtnReiniciar";
            this.BtnReiniciar.Size = new System.Drawing.Size(75, 23);
            this.BtnReiniciar.TabIndex = 8;
            this.BtnReiniciar.TabStop = false;
            this.BtnReiniciar.Text = "Reiniciar";
            this.BtnReiniciar.UseVisualStyleBackColor = true;
            this.BtnReiniciar.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(420, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Use A, S, D, W";
            // 
            // FrmTablero
            // 
            this.ClientSize = new System.Drawing.Size(588, 417);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnReiniciar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LblMovidas);
            this.Controls.Add(this.LblPuntos);
            this.Controls.Add(this.BtnDerecha);
            this.Controls.Add(this.BtnAbajo);
            this.Controls.Add(this.BtnIzquierda);
            this.Controls.Add(this.BtnArriba);
            this.Controls.Add(this.PnlCuadrados);
            this.Name = "FrmTablero";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmTablero_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cuadradosEnCero > 0)
            {
                procCuadrado.sumarNumeros(this.getTablero().getArrayCuadradosDelTablero());
            }
            else
            {
                procCuadrado.verificaSiPerdio();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.getTablero().generarTableroNuevo(this);
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            this.getTablero().refrescarTablero(this);
        }

        private void BtnAgregarCuadrado_Click(object sender, EventArgs e)
        {
            this.getTablero().setValorAzarCuadradoAzarSiValorEs0(1);
        }

        private void BtnDerecha_Click(object sender, EventArgs e)
        {
            if (cuadradosEnCero>0) { 
            tablero.rotarTablero90DerechaXVeces(3);
            procCuadrado.sumarNumeros(this.getTablero().getArrayCuadradosDelTablero());
            tablero.rotarTablero90DerechaXVeces(1);
            }
            else
            {
                procCuadrado.verificaSiPerdio();
            }
        }

        private void BtnIzquierda_Click(object sender, EventArgs e)
        {
            if (cuadradosEnCero > 0)
            {
                tablero.rotarTablero90DerechaXVeces(1);
            procCuadrado.sumarNumeros(this.getTablero().getArrayCuadradosDelTablero());
            tablero.rotarTablero90DerechaXVeces(3);
            }
            else
            {
                procCuadrado.verificaSiPerdio();
            }
        }

        private void BtnAbajo_Click(object sender, EventArgs e)
        {
            if (cuadradosEnCero > 0)
            {
                tablero.rotarTablero90DerechaXVeces(2);
            procCuadrado.sumarNumeros(this.getTablero().getArrayCuadradosDelTablero());
            tablero.rotarTablero90DerechaXVeces(2);
            }
            else
            {
                procCuadrado.verificaSiPerdio();
            }
        }

        private void BtnVerificaSumar_Click(object sender, EventArgs e)
        {
            procCuadrado.verificaSumaCuadrado(this.getTablero().getArrayCuadradosDelTablero());
        }

        private void BtnVerificaSiPerdio_Click(object sender, EventArgs e)
        {
            procCuadrado.verificaSiPerdio();
        }

        private void BtnLlenarTablero_Click(object sender, EventArgs e)
        {
            this.getTablero().generarTableroNuevoTesting(this);
        }

       

        private void FrmTablero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 119)
            {
                BtnArriba.PerformClick();
            }else if (e.KeyChar == 100)
            {
                BtnDerecha.PerformClick();
            }
            else if(e.KeyChar == 115)
            {
                BtnAbajo.PerformClick();
            }
            else if(e.KeyChar == 97)
            {
                BtnIzquierda.PerformClick();
            }
        }
    }
}
