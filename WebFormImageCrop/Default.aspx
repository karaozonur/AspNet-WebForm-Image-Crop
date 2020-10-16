<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormImageCrop.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src='<%=ResolveUrl("Scripts/jquery-3.5.1.js" )%>'></script>
    <link href="assets/css/jquery.Jcrop.css" rel="stylesheet" />
    <script src='<%=ResolveUrl("assets/js/jquery.Jcrop.js")%>'></script>
    <script src="assets/js/jquery.Jcrop.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=imgUpload.ClientID%>").Jcrop({
                onSelect:SelectCropArea
            });

        });

        function SelectCropArea(c) {
            $("#<%=X.ClientID%>").val(parseInt(c.x));
            $("#<%=Y.ClientID%>").val(parseInt(c.y));
            $("#<%=W.ClientID%>").val(parseInt(c.w));
            $("#<%=H.ClientID%>").val(parseInt(c.h));
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>
        <div>
            <asp:Button ID="BTNUPLOAD" runat="server" Text="Button" OnClick="BTNUPLOAD_Click" />
        </div>
             <div>

                 <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
             </div>
        <div>
            <asp:Panel ID="PnlCrop" runat="server" ForeColor="Red">
                <table>

                    <tr>
                        <td>
                            <asp:Image ID="imgUpload" runat="server" Width="100%" />
                        </td>
                        <td>
                             <asp:Button ID="BTNCROP" runat="server" Text="crop" OnClick="BTNCROP_Click" />
                        </td>
                        <td>
                            <asp:HiddenField ID="X" runat="server" />
                             <asp:HiddenField ID="Y" runat="server" />
                             <asp:HiddenField ID="W" runat="server" />
                             <asp:HiddenField ID="H" runat="server" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
