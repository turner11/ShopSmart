<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ShopSmart.Web.Home" %>


<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <%--<asp:Literal ID="Literal3" runat="server" Text="<%$Resources:shopSmart.language,Products%>"/>--%>

    <link rel="stylesheet" type="text/css" media="screen" href="<%: ResolveUrl("~/Content/Home.css") %>" />
    <%-- JqGrid --%>
    <link rel="stylesheet" type="text/css" media="screen" href="<%: ResolveUrl("~/Scripts/JqGrid/css/ui.jqgrid.css") %>" />
    <script src="<%: ResolveUrl("~/Scripts/JqGrid/js/i18n/grid.locale-he.js") %>" type="text/javascript"></script>
    <script src="<%: ResolveUrl("~/Scripts/JqGrid/js/jquery.jqGrid.min.js") %>" type="text/javascript"></script>

    <script src="<%: ResolveUrl("~/Scripts/Home.js") %>"></script>
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Modify this template to jump-start your ASP.NET application.</h2>
            </hgroup>
            <p>
                To learn more about ASP.NET, visit <a href="http://asp.net" title="ASP.NET Website">http://asp.net</a>.
                The page features <mark>videos, tutorials, and samples</mark> to help you get the most from ASP.NET.
                If you have any questions about ASP.NET visit
                <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">our forums</a>.
            </p>

        </div>

    </section>

</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
        <asp:Label ID="Label1" Text="פילטר:" runat="server" />
    <input type="text" id="txbFilter" onkeyup="FilterList(arguments[0]||event)" />
    <asp:Button ID="btnExpandAll" Text="הרחב הכל" runat="server" CausesValidation="false" class="btn btn-primary btn-large" OnClientClick="SetGroupsState(true); return false;" />
    <asp:Button ID="btnCollapseAll" Text="צמצם הכל" runat="server" CausesValidation="false" class="btn btn-primary btn-large" OnClientClick="SetGroupsState(false); return false;" />
    <asp:Button ID="btnGetShoppingList" Text="קבל רשימת קניות" runat="server" CausesValidation="false" class="btn btn-large" OnClientClick="GetSelectedProducts(); return false;" />

    
<div>
	
    
</div>

    <section>



        <table id="tblProducts">
            <tr>
                <td></td>
            </tr>
        </table>
        <div id="divTblProductsPage"></div>
    </section>
</asp:Content>
