<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Submit.aspx.cs" Inherits="_2SecondLean.Submit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Label ID="Error_Label" runat="server" Text="Error" Visible="false" ForeColor="Red"></asp:Label>


    <p>Before: </p> 
    <asp:FileUpload ID="Before_FileUpload" runat="server" accept=".png,.jpg,.jpeg,.gif"/>
    <br />

    <p>After:</p>
    <asp:FileUpload ID="After_FileUpload" runat="server" accept=".png,.jpg,.jpeg,.gif" />
    <br />

    <p>Department:</p>
    <asp:DropDownList ID="Department" runat="server" DataSourceID="SqlDataSource1" DataTextField="Area" DataValueField="Area">
    </asp:DropDownList>

    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="Data Source=decosql02;Initial Catalog=Production;User ID=PartHistoryUser;Password=PartHistoryUser" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Area]  FROM [Quality].[dbo].[Two_Second_Lean_Areas]"></asp:SqlDataSource>
    <br />  
    <br />
       
    

    <table>
        <tr>
            <td>
                <p>Name:</p>
            </td>
            <td>
                <asp:TextBox runat="server" Rows="2" Columns="40" TextMode="MultiLine" placeholder="Your name here (Optional)" name="Name" id="Name" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <p>Issue/Problem:</p>
            </td>
            <td>
                <asp:TextBox runat="server" Rows="3" Columns="40" TextMode="MultiLine" placeholder="Describe your problem here" name="Issue" id="Issue" required="required"></asp:TextBox>
            </td>          
        </tr>
        <tr>
            <td>
                <p>What Changed:</p>
            </td>
            <td>
                <asp:TextBox runat="server" Rows="3" Columns="40" TextMode="MultiLine" placeholder="Describe what you did here" name="Change" id="Change" required="required"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <p>Benefit:</p>
            </td>
            <td>
                <asp:TextBox runat="server" Rows="3" Columns="40" TextMode="MultiLine" placeholder="Explain the benefit here" name="Benefit" id="Benefit" required="required"></asp:TextBox>
            </td>
        </tr>
    </table>   
    
    <br />
    <br />

    <asp:Button ID="Submit_Button" runat="server" Text="Submit" OnClick="Submit_Button_Click" />

</asp:Content>
