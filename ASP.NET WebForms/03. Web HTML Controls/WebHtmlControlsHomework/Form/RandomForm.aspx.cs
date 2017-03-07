using System;

namespace Form
{
    public partial class RandomForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            if (this.textBox.Text == null)
            {
                this.showTextLabel.Text = "Please enter text!";
                return;
            }

            string text = this.textBox.Text;

            this.showTextBox.Text = text;
            this.showTextLabel.Text = Server.HtmlEncode(text);
        }
    }
}