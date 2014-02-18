<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="_configurator.aspx.cs" Inherits="WebStore.configurator" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<meta http-equiv="Page-Enter" content="progid:DXImageTransform.Microsoft.GradientWipe(duration=2,irisStyle=star)"/>
<meta http-equiv="Page-Exit" content="progid:DXImageTransform.Microsoft.GradientWipe(duration=2,irisStyle=star)"/>

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
            <td style="text-align:center; width: 300px;">
                <asp:DropDownList ID="DropDownList3" runat="server">
                </asp:DropDownList>
            </td>
            <td style="text-align:center; width: 200px;">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="Button3" runat="server" Text="Generează configuraţii" 
                    onclick="Button3_Click" />
            </td>
        </tr>
    </table>
    <asp:PlaceHolder ID="listPlaceHolder" runat="server"></asp:PlaceHolder>
    <br />
  

</div>
</asp:Content>