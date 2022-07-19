<%@ Page Title="" Language="C#" MasterPageFile="~/Menuprincipal.Master" AutoEventWireup="true" CodeBehind="CatUser.aspx.cs" Inherits="universidadUH.CatUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <h1>Catalogo de Usuarios</h1>
    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#594B9C" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#33276A" />
        </asp:GridView>
        <br />
    Codigo:<asp:Textbox ID="tcodigo" runat="server"></asp:Textbox>
    Usuario:<asp:Textbox ID="tusuario" runat="server"></asp:Textbox>
    Clave:<asp:Textbox ID="tclave" type="password" runat="server"></asp:Textbox>
   

        <br />
   

    <asp:Button ID="bagregar" CssClass="button button1" runat="server" Text="Agregar" OnClick="bagregar_Click" />
     <asp:Button ID="bborrar" CssClass="button button3" runat="server" Text="Borrar" OnClick="bborrar_Click" />
     <asp:Button ID="bmodificar" CssClass="button button1" runat="server" Text="Modificar" OnClick="bmodificar_Click" />
     <asp:Button ID="Bconsultar" CssClass="button button3" runat="server" Text="Consultar" OnClick="Bconsultar_Click" />
    </form>
</asp:Content>
