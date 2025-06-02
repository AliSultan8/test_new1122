<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="QueryByClass.aspx.cs" Inherits="QueryByClass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   Inquiry by Class
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <h2>Inquiry by Class</h2>
            <asp:DropDownList ID="ddlGrades" runat="server" CssClass="inputField" />
            <asp:Button ID="btnQueryClass" runat="server" Text="Search" OnClick="btnQueryClass_Click" CssClass="btnSubmit" />
            <br /><br />
            <asp:Label ID="lblClassResult" runat="server" ForeColor="Blue" Font-Size="Large" />
           </asp:Content>