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

        SolidBrush drawBrush = new SolidBrush(Color.White);
        SolidBrush drawBrush2 = new SolidBrush(Color.Black);

        List<Plant> plants = new List<Plant>();
        List<Peashooter> pea = new List<Peashooter>();
        List<Sunflower> sun = new List<Sunflower>();
        List<Zombies> zombies = new List<Zombies>();
        List<String> peaLane1 = new List<String>();
        List<String> peaLane2 = new List<String>();
        List<String> peaLane3 = new List<String>();
        List<String> peaLane4 = new List<String>();
        List<String> peaLane5 = new List<String>();

        Image peashooterImage = Properties.Resources.peashooter;
        Image sunflowerImage = Properties.Resources.pvz_sunflower;
        Image zombieImage = Properties.Resources.zombie;
        Image sunCountImage = Properties.Resources.pvz_sun_count;
        Image peaImage = Properties.Resources.pea;

        int lane1 = 90;
        int lane2 = 190;
        int lane3 = 290;
        int lane4 = 390;
        int lane5 = 490;
        int startZombie = 1100;
        int zombieSize = 75;
        int speed = 3;

        int sunCounter = 50;
        int newZombieCounter = 0;

        string sunflower = "unselected";
        string peashooter = "unselected";

        Random randGen = new Random();

        public GameScreen()
        {
            InitializeComponent();
        }



        public void GameInitialize()
        {
            string sunflower = "unselected";
            string peashooter = "unselected";

            int sunCounter = 0;
            int newZombieCounter = 0;
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            GameInitialize();
        }

        private void setParameters()
        {

        }

        #region plant buttons
        private void sunflowerButton_Click(object sender, EventArgs e)
        {
            sunflower = "selected";
            peashooter = "unselected";

            sunflowerButton.BackColor = Color.DarkGray;
            peashooterButton.BackColor = Color.LightGray;
        }
        private void peashooterButton_Click(object sender, EventArgs e)
        {
            peashooter = "selected";
            sunflower = "unselected";

            peashooterButton.BackColor = Color.DarkGray;
            sunflowerButton.BackColor = Color.LightGray;
        }
        #endregion 

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            sunCounter += 1;
            sunLabel.Text = $"{sunCounter}";

            #region spawn zombies
            newZombieCounter++;

            if (newZombieCounter % 50 == 0)
            {
                int newZomb = randGen.Next(1, 6);


                if (newZomb == 1)
                {
                    Zombies newZombies = new Zombies(startZombie, lane1, zombieSize, speed);
                    zombies.Add(newZombies);
                }

                if (newZomb == 2)
                {
                    Zombies newZombies = new Zombies(startZombie, lane2, zombieSize, speed);
                    zombies.Add(newZombies);
                }

                if (newZomb == 3)
                {
                    Zombies newZombies = new Zombies(startZombie, lane3, zombieSize, speed);
                    zombies.Add(newZombies);
                }

                if (newZomb == 4)
                {
                    Zombies newZombies = new Zombies(startZombie, lane4, zombieSize, speed);
                    zombies.Add(newZombies);
                }

                if (newZomb == 5)
                {
                    Zombies newZombies = new Zombies(startZombie, lane5, zombieSize, speed);
                    zombies.Add(newZombies);
                }
                #endregion


            }

            foreach (Zombies z in zombies)
            {
                z.Move();

                if(z.x <= 200)
                {
                    gameTimer.Enabled = false;

                    Form f = this.FindForm();
                    f.Controls.Remove(this);

                    GameOverScreen gos = new GameOverScreen();
                    f.Controls.Add(gos);
                    gos.Location = new Point((f.Width - gos.Width) / 2, (f.Height - gos.Height) / 2);
                }
            }

            foreach (Sunflower s in sun)
            {
                sunCounter += 1;
            }


            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {

            foreach (Peashooter p in pea)
            {
                e.Graphics.DrawImage(peashooterImage, p.x, p.y, p.size, p.size);
            }

            foreach (Sunflower s in sun)
            {
                e.Graphics.DrawImage(sunflowerImage, s.x, s.y, s.size, s.size);
            }

            foreach (Zombies z in zombies)
            {
                e.Graphics.DrawImage(zombieImage, z.x, z.y, z.size, z.size);
            }

            e.Graphics.DrawImage(sunCountImage, 21, 10, 80, 80);

        }

        #region blocks 1-25
        private void label1_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block1.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(255, 90, 70);
                pea.Add(newPea);
                peaLane1.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block1.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block1.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(255, 90, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block1.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block2_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block2.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(255, 190, 70);
                pea.Add(newPea);
                peaLane2.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block2.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block2.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(255, 190, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block2.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block3_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block3.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(255, 290, 70);
                pea.Add(newPea);
                peaLane3.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block3.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block3.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(255, 290, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block3.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block4_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block4.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(255, 390, 70);
                pea.Add(newPea);
                peaLane4.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block4.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block4.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(255, 390, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block4.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block5_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block5.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(255, 490, 70);
                pea.Add(newPea);
                peaLane5.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block5.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block5.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(255, 490, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block5.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block6_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block6.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(340, 90, 70);
                pea.Add(newPea);
                peaLane1.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block6.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block6.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(340, 90, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block6.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block7_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block7.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(340, 190, 70);
                pea.Add(newPea);
                peaLane2.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block7.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block7.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(340, 190, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block7.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block8_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block8.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(340, 290, 70);
                pea.Add(newPea);
                peaLane3.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block8.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block8.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(340, 290, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block8.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block9_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block9.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(340, 390, 70);
                pea.Add(newPea);
                peaLane4.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block9.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block9.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(340, 390, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block9.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block10_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block10.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(340, 490, 70);
                pea.Add(newPea);
                peaLane5.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block10.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block10.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(340, 490, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block10.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block11_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block11.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(420, 90, 70);
                pea.Add(newPea);
                peaLane1.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block11.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block11.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(420, 90, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block11.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block12_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block12.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(420, 190, 70);
                pea.Add(newPea);
                peaLane2.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block12.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block12.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(420, 190, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block12.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block13_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block13.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(420, 290, 70);
                pea.Add(newPea);
                peaLane3.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block13.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block13.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(420, 290, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block13.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block14_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block14.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(420, 390, 70);
                pea.Add(newPea);
                peaLane4.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block14.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block14.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(420, 390, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block14.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block15_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block15.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(420, 490, 70);
                pea.Add(newPea);
                peaLane5.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block15.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block15.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(420, 490, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block15.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block16_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block16.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(500, 90, 70);
                pea.Add(newPea);
                peaLane1.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block16.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block16.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(500, 90, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block16.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block17_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block17.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(500, 190, 70);
                pea.Add(newPea);
                peaLane2.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block17.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block17.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(500, 190, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block17.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block18_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block18.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(500, 290, 70);
                pea.Add(newPea);
                peaLane3.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block18.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block18.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(500, 290, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block18.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block19_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block19.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(500, 390, 70);
                pea.Add(newPea);
                peaLane4.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block19.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block19.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(500, 390, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block19.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block20_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block20.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(500, 490, 70);
                pea.Add(newPea);
                peaLane5.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block20.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block20.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(500, 490, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block20.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block21_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block21.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(580, 90, 70);
                pea.Add(newPea);
                peaLane1.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block21.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block21.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(580, 90, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block21.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block22_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block22.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(580, 190, 70);
                pea.Add(newPea);
                peaLane2.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block22.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block22.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(580, 190, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block22.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block23_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block23.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(580, 290, 70);
                pea.Add(newPea);
                peaLane3.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block23.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block23.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(580, 290, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block23.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block24_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block24.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(580, 390, 70);
                pea.Add(newPea);
                peaLane4.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block24.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block24.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(580, 390, 70);
                sun.Add(newSun);


                sunCounter -= 50;

                sunflower = "unselected";
                block24.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        private void block25_Click(object sender, EventArgs e)
        {
            if (peashooter == "selected" && block25.Visible == true && sunCounter >= 100)
            {
                Peashooter newPea = new Peashooter(580, 490, 70);
                pea.Add(newPea);
                peaLane5.Add(Convert.ToString(newPea));

                sunCounter -= 100;

                peashooter = "unselected";
                block25.Visible = false;
                peashooterButton.BackColor = Color.LightGray;
            }

            if (sunflower == "selected" && block25.Visible == true && sunCounter >= 50)
            {
                Sunflower newSun = new Sunflower(580, 490, 70);
                sun.Add(newSun);

                sunCounter -= 50;

                sunflower = "unselected";
                block25.Visible = false;
                sunflowerButton.BackColor = Color.LightGray;
            }
        }

        #endregion
    }
}
