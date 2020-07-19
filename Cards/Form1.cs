using BOLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cards
{
    public partial class Form1 : Form
    {
        //Instantiate essential things for the game
        private Deck aDeck;
        private Deck winnerDeck;
        private Hand hand1;
        private Hand hand2;
        private Hand hand3;
        private Hand hand4;
        private Hand drawHand;
        private Hand previousHand;

        private Card threeSpadesCard = new Card(Suit.Spades, FaceValue.Three);

        int value;
        int oldValue;
        string ranking;
        bool isExamined;
        public Form1()
        {
            InitializeComponent();
        }


        #region Built Methods
        private void SetUp()
        {
            try
            {
                lblPlayer1.Text = "Player 1";
                lblPlayer2.Text = "Player 2";
                lblPlayer3.Text = "Player 3";
                lblPlayer4.Text = "Player 4";

                lblPlayer1.ForeColor = Color.Black;
                lblPlayer2.ForeColor = Color.Black;
                lblPlayer3.ForeColor = Color.Black;
                lblPlayer4.ForeColor = Color.Black;

                Player1.Visible = true;
                Player2.Visible = true;
                Player3.Visible = true;
                Player4.Visible = true;

                Player1.Controls.Clear();
                Player2.Controls.Clear();
                Player3.Controls.Clear();
                Player4.Controls.Clear();
                DrawPlatform.Controls.Clear();
                PreviousDraw.Controls.Clear();
                aDeck = new Deck();
                drawHand = new Hand();
                previousHand = new Hand();
                winnerDeck = new Deck();
                aDeck.Shuffle();

                value = 0;
                oldValue = 0;
                
                ranking = "";

                ranking = "";

                lblInstruct.Text = "Click New Game to proceed into the game for four people.\r\n" +
                                   "Follow the instructions here carefully to experience\r\n" +
                                   "the game wonderfully. Thank you for playing Killer 13.";

                //For the players to be able to click the cards (Except the DrawPlatform and PreviousDraw)
                Player1.Enabled = true;
                Player2.Enabled = true;
                Player3.Enabled = true;
                Player4.Enabled = true;
                DrawPlatform.Enabled = true;
                PreviousDraw.Enabled = false;

                btnEnd.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// End the turn of this player and initiate the turn of the next player
        /// </summary>
        /// <param name="thisPlayer"></param>
        /// <param name="nextPlayer"></param>
        /// <param name="thisHand"></param>
        /// <param name="nextHand"></param>
        private void PassPlayer(Panel thisPlayer, Panel nextPlayer, Hand thisHand, Hand nextHand)
        {
            thisPlayer.Enabled = false;
            nextPlayer.Enabled = true;
            ShowHand(nextPlayer, nextHand);
            ShowBlankHand(thisPlayer, thisHand.Count);
        }

        /// <summary>
        /// Draw out the card from the player's hand to the draw deck
        /// </summary>
        /// <param name="drawnCard"></param>
        /// <param name="thisHand"></param>
        /// <param name="thisPlayer"></param>
        private void DrawOutCard(Card drawnCard, Hand thisHand, Panel thisPlayer)
        {
            value += ReturnValue(drawnCard);
            ShowHand(thisPlayer, thisHand);
            drawHand.AddCard(drawnCard);
            ShowHand(DrawPlatform, drawHand);
        }

        /// <summary>
        /// Click the card to put the card from Draw deck to the player's hand.
        /// </summary>
        /// <param name="retrievedCard"></param>
        /// <param name="thisHand"></param>
        /// <param name="thisPlayer"></param>
        private void PutCardBack(Card retrievedCard, Hand thisHand, Panel thisPlayer)
        {
            value -= ReturnValue(retrievedCard);
            ShowHand(DrawPlatform, drawHand);
            thisHand.AddCard(retrievedCard);
            ShowHand(thisPlayer, thisHand);
        }

        /// <summary>
        /// Make next player can not click continue to pass as the previous one won
        /// </summary>
        private void StartAgainAfterWinning()
        {
            MessageBox.Show("You have to start a new turn.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            oldValue = 0;
            PreviousDraw.Controls.Clear();
            previousHand = new Hand();
        }

        /// <summary>
        /// Conditions to turn a player to win state
        /// </summary>
        /// <param name="player"></param>
        /// <param name="lblPlayer"></param>
        private void MakeAPlayerWin(Panel player, Label lblPlayer)
        {
            player.Visible = false;
            lblPlayer.ForeColor = Color.Green;
        }
        /// <summary>
        /// Gets the player who has finished the game
        /// </summary>
        /// <param name="playerLabel"></param>
        /// <returns></returns>
        private bool FinishedPlayer(Label playerLabel)
        {
            return playerLabel.ForeColor == Color.Green;

        }

        /// <summary>
        /// Check if all other 3 players have passed so that the remaining one can go a new turn.
        /// </summary>
        /// <returns></returns>
        private bool EnableAPlayerToPlayAfterAllPass()
        {
            return ((lblPlayer3.Text == "Player 3 (PASS)" && lblPlayer4.Text == "Player 4 (PASS)" && lblPlayer2.Text == "Player 2 (PASS)") ||
                     (lblPlayer3.Text == "Player 3 (PASS)" && lblPlayer4.Text == "Player 4 (PASS)" && lblPlayer1.Text == "Player 1 (PASS)") ||
                     (lblPlayer4.Text == "Player 4 (PASS)" && lblPlayer1.Text == "Player 1 (PASS)" && lblPlayer2.Text == "Player 2 (PASS)") ||
                     (lblPlayer1.Text == "Player 1 (PASS)" && lblPlayer2.Text == "Player 2 (PASS)" && lblPlayer3.Text == "Player 3 (PASS)"));
        }

        /// <summary>
        /// Make the next player have to draw out cards after the previous one won
        /// </summary>
        private void ForceNextPlayerToPlayAfterWinning()
        {
            oldValue = 0;
            PreviousDraw.Controls.Clear();
            isExamined = false;
        }

        /// <summary>
        /// Identify the first player being called is the first place.
        /// </summary>
        /// <param name="firstHand"></param>
        /// <param name="secondHand"></param>
        /// <param name="thirdHand"></param>
        /// <param name="fourthHand"></param>
        /// <returns></returns>
        private bool FirstPlace(Hand firstHand, Hand secondHand, Hand thirdHand, Hand fourthHand)
        {
            return (firstHand.Count == 0 && secondHand.Count != 0 && thirdHand.Count != 0 && fourthHand.Count != 0);
        }

        /// <summary>
        ///  Identify the first player as the second place
        /// </summary>
        /// <param name="secondPlace"></param>
        /// <param name="lblfirstPlace"></param>
        /// <param name="thirdHand"></param>
        /// <param name="fourthHand"></param>
        /// <returns></returns>
        private bool SecondPlace(Hand secondPlace, Label lblFirstPlace, Hand thirdHand, Hand fourthHand)
        {
            return (lblFirstPlace.ForeColor == Color.Green && secondPlace.Count == 0 && thirdHand.Count != 0 && fourthHand.Count != 0);
        }

        /// <summary>
        /// Identify the first player as the third place
        /// </summary>
        /// <param name="thirdPlace"></param>
        /// <param name="lblFirstPlace"></param>
        /// <param name="lblSecondPlace"></param>
        /// <param name="fourthHand"></param>
        /// <returns></returns>
        private bool ThirdPlace(Hand thirdPlace, Label lblFirstPlace, Label lblSecondPlace, Hand fourthHand)
        {
            return (lblFirstPlace.ForeColor == Color.Green && lblSecondPlace.ForeColor == Color.Green && thirdPlace.Count == 0 && fourthHand.Count != 0);
        }

        /// <summary>
        /// List out all three players have won to identify the fourth place
        /// </summary>
        /// <param name="lblOne"></param>
        /// <param name="lblTwo"></param>
        /// <param name="lblThree"></param>
        /// <returns></returns>
        private bool HaveWon(Label lblOne, Label lblTwo, Label lblThree)
        {
            return (lblOne.ForeColor == Color.Green && lblTwo.ForeColor == Color.Green && lblThree.ForeColor == Color.Green);
        }

        /// <summary>
        /// This is used to end the game and be able to click the End button to show results
        /// </summary>
        private void EndTheGame()
        {
            lblPlayer1.Text = "Player 1 (PASS)";
            lblPlayer2.Text = "Player 2 (PASS)";
            lblPlayer3.Text = "Player 3 (PASS)";
            lblPlayer4.Text = "Player 4 (PASS)";

            lblPlayer1.ForeColor = Color.Green;
            lblPlayer2.ForeColor = Color.Green;
            lblPlayer3.ForeColor = Color.Green;
            lblPlayer4.ForeColor = Color.Green;

            DrawPlatform.Controls.Clear();
            PreviousDraw.Controls.Clear();

            btnContinue.Enabled = false;
            btnEnd.Enabled = true;
            btnEnd.Focus();
        }

        /// <summary>
        /// Returns the value of the card drawn out
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public int ReturnValue(Card card)
        {
            FaceValue value = card.FaceValue;
            Suit suit = card.Suit;
            int result = (int)value + (int)suit;
            return result;
        }


        /// <summary>
        /// Used to return the back of the card for the player
        /// </summary>
        /// <param name="thePanel"></param>
        /// <param name="counter"></param>
        /// 
        private void ShowBlankHand(Panel thePanel, int counter)
        {
            thePanel.Controls.Clear();
            PictureBox aPic;

            for (int i = 0; i < counter; i++)
            {
                string path = @"images\cardback.gif";

                aPic = new PictureBox()
                {
                    Image = Image.FromFile(path),
                    Width = 70,
                    Height = 100,
                    Left = 75 * i
                };
                thePanel.Controls.Add(aPic);
            }
        }

        /// <summary>
        /// Show the cards of a Player
        /// </summary>
        /// <param name="thePanel"></param>
        /// <param name="theHand"></param>
        private void ShowHand(Panel thePanel, Hand theHand)
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
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            SetUp();
            //For identifying the buttons to click easier
            btnStart.Enabled = false;
            btnContinue.Enabled = false;
            btnReset.Enabled = false;

        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            //Display instructions
            lblInstruct.Text = "Please click on the card you want to draw out. After that, you can click \r\n" +
                               "Continue so that the next player can play. \r\n" +
                               "If you wish to pass this turn, please click Continue without drawing any cards. \r\n" +
                               "After all players have done, please click End to show the full results of the game.\r\n" +
                                "\r\n If you wish to reset the game at anytime, please \r\n" +
                                   "choose the Reset button.";

            #region Instantiate the player's cards
            hand1 = aDeck.DealHand(13);
            hand1.SortCard();
            hand2 = aDeck.DealHand(13);
            hand2.SortCard();
            hand3 = aDeck.DealHand(13);
            hand3.SortCard();
            hand4 = aDeck.DealHand(13);
            hand4.SortCard();
            #endregion

            btnStart.Enabled = false;
            btnContinue.Enabled = true;
            btnContinue.Focus();

            #region To test which player has the three spades (which is the card have to start first)
            if (hand1.ContainsCard(threeSpadesCard))
            {
                ShowHand(Player1, hand1);
                Player2.Enabled = false;
                Player3.Enabled = false;
                Player4.Enabled = false;
            }
            else if (hand2.ContainsCard(threeSpadesCard))
            {
                ShowHand(Player2, hand2);
                Player3.Enabled = false;
                Player4.Enabled = false;
                Player1.Enabled = false;
            }
            else if (hand3.ContainsCard(threeSpadesCard))
            {
                ShowHand(Player3, hand3);
                Player4.Enabled = false;
                Player1.Enabled = false;
                Player2.Enabled = false;
            }
            else
            {
                ShowHand(Player4, hand4);
                Player1.Enabled = false;
                Player2.Enabled = false;
                Player3.Enabled = false;
            }
            #endregion
        }
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            try
            {
                //Display Instructions
                lblInstruct.Text = "Four hands have been divided to all players.\r\n" +
                                   "After deciding who is playing which hand, plese press \r\n" +
                                   "Start to begin the competition!! \r\n" +
                                   "\r\nThe player that has the Three Spades please draw out the combination with that card \r\n" +
                                   "\r\n If you wish to reset the game at anytime, please \r\n" +
                                   "choose the Reset button.";

                //This is to begin the game with the back of the cards for every players
                ShowBlankHand(Player1, 13);
                ShowBlankHand(Player2, 13);
                ShowBlankHand(Player3, 13);
                ShowBlankHand(Player4, 13);
                btnNewGame.Enabled = false;
                btnStart.Enabled = true;
                btnReset.Enabled = true;
                btnStart.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        private void PictureBox_Click(object sender, EventArgs e)
        {
            try
            {


                PictureBox picClicked = (PictureBox)sender;
                int cardPlayer1 = Player1.Controls.IndexOf(picClicked);
                int cardPlayer2 = Player2.Controls.IndexOf(picClicked);
                int cardPlayer3 = Player3.Controls.IndexOf(picClicked);
                int cardPlayer4 = Player4.Controls.IndexOf(picClicked);

                if (cardPlayer1 != -1)
                {
                    //To show the player has passed this turn
                    if (lblPlayer1.Text == "Player 1 (PASS)")
                    {
                        MessageBox.Show("This player has passed this turn.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //remove the card from the player's hand and put it into the DrawPlatform
                    Card drawnCard = hand1.RemoveCard((Card)picClicked.Tag);
                    DrawOutCard(drawnCard, hand1, Player1);

                }
                else if (cardPlayer2 != -1)
                {
                    if (lblPlayer2.Text == "Player 2 (PASS)")
                    {
                        MessageBox.Show("This player has passed this turn.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Card drawnCard = hand2.RemoveCard((Card)picClicked.Tag);
                    DrawOutCard(drawnCard, hand2, Player2);
                }
                else if (cardPlayer3 != -1)
                {
                    if (lblPlayer3.Text == "Player 3 (PASS)")
                    {
                        MessageBox.Show("This player has passed this turn.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Card drawnCard = hand3.RemoveCard((Card)picClicked.Tag);
                    DrawOutCard(drawnCard, hand3, Player3);
                }
                else if (cardPlayer4 != -1)
                {
                    if (lblPlayer4.Text == "Player 4 (PASS)")
                    {
                        MessageBox.Show("This player has passed this turn.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Card drawnCard = hand4.RemoveCard((Card)picClicked.Tag);
                    DrawOutCard(drawnCard, hand4, Player4);
                }
                //This else is used to retrieve the card from Draw Platform to the player's hand.
                else
                {
                    Card retrievedCard = drawHand.RemoveCard((Card)picClicked.Tag);

                    if (Player1.Enabled == true)
                    {
                        PutCardBack(retrievedCard, hand1, Player1);
                    }
                    if (Player2.Enabled == true)
                    {
                        PutCardBack(retrievedCard, hand2, Player2);
                    }
                    if (Player3.Enabled == true)
                    {
                        PutCardBack(retrievedCard, hand3, Player3);
                    }
                    if (Player4.Enabled == true)
                    {
                        PutCardBack(retrievedCard, hand4, Player4);
                    }

                }

                #region If all 3 other players have passed, the other one can start the turn again
                if (EnableAPlayerToPlayAfterAllPass())
                {
                    oldValue = 0;
                    PreviousDraw.Controls.Clear();
                    isExamined = false;

                    lblPlayer1.Text = "Player 1";
                    lblPlayer2.Text = "Player 2";
                    lblPlayer3.Text = "Player 3";
                    lblPlayer4.Text = "Player 4";
                    if (FinishedPlayer(lblPlayer1))
                    {
                        lblPlayer1.Text = "Player 1 (PASS)";
                    }
                    if (FinishedPlayer(lblPlayer2))
                    {
                        lblPlayer2.Text = "Player 2 (PASS)";
                    }
                    if (FinishedPlayer(lblPlayer3))
                    {
                        lblPlayer3.Text = "Player 3 (PASS)";
                    }
                    if (FinishedPlayer(lblPlayer4))
                    {
                        lblPlayer4.Text = "Player 4 (PASS)";
                    }

                }
                #endregion

                #region Clear the PreviousDraw so that the next player can start a new turn after the previous player won first place
                //This if here is to make the player 2 to start a new turn for the game.
                if (FinishedPlayer(lblPlayer1) && lblPlayer1.Text == "Player 1")
                {
                    lblPlayer1.Text = "Player 1 (PASS)";
                    ForceNextPlayerToPlayAfterWinning();
                    return;
                }
                //This if here is to make the player 3 to start a new turn for the game.
                if (FinishedPlayer(lblPlayer2) && lblPlayer2.Text == "Player 2")
                {
                    lblPlayer2.Text = "Player 2 (PASS)";
                    ForceNextPlayerToPlayAfterWinning();
                    return;
                }
                //This if here is to make the player 4 to start a new turn for the game.
                if (FinishedPlayer(lblPlayer3) && lblPlayer3.Text == "Player 3")
                {
                    lblPlayer3.Text = "Player 3 (PASS)";
                    ForceNextPlayerToPlayAfterWinning();
                    return;
                }
                //This if here is to make the player 1 to start a new turn for the game.
                if (FinishedPlayer(lblPlayer4) && lblPlayer4.Text == "Player 4")
                {
                    lblPlayer4.Text = "Player 4 (PASS)";
                    ForceNextPlayerToPlayAfterWinning();
                    return;
                }
                #endregion

                //Mark the code for the first place, then second place, then third place
                // then the fourth place (in the BtnContinue_Click)


                #region Code to make a player the third place

                #region Player 1
                // Player 1 - THIRD PLACE


                if (ThirdPlace(hand1, lblPlayer2, lblPlayer3, hand4) ||  //Player 2 and 3 have won
                    ThirdPlace(hand1, lblPlayer2, lblPlayer4, hand3) ||  //Player 2 and 4 have won
                    ThirdPlace(hand1, lblPlayer3, lblPlayer4, hand2))    //Player 3 and 4 have won
                {
                    MessageBox.Show("Nice! You (Player 1) come at the third in this game", "THIRD PLACE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ranking += "Player 1 : THIRD PLACE (3rd). ♣\r\n";
                    hand1 = winnerDeck.DealHand(3);
                    MakeAPlayerWin(Player1, lblPlayer1);
                    return;
                }
                #endregion

                #region Player 2
                // Player 2 - THIRD PLACE


                if (ThirdPlace(hand2, lblPlayer1, lblPlayer3, hand4) ||  //Player 1 and 3 have won 
                    ThirdPlace(hand2, lblPlayer3, lblPlayer4, hand1) ||  //Player 3 and 4 have won
                    ThirdPlace(hand2, lblPlayer1, lblPlayer4, hand3))   //Player 1 and 4 have won
                {
                    MessageBox.Show("Nice! You (Player 2) come at the third in this game", "THIRD PLACE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ranking += "Player 2 : THIRD PLACE (3rd).♣\r\n";
                    hand2 = winnerDeck.DealHand(3);
                    MakeAPlayerWin(Player2, lblPlayer2);
                    return;
                }
                #endregion

                #region Player 3
                // Player 3 - THIRD PLACE

                if (ThirdPlace(hand3, lblPlayer1, lblPlayer2, hand4) ||   //Player 1 and 2 have won 
                    ThirdPlace(hand3, lblPlayer1, lblPlayer4, hand2) ||  //Player 1 and 4 have won
                    ThirdPlace(hand3, lblPlayer4, lblPlayer2, hand1))    //Player 2 and 4 have won
                {
                    MessageBox.Show("Nice! You (Player 3) come at the third in this game", "THIRD PLACE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ranking += "Player 3 : THIRD PLACE (3rd).♣\r\n";
                    hand3 = winnerDeck.DealHand(3);
                    MakeAPlayerWin(Player3, lblPlayer3);
                    return;
                }
                #endregion

                #region Player 4
                // Player 4 - THIRD PLACE


                if (ThirdPlace(hand4, lblPlayer1, lblPlayer2, hand3) ||  //Player 1 and 2 have won
                    ThirdPlace(hand4, lblPlayer3, lblPlayer2, hand1) ||  //Player 2 and 3 have won 
                    ThirdPlace(hand4, lblPlayer1, lblPlayer3, hand2))    //Player 1 and 3 have won 
                {
                    MessageBox.Show("Nice! You (Player 4) come at the third in this game", "THIRD PLACE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ranking += "Player 4 : THIRD PLACE (3rd).♣\r\n";
                    hand4 = winnerDeck.DealHand(3);
                    MakeAPlayerWin(Player4, lblPlayer4);
                    return;
                }
                #endregion

                #endregion

                #region Code to make a player the second place

                #region Player 1
                //this is for making the player 1 the second place of the game

                //Player 2 is the first place already
                if (SecondPlace(hand1, lblPlayer2, hand3, hand4) ||
                    SecondPlace(hand1, lblPlayer3, hand2, hand4) ||
                    SecondPlace(hand1, lblPlayer4, hand2, hand3))
                {
                    MessageBox.Show("Great! You (Player 1) come at the Second place of this game", "SECOND PLACE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ranking += "Player 1 : SECOND PLACE (2nd).♦ \r\n";
                    hand1 = winnerDeck.DealHand(3);
                    MakeAPlayerWin(Player1, lblPlayer1);
                    return;
                }
                #endregion

                #region Player 2

                //Player 1 is the first place already
                if (SecondPlace(hand2, lblPlayer1, hand3, hand4) ||
                    SecondPlace(hand2, lblPlayer3, hand1, hand4) ||
                    SecondPlace(hand2, lblPlayer4, hand1, hand3))
                {
                    MessageBox.Show("Great! You (Player 2) come at the Second place of this game", "SECOND PLACE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ranking += "Player 2 : SECOND PLACE (2nd).♦\r\n";
                    hand2 = winnerDeck.DealHand(2);
                    MakeAPlayerWin(Player2, lblPlayer2);
                    return;
                }
                //Player 3 is the first place already
                if (SecondPlace(hand2, lblPlayer3, hand1, hand4))
                {
                    MessageBox.Show("Great! You (Player 2) come at the Second place of this game", "SECOND PLACE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ranking += "Player 2 : SECOND PLACE (2nd).♦\r\n";
                    hand2 = winnerDeck.DealHand(2);
                    MakeAPlayerWin(Player2, lblPlayer2);
                    return;
                }
                //Player 4 is the first place already
                if (SecondPlace(hand2, lblPlayer4, hand1, hand3))
                {
                    MessageBox.Show("Great! You (Player 2) come at the Second place of this game", "SECOND PLACE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ranking += "Player 2 : SECOND PLACE (2nd).♦\r\n";
                    hand2 = winnerDeck.DealHand(2);
                    MakeAPlayerWin(Player2, lblPlayer2);
                    return;
                }
                #endregion

                #region Player 3
                //this is for making the player 3 the second place of the game
                if (SecondPlace(hand3, lblPlayer1, hand2, hand4) ||
                   (SecondPlace(hand3, lblPlayer2, hand1, hand4)) ||
                   (SecondPlace(hand3, lblPlayer4, hand2, hand1)))
                {
                    MessageBox.Show("Great! You (Player 3) come at the Second place of this game", "SECOND PLACE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ranking += "Player 3 : SECOND PLACE (2nd).♦\r\n";
                    hand3 = winnerDeck.DealHand(2);
                    MakeAPlayerWin(Player3, lblPlayer3);
                    return;
                }

                #endregion

                #region Player 4
                //this is for making the player 4 the second place of the game

                if (SecondPlace(hand4, lblPlayer2, hand3, hand1) ||
                   (SecondPlace(hand4, lblPlayer3, hand2, hand1)) ||
                   (SecondPlace(hand4, lblPlayer1, hand2, hand3)))
                {
                    MessageBox.Show("Great! You (Player 4) come at the Second place of this game", "SECOND PLACE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ranking += "Player 4 : SECOND PLACE (2nd).♦\r\n";
                    hand4 = winnerDeck.DealHand(2);
                    MakeAPlayerWin(Player4, lblPlayer4);
                    return;
                }

                #endregion

                #endregion

                #region Code to make a player the first place
                //This is for when the player 1 is the first place, make the panel player 1 invisible
                if (Player1.Visible == false)
                {
                    return;

                }
                else
                {
                    if (FirstPlace(hand1, hand2, hand3, hand4))
                    {
                        MessageBox.Show("Congratulations! You (Player 1) are the winner of this game", "FIRST PLACE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ranking += "Player 1 : FIRST PLACE (1st).♥\r\n";
                        hand1 = winnerDeck.DealHand(1);
                        MakeAPlayerWin(Player1, lblPlayer1);
                        return;
                    }
                }

                //This is for when the player 2 is the first place, make the panel player 2 invisible
                if (Player2.Visible == false)
                {
                    return;

                }
                else
                {
                    if (FirstPlace(hand2, hand1, hand3, hand4))
                    {
                        MessageBox.Show("Congratulations! You (Player 2) are the winner of this game", "FIRST PLACE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ranking += "Player 2 : FIRST PLACE (1st).♥\r\n";
                        hand2 = winnerDeck.DealHand(1);
                        MakeAPlayerWin(Player2, lblPlayer2);
                        return;
                    }
                }

                //This is for when the player 3 is the first place, make the panel player 3 invisible
                if (Player3.Visible == false)
                {
                    return;

                }
                else
                {
                    if (FirstPlace(hand3, hand1, hand2, hand4))
                    {
                        MessageBox.Show("Congratulations! You (Player 3) are the winner of this game", "FIRST PLACE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ranking += "Player 3 : FIRST PLACE (1st).♥\r\n";
                        hand3 = winnerDeck.DealHand(1);
                        MakeAPlayerWin(Player3, lblPlayer3);
                        return;
                    }
                }

                //This is for when the player 4 is the first place, make the panel player 4 invisible
                if (Player4.Visible == false)
                {
                    return;

                }
                else
                {
                    if (FirstPlace(hand4, hand1, hand2, hand3))
                    {
                        MessageBox.Show("Congratulations! You (Player 4) are the winner of this game", "FIRST PLACE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ranking += "Player 4 : FIRST PLACE (1st).♥\r\n";
                        hand4 = winnerDeck.DealHand(1);
                        MakeAPlayerWin(Player4, lblPlayer4);
                        return;
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            #region Sort cards for every player
            hand1.SortCard();
            hand2.SortCard();
            hand3.SortCard();
            hand4.SortCard();
            #endregion

            #region Code to make the remaining player the last place

            //Player 1 is the fourth place
            if (HaveWon(lblPlayer2, lblPlayer3, lblPlayer4))
            {
                MessageBox.Show("Good work! You (Player 1) has lost the game (4th Place), try better next time.", "FOURTH PLACE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ranking += "Player 1 : FOURTH PLACE (4th).♠\r\n";
                ShowBlankHand(Player1, 0);
                Player1.Visible = false;
                EndTheGame();
                return;
            }

            //Player 2 is the fourth place
            if (HaveWon(lblPlayer1, lblPlayer3, lblPlayer4))
            {
                MessageBox.Show("Good work! You (Player 2) has lost the game (4th Place), try better next time.", "FOURTH PLACE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ranking += "Player 2 : FOURTH PLACE (4th).♠\r\n";
                ShowBlankHand(Player2, 0);
                Player2.Visible = false;
                EndTheGame();
                return;
            }

            //Player 3 is the fourth place
            if (HaveWon(lblPlayer1, lblPlayer2, lblPlayer4))
            {
                MessageBox.Show("Good work! You (Player 3) has lost the game (4th Place), try better next time.", "FOURTH PLACE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ranking += "Player 3 : FOURTH PLACE (4th).♠\r\n";
                ShowBlankHand(Player3, 0);
                Player3.Visible = false;
                EndTheGame();
                return;
            }

            //Player 4 is the fourth place
            if (HaveWon(lblPlayer2, lblPlayer3, lblPlayer1))
            {
                MessageBox.Show("Good work! You (Player 4) has lost the game (4th Place), try better next time.", "FOURTH PLACE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ranking += "Player 4 : FOURTH PLACE (4th).♠\r\n";
                ShowBlankHand(Player4, 0);
                Player4.Visible = false;
                EndTheGame();
                return;
            }
            #endregion

            #region Make the next player has to play after the previous player won first place
            //The player 1 is the winner and player 2 has to start a new turn or else we cant continue.
            if (FinishedPlayer(lblPlayer1) && lblPlayer1.Text == "Player 1" && drawHand.Count == 0)
            {
                lblPlayer1.Text = "Player 1 (PASS)";
                StartAgainAfterWinning();
                return;
            }

            //The player 2 is the winner and player 3 has to start a new turn or else we cant continue.
            if (FinishedPlayer(lblPlayer2) && lblPlayer2.Text == "Player 2" && drawHand.Count == 0)
            {
                lblPlayer2.Text = "Player 2 (PASS)";
                StartAgainAfterWinning();
                return;
            }

            //The player 3 is the winner and player 4 has to start a new turn or else we cant continue.
            if (FinishedPlayer(lblPlayer3) && lblPlayer3.Text == "Player 3" && drawHand.Count == 0)
            {
                lblPlayer3.Text = "Player 3 (PASS)";
                StartAgainAfterWinning();
                return;
            }

            //The player 4 is the winner and player 4 has to start a new turn or else we cant continue.
            if (FinishedPlayer(lblPlayer4) && lblPlayer4.Text == "Player 4" && drawHand.Count == 0)
            {
                lblPlayer4.Text = "Player 4 (PASS)";
                StartAgainAfterWinning();
                return;
            }
            #endregion

            #region The player has to start a turn with the 3 spades to continue after clicking the Start button
            if (previousHand.Count == 0 && drawHand.Count == 0)
            {
                MessageBox.Show("You have to start a new turn with combinations.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #endregion

            #region  The player has to draw out cards that are the same number as the previous one,

            if (previousHand.Count != drawHand.Count && previousHand.Count != 0 && drawHand.Count != 0 && isExamined == true)
            {
                MessageBox.Show("You have to draw appropriate combinations.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;


            }

            #endregion

            //This is the code for each player's turn.
            #region Player 1
            if (Player1.Enabled == true)
            {
                # region If all three other players have passed, the last one can not click Continue until draw cards.
                if ((lblPlayer2.Text == "Player 2 (PASS)" && lblPlayer3.Text == "Player 3 (PASS)" && lblPlayer4.Text == "Player 4 (PASS)"))
                {
                    MessageBox.Show("You have to start a new turn with combinations before continue.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                #endregion

                #region This if here is used when the player 2 has won and prevent 2 from playing
                if (FinishedPlayer(lblPlayer2))
                {
                    #region Execute when the player wants to pass.
                    if (drawHand.Count == 0)
                    {

                        lblPlayer1.Text = "Player 1 (PASS)";
                        Player2.Enabled = false;
                        lblPlayer2.Text = "Player 2 (PASS)";
                        Player3.Enabled = true;
                        if (value == 0)
                        {
                            //All these conditions are for when Player 2 has won with...
                            if (FinishedPlayer(lblPlayer3))  //with Player 3
                            {
                                Player3.Enabled = false;
                                PassPlayer(Player1, Player4, hand1, hand4);
                            }
                            else if (FinishedPlayer(lblPlayer4)) //with Player 4
                            {
                                Player4.Enabled = false;
                                PassPlayer(Player1, Player3, hand1, hand3);
                            }
                            else //The above players didnt win so continue with the player after Player 2
                            {
                                PassPlayer(Player1, Player3, hand1, hand3);
                            }
                            return;
                        }

                    }
                    #endregion

                    #region Execute when the player doesnt want to pass.
                    //If the player draws out cards that are smaller than the previous one
                    if (value < oldValue)
                    {
                        MessageBox.Show("You cannot play with these cards", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //All these conditions are for when Player 2 has won with...
                    if (FinishedPlayer(lblPlayer3))  //with Player 3
                    {
                        Player3.Enabled = false;
                        PassPlayer(Player1, Player4, hand1, hand4);
                    }
                    else if (FinishedPlayer(lblPlayer4)) //with Player 4
                    {
                        Player4.Enabled = false;
                        PassPlayer(Player1, Player3, hand1, hand3);
                    }
                    else //The above players didnt win so continue with the player after Player 2
                    {
                        PassPlayer(Player1, Player3, hand1, hand3);
                    }
                    oldValue = value;
                    value = 0;
                    #endregion

                }
                #endregion

                #region this else represents a turn of a player
                else
                {
                    //this if is used to identify if the player want to pass this turn
                    if (drawHand.Count == 0)
                    {
                        lblPlayer1.Text = "Player 1 (PASS)";
                        PassPlayer(Player1, Player2, hand1, hand2);
                        return;

                    }
                    //If the player draws out cards that are smaller than the previous one
                    if (value < oldValue)
                    {
                        MessageBox.Show("You cannot play with these cards", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    PassPlayer(Player1, Player2, hand1, hand2);
                    oldValue = value;
                    value = 0;

                }
                #endregion
            }
            #endregion

            #region Player 2
            else if (Player2.Enabled == true)
            {
                # region If all three other players have passed, the last one can not click Continue until draw cards.
                if ((lblPlayer1.Text == "Player 1 (PASS)" && lblPlayer3.Text == "Player 3 (PASS)" && lblPlayer4.Text == "Player 4 (PASS)"))
                {
                    MessageBox.Show("You have to start a new turn with combinations before continue.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                #endregion

                #region This if here is used when the player 3 has won and prevent 3 from playing
                if (Player3.Visible == false)
                {
                    #region Execute when the player wants to pass
                    if (drawHand.Count == 0)
                    {
                        lblPlayer2.Text = "Player 2 (PASS)";
                        Player3.Enabled = false;
                        lblPlayer3.Text = "Player 3 (PASS)";
                        if (value == 0)
                        {
                            if (FinishedPlayer(lblPlayer4))
                            {
                                Player4.Enabled = false;
                                PassPlayer(Player2, Player1, hand2, hand1);
                            }
                            else if (FinishedPlayer(lblPlayer1))
                            {
                                Player1.Enabled = false;
                                PassPlayer(Player2, Player4, hand2, hand4);
                            }
                            else
                            {
                                PassPlayer(Player2, Player4, hand2, hand4);
                            }
                            return;
                        }

                    }
                    #endregion

                    #region Execute when the player does not want to pass
                    //If the player draws out cards that are smaller than the previous one
                    if (value < oldValue)
                    {
                        MessageBox.Show("You cannot play with these cards", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //All these conditions are for when Player 3 has won with... (another player)
                    if (FinishedPlayer(lblPlayer4)) //Player 4
                    {
                        Player4.Enabled = false;
                        PassPlayer(Player2, Player1, hand2, hand1);
                    }
                    else if (FinishedPlayer(lblPlayer1)) //Player 1
                    {
                        Player1.Enabled = false;
                        PassPlayer(Player2, Player4, hand2, hand4);
                    }
                    else //continue with the next player after player 3
                    {
                        PassPlayer(Player2, Player4, hand2, hand4);
                    }
                    oldValue = value;
                    value = 0;
                    #endregion
                }
                #endregion

                #region this else represents a turn of a player
                else
                {
                    //this if is used to identify if the player want to pass this turn
                    if (drawHand.Count == 0)
                    {
                        lblPlayer2.Text = "Player 2 (PASS)";
                        PassPlayer(Player2, Player3, hand2, hand3);
                        return;

                    }
                    //If the player draws out cards that are smaller than the previous one
                    if (value < oldValue)
                    {
                        MessageBox.Show("You cannot play with these cards", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    PassPlayer(Player2, Player3, hand2, hand3);
                    oldValue = value;
                    value = 0;

                }
                #endregion
            }
            #endregion

            #region Player 3

            else if (Player3.Enabled == true)
            {
                # region If all three other players have passed, the last one can not click Continue until draw cards.
                if ((lblPlayer2.Text == "Player 2 (PASS)" && lblPlayer1.Text == "Player 1 (PASS)" && lblPlayer4.Text == "Player 4 (PASS)"))
                {
                    MessageBox.Show("You have to start a new turn with combinations before continue.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                #endregion

                #region This if here is used when the player 4 has won and prevent 4 from playing
                if (FinishedPlayer(lblPlayer4))
                {
                    #region Execute when the player wants to pass
                    if (drawHand.Count == 0)
                    {
                        lblPlayer3.Text = "Player 3 (PASS)";
                        Player4.Enabled = false;
                        lblPlayer4.Text = "Player 4 (PASS)";
                        Player1.Enabled = true;
                        if (value == 0)
                        {
                            //All these conditions are for when Player 4 has won with...
                            if (FinishedPlayer(lblPlayer1))   //Player 1
                            {
                                Player1.Enabled = false;
                                PassPlayer(Player3, Player2, hand3, hand2);
                            }
                            else if (FinishedPlayer(lblPlayer2)) //Player 2
                            {
                                Player2.Enabled = false;
                                PassPlayer(Player3, Player1, hand3, hand1);
                            }
                            else //continue with the player after player 4
                            {
                                PassPlayer(Player3, Player1, hand3, hand1);
                            }
                            return;
                        }
                    }
                    #endregion

                    #region Execute when the player doesnt want to pass
                    //If the player draws out cards that are smaller than the previous one
                    if (value < oldValue)
                    {
                        MessageBox.Show("You cannot play with these cards", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //All these conditions are for when Player 4 has won with...
                    if (FinishedPlayer(lblPlayer1))   //Player 1
                    {
                        Player1.Enabled = false;
                        PassPlayer(Player3, Player2, hand3, hand2);
                    }
                    else if (FinishedPlayer(lblPlayer2)) //Player 2
                    {
                        Player2.Enabled = false;
                        PassPlayer(Player3, Player1, hand3, hand1);
                    }
                    else //continue with the player after player 4
                    {
                        PassPlayer(Player3, Player1, hand3, hand1);
                    }
                    oldValue = value;
                    value = 0;
                    #endregion
                }
                #endregion

                #region this else represents a turn of a player
                else
                {
                    //this if is used to identify if the player want to pass this turn
                    if (drawHand.Count == 0)
                    {
                        lblPlayer3.Text = "Player 3 (PASS)";
                        PassPlayer(Player3, Player4, hand3, hand4);
                        return;

                    }
                    //If the player draws out cards that are smaller than the previous one
                    if (value < oldValue)
                    {
                        MessageBox.Show("You cannot play with these cards", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    PassPlayer(Player3, Player4, hand3, hand4);
                    oldValue = value;
                    value = 0;


                }
                #endregion
            }
            #endregion

            #region Player 4
            else
            {
                # region If all three other players have passed, the last one can not click Continue until draw cards.
                if ((lblPlayer2.Text == "Player 2 (PASS)" && lblPlayer3.Text == "Player 3 (PASS)" && lblPlayer1.Text == "Player 1 (PASS)"))
                {
                    MessageBox.Show("You have to start a new turn with combinations before continue.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                #endregion

                #region This if here is used when the player 1 has won and prevent 1 from playing
                if (FinishedPlayer(lblPlayer1))
                {
                    #region Execute when the player wants to pass
                    if (drawHand.Count == 0)
                    {
                        lblPlayer4.Text = "Player 4 (PASS)";
                        Player1.Enabled = false;
                        lblPlayer1.Text = "Player 1 (PASS)";
                        Player2.Enabled = true;
                        if (value == 0)
                        {
                            //All these conditions are for when Player 1 has won with...
                            if (FinishedPlayer(lblPlayer2)) //Player 2
                            {
                                Player2.Enabled = false;
                                PassPlayer(Player4, Player3, hand4, hand3);
                            }
                            else if (FinishedPlayer(lblPlayer3)) //Player 3
                            {
                                Player3.Enabled = false;
                                PassPlayer(Player4, Player2, hand4, hand2);
                            }
                            else //Continue with the player after player 1
                            {
                                PassPlayer(Player4, Player2, hand4, hand2);
                            }
                            return;
                        }
                    }
                    #endregion

                    #region  Execute when the player does not want to pass
                    //If the player draws out cards that are smaller than the previous one
                    if (value < oldValue)
                    {
                        MessageBox.Show("You cannot play with these cards", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //All these conditions are for when Player 1 has won with...
                    if (FinishedPlayer(lblPlayer2)) //Player 2
                    {
                        Player2.Enabled = false;
                        PassPlayer(Player4, Player3, hand4, hand3);
                    }
                    else if (FinishedPlayer(lblPlayer3)) //Player 3
                    {
                        Player3.Enabled = false;
                        PassPlayer(Player4, Player2, hand4, hand2);
                    }
                    else //Continue with the player after player 1
                    {
                        PassPlayer(Player4, Player2, hand4, hand2);
                    }
                    oldValue = value;
                    value = 0;
                    #endregion

                }
                #endregion

                #region this else represents a turn of a player
                else
                {
                    //this if is used to identify if the player want to pass this turn
                    if (drawHand.Count == 0)
                    {
                        lblPlayer4.Text = "Player 4 (PASS)";
                        PassPlayer(Player4, Player1, hand4, hand1);
                        return;
                    }
                    //If the player draws out cards that are smaller than the previous one
                    if (value < oldValue)
                    {
                        MessageBox.Show("You cannot play with these cards", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    PassPlayer(Player4, Player1, hand4, hand1);
                    oldValue = value;
                    value = 0;

                }
                #endregion
            }
            #endregion


            #region This is used to transfer the DrawPlatform's cards to the PreviousDraw.
            //The count = 0 here is when the player pass the turn so the PreviousDraw
            //will remain the same after clicking Continue button.
            if (drawHand.Count == 0)
            {
                ShowHand(PreviousDraw, previousHand);

            }
            //else the player's draw cards from the DrawPlatform will be transfered to the Previous Draw
            else
            {
                previousHand = drawHand;
                drawHand = new Hand();

                ShowHand(PreviousDraw, previousHand);
            }

            DrawPlatform.Controls.Clear();
            isExamined = true;

            #endregion
        }
        private void BtnReset_Click(object sender, EventArgs e)
        {
            SetUp();
            btnReset.Enabled = false;
            btnStart.Enabled = false;
            btnNewGame.Enabled = true;
            btnContinue.Enabled = false;

        }

        private void BtnEnd_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ranking, "RANKING RESULTS:");
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("You want to escape the game so soon?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
