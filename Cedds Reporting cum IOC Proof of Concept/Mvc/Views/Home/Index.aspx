<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Reporting.MvcUI.Models.ReportModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create Report</h2>
    <p>
	<% using (Html.BeginForm("CreateReport", "Home")) { %>
	<table>
		<tr>
			<td>
		<%= Html.Label("Report")%>
			</td>
			<td>
		<%= Html.DropDownList("reportName", Model.Reports)%>
			</td>
		</tr>
		<tr>
			<td>
		<%= Html.Label("Report Format")%>
			</td>
			<td>
		<%= Html.DropDownList("writerName", Model.Writers)%>
			</td>
		</tr>
		<tr>
			<td>
		<%= Html.Label("Microsoft Word Template (for Word Reports)")%>
			</td>
			<td>
		<%= Html.TextBox("wordTemplate")%>
			</td>
		</tr>
	</table>

		<input type="submit" value="Create Report"/>		
	<% } %> 	
        
    </p>
</asp:Content>
