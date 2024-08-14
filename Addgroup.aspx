<%@ Page Language="C#" MasterPageFile="~/Usermas.master" AutoEventWireup="true" CodeFile="Addgroup.aspx.cs" Inherits="Addgroup" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align=center>
<br />
    <asp:Label ID="Label1" runat="server" Text="Create Group Here" Font-Bold="True" 
        Font-Size="Large"></asp:Label>
<br />

<table width="450" height="90">
<tr>
<td>

    <asp:Label ID="Label2" runat="server" Text="Group Name" Font-Bold="True"></asp:Label>
</td>
<td>

    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</td>
</tr>


</table>
    <asp:Button ID="Button1" runat="server" Text="Create" onclick="Button1_Click" />
    <br />
     <br />
    <asp:Label ID="Label4" runat="server" Text="Group Details" Font-Bold="True"></asp:Label>
    <br />
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" Width="500px" onrowdeleting="GridView1_RowDeleting" 
        onselectedindexchanging="GridView1_SelectedIndexChanging">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#E3EAEB" />
        <Columns>
            <asp:CommandField SelectText="Join" ShowSelectButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#7C6F57" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
     <br />
     
      <br />
     <br />
    <asp:Label ID="Label5" runat="server" Text="Join Group Details" Font-Bold="True"></asp:Label>
    <br />
    <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" Width="500px" onrowdeleting="GridView2_RowDeleting">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#E3EAEB" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" DeleteText="Revocation" />
        </Columns>
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#7C6F57" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
     <br />
     
     
      <br />
     <br />
    <asp:Label ID="Label6" runat="server" Text="Group Members" Font-Bold="True"></asp:Label>
    <br />
    <asp:GridView ID="GridView3" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" Width="500px">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#E3EAEB" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#7C6F57" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
     <br />
</div>
</asp:Content>

