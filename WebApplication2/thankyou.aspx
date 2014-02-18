<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="thankyou.aspx.cs" Inherits="WebStore.thankyou" %>

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
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

    <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
        DataFile="Z:\\info\\PROJECTS\\trinity_web\\WebApplication2\\baza.mdb" 
        DeleteCommand="DELETE FROM [User] WHERE [Username] = ?" 
        InsertCommand="INSERT INTO [User] ([Username], [Password], [Email], [Address], [Current_cart], [Order_history]) VALUES (?, ?, ?, ?, ?, ?)" 
        SelectCommand="SELECT * FROM [User]" 
        UpdateCommand="UPDATE [User] SET [Current_cart] = ?, [Order_history] = ? WHERE [Username] = ?">
        <DeleteParameters>
            <asp:Parameter Name="Username" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Username" Type="String" />
            <asp:Parameter Name="Password" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Address" Type="String" />
            <asp:Parameter Name="Current_cart" Type="String" />
            <asp:Parameter Name="Order_history" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:SessionParameter DefaultValue="" Name="Current_cart" 
                SessionField="cartEncoded" Type="String" />
            <asp:SessionParameter DefaultValue="" Name="Order_history" 
                SessionField="historyEncoded" Type="String" />
            <asp:SessionParameter Name="Username" SessionField="username" Type="String" />
        </UpdateParameters>
    </asp:AccessDataSource>

    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The order has been added to the database!
</div>
</asp:Content>
