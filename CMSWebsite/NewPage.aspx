<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="NewPage.aspx.cs" Inherits="CMSWebsite.NewPage" %>

<asp:Content ID="newpage" ContentPlaceHolderID="body" runat="server">

    <div class="active-black-4 mb-4 p-4">
        <h1>Add Page</h1>
        <form>
            <div class="form-group">
                <label>Title</label>
                <asp:TextBox runat="server" class="form-control" ID="page_title" placeholder="Title" />
            </div>
            <div class="form-group">
                <label>Body</label>
                <asp:TextBox runat="server" TextMode="MultiLine" class="form-control" ID="page_body" placeholder="Body" />
            </div>

            <div class="input-group pb-3">
                <input type="text" class="form-control" disabled placeholder="Upload Image" id="file">
                <div class="input-group-append">
                    <button type="button" class="browse btn bg-dark text-white">Browse...</button>
                </div>
            </div>

            <asp:Button OnClick="Add_Page" Text="Submit" runat="server" class="btn text-white bg-dark"/>
            
        </form>
    </div>
</asp:Content>
