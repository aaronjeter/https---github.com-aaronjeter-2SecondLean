<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="_2SecondLean.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="Department" runat="server" Text="" Font-Size="32"></asp:Label>
    <asp:Label ID="Label1" runat="server" Text="  -  " Font-Size="32"></asp:Label>
    <asp:Label ID="Name" runat="server" Text="" Font-Size="32"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="  -  " Font-Size="32"></asp:Label>
    <asp:Label ID="Time" runat="server" Text="" Font-Size="32"></asp:Label>
    <asp:Image ID="Magna_Logo" ImageUrl="~/Resources/Magna Exteriors 2014 Logo.png" ImageAlign="Right" Width="200" Height="50" runat="server" />
    <hr style="border-color:#ff0000" />

    <div style="text-align:center">
      
    <asp:Table ID="Table2" runat="server">
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
                        <img runat="server" id="imgBefore" height="450" width="450" />
                        <br />
                        <asp:Button ID="Before_Rotate_Button" runat="server" Text="Rotate" OnClick="Before_Rotate_Button_Click"  />
                    </div>
                </asp:TableCell>
                <asp:TableCell>

                </asp:TableCell>
                <asp:TableCell>
                    <div>
                        <img runat="server" id="imgAfter" height="450" width="450" />
                        <br />
                        <asp:Button ID="After_Rotate_Button" runat="server" Text="Rotate" OnClick="After_Rotate_Button_Click" />
                    </div>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell Width="450">
                    <asp:Label ID="Issue_Label" runat="server" Text="Issue" Font-Size="18" Font-Bold="true" Font-Underline="true"></asp:Label>
                </asp:TableCell>
                <asp:TableCell Width="250">
                    <asp:Label ID="Change_Label" runat="server" Text="What Changed" Font-Size="18" Font-Bold="true" Font-Underline="true"></asp:Label>
                </asp:TableCell>
                <asp:TableCell Width="450">
                    <asp:Label ID="Benefit_Label" runat="server" Text="Benefit" Font-Size="18" Font-Bold="true" Font-Underline="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Issue" runat="server" Text="" Font-Size="18"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Change" runat="server" Text="" Font-Size="18"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Benefit" runat="server" Text="" Font-Size="18"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        </div>
    <asp:Image ID="Logo" runat="server" Height="150" Width="150"  ImageUrl="~/Resources/StopWatch.png" />
</asp:Content>
