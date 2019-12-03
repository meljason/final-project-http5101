<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="DeletePage.aspx.cs" Inherits="CMSWebsite.DeletePage" %>
<asp:Content ContentPlaceHolderID="body" runat="server">

    <h2>Are you sure you want to delete <span runat="server" id="pagetitle"></span>?</h2>

    <div class="viewnav thin">
        <a class="left" href="ShowPage.aspx?pageid=<%= Request.QueryString["pageid"] %>">No</a>
        <asp:Button Text="Yes" runat="server" OnClick="Delete_Page" CssClass="right"/>
    </div>
</asp:Content>
