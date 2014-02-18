<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebStore.home" %>
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

<div id="Content1" style="height:700px;width: 820px; position:relative; left: 20px; overflow:auto;">
Font size:
<asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
        onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
        RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem>Small</asp:ListItem>
        <asp:ListItem>Medium</asp:ListItem>
        <asp:ListItem>Large</asp:ListItem>
    </asp:RadioButtonList>
   <br /><br />
  <span style="font-size: larger;">

      <asp:Label ID="prez" runat="server">
 
I. <br/><br/>
	 Bun venit pe <i>Trinity Computers</i>, site-ul care îţi face singur configuraţia la calculator!<br /><br />
 Orice magazin are nevoie de sisteme performante de gestiune a produselor, astfel încât inventarele să devină redundante şi marfa securizată; un magazin on-line nu face excepţie de la această regulă, ci în special are nevoie ca aceste tehnologii să fie fiabile, eficiente şi organizate.
	<br/><br/>Activitatea unui site on-line care vinde piese de calculator poate fi uşor implementată în structuri orientate pe obiecte. Accesul clientului la informaţiile despre produse este înlesnit, precum şi serviciile aduse de site.
    <br/><br/>Aţi dorit vreodată să cumpăraţi un calculator încadrându-vă într-o sumă dată dar v-a fost difcil să alegeţi piesele, deoarece nu aveţi cunoştinţe de performanţă, valoare şi compatibilitate? Aţi auzit de i7 şi vreţi un calculator cu el înauntru, dar nu ştiţi cu ce se potriveşte? Serviciile aduse de site-ul nostru se referă la un ajutor virtual în alcătuirea unei configuraţii de calculator. 
	<br/><br/>În soluţia propusă de noi pentru această idee ne-am folosit de un program implementat pe obiecte care se ocupă exclusiv de operaţiile efectuate de cumpărător cu aceste produsele selectate înaintea cumpărării lor propriu-zise.
    <br/><br/>

</asp:Label>

    </span>
</div>
</asp:Content>
