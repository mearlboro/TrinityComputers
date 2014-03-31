<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="sitemap.aspx.cs" Inherits="WebStore.Styles.impl" %>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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


<div id="Content1" style="height:700px;width: 820px; position:relative; left: 20px; overflow:auto;">

    <br /><br />
<span style="font-size: larger;">
    <asp:Label ID="prez" runat="server">

<ul type=circle><b>Site map</b>
    <li><a href="home.aspx">Home</a></li>
    <li>Products
    <ul type=disc>
        <li><a href="mother.aspx">Motherboards</a></li>
        <li><a href="cpu.aspx">CPUs</a></li>                    
        <li><a href="graphics.aspx">Graphics Cards</a></li>
        <li><a href="ram.aspx">Memory</a></li>                    
        <li><a href="audio.aspx">Sound Cards</a></li>                   
        <li><a href="hdd.aspx">Hard drives</a></li>                   
        <li><a href="ups.aspx">Power supplies</a></li>                    
    </ul>
    </li>
    <li>Services
    <ul type="circle">
                    <li><a href="_cart.aspx">Shopping cart</a></li>
                    <li><a href="_compare.aspx">Compare</a>     </li>                              
                    <li><a href="_configurator.aspx">Configure</a></li>
    </ul>
    </li>
<li><a href="about.aspx">About</a></li>
<li><a href="sitemap.aspx">Site Map</a></li>
</ul>


</asp:Label>

</span>
</div>
</asp:Content>

