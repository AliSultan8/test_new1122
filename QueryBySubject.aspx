<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="QueryBySubject.aspx.cs" Inherits="QueryBySubject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   Search By Subject
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h2>Search for Subject Grades</h2>
<asp:Label ID="lblSubject" runat="server" Text="Subject Name:"></asp:Label>
<asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
<asp:GridView ID="GridView1" runat="server"></asp:GridView>

</asp:Content>