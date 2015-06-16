<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Knockout.Models.ViewModel>" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    <form action='<%=Url.Action("Index") %>' method="post" data-bind="submit:onSubmit">
        <table>
            <tr>
                <th>Available</th><th>&nbsp;</th><th>Requested</th>
            </tr>
            <tr>
                <td valign="top">
                    <%=Html.ListBoxFor(m => m.AvailableSelected, 
                        new MultiSelectList(Model.AvailableProducts, "Id", "Name", Model.AvailableSelected),
                                            new Dictionary<string, object>{{"data-bind","options:availableProducts, selectedOptions:availableSelected, optionsText:'Name'"}})%>
                </td>
                <td valign="top">
                    <input type="submit" name="add" value=">>" data-bind="click: addRequested, enable:availableSelected().length > 0" /><br />
                    <input type="submit" name="remove" value="<<" data-bind="click: removeRequested, enable:requestedSelected().length > 0" />
                </td>
                <td valign="top">
                    <%=Html.ListBoxFor(m => m.RequestedSelected, new MultiSelectList(Model.RequestedProducts, "Id", "Name", Model.RequestedSelected),
                        new Dictionary<string,object>{{"data-bind", "options:requestedProducts, selectedOptions:requestedSelected, optionsText:'Name'"}})%>
                </td>
            </tr>
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
                <tbody data-bind='template: { name: "requestedTemplate", foreach: requestedProducts }'>
                <%foreach(var product in Model.RequestedProducts) { %>
                    <tr>
                        <td><%=product.Name %></td>
                        <td><%=product.Description %></td>
                        <td><%=product.Price.ToString("G") %></td>
                    </tr>
                <%} %>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="2">&nbsp;</td>
                        <td><span id="total" style="font-weight:bold;" data-bind="text:requestedTotal().toFixed(2)"><%=Model.RequestedTotal.ToString("G") %></span></td>
                    </tr>
                </tfoot>          
            </table>
        </fieldset>
        <input type="submit" name="send" value="Send to Santa!" data-bind="enable:canSubmit" />
        <%=Html.ValidationSummary() %>
    </form>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    
    <script id="requestedTemplate" type="text/html">
        <tr>
            <td>${Name}</td>
            <td>${Description}</td>
            <td>${Price}</td>
        </tr>
    </script>
    
    <script type="text/javascript">        
        var viewModel = {
            availableProducts: ko.observableArray(<%=new JavaScriptSerializer().Serialize(Model.AvailableProducts) %>),
            availableSelected: ko.observableArray([]),
            requestedProducts: ko.observableArray(<%=new JavaScriptSerializer().Serialize(Model.RequestedProducts) %>),
            requestedSelected: ko.observableArray([]),                                    
            addRequested: function(){
                var requested = this.requestedProducts;
                $.each(this.availableSelected(), function(n, item) {
                    requested.push(item);
                });
                this.availableProducts.removeAll(this.availableSelected());
                this.availableSelected.splice(0,this.availableSelected().length);
            },            
            removeRequested: function(){
                var available = this.availableProducts;
                $.each(this.requestedSelected(), function(n, item) {
                    available.push(item);
                });
                this.requestedProducts.removeAll(this.requestedSelected());
                this.requestedSelected.splice(0,this.requestedSelected().length);
            },
            onSubmit: function(){                
                var ids = [];
                $.each(this.requestedProducts(), function(n, item) {
                    ids.push(item.Id);
                });
                $("#SavedRequested").val(ids.join());
                return true;
            }
        };        
        viewModel.requestedTotal = ko.dependentObservable(function(){                
                var total = 0;
                $.each(this.requestedProducts(), function(n, item){
                    total = total + item.Price;
                });
                return total;
            }, viewModel);
            
        viewModel.canSubmit = ko.dependentObservable(function(){
            return this.requestedProducts().length >0 && this.requestedProducts().length <=3 && this.requestedTotal() <=400;
        }, viewModel);            
        $(function() {                        
            ko.applyBindings(viewModel);            
        });
    </script>
</asp:Content>
