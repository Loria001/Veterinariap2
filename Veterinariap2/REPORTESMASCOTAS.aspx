<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GestionMascotas.aspx.cs" Inherits="Veterinariap2.GestionMascotas" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        /* Estilos para centrar y uniformar tamaño de elementos */
        .container {
            text-align: center;
            margin-top: 20px;
        }
        .form-element {
            margin-bottom: 10px;
            width: 300px;
        }
        .form-element input[type="text"] {
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

    <h2> GESTIÓN DE MASCOTAS</h2>
    <div class="container">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id_mascota" DataSourceID="SqlDataMascotas">
            <Columns>
                <asp:BoundField DataField="id_mascota" HeaderText="ID Mascota" SortExpression="id_mascota" />
                <asp:BoundField DataField="nombre_mascota" HeaderText="Nombre Mascota" SortExpression="nombre_mascota" />
                <asp:BoundField DataField="tipo_mascota" HeaderText="Tipo Mascota" SortExpression="tipo_mascota" />
                <asp:BoundField DataField="comida_favorita" HeaderText="Comida Favorita" SortExpression="comida_favorita" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataMascotas" runat="server" ConnectionString="<%$ ConnectionStrings:DBVETERINARIAConnectionString %>" ProviderName="<%$ ConnectionStrings:DBVETERINARIAConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Mascota]"></asp:SqlDataSource>

        <asp:Label ID="lblMensajeError" runat="server" CssClass="message" Visible="true"></asp:Label>

        <div class="form-element">
            <asp:TextBox ID="txtNombreMascota" runat="server" CssClass="form-control" placeholder="Nombre Mascota"></asp:TextBox>
        </div>
        <div class="form-element">
            <asp:TextBox ID="txtTipoMascota" runat="server" CssClass="form-control" placeholder="Tipo Mascota"></asp:TextBox>
        </div>
        <div class="form-element">
            <asp:TextBox ID="txtComidaFavorita" runat="server" CssClass="form-control" placeholder="Comida Favorita"></asp:TextBox>
        </div>
        <div class="form-element">
            <asp:TextBox ID="txtIdMascota" runat="server" CssClass="form-control" placeholder="ID Mascota"></asp:TextBox>
        </div>
        <asp:Button ID="btnAgregar" runat="server" CssClass="custom-button" Text="Agregar" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnEliminar" runat="server" CssClass="custom-button" Text="Eliminar" OnClick="btnEliminar_Click" />
        <asp:Button ID="btnModificar" runat="server" CssClass="custom-button" Text="Modificar" OnClick="btnModificar_Click" />

    </div>
</asp:Content>
