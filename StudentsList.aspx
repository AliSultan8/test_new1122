<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="StudentsList.aspx.cs" Inherits="StudentsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   Students List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <h2>Students List</h2>
            <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" CssClass="gridview" AllowPaging="True" PageSize="10"
                OnPageIndexChanging="gvStudents_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="StudentID" HeaderText="Student ID" ReadOnly="True" />
                    <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                    <asp:BoundField DataField="FatherName" HeaderText="Father's Name" />
                    <asp:BoundField DataField="MotherName" HeaderText="Mother's Name" />
                    <asp:BoundField DataField="BirthDate" HeaderText="Birth Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                    <asp:BoundField DataField="Area" HeaderText="Area" />
                    <asp:BoundField DataField="GradeName" HeaderText="Grade" />
                </Columns>
            </asp:GridView>
       
</asp:Content>