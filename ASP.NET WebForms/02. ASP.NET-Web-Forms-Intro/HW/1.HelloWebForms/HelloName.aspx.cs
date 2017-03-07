using System;
using System.Web.UI;

namespace _1.HelloWebForms
{
	public partial class HelloName : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			this.Label2.Text = string.Format("Hello, {0}", Server.HtmlEncode(Name.Text));
		}
	}
}