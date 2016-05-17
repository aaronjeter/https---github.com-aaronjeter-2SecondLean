<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SlideShow.aspx.cs" Inherits="_2SecondLean.SlideShow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="margin: 0px auto">
        <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see http://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="respond" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>

        <div class="container body-content" style="margin-left:10%; margin-right:12%; margin-top:2%">

        <asp:Label ID="Department" runat="server" Text="" Font-Size="32"></asp:Label> 
        <asp:Label ID="Label1" runat="server" Text="  -  " Font-Size="32"></asp:Label>
        <asp:Label ID="Name" runat="server" Text="" Font-Size="32"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="  -  " Font-Size="32"></asp:Label>
        <asp:Label ID="Time" runat="server" Text="" Font-Size="32"></asp:Label>

        <asp:Image ID="Magna_Logo" ImageUrl="~/Resources/Magna Exteriors 2014 Logo.png"  ImageAlign="Right" Width="200" Height="50"  runat="server"  />

            <hr style="border-color:#ff0000" />

    <div style="text-align:center">

        <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="15000"></asp:Timer>


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
                        <img runat="server" id="imgBefore" height="500" width="500" />
                    </asp:TableCell>
                    <asp:TableCell>
                            
                    </asp:TableCell>
                    <asp:TableCell>
                        <img runat="server" id="imgAfter" height="500" width="500" />
                    </asp:TableCell>
                </asp:TableRow>



                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Issue_Label" runat="server" Text="Issue: " Font-Size="18" Font-Bold="true" Font-Underline="true"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="Change_Label" runat="server" Text="What Changed: " Font-Bold="true" Font-Size="18" Font-Underline="true"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="Benefit_Label" runat="server" Text="Benefit: " Font-Bold="true" Font-Size="18" Font-Underline="true"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell Width="500">
                        <asp:Label ID="Issue" runat="server" Text="" Font-Size="18"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="300">
                        <asp:Label ID="Change" runat="server" Text="" Font-Size="18"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="500">
                        <asp:Label ID="Benefit" runat="server" Text="" Font-Size="18"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>

            

    </div>

        <asp:Image ID="Logo" runat="server" Height="150" Width="150"  ImageUrl="~/Resources/StopWatch.png" />

            </div>
    </form>
</body>
</html>
