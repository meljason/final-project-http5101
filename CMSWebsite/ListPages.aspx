<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="ListPages.aspx.cs" Inherits="CMSWebsite.ListPages" %>

<asp:Content ID="pages_list" ContentPlaceHolderID="body" runat="server">

    <div class="active-black-4 mb-4 p-4">
        <h1>Pages</h1>
        <asp:TextBox runat="server" ID="page_search" placeholder="Search" aria-label="Search" />
        <asp:Button Text="submit" runat="server" class="btn btn-dark" />
        <div id="sql_debugger" runat="server"></div>
        <button type="button" class="btn btn-dark"><a href="NewPage.aspx" class="text-white">Add Page</a></button>
    </div>

    <table class="table table-striped">
        <thead>
            <tr>
                <th scope="col">Page Number</th>
                <th scope="col">Title</th>
                <th scope="col">Body</th>
                <th scope="col">Image</th>
                <th scope="col">Date Uploaded</th>
                <th scope="col">Actions</th>
            </tr>
        </thead>
        <tbody>
                <div id="pages_result" runat="server" />
        </tbody>
    </table>
</asp:Content>
