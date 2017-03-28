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
            //Majorita
            //DibujarCoordenadas(370, 430, 120, 210);
            //DibujarCoordenadas(120, 210, 150, 90);
            //DibujarCoordenadas(150, 90, 220, 30);
            //DibujarCoordenadas(220, 25, 350, 100);
            //DibujarCoordenadas(350, 100, 460, 30);
            //DibujarCoordenadas(460, 30, 553, 75);
            //DibujarCoordenadas(553, 75, 590, 188);
            //DibujarCoordenadas(590, 188, 371, 432);

            //DibujarCoordenadas(195, 28, 250, 28);
            //DibujarCoordenadas(250, 28, 210, 1);
            //DibujarCoordenadas(210, 1, 195, 28);

            //DibujarCoordenadas(437, 7, 510, 7);
            //DibujarCoordenadas(510, 7, 626, 1);
            //DibujarCoordenadas(626, 1, 437, 7);

            //DibujarCoordenadas(272, 239 ,216 ,170 );
            //DibujarCoordenadas(216,170 ,258 ,114 );
            //DibujarCoordenadas(258,114 ,331 ,178 );
            //DibujarCoordenadas(331,178 ,331 ,178 );

            //DibujarCoordenadas(441,173 ,450 ,124 );
            //DibujarCoordenadas(450,124 ,517 ,183 );
            //DibujarCoordenadas(517,183 ,469 ,225 );

            //Relojkito de Arenita
            //DibujarCoordenadas(250, 430, 450, 430);
            //DibujarCoordenadas(450, 430, 250, 230);
            //DibujarCoordenadas(230, 230, 450, 230);
            //DibujarCoordenadas(450, 230, 250, 430);

            //Reliquias de la muerte
            DibujarCirculo(350, 300, 100);

            DibujarCoordenadas(100, 400, 600, 400);
            DibujarCoordenadas(600, 400, 350, 200);
            DibujarCoordenadas(350, 150, 100, 400);

            DibujarCoordenadas(350, 400, 350, 150);



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
            x[0] = Convert.ToInt32(e.X);
            x[1] = Convert.ToInt32(e.Y);

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

        private void button1_Click(object sender, EventArgs e)
        {
            int[] x = new int[2];
            x[0] = Convert.ToInt32(textBox1.Text);
            x[1] = Convert.ToInt32(textBox2.Text);

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DibujarCoordenadas(int x1, int y1, int x2, int y2)
        {
            int a = x2 - x1;
            int b = y1 - y2;
            DibujarLinea(a, b, x1, y1, Color.Crimson);
        }

        private void DibujarCirculo(int x, int y, int r)
        {
            int x1 = 0;
            int y1 = r;
            int d = 3 - 2*r;
            Graphics graphicsObj = CreateGraphics();
            Pen pluma = new Pen(Color.Crimson, 1);
            while (x1 <= y1)
            {
                graphicsObj.DrawRectangle(pluma, x + x1, y + y1, 1, 1);
                graphicsObj.DrawRectangle(pluma, x - x1, y + y1, 1, 1);
                graphicsObj.DrawRectangle(pluma, x + x1, y - y1, 1, 1);
                graphicsObj.DrawRectangle(pluma, x - x1, y - y1, 1, 1);
                graphicsObj.DrawRectangle(pluma, x + y1, y + x1, 1, 1);
                graphicsObj.DrawRectangle(pluma, x - y1, y + x1, 1, 1);
                graphicsObj.DrawRectangle(pluma, x + y1, y - x1, 1, 1);
                graphicsObj.DrawRectangle(pluma, x - y1, y - x1, 1, 1);
                if (d < 0)
                {
                    d += 4*x1 + 6;
                }
                else
                {
                    d += 4*(x1 - y1) + 10;
                    y1--;
                }
                x1++;
            }
        }
    }
}
