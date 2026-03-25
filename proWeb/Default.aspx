<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Products management</h2> [cite: 156]
    
    <table style="width: 100%;">
        <tr>
            <td>Code</td>
            <td><asp:TextBox ID="tbCode" runat="server" MaxLength="16"></asp:TextBox></td> [cite: 157, 189]
        </tr>
        <tr>
            <td>Name</td>
            <td><asp:TextBox ID="tbName" runat="server" MaxLength="32"></asp:TextBox></td> [cite: 158, 190]
        </tr>
        <tr>
            <td>Amount</td>
            <td><asp:TextBox ID="tbAmount" runat="server" TextMode="Number"></asp:TextBox></td> [cite: 159, 191]
        </tr>
        <tr>
            <td>Category</td>
            <td>
                <asp:DropDownList ID="ddlCategory" runat="server">
                    <asp:ListItem Value="0">Computing</asp:ListItem> [cite: 197]
                    <asp:ListItem Value="1">Telephony</asp:ListItem> [cite: 197]
                    <asp:ListItem Value="2">Gaming</asp:ListItem> [cite: 197]
                    <asp:ListItem Value="3">Home appliances</asp:ListItem> [cite: 197]
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Price</td>
            <td><asp:TextBox ID="tbPrice" runat="server"></asp:TextBox></td> [cite: 161, 192]
        </tr>
        <tr>
            <td>Creation Date</td>
            <td><asp:TextBox ID="tbDate" runat="server"></asp:TextBox></td> [cite: 162, 196]
        </tr>
    </table>

    <br />
    <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" /> [cite: 163]
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" /> [cite: 164]
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" /> [cite: 165]
    <asp:Button ID="btnRead" runat="server" Text="Read" OnClick="btnRead_Click" /> [cite: 166]
    <asp:Button ID="btnReadFirst" runat="server" Text="Read First" OnClick="btnReadFirst_Click" /> [cite: 167]
    <asp:Button ID="btnReadPrev" runat="server" Text="Read Prev" OnClick="btnReadPrev_Click" /> [cite: 168]
    <asp:Button ID="btnReadNext" runat="server" Text="Read Next" OnClick="btnReadNext_Click" /> [cite: 168]

    <br /><br />
    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label> [cite: 186]
</asp:Content>