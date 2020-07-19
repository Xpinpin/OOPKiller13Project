using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOLayer
{
    public class Player : Panel
    {
        public Player(Hand hand)
        {
            handPlayer = hand;
        }

        private Hand handPlayer = new Hand();
        private readonly EventHandler PictureBox_Click;

        /// <summary>
        /// Show the cards of a Player
        /// </summary>
        /// <param name="thePanel"></param>
        /// <param name="theHand"></param>
        public void ShowHand(Panel thePanel, Hand theHand)
        {
            thePanel.Controls.Clear();
            Card aCard;
            PictureBox aPic;

            for (int i = 0; i < theHand.Count; i++)
            {
                aCard = theHand[i];
                string path = @"images\" + aCard.FaceValue.ToString() + aCard.Suit.ToString() + ".jpg";

                aPic = new PictureBox()
                {
                    Image = Image.FromFile(path),
                    Text = aCard.FaceValue.ToString(),
                    Width = 70,
                    Height = 100,
                    Left = 75 * i,
                    Tag = aCard
                };
                aPic.Click += PictureBox_Click;
                thePanel.Controls.Add(aPic);
            }
        }

        public void MakeTurn(Hand drawHand, Label lblPlayer,int value, int oldValue)
        {
            if(base.Enabled == true)
            {
                
            }
        }
    }
}
