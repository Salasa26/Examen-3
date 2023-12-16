<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="EncuestaUH.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class= "contanie text-center">
        <h1>Registre su encuesta</h1>

</div>
<div>

    <br />
    <asp:GridView runat="server" ID="Registrodatagrid" PageSize="10" HorizontalAlign="Center"
        CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
        RowStyle-CssClass="rows" AllowPaging="True" />
    <br />

</div>

    <div class="container text-center">
    Nombre: <asp:TextBox ID="Nombre" class="form-control" runat="server"></asp:TextBox>
    Edad: <asp:TextBox ID="Edad" class="form-control" runat="server"></asp:TextBox>
    CorreoElectronico:<asp:TextBox ID="CorreoElectronico" class="form-control" runat="server"></asp:TextBox>

    Partido: <asp:DropDownList ID="DropDownListPartido" class="form-control" runat="server"></asp:DropDownList>
    
    
    
    

</div>
<div class="container text-center">
    <br />
    <asp:Button ID="Agregar" class="btn btn-outline-primary" runat="server" Text="Guardar encuesta" OnClick="Agregar_Click" />

    <br />

</div>


    
</asp:Content>



