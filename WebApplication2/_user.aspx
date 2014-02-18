<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="_user.aspx.cs" Inherits="WebStore._user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="height: 700px;">
    <h3> My Account</h3>
    <br />
    <asp:PlaceHolder ID="PlaceHolderInfo" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolderCart" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolderHistory" runat="server"></asp:PlaceHolder>
    

</div>


</asp:Content>
