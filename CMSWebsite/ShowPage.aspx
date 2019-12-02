<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="ShowPage.aspx.cs" Inherits="CMSWebsite.ShowPage" %>

<asp:Content ID="page_view" ContentPlaceHolderID="body" runat="server">

    <div class="active-black-4 mb-4 p-4">
        <h1>View Page</h1>
        <button type="button" class="btn btn-dark"><a href="UpdatePage.aspx?pageid=<%= Request.QueryString["pageid"] %>" class="text-white">Edit</a></button>

    </div>

    <div id="page" runat="server">
        <h2>Details for <span id="page_title_name" runat="server"></span></h2>
        Title: <span id="page_title" runat="server"></span><br />
        Body: <span id="page_body" runat="server"></span><br />
        Image: <span id="page_image" runat="server"></span><br />
        Date Uploaded: <span id="upload_date" runat="server"></span><br />
    </div>

</asp:Content>
