<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="EncuestaUH.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class= "contanie text-center">
        <h1>Reportes</h1>

</div>
<div>

    <br />
    <asp:GridView runat="server" ID="Registrodatagrid" PageSize="10" HorizontalAlign="Center"
        CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
        RowStyle-CssClass="rows" AllowPaging="True" />
    <br />

</div>

    <div class="container text-center">
    # de encuesta a Eliminar: <asp:TextBox ID="IDEncuesta" class="form-control" runat="server"></asp:TextBox>
    Partido que desea buscar: <asp:DropDownList ID="DropDownListPartido" class="form-control" runat="server"></asp:DropDownList>
   
    

</div>
<div class="container text-center">
    <br />
    <asp:Button ID="Borrar" class="btn btn-outline-primary" runat="server" Text="Eliminar # de encuesta" OnClick="Borrar_Click" />
    <asp:Button ID="Buscar" class="btn btn-outline-primary" runat="server" Text="Buscar por partido" OnClick="Buscar_Click" />
    <br />

</div>

</asp:Content>
