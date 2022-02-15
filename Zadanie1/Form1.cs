using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Fraction;
using Worm;

namespace Zadanie1
{
    public partial class Form1 : Form
    {
        private Fraction myMap;
        private Panel[] redRoadArr;
        private Panel[] blueRoadArr;
        private Panel[] yellowRoadArr;

        public Form1()
        {
            InitializeComponent();
            this.redRoadArr = new Panel[] {this.panel1, this.panel2, this.panel3, this.panel4, this.panel5,
                                           this.panel6, this.panel7, this.panel8, this.panel9, this.panel10,
                                           this.panel11, this.panel12, this.panel13, this.panel14, this.panel15,
                                           this.panel16, this.panel17, this.panel18, this.panel19, this.panel20,
                                           this.panel21, this.panel22, this.panel23, this.panel24, this.panel25,
                                           this.panel26, this.panel27, this.panel28, this.panel29, this.panel30 };

            this.blueRoadArr = new Panel[]{this.panel61, this.panel62, this.panel63, this.panel64, this.panel65,
                                           this.panel66, this.panel67, this.panel17, this.panel16, this.panel15,
                                           this.panel14, this.panel13, this.panel12, this.panel11, this.panel10,
                                           this.panel9, this.panel8, this.panel52, this.panel51, this.panel50,
                                           this.panel53, this.panel54, this.panel55, this.panel56, this.panel57,
                                           this.panel58, this.panel59, this.panel60 };

            this.yellowRoadArr = new Panel[]{this.panel47, this.panel48, this.panel49, this.panel50, this.panel51,
                                           this.panel52, this.panel8, this.panel7, this.panel6, this.panel5,
                                           this.panel31, this.panel32, this.panel33, this.panel34, this.panel35,
                                           this.panel36, this.panel37, this.panel38, this.panel39, this.panel40,
                                           this.panel41, this.panel42, this.panel43, this.panel44, this.panel45,
                                           this.panel46};

            this.myMap = new Fraction();
            this.myMap.StartSimulation();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.SetWorm(Worm.Colour.Red);
            this.SetWorm(Worm.Colour.Blue);
            this.SetWorm(Worm.Colour.Yellow);

        }

        private void SetWorm(Worm.Colour color)
        {
            Wormik worm = this.myMap.GetWorm(color);
            uint head = worm.GetHead();
            uint tail = worm.GetTail();
            this.SetHead(color, head);
            this.SetTail(color, tail);

        }

        private void SetHead(Worm.Colour color, uint head)
        {
            switch (color)
            {
                case Colour.Red:
                    redRoadArr[head].BackColor = System.Drawing.Color.Red;
                    break;
                case Colour.Blue:
                    blueRoadArr[head].BackColor = System.Drawing.Color.Blue;
                    break;
                case Colour.Yellow:
                    yellowRoadArr[head].BackColor = System.Drawing.Color.Yellow;
                    break;

            }

        }

        private void SetTail(Worm.Colour color, uint tail)
        {
            switch (color)
            {
                case Colour.Red:
                    redRoadArr[tail].BackColor = System.Drawing.Color.White;
                    break;
                case Colour.Blue:
                    blueRoadArr[tail].BackColor = System.Drawing.Color.White;
                    break;
                case Colour.Yellow:
                    yellowRoadArr[tail].BackColor = System.Drawing.Color.White;
                    break;

            }
        }


    }
}
