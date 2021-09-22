using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//form2 = new Form2();
//form2.ShowDialog();

namespace NumberGame
{
    public partial class Form1 : Form
    {
        Form2 form2;
        int count = 0;
        int plusMinusCount = 0;
        int currentValue = 0;
        int oldValue = 0;
        int firstValue = 0;
        int computerGuessNumber;
        int playerGuessNumber;
        int suggestedNumber;
        int computerNumber = randomNumberGenerator();

        public class cowsAndBullsGame
        {
            int guessNumber;
            public cowsAndBullsGame(int number)
            {
                guessNumber = number;

            }
            public void digitCompare(int computerNumber, ref int countCows, ref int countBulls)
            {
                int guessDigit1 = 0;
                int guessDigit2 = 0;
                int guessDigit3 = 0;
                int guessDigit4 = 0;
                int flagDigit1 = 0;
                int flagDigit2 = 0;
                int flagDigit3 = 0;
                int flagDigit4 = 0;

                int computerDigit1 = (computerNumber / 1000) % 10;
                int computerDigit2 = (computerNumber / 100) % 10;
                int computerDigit3 = (computerNumber / 10) % 10;
                int computerDigit4 = (computerNumber / 1) % 10;

                guessDigit1 = (guessNumber / 1000) % 10;
                guessDigit2 = (guessNumber / 100) % 10;
                guessDigit3 = (guessNumber / 10) % 10;
                guessDigit4 = (guessNumber / 1) % 10;

                int digitToCheck1 = computerDigit1;
                int digitToCheck2 = computerDigit2;
                int digitToCheck3 = computerDigit3;
                int digitToCheck4 = computerDigit4;
                for (int i = 0; i <= 9; i++)
                {
                    if (flagDigit1 == 0)
                    {
                        if (guessDigit1 == digitToCheck1)
                        {
                            countBulls++;
                            flagDigit1 = 1;
                        }
                        else if (guessDigit1 == digitToCheck2)
                        {
                            countCows--;
                            flagDigit1 = 1;
                        }
                        else if (guessDigit1 == digitToCheck3)
                        {
                            countCows--;
                            flagDigit1 = 1;
                        }
                        else if (guessDigit1 == digitToCheck4)
                        {
                            countCows--;
                            flagDigit1 = 1;
                        }
                    }

                    if (flagDigit2 == 0)
                    {
                        if (guessDigit2 == digitToCheck2)
                        {
                            countBulls++;
                            flagDigit2 = 1;
                        }
                        else if (guessDigit2 == digitToCheck1)
                        {
                            countCows--;
                            flagDigit2 = 1;
                        }
                        else if (guessDigit2 == digitToCheck3)
                        {
                            countCows--;
                            flagDigit2 = 1;
                        }
                        else if (guessDigit2 == digitToCheck4)
                        {
                            countCows--;
                            flagDigit2 = 1;
                        }
                    }

                    if (flagDigit3 == 0)
                    {

                        if (guessDigit3 == digitToCheck3)
                        {
                            countBulls++;
                            flagDigit3 = 1;
                        }
                        else if (guessDigit3 == digitToCheck1)
                        {
                            countCows--;
                            flagDigit3 = 1;
                        }
                        else if (guessDigit3 == digitToCheck2)
                        {
                            countCows--;
                            flagDigit3 = 1;
                        }
                        else if (guessDigit3 == digitToCheck4)
                        {
                            countCows--;
                            flagDigit3 = 1;
                        }
                    }

                    if (flagDigit4 == 0)
                    {
                        if (guessDigit4 == digitToCheck4)
                        {
                            countBulls++;
                            flagDigit4 = 1;
                        }
                        else if (guessDigit4 == digitToCheck1)
                        {
                            countCows--;
                            flagDigit4 = 1;
                        }
                        else if (guessDigit4 == digitToCheck2)
                        {
                            countCows--;
                            flagDigit4 = 1;
                        }
                        else if (guessDigit4 == digitToCheck3)
                        {
                            countCows--;
                            flagDigit4 = 1;
                        }
                    }
                }
            }
        }


        bool IsUnique(string text) //checks if input number digits are unique
        {
            if (text[0] == text[1] || text[0] == text[2] || text[0] == text[3] ||
                text[1] == text[2] || text[1] == text[3] || text[2] == text[3])
                return false;
            else
                return true;
        }

        static int randomNumberGenerator() //generates a random number with unique digits
        {
            int min = 1000;
            int max = 9999;
            Random number = new Random();

            int generatedDigit1 = 0;
            int generatedDigit2 = 0;
            int generatedDigit3 = 0;
            int generatedDigit4 = 0;

            int generatedNumber = 0;

            while (generatedDigit1 == generatedDigit2 || generatedDigit1 == generatedDigit3 || generatedDigit1 == generatedDigit4 ||
                   generatedDigit2 == generatedDigit3 || generatedDigit2 == generatedDigit4 || generatedDigit3 == generatedDigit4)
            {
                generatedNumber = number.Next(min, max);
                generatedDigit1 = (generatedNumber / 1000) % 10;
                generatedDigit2 = (generatedNumber / 100) % 10;
                generatedDigit3 = (generatedNumber / 10) % 10;
                generatedDigit4 = (generatedNumber / 1) % 10;
                
            }

            return generatedNumber;
        }

        bool plusMinusCheck(string x)
        {
            var plusminuscheck = new[] { "+", "-" };
            bool value = plusminuscheck.Any(x.Contains);
            return value;
        }


        public Form1()
        {
            
            InitializeComponent();
            
            radioButton1.Checked = true;
            textBox1.Text = "Guess the 4-digit number";
            textBox2.Text = "0";
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            label1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            string numberToGuess = randomNumberGenerator().ToString();


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox1.Text = "Guess the 4-digit number";
                textBox2.Visible = false;
                textBox3.Visible = false;
                label1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                string numberToGuess = randomNumberGenerator().ToString();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                textBox1.Text = "Enter a 4-digit number";
                textBox3.Visible = false;
                textBox4.Visible = false;

            }

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (radioButton1.Checked == true && textBox1.Text.Length == 0)
                textBox1.Text = "Guess the 4-digit number";
            else if (radioButton2.Checked == true && textBox1.Text.Length == 0)
                textBox1.Text = "Enter a 4-digit number";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 4)
            {
                MessageBox.Show("Please enter 4 digits");
                textBox1.Text = "";
            }
            if (radioButton2.Checked == true && textBox1.TextLength == 4)
            {
                
                if (IsUnique(textBox1.Text) == false)
                {
                    MessageBox.Show("Please enter unique digits");
                }

                else if (textBox1.Text.StartsWith("0") == true)
                {
                    MessageBox.Show("Number cannot start with 0");
                    textBox1.Text = "";
                }
                else
                {
                    count++;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = false;
                    label1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    computerGuessNumber = int.Parse(textBox1.Text);
                }
            }

            if (radioButton1.Checked == true && textBox1.TextLength == 4)
            {
                if (IsUnique(textBox1.Text) == false)
                {
                    MessageBox.Show("Please enter unique digits");
                }
                else if (textBox1.TextLength != 4)
                {
                    MessageBox.Show("Please enter 4 digits");
                    textBox1.Text = "";
                }
                else if (textBox1.Text.StartsWith("0") == true)
                {
                    MessageBox.Show("Number cannot start with 0");
                    textBox1.Text = "";
                }
                else
                {
                    playerGuessNumber = int.Parse(textBox1.Text);
                    textBox4.Visible = true;
                    cowsAndBullsGame Game1 = new cowsAndBullsGame(playerGuessNumber);
                    int cows=0;
                    int bulls=0;
                    
                    Game1.digitCompare(computerNumber, ref cows, ref bulls);
                    textBox4.Text = computerNumber.ToString();
                    if (cows != 0 && bulls != 0)
                    {
                        MessageBox.Show(cows.ToString());
                        MessageBox.Show("+" + bulls.ToString());
                    }
                    else if (cows == 0 && bulls != 0)
                    {
                        MessageBox.Show("+" + bulls.ToString());
                        if (bulls == 4)
                            MessageBox.Show("Correct");
                    }
                    else if (cows != 0 && bulls == 0)
                        MessageBox.Show(cows.ToString());
                    else
                        MessageBox.Show("0");
                }
            }

        }       

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsSymbol(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "0";
            while (plusMinusCount <= 2)
            {
                oldValue = currentValue;
                firstValue = oldValue;
                plusMinusCount++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentValue = int.Parse(textBox2.Text);
            if (currentValue < 4)
            {
                currentValue++;
            }
            textBox2.Text = currentValue.ToString();           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentValue = int.Parse(textBox2.Text);
            if (currentValue > -4)
            {
                currentValue--;
            }
            textBox2.Text = currentValue.ToString();
        }
    }
}
