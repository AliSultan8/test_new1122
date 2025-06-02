<%@ Page Title="Add Student" ResponseEncoding="utf-8" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddStudent.aspx.cs" Inherits="AddStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Add Student
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add New Student</h2>
    <table>
        <tr><td>Name:</td><td><asp:TextBox ID="txtStudent" runat="server" CssClass="inputField" /></td></tr>
        <tr><td>Father's Name:</td><td><asp:TextBox ID="txtFname" runat="server" CssClass="inputField" /></td></tr>
        <tr><td>Mother's Name:</td><td><asp:TextBox ID="txtMname" runat="server" CssClass="inputField" /></td></tr>
        <tr><td>Birth Date:</td><td><asp:TextBox ID="txtDate" runat="server" CssClass="inputField" placeholder="yyyy-MM-dd" /></td></tr>
        <tr><td>Phone Number:</td><td><asp:TextBox ID="txtPhone" runat="server" CssClass="inputField" /></td></tr>
        <tr><td>Region:</td><td><asp:TextBox ID="txtRegion" runat="server" CssClass="inputField" /></td></tr>
        <tr>
            <td>Grade:</td>
            <td>
                <asp:DropDownList ID="ddlGrades" runat="server" CssClass="inputField" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center;">
                <asp:Button ID="btnAddStudent" runat="server" Text="Add" OnClick="btnAddStudent_Click" CssClass="btnSubmit" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center;">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
            </td>
        </tr>
    </table>
</asp:Content>