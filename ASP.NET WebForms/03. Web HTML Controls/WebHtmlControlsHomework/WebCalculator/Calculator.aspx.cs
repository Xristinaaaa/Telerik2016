using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _5.WebCalculator
{
	public partial class Calculator : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		protected void button_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;

			this.textBoxDisplay.Text += button.Text;
		}

		protected void buttonClear_Click(object sender, EventArgs e)
		{
			this.textBoxDisplay.Text = string.Empty;
		}

		protected void buttonOperation_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;

			switch (button.Text)
			{
				case "+":
					this.lastOperation.Value = "+";
					this.Sum(this.textBoxDisplay.Text);
					break;
				case "-":
					this.lastOperation.Value = "-";
					this.Substraction(this.textBoxDisplay.Text);
					break;
				case "*":
					this.lastOperation.Value = "*";
					this.Addition(this.textBoxDisplay.Text);
					break;
				case "/":
					this.lastOperation.Value = "/";
					this.Division(this.textBoxDisplay.Text);
					break;
				case "√":
					var number = double.Parse(this.textBoxDisplay.Text);
					this.textBoxDisplay.Text = Math.Sqrt(number).ToString();
					break;

				default:
					break;
			}
		}

		private void Sum(string text)
		{
			this.helper.Value = text;
			this.textBoxDisplay.Text = string.Empty;
		}

		private void Substraction(string text)
		{
			this.helper.Value = text;
			this.textBoxDisplay.Text = string.Empty;
		}

		private void Addition(string text)
		{
			this.helper.Value = text;
			this.textBoxDisplay.Text = string.Empty;
		}

		private void Division(string text)
		{
			this.helper.Value = text;
			this.textBoxDisplay.Text = string.Empty;
		}

		protected void buttonEqual_Click(object sender, EventArgs e)
		{
			switch (this.lastOperation.Value)
			{
				case "+":
					this.textBoxDisplay.Text = (decimal.Parse(this.helper.Value) + decimal.Parse(this.textBoxDisplay.Text)).ToString();
					break;
				case "-":
					this.textBoxDisplay.Text = (decimal.Parse(this.helper.Value) - decimal.Parse(this.textBoxDisplay.Text)).ToString();
					break;
				case "*":
					this.textBoxDisplay.Text = (decimal.Parse(this.helper.Value) * decimal.Parse(this.textBoxDisplay.Text)).ToString();
					break;
				case "/":
					this.textBoxDisplay.Text = (decimal.Parse(this.helper.Value) / decimal.Parse(this.textBoxDisplay.Text)).ToString();
					break;
				default:
					break;
			}
		}
	}
}