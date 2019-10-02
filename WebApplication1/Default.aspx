<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html>

<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
        <div style="font-family: Arial">

            <asp:Button ID="btnGetDataFromDB" runat="server" Text="Get Data from Database" />
            <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" >
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                    <asp:BoundField DataField="TotalMarks" HeaderText="TotalMarks" SortExpression="TotalMarks" />
                </Columns>
            </asp:GridView>

            <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btnUpdateDB" runat="server" Text="Button" />

        </div>
    </form>
</body>
</html>
  
