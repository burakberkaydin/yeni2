using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private MyButton[,] btnGrid;
        private Color currColor;
        private int rows, cols;
        private int currRow, currCol;
        Timer timer = new Timer();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
            gamepanel.Height = MyButton.Btn_size * 9;
            gamepanel.Width = MyButton.Btn_size * 9;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            populateGrid();

        }
        public void populateGrid()
        {


            cols = gamepanel.Height / MyButton.Btn_size;
            rows = gamepanel.Width / MyButton.Btn_size;



            btnGrid = new MyButton[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    btnGrid[r, c] = new MyButton();
                    btnGrid[r, c].row = r;
                    btnGrid[r, c].col = c;

                    btnGrid[r, c].Click += btnWhite_Click;
                    gamepanel.Controls.Add(btnGrid[r, c]);
                    btnGrid[r, c].Location = new Point(r * MyButton.Btn_size, c * MyButton.Btn_size);
                }
            }
            assignColor();

        }
        private void assignColor()
        {


            Color[] colors = { Color.Blue, Color.Yellow, Color.Purple };
            Random random = new Random();

            int n = 3;
            while (n > 0)
            {

                int r = random.Next(rows);
                int c = random.Next(cols);


                if (btnGrid[r, c].BackColor == Color.White)
                {

                    btnGrid[r, c].BackColor = colors[random.Next() % colors.Length];

                    btnGrid[r, c].Click += btnColor_Click;
                    gamepanel.Controls.Add(btnGrid[r, c]);

                    btnGrid[r, c].Location = new Point(r * MyButton.Btn_size, c * MyButton.Btn_size);
                    n--;
                }
                else
                {
                    continue;
                }



            }


        }
        private void btnColor_Click(object sender, EventArgs e)
        {

            Button cb = (sender as Button);
            currCol = cb.Location.Y / MyButton.Btn_size;
            currRow = cb.Location.X / MyButton.Btn_size;
            currColor = cb.BackColor;

        }
        private void btnWhite_Click(object sender, EventArgs e)
        {
            try

            {
                if(currCol ==null && currRow== null)
                {

                }
                else
                {
                    Button cb = (sender as Button);

                    int c = currCol;
                    int r = currRow;


                    btnGrid[currRow, currCol].BackColor = Color.White;
                    btnGrid[r, c] = new MyButton();
                    btnGrid[r, c].row = r;
                    btnGrid[r, c].col = c;

                    btnGrid[r, c].Click += btnWhite_Click;
                    gamepanel.Controls.Add(btnGrid[r, c]);
                    btnGrid[r, c].Location = new Point(r * MyButton.Btn_size, c * MyButton.Btn_size);



                    c = cb.Location.Y / MyButton.Btn_size;
                    r = cb.Location.X / MyButton.Btn_size;


                    btnGrid[r, c].row = r;
                    btnGrid[r, c].col = c;
                    btnGrid[r, c].BackColor = currColor;

                    gamepanel.Controls.Add(btnGrid[r, c]);
                    btnGrid[r, c].Click -= btnWhite_Click;



                    btnGrid[r, c].Location = new Point(r * MyButton.Btn_size, c * MyButton.Btn_size);
                    assignColor();

                }




            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
               
            }


        }
      
        private void MoveButton(int r, int c,int curr_r,int curr_c)
        {
           

            

            timer.Interval = 2000;
          
            timer.Tick += Timer_Tick;
            timer.Start();
            btnGrid[curr_r, curr_c].Location = new Point(btnGrid[r, c].Location.X + 1, btnGrid[r, c].Location.Y);


            if (btnGrid[r, c].Location.X + btnGrid[r, c].Width >= ClientSize.Width)
            {
                timer.Stop();
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {

            btnGrid[currRow, currCol].Location = new Point(btnGrid[currRow, currCol].Location.X + 1, btnGrid[currRow, currCol].Location.Y);


            if (btnGrid[currRow, currRow].Location.X + btnGrid[currRow, currCol].Width >= ClientSize.Width)
            {
                timer.Stop();
            }
        }
    }
}
