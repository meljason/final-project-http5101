<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="ListPages.aspx.cs" Inherits="CMSWebsite.ListPages" %>

<asp:Content ID="pages_list" ContentPlaceHolderID="body" runat="server">

    <div class="active-black-4 mb-4 p-4">
        <h1>Pages</h1>
        <asp:TextBox runat="server" ID="page_search" placeholder="Search" aria-label="Search" />
        <asp:Button Text="submit" runat="server" class="btn btn-dark" />
        <div id="sql_debugger" runat="server"></div>
        <button type="button" class="btn btn-dark"><a href="NewPage.aspx" class="text-white">Add Page</a></button>
    </div>

    <%--<asp:ListView runat="server" ID="ListPageView" GroupPlaceholderID="groupplaceholder" ItemPlaceholderID="itemplaceholder">--%>
        <%--<LayoutTemplate>--%>
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
                <%--<tr>
                    <td colspan="5" style="text-align:center;">
                        <asp:DataPager id="DataPager1" runat="server"
                            PagedControlID="ListPageView" PageSize="10">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Link" 
                                    ShowFirstPageButton="true"
                                    ShowPreviousPageButton="true"
                                    ShowNextPageButton="false"/>
                                <asp:NumericPagerField ButtonType="Button" />
                                <asp:NextPreviousPagerField ButtonType="Link"
                                    ShowNextPageButton="true"
                                    ShowLastPageButton="true"
                                    ShowPreviousPageButton="false" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>--%>
            </table>
        <%--</LayoutTemplate>--%>
    <%--</asp:ListView>--%>
</asp:Content>
