<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="StudentsAndCourses.Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
		<asp:Label ID="firstNameLabel" runat="server">First Name: </asp:Label>
        <asp:TextBox ID="firstName" runat="server" CssClass="form-control" />
		<br />

		<asp:Label ID="lastNameLabel" runat="server">Last Name: </asp:Label>
        <asp:TextBox ID="lastName" runat="server" CssClass="form-control" />
		<br />

		<asp:Label ID="facultyNumberLabel" runat="server">Faculty Number: </asp:Label>
        <asp:TextBox ID="facultyNumber" runat="server" CssClass="form-control" />
		<br />

		<asp:Label ID="universityLabel" runat="server">University: </asp:Label>
        <asp:DropDownList ID="DropDownListUniversities" runat="server"
            AutoPostBack="True">
            <asp:ListItem Value="Sofia University">Sofia University</asp:ListItem>
            <asp:ListItem Value="New Bulgarian University">New Bulgarian University</asp:ListItem>
            <asp:ListItem Value="Medical University">Medical University - Sofia</asp:ListItem>
            <asp:ListItem Value="Technical University">Technical University</asp:ListItem>
            <asp:ListItem Value="NWE University">University of National and World Economy</asp:ListItem>
        </asp:DropDownList>
		<br />

        <asp:DropDownList ID="DropDownListSpecialties" runat="server"
            AutoPostBack="True">
            <asp:ListItem Value="SE">Software Engineering</asp:ListItem>
            <asp:ListItem Value="CS">Computer Science</asp:ListItem>
            <asp:ListItem Value="PH">Philosophy</asp:ListItem>
            <asp:ListItem Value="PR">Public relations</asp:ListItem>
        </asp:DropDownList>
		<br />

        <asp:CheckBoxList ID="Courses" runat="server">
            <asp:ListItem Text="Data Structures and Algorithms" Value="Data Structures and Algorithms" />
            <asp:ListItem Text="Python for everybody" Value="Python for everybody" Selected="True" />
            <asp:ListItem Text="Java fundamentals" Value="Java fundamentals" />
            <asp:ListItem Text="Game design and development" Value="Game design and development" />
            <asp:ListItem Text="IOS" Value="IOS" />
        </asp:CheckBoxList>
		<br />

        <asp:Button ID="ButtonSubmit" runat="server"
            Text="Submit" OnClick="ButtonSubmit_Click" />
    </form>
</body>
</html>
