<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="QueryByStudent.aspx.cs" Inherits="QueryByStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   Search By Student
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h2>Search for Student Grades</h2>
<asp:Label ID="lblStudentName" runat="server" Text="Student Name:"></asp:Label>
<asp:TextBox ID="txtStudentName" runat="server"></asp:TextBox>
<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
<asp:GridView ID="GridView1" runat="server"></asp:GridView>

</asp:Content>