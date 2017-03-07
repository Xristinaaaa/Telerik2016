using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentsAndCourses
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            this.Response.Write($@"<h3>First Name: {this.firstName.Text}</h3>
                                <h3>LastName: {this.lastName.Text}</h3>
                                <h3>Fac Num: {this.facultyNumber.Text}</h3>
                                <h3>University: {this.DropDownListUniversities.Text}</h3>
                                <h3>Specialty: {this.DropDownListSpecialties.Text}</h3>
                                <h3>Courses:</h3>");

            this.Response.Write("<ul>");

            foreach (ListItem item in this.Courses.Items)
            {
                if (item.Selected)
                {
                    this.Response.Write($"<li>{item.Value}</li>");
                }
            }

            this.Response.Write("</ul>");
            this.Response.End();
        }
    }
}