<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="REPORTESCITAS.aspx.cs" Inherits="Veterinariap2.REPORTES_CITAS" %>

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

    <h2> REPORTE DE CITAS</h2>
    <table class="container">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id_mascota" DataSourceID="SqlDatamascotas">
                    <Columns>
                        <asp:BoundField DataField="id_cita" HeaderText="ID Cita" SortExpression="id_cita" />
                        <asp:BoundField DataField="id_mascota" HeaderText="ID Mascota" InsertVisible="False" ReadOnly="True" SortExpression="id_mascota" />
                        <asp:BoundField DataField="proxima_fecha" HeaderText="Fecha de la proxima cita" SortExpression="proxima_fecha" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField DataField="medico_asiganado" HeaderText="Medico asignado" SortExpression="medico_asiganado" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDatamascotas" runat="server" ConnectionString="<%$ ConnectionStrings:DBVETERINARIAConnectionString %>" ProviderName="<%$ ConnectionStrings:DBVETERINARIAConnectionString.ProviderName %>" 
                    SelectCommand="SELECT * FROM [Cita] WHERE proxima_fecha >= GETDATE() ORDER BY proxima_fecha ASC">
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
            <asp:TextBox ID="txtIdMascota" runat="server" CssClass="form-control" placeholder="ID Mascota"></asp:TextBox>
        </div>
        <div class="form-element">
            <asp:TextBox ID="txtProximaFecha" runat="server" CssClass="form-control" placeholder="Próxima Fecha"></asp:TextBox>
        </div>
        <div class="form-element">
            <asp:TextBox ID="txtMedicoAsignado" runat="server" CssClass="form-control" placeholder="Médico Asignado"></asp:TextBox>
        </div>
        <div class="form-element">
            <asp:TextBox ID="txtIdCita" runat="server" CssClass="form-control" placeholder="ID Cita"></asp:TextBox>
        </div>
        <asp:Button ID="btnAgregar" runat="server" CssClass="custom-button" Text="Agregar" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnEliminar" runat="server" CssClass="custom-button" Text="Eliminar" OnClick="btnEliminar_Click" />
        <asp:Button ID="btnModificar" runat="server" CssClass="custom-button" Text="Modificar" OnClick="btnModificar_Click" />
    </div>
</asp:Content>
