<%@ Page 
    Title="About" 
    Language="C#" 
    MasterPageFile="~/EnMasterPage.master"
    AutoEventWireup="true" 
    CodeBehind="About.aspx.cs"
    Inherits="NestedMasterPages.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="EnContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
</asp:Content>
