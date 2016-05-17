<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="_2SecondLean.Admin.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="Content_Panel" runat="server" visible="false">

        <asp:Button ID="Approve_Button" runat="server" Text="Mark as Reviewed" OnClick="Approve_Button_Click" />
        <asp:Button ID="Delete_Button" runat="server" Text="Delete" OnClick="Delete_Button_Click" style="float:right" />
        <br />

        <asp:Label ID="Department" runat="server" Text="" Font-Size="32"></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="  -  " Font-Size="32"></asp:Label>
        <asp:Label ID="Name" runat="server" Text="" Font-Size="32"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="  -  " Font-Size="32"></asp:Label>
        <asp:Label ID="Time" runat="server" Text="" Font-Size="32"></asp:Label>
        <asp:Image ID="Magna_Logo" ImageUrl="~/Resources/Magna Exteriors 2014 Logo.png" ImageAlign="Right" Width="200" Height="50" runat="server" />
        <hr style="border-color:#ff0000" />

        <div style="text-align:center">

        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Before_Label" runat="server" Text="Before" Width="50" Font-Size="24" Font-Bold="true"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>

                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="After_Label" runat="server" Text="After" Width="50" Font-Size="24" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <div>
                    <img runat="server" id="imgBefore" height="500" width="500" />
                    <br />
                    <asp:Button ID="Before_Rotate_Button" runat="server" Text="Rotate" OnClick="Before_Rotate_Button_Click"  />
                </div>
            </asp:TableCell>
            <asp:TableCell>

            </asp:TableCell>
            <asp:TableCell>
                <div>
                    <img runat="server" id="imgAfter" height="500" width="500" />
                    <br />
                    <asp:Button ID="After_Rotate_Button" runat="server" Text="Rotate" OnClick="After_Rotate_Button_Click" />
                </div>
            </asp:TableCell>      
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="Issue_Label" runat="server" Text="Issue" Font-Size="18" Font-Bold="true" Font-Underline="true"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Change_Label" runat="server" Text="What Changed" Font-Size="18" Font-Bold="true" Font-Underline="true"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Benefit_Label" runat="server" Text="Benefit" Font-Size="18" Font-Bold="true" Font-Underline="true"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:TextBox ID="Issue" runat="server" Rows="4" Columns="40" TextMode="MultiLine" ></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Change" runat="server" Rows="4" Columns="40" TextMode="MultiLine"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Benefit" runat="server" Rows="4" Columns="40" TextMode="MultiLine"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />    
            <asp:Button ID="Save_Button" runat="server" Text="Save Changes" OnClick="Save_Button_Click" />

            </div>
        <asp:Image ID="Logo" runat="server" Height="150" Width="150"  ImageUrl="~/Resources/StopWatch.png" />

        <div style="float:right">
            Name: <asp:TextBox ID="Edit_Name" runat="server"></asp:TextBox>
            <br />
            Department: <asp:TextBox ID="Edit_Department" runat="server"></asp:TextBox>
        </div>
        

    </asp:Panel>

</asp:Content>
