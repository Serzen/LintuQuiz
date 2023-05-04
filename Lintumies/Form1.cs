using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Media;
using Lintumies.Database;


namespace Lintumies
{
    //basic code to create and save a bird

    //BirdBD bird = new BirdBD()
    //{
    //    birdName = "Some bird name",
    //    heardCnt = 10,
    //    correctCnt = 5,
    //    wrongCnt = 5,
    //    Priority = 2
    //};
    //bird.SaveToJson("birdData.json");
    public partial class Form1 : Form
    {
        string bird = "Varis";
        bool clicked = false;
        public Form1()
        {
            InitializeComponent();

        }


        List<string> arr = new List<string> { "Varis_1.wav", "Varis_2.wav", "Varis_3.wav"
            , "Varis_4.wav", "Varis_5.wav" }; //Test code for .wav files

        string birdImagePath = Path.GetFullPath("../../../Lintukuvat/Varis.jpg");

        private void button1_Click(object sender, EventArgs e)
        {
            //Test code for .wav files

            //Random rnd = new Random();
            //int rndN = rnd.Next(0, arr.Count);
            BirdDB.BirdDBMethods varis = BirdDB.BirdDBMethods.GetBirdDetails("Hippiainen");

            string birdSound = arr[0];
            //Debug.WriteLine(arr[0]);
            string birdSoundPath = Path.GetFullPath("../../../Lintuaanet/Varis/" + birdSound);

            SoundPlayer player = new SoundPlayer(varis.birdSounds[0]);
            Debug.WriteLine(varis.birdSounds[0]);

            player.Play();


        }

        /*
         * button changes colors of wrong answers to red and correct to green
         * chosen answer changes outline to yellow
         * bird image will be shown
        */
        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (!clicked)
            {
                clicked = true;
                btn.ForeColor = Color.Yellow;
                if (button2.Text == bird)
                {
                    button2.BackColor = Color.Green;
                    button3.BackColor = Color.Red;
                    button4.BackColor = Color.Red;
                    button5.BackColor = Color.Red;


                    pictureBox1.Image = Image.FromFile(birdImagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                else if (button3.Text == bird)
                {
                    button3.BackColor = Color.Green;

                    button2.BackColor = Color.Red;
                    button4.BackColor = Color.Red;
                    button5.BackColor = Color.Red;


                    pictureBox1.Image = Image.FromFile(birdImagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (button4.Text == bird)
                {
                    button4.BackColor = Color.Green;

                    button2.BackColor = Color.Red;
                    button3.BackColor = Color.Red;
                    button5.BackColor = Color.Red;


                    pictureBox1.Image = Image.FromFile(birdImagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                else if (button5.Text == bird)
                {
                    button5.BackColor = Color.Green;

                    button2.BackColor = Color.Red;
                    button3.BackColor = Color.Red;
                    button4.BackColor = Color.Red;


                    pictureBox1.Image = Image.FromFile(birdImagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        //button for Next bird sound
        private void button6_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.Magenta;
            button3.BackColor = Color.Magenta;
            button4.BackColor = Color.Magenta;
            button5.BackColor = Color.Magenta;


            button2.ForeColor = Color.White;
            button3.ForeColor = Color.White;
            button4.ForeColor = Color.White;
            button5.ForeColor = Color.White;

            pictureBox1.Image = Image.FromFile(birdImagePath);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            clicked = false;

            List<BirdDB.BirdDBMethods> birdList = new List<BirdDB.BirdDBMethods>();
            BirdDB.BirdDBMethods bird = new BirdDB.BirdDBMethods();
            //bird.AddBird("bird name", 10, 5, 5, 1);
            bird.UpdateBird("sparrow", 20, 10, 5, 10);

            BirdDB.BirdDBMethods varis = BirdDB.BirdDBMethods.GetBirdDetails("sparrow");



        }
    }

    internal class Lintu
    {
        public Lintu(int id, string nimi)
        {
            Id = id;
            Nimi = nimi;
        }

        public int Id { get; set; }
        public string Nimi { get; set; }

        public void Satunnainen()
        {
            List<Lintu> linnut = new List<Lintu>()
            {
                new Lintu(1, "Harakka"),
                new Lintu(2, "Hippiainen"),
                new Lintu(3, "Jarripeippo"),
                new Lintu(4, "Kaki"),
                new Lintu(5, "Pajulintu"),
                new Lintu(6, "Peippo"),
                new Lintu(7, "Punarinta"),
                new Lintu(8, "Rakattirastas"),
                new Lintu(9, "Selkalokki"),
                new Lintu(10, "Varis")
            };
            Random random = new Random();
            int luku = random.Next(1, 11);
            var etsi = from x in linnut
                       where x.Id == luku
                       select x.Nimi;
        }
    }
}