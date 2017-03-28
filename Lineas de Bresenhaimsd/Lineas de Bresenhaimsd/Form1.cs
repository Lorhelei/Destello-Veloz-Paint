using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Lineas_de_Bresenhaimsd
{
    public partial class Form1 : Form
    {

        private int actual = 0;
        List<int[]> listaPosiciones = new List<int[]>(2);
         
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void DibujarLinea(int xfinal, int yfinal, int inicialx, int inicialy, Color color, int grosor = 1)
        {
            int xi, yi, xf, yf;
            xi = yi = 0;
            xf = xfinal;
            yf = yfinal;
            int s1, s2, intercambio, x, y;
            float ei, ax, ay, temp;


            Graphics graphicsObj = CreateGraphics();
            Pen pluma = new Pen(color, grosor);
            x = xi;
            y = yi;
            ax = Math.Abs(xf - xi);
            ay = Math.Abs(yf - yi);
            s1 = signo(xf - xi);
            s2 = signo(yf - yi);

            if (ay > ax)
            {
                temp = ax;
                ax = ay;
                ay = temp;
                intercambio = 1;
            }
            else
            {
                intercambio = 0;
            }

            ei = 2 * ay - ax;

            for (int m = 1; m < ax; m++)
            {
                int puntox, puntoy;
                puntox = inicialx + x;
                puntoy = inicialy - y;
                graphicsObj.DrawRectangle(pluma, puntox, puntoy, 1, 1);
                if (ei >= 0)
                {
                    if (intercambio == 1)
                    {
                        x = x + s1;
                    }
                    else
                    {
                        y = y + s2;
                    }

                    ei = ei - (s2 * ax);
                }

                if (intercambio == 1)
                {
                    y = y + s2;
                }
                else
                {
                    x = x + s1;
                }

                ei = ei + 2 * ay;
            }
        }

        int signo(int num)
        {
            int resultado = 0;
            if (num < 0)
            {
                resultado = -1;
            }

            if (num > 0)
            {
                resultado = 1;
            }

            if (num == 0)
                return resultado;

            return resultado;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int[] x = new int[2];
            x[0] = e.X;
            x[1] = e.Y;

            listaPosiciones.Add(x);


            try
            {
                int x1 = listaPosiciones[actual][0] - listaPosiciones[actual - 1][0];
                int y1 = listaPosiciones[actual - 1][1] - listaPosiciones[actual][1];
                int x2 = listaPosiciones[actual - 1][0];
                int y2 = listaPosiciones[actual - 1][1];
                DibujarLinea(x1, y1, x2, y2, Color.Crimson);
            }
            catch (Exception)
            {

            }

            actual++;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            string coordenadas;
            coordenadas = e.Location.ToString();
            toolStripStatusLabel1.Text = coordenadas;
        }

        private void DibujarSombra()
        {
            
        }
    }
}
