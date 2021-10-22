using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace pvz
{
    public partial class GameScreen : UserControl
    {

        Boolean upArrownDown, downArrownDown, rightArrownDown, leftArrownDown, mKeyDown, nKeyDown, bKeyDown, spaceKeyDown;

        SolidBrush drawBrush = new SolidBrush(Color.White);
        SolidBrush drawBrush2 = new SolidBrush(Color.Black);

        List <Plant> plants = new List <Plant>();
        List <Zombies> zombies= new List <Zombies>();

        Image peashooter = Properties.Resources.peashooter;
        Image zombie = Properties.Resources.zombie;


        Font font = new Font("ariel", 20);

        int newPlantX = 250;
        int counter = 0;
        int speed = 1;

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            Zombies newZombies = new Zombies(800, 60, 100, 5);
            zombies.Add(newZombies);
        }

        private void GameScreen_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrownDown = true;
                    break;
                case Keys.Down:
                    downArrownDown = true;
                    break;
                case Keys.Left:
                    leftArrownDown = true;
                    break;
                case Keys.Right:
                    rightArrownDown = true;
                    break;
                case Keys.M:
                    mKeyDown = true;
                    break;
                case Keys.N:
                    nKeyDown = true;
                    break;
                case Keys.B:
                    bKeyDown = true;
                    break;
                case Keys.Space:
                    spaceKeyDown = true;
                    break;
            }

        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrownDown = true;
                    break;
                case Keys.Down:
                    downArrownDown = true;
                    break;
                case Keys.Left:
                    leftArrownDown = true;
                    break;
                case Keys.Right:
                    rightArrownDown = true;
                    break;
                case Keys.M:
                    mKeyDown = true;
                    break;
                case Keys.N:
                    nKeyDown = true;
                    break;
                case Keys.B:
                    bKeyDown = true;
                    break;
                case Keys.Space:
                    spaceKeyDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrownDown = false;
                    break;
                case Keys.Down:
                    downArrownDown = false;
                    break;
                case Keys.Left:
                    leftArrownDown = false;
                    break;
                case Keys.Right:
                    rightArrownDown = false;
                    break;
                case Keys.M:
                    mKeyDown = false;
                    break;
                case Keys.N:
                    nKeyDown = false;
                    break;
                case Keys.B:
                    bKeyDown = false;
                    break;
                case Keys.Space:
                    spaceKeyDown = false;
                    break;
            }
        }
        private void setParameters()
        {

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //add new plant
            counter++;

            if (mKeyDown == true && counter > 100)
            {
                Plant newPlant = new Plant(newPlantX, 80, 70);
                plants.Add(newPlant);
                newPlantX += 82;
                counter -= 100;
            }

            counterLabel.Text = $"{counter}";


            foreach (Zombies z in zombies)
            {
                z.x -= speed;
            }

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {

            foreach(Plant p in plants)
            {
                e.Graphics.DrawImage(peashooter, p.x, p.y, p.size, p.size);
            }
           
            foreach(Zombies z in zombies)
            {
                e.Graphics.DrawImage(zombie, z.x, z.y, z.size, z.size);
            }

            e.Graphics.FillRectangle(drawBrush, 20, 50, 100, 130);
            e.Graphics.DrawImage(peashooter, 20, 50, 100, 100);
            e.Graphics.DrawString("100", font, drawBrush2, 20, 150);

        }
    }
}
