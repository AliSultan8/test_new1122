<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddGrade.aspx.cs" Inherits="AddGrade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Add Grade
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       
            <h2>Add New Grade</h2>
            Grade Name:
            <asp:TextBox ID="txtGradeName" runat="server" CssClass="inputField"/>
            <br />
            <asp:Button ID="btnAddGrade" runat="server" Text="Add" OnClick="btnAddGrade_Click" CssClass="btnSubmit" />
            <br /><br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
       
</asp:Content>