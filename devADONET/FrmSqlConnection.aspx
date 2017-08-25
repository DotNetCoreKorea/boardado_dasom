<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSqlConnection.aspx.cs" Inherits="devADONET.FrmSqlConnection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>sqlConnection 클래스 </title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

        </div>
        <asp:Button ID="btnSqlConnection" runat="server" Text="SQL Server에 연결하기" OnClick="btnSqlConnection_Click" />
        <hr />
        <asp:Label ID="lblDisplay" runat="server"></asp:Label>
    </form>
</body>
</html>
