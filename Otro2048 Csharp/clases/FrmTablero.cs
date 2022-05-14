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

        public FrmTablero()
        {
            Size = new Size(393, 413);
            Text = "Otro 2048 C# version";
            tablero = new(this);
        }



    }
}
