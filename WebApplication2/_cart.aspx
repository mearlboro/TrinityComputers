<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="_cart.aspx.cs" Inherits="WebStore._cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


 <script language="javascript">

                document.body.style.scrollbarFaceColor = #700000
                document.body.style.scrollbarArrowColor = #700000
                document.body.style.scrollbarTrackColor = "black"
                document.body.style.scrollbarShadowColor = "black"
                document.body.style.scrollbarHighlightColor = "black"
                document.body.style.scrollbar3dlightColor = "black"
                document.body.style.scrollbarDarkshadowColor = "black"
            </script>

<div id="Content1" style="height:700px;overflow:auto;">

    <span style="font-size:large">
    
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    
    <asp:Label ID="LabelTotal" runat="server" Text="Total: 0.00 £" Visible="False"></asp:Label>

    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="LabelEmpty" runat="server">Your cart is empty!</asp:Label>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
        Text="EMPTY" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
        Text="PLACE ORDER" />


</div>

</asp:Content>
