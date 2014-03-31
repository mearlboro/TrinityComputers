<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="hdd.aspx.cs" Inherits="WebStore.hdd" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <meta http-equiv="Page-Enter" content="progid:DXImageTransform.Microsoft.GradientWipe(duration=2,irisStyle=star)">
<meta http-equiv="Page-Exit" content="progid:DXImageTransform.Microsoft.GradientWipe(duration=2,irisStyle=star)">

 <script language="javascript">

                document.body.style.scrollbarFaceColor = #700000
                document.body.style.scrollbarArrowColor = #700000
                document.body.style.scrollbarTrackColor = "black"
                document.body.style.scrollbarShadowColor = "black"
                document.body.style.scrollbarHighlightColor = "black"
                document.body.style.scrollbar3dlightColor = "black"
                document.body.style.scrollbarDarkshadowColor = "black"
            </script>

             
    <script src="js/jquery-1.7.2.min.js"></script>
    <script src="js/lightbox.js"></script>
    <link href="Styles/lightbox.css" rel="stylesheet" />

<div id="Content1" style="height:700px;">
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="baza.mdb" 
        SelectCommand="SELECT * FROM [Stocare]"></asp:AccessDataSource>
    <asp:PlaceHolder ID="MainPlaceHolder" runat="server">
    <table style="width:100%; text-align:center;">
        <tr>
            <td style="height: 35px" colspan="3">
                
               Hard Drives</td>
        </tr>
        
   </asp:PlaceHolder>
    </div>
</asp:Content>
