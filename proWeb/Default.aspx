<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Products Mananagement</h2>
    
    <table>
        <tr>
            <td>Code:</td>
            <td><asp:TextBox ID="tbCode" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Name:</td>
            <td><asp:TextBox ID="tbName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Amount:</td>
            <td><asp:TextBox ID="tbAmount" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
                <td>Category:</td>
    <td><asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList></td>
</tr>
<tr>
            <td>Price:</td>
            <td><asp:TextBox ID="tbPrice" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
           
            <td>Creation Date:</td>
            <td><asp:TextBox ID="tbDate" runat="server"></asp:TextBox></td>
        </tr>
    </table>

    <br />
    <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" />
    <asp:Button ID="btnRead" runat="server" Text="Read" OnClick="btnRead_Click" />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
    
    <br /><br />
    <asp:Button ID="btnReadFirst" runat="server" Text="Read First" OnClick="btnReadFirst_Click" />
    <asp:Button ID="btnReadPrev" runat="server" Text="Read Prev" OnClick="btnReadPrev_Click" />
    <asp:Button ID="btnReadNext" runat="server" Text="Read Next" OnClick="btnReadNext_Click" />

    <br /><br />
    <asp:Label ID="lblMessage" runat="server" Font-Bold="true"></asp:Label>

</asp:Content>