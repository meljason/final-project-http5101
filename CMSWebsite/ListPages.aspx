<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="ListPages.aspx.cs" Inherits="CMSWebsite.ListPages" %>

<asp:Content ID="pages_list" ContentPlaceHolderID="body" runat="server">

    <div class="active-black-4 mb-4 p-4">
        <h1>Pages</h1>
        <asp:TextBox runat="server" ID="page_search" placeholder="Search" aria-label="Search"/>
        <asp:Button Text="submit" runat="server" class="btn btn-dark"/>
    </div>
</asp:Content>
