<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="QueryByRegion.aspx.cs" Inherits="QueryByRegion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   Query By Region
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <h2>Query By Region</h2>
            <asp:TextBox ID="txtRegion" runat="server" CssClass="inputField" Placeholder="Enter region name" />
            <asp:Button ID="btnQuery" runat="server" Text="Search" OnClick="btnQuery_Click" CssClass="btnSubmit" />
            <br /><br />
            <asp:Label ID="lblResult" runat="server" ForeColor="Blue" Font-Size="Large" />
         </asp:Content>