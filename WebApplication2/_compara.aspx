<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="_Compare.aspx.cs" Inherits="WebStore._Compare" %>


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

<div id="Content1" style="height:700px;overflow:auto;">
  

    <br />
    <table>
        <tr>
            <td style="width:270px;text-align:center">
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
            </td>
            <td style="width:270px;text-align:center">
    <asp:DropDownList ID="DropDownList2" runat="server">
    </asp:DropDownList>
            </td>
            <td>
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
        Text="Compară" />
            </td>
        </tr>
        <tr>
            <td>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </td>
            <td>
    <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
  

            </td>
        </tr>
    </table>
  

    <asp:Label ID="Label1" runat="server" 
        Text="Nu se pot Compare decat piesele de acelasi tip"></asp:Label>
  

</div>
</asp:Content>