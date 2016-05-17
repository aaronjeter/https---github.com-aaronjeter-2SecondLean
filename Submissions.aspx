<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Submissions.aspx.cs" Inherits="_2SecondLean.Submissions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:DropDownList ID="Department_DropDownList" runat="server" AutoPostBack="true">
        <asp:ListItem Selected="True">All</asp:ListItem>
    </asp:DropDownList>
        
    <asp:TextBox ID="Start_Date_TextBox" runat="server" placeholder="MM/DD/YYYY" AutoPostBack="true"></asp:TextBox>    
    <asp:TextBox ID="End_Date_TextBox" runat="server" placeholder="MM/DD/YYYY" AutoPostBack="true"></asp:TextBox>

    <asp:GridView ID="GridView1" runat="server" OnRowCreated="GridView1_RowCreated" CssClass="table table-hover table-striped" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" AllowSorting="True">
        <Columns>
            <asp:CommandField ShowSelectButton="True"></asp:CommandField>
            <asp:BoundField DataField="id" HeaderText="ID #" ReadOnly="True" InsertVisible="False" SortExpression="id"></asp:BoundField>
            <asp:BoundField DataField="time" HeaderText="Time" SortExpression="time" DataFormatString="{0:d}"></asp:BoundField>
            <asp:BoundField DataField="department" HeaderText="Department" SortExpression="department"></asp:BoundField>
            <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name"></asp:BoundField>
            <asp:BoundField DataField="issue" HeaderText="Issue" SortExpression="issue"></asp:BoundField>
            <asp:BoundField DataField="change" HeaderText="Change" SortExpression="change"></asp:BoundField>
            <asp:BoundField DataField="benefit" HeaderText="Benefit" SortExpression="benefit"></asp:BoundField>
                        
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="Data Source=decosql02;Initial Catalog=Production;User ID=PartHistoryUser;Password=PartHistoryUser" ProviderName="System.Data.SqlClient" 
        SelectCommand="SELECT [id], [time], [department], [name], [issue], [change], [benefit] FROM [Quality].[dbo].[two_second_lean] order by id desc"></asp:SqlDataSource>
</asp:Content>
