<%@ Page Language="C#" CodeBehind="HelloName.aspx.cs" Inherits="_1.HelloWebForms.HelloName" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:Label ID="Label1" Text="Enter name: " runat="server" />
		<br />
		<asp:TextBox ID="Name" runat="server" />
		<asp:Button ID="Button" Text="Result" runat="server" />
		<br />
		<asp:Label ID="Label2" Text="text" runat="server" />
    </div>
    </form>
</body>
</html>
