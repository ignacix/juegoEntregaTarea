using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int[] vector = {0,79,158};
        public Random random = new Random();
        int cont = 1;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();                                                                                  
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //movimiento Gota
            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;
            y=y+5;
            
            pictureBox1.Location = new Point(x,y);                        

            //Utilizo la misma gota(pictureBox1)
            if (pictureBox1.Location.Y > 500)
            {
                //creo el obj random
                //saco la longitud del vector. Creo un numero aleatorio y lo utilizo para acceder a algun numero del vector
                int aleatorio = random.Next(0, vector.Length);
                pictureBox1.Location = new Point(vector[aleatorio], 0);
                label1.Text = $"Puntos: {cont++}";
            }

            if ((pictureBox1.Location.Y == 290) && (pictureBox1.Location.X == pictureBox2.Location.X))
            {
                timer1.Stop();
                var jugar = MessageBox.Show($"\tPERDISTE\n\nPuntos: {cont-1}\n\n¿Quiere jugar denuevo?","",MessageBoxButtons.YesNo);                
                if (jugar.ToString()=="Yes")
                {
                    cont = 0;
                    timer1.Start();
                }
                else
                {
                    Form.ActiveForm.Close();
                }
            }                                
            
                
                        
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            int x = pictureBox2.Location.X;
            int y = pictureBox2.Location.Y;
            MouseEventArgs click = (MouseEventArgs)e;
            if (click.Button==MouseButtons.Left)
            {
                if ((x-79)>=0)                
                    pictureBox2.Location = new Point(x-79,y);
                
            }
            else if (click.Button == MouseButtons.Right)
            {
                if ((x+79)<=200)
                    pictureBox2.Location = new Point(x+79,y);
            }
            //label1.Text = (pictureBox2.Location.X.ToString());
        }
    }
}
