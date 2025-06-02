<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TeachersBySubject.aspx.cs" Inherits="TeachersBySubject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   Subject Teachers
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <h2>Subject Teachers</h2>
            <asp:DropDownList ID="ddlSubjects" runat="server" CssClass="inputField" />
            <asp:Button ID="btnQueryTeachers" runat="server" Text="Show" OnClick="btnQueryTeachers_Click" CssClass="btnSubmit" />
            <br /><br />
            <asp:GridView ID="gvTeachers" runat="server" AutoGenerateColumns="False" CssClass="gridview" Visible="false">
                <Columns>
                    <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                </Columns>
            </asp:GridView>
        
</asp:Content>