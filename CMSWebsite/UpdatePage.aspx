<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="UpdatePage.aspx.cs" Inherits="CMSWebsite.UpdatePage" %>

<asp:Content ID="updatepage" ContentPlaceHolderID="body" runat="server">

    <div id="pages" class="active-black-4 mb-4 p-4">
        <h1>Edit Page</h1>
        <form>
            <div class="form-group">
                <label>Title</label>
                <asp:TextBox runat="server" class="form-control" ID="page_title" placeholder="" />
            </div>
            <div class="form-group">
                <label>Body</label>
                <asp:TextBox runat="server" TextMode="MultiLine" class="form-control" ID="page_body" placeholder="" />
            </div>

            <div class="input-group pb-3">
                <input type="text" class="form-control" disabled placeholder="Upload Image" id="file">
                <div class="input-group-append">
                    <button type="button" class="browse btn bg-dark text-white">Browse...</button>
                </div>
            </div>

            <asp:Button Text="Update Page" OnClick="Update_Page" class="btn text-white bg-dark" runat="server" />
            
        </form>
    </div>
</asp:Content>
