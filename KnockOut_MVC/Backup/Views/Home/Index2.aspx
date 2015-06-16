<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Knockout.Models.ViewModel>" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index	
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript" src="../../Scripts/PageFunctions.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    <%using(Html.BeginForm()){ %>
        <div>
        <table>
            <thead>
                <tr>
                    <th>Available</th><th>&nbsp;</th><th>Requested</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td valign="top">
                        <%=Html.ListBoxFor(m => m.AvailableSelected, 
                            new MultiSelectList(Model.AvailableProducts, "Id", "Name", Model.AvailableSelected))%>
                    </td>
                    <td valign="top">
                        <input type="submit" name="add" id="add" value="&gt;&gt;" /><br />
                        <input type="submit" name="remove" id="remove" value="&lt;&lt;" />
                    </td>
                    <td valign="top">
                        <%=Html.ListBoxFor(m => m.RequestedSelected, Model.RequestedProducts.Count == 0? new SelectList(new string[]{""}) //add empty <option> element as xhtml validator insists on one
                            : new MultiSelectList(Model.RequestedProducts, "Id", "Name", Model.RequestedSelected))%>
                    </td>
                </tr>
            </tbody>
        </table>
        <br />
        <%=Html.HiddenFor(m=>m.SavedRequested) %>                    
        
        <fieldset>
            <legend>Your wish list</legend>
            <table>
                <thead>
                    <tr>
                        <th>Product</th>
                        <th>Description</th>
                        <th>Price</th>
                    </tr>
                </thead>
                <tfoot>
                    <tr>
                        <td colspan="2">&nbsp;</td>
                        <td><span id="total" style="font-weight:bold;"><%=Model.RequestedTotal.ToString("G") %></span></td>
                    </tr>
                </tfoot> 
                <tbody id="tableBody">
                    <tr style="display:none;">
                        <td colspan="3">This is here because xhtml validator won't allow tbody with no rows</td>
                    </tr>
                <%foreach(var product in Model.RequestedProducts) { %>
                    <tr>
                        <td><%=product.Name %></td>
                        <td><%=product.Description %></td>
                        <td><%=product.Price.ToString("G") %></td>
                    </tr>
                <%} %>
                </tbody>                         
            </table>
        </fieldset>
        <input type="submit" name="send" id="send" value="Send to Santa!" />
        <%=Html.ValidationSummary() %>
        </div>
    <%} %>
</asp:Content>
