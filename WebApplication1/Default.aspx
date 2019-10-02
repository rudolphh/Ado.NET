<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html>

<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
        <div style="font-family: Arial">

            <asp:Button ID="btnGetDataFromDB" runat="server" Text="Get Data from Database" />
            <asp:GridView ID="gvStudents" runat="server"></asp:GridView>

            <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btnUpdateDB" runat="server" Text="Button" />

        </div>
    </form>
</body>
</html>
  
