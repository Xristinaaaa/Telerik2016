using System;
using System.Reflection;
using System.Web.UI;

namespace _2.HelloASP
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			this.Label2.Text = string.Format("Hello, ASP.NET");
			this.Location.Text = Assembly.GetExecutingAssembly().Location.ToString();
		}
	}
}