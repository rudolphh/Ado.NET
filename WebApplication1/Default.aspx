﻿<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<html>

<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
        <div style="font-family: Arial">

            <asp:Button ID="btnGetDataFromDB" runat="server" Text="Get Data from Database" OnClick="btnGetDataFromDB_Click" />
            <asp:Button ID="Button1" runat="server" Text="Undo" OnClick="Button1_Click" />
            <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowCancelingEdit="gvStudents_RowCancelingEdit" OnRowDeleting="gvStudents_RowDeleting" OnRowEditing="gvStudents_RowEditing" OnRowUpdating="gvStudents_RowUpdating" >
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                    <asp:BoundField DataField="TotalMarks" HeaderText="TotalMarks" SortExpression="TotalMarks" />
                </Columns>
            </asp:GridView>

            <asp:Button ID="btnUpdateDB" runat="server" Text="Update Database Table" OnClick="btnUpdateDB_Click" />
            <br />

            <asp:Label ID="lblMessage" Font-Bold="true" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>
  
