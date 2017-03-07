using System;
using System.Threading;
using System.Web.UI.WebControls;

namespace TicTacToe
{
    public partial class TicToe : System.Web.UI.Page
    {
        private Button[] buttons;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.buttons = new Button[] {
                this.Button1,
                this.Button2,
                this.Button3,
                this.Button4,
                this.Button5,
                this.Button6,
                this.Button7,
                this.Button8,
                this.Button9
            };
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            this.HandleClick(but);
        }

        private void HandleClick(Button button)
        {
            button.Text = "O";
            button.Attributes.Add("disabled", "disabled");
            this.HandleVictory();

            ComputerMove();
        }

        private void ComputerMove()
        {
            Thread.Sleep(500);
            this.Span.Text = "Computer is thinking ...";
            Random rand = new Random();
            int position = rand.Next(0, 9);
            Button currentButton = this.buttons[position];

            if (currentButton.Text == string.Empty)
            {
                currentButton.Text = "X";
                this.HandleVictory();

                return;
            }

            this.ComputerMove();
        }

        private void HandleVictory()
        {
            if (CheckIfWon())
            {
                foreach (var b in this.buttons)
                {
                    b.Attributes.Add("disabled", "disabled");
                }

                this.Span.Text = "Someone won!";
            }
            else
            {
                this.Span.Text = "Your move!";
            }
        }

        private bool CheckIfWon() //TODO: fix!
        {
            if (!string.IsNullOrEmpty(this.Button1.Text) && this.Button1.Text == this.Button2.Text && this.Button1.Text == this.Button3.Text)
            {
                return true;
            }

            if (!string.IsNullOrEmpty(this.Button4.Text) && this.Button4.Text == this.Button5.Text && this.Button4.Text == this.Button6.Text)
            {
                return true;
            }

            if (!string.IsNullOrEmpty(this.Button7.Text) && this.Button7.Text == this.Button8.Text && this.Button7.Text == this.Button9.Text)
            {
                return true;
            }

            if (!string.IsNullOrEmpty(this.Button1.Text) && this.Button1.Text == this.Button4.Text && this.Button1.Text == this.Button7.Text)
            {
                return true;
            }

            if (!string.IsNullOrEmpty(this.Button2.Text) && this.Button2.Text == this.Button5.Text && this.Button2.Text == this.Button8.Text)
            {
                return true;
            }

            if (!string.IsNullOrEmpty(this.Button3.Text) && this.Button3.Text == this.Button6.Text && this.Button3.Text == this.Button9.Text)
            {
                return true;
            }

            if (!string.IsNullOrEmpty(this.Button1.Text) && this.Button1.Text == this.Button5.Text && this.Button1.Text == this.Button9.Text)
            {
                return true;
            }

            if (!string.IsNullOrEmpty(this.Button3.Text) && this.Button3.Text == this.Button5.Text && this.Button3.Text == this.Button7.Text)
            {
                return true;
            }

            return false;
        }
    }
}