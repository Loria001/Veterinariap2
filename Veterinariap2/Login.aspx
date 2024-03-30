<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Veterinariap2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/logincss.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div class="login-box">
            <h2>Login</h2>
           <label for="Tusuario">Usuario</label>
            <asp:TextBox ID="Tusuario" runat="server" placeholder="Usuario" required></asp:TextBox>
            <label for="Tclave">Contraseña</label>
            <asp:TextBox ID="Tclave" runat="server" TextMode="Password" placeholder="Contraseña" required></asp:TextBox>
            
            <asp:Button ID="Bingresar" runat="server" Text="Ingresar" class="btn btn-primary btn-block btn-large" OnClick="Bingresar_Click" />
            <br />
            <asp:Label ID="Lerror" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>

