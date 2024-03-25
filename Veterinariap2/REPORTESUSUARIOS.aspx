<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GestionUsuarios.aspx.cs" Inherits="Veterinariap2.GestionUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2> GESTIÓN DE USUARIOS</h2>

    <style>
        .container {
            text-align: center;
            margin-top: 20px;
        }
        .form-element {
            margin-bottom: 10px;
            width: 300px;
        }
        .form-element input[type="text"], .form-element input[type="password"] {
            width: calc(100% - 12px);
            padding: 5px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 16px;
        }
        .custom-button {
            width: 120px;
            margin: 5px;
            padding: 10px;
            font-size: 16px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        .custom-button:hover {
            background-color: #0056b3;
        }
        .message {
            color: red;
            font-size: 16px;
        }
    </style>

    <table class="container">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="login_usuario" DataSourceID="SqlDataUsuarios">
                    <Columns>
                        <asp:BoundField DataField="login_usuario" HeaderText="Login de usuario" SortExpression="login_usuario" />
                        <asp:BoundField DataField="nombre_usuario" HeaderText="Nombre de Usuario" SortExpression="nombre_usuario" />
                        <asp:TemplateField HeaderText="Clave de Usuario">
                            <ItemTemplate>
                                <asp:Label ID="lblClaveUsuario" runat="server" Text="*****"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:DBVETERINARIAConnectionString %>" ProviderName="<%$ ConnectionStrings:DBVETERINARIAConnectionString.ProviderName %>"
                    SelectCommand="SELECT * FROM [Usuario]">
                </asp:SqlDataSource>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblMensajeError" runat="server" CssClass="message" Visible="true"></asp:Label>
            </td>
        </tr>
    </table>

    <div class="container">
        <div class="form-element">
            <asp:TextBox ID="txtLoginUsuario" runat="server" CssClass="form-control" placeholder="Login Usuario"></asp:TextBox>
        </div>
        <div class="form-element">
            <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control" placeholder="Nombre de Usuario"></asp:TextBox>
        </div>
        <div class="form-element">
            <asp:TextBox ID="txtClaveUsuario" runat="server" CssClass="form-control" TextMode="Password" placeholder="Clave de Usuario"></asp:TextBox>
        </div>
        <asp:Button ID="btnAgregar" runat="server" CssClass="custom-button" Text="Agregar" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnEliminar" runat="server" CssClass="custom-button" Text="Eliminar" OnClick="btnEliminar_Click" />
        <asp:Button ID="btnModificar" runat="server" CssClass="custom-button" Text="Modificar" OnClick="btnModificar_Click" />
    </div>
</asp:Content>
