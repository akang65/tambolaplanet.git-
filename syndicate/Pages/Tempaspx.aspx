<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tempaspx.aspx.cs" Inherits="syndicate.Pages.Tempaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />


    <%--<script>
    $.connection.hub.start()
        .done(function () {
          $.connection.hub.logging = true;
        console.log("works");
        $.connection.myHub2.server.announce("something test");
        });
    $.connection.myHub2.client.getdata = function (message) {
        var test = document.getElementById("welcomeMessages");
        test.append(message);
        $("welcomeMessages").append(message);
    }
</script>--%>
</head>
<body>

    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>

       <p> <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label></p>
        <p><asp:Label ID="Label11" runat="server" Text="Label"></asp:Label></p>
      <p><asp:Label ID="Label12" runat="server" Text="Label"></asp:Label></p>  
       <p><asp:Label ID="Label14" runat="server" Text="Label"></asp:Label></p> 

       <p><asp:TextBox ID="TextBox1" runat="server" TextMode="DateTimeLocal"></asp:TextBox></p> 
        <p>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /></p>
        <table>
            <tbody>
                <tr>
                    <td>converted utc</td>
                    <td >
                       <asp:Label ID="Labelutc" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>converted ist</td>
                    <td >
                       <asp:Label ID="Labelist" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>Arizona </td>
                      <td > <asp:Label ID="LabelArizona" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>Utc time </td>
                      <td > <asp:Label ID="LabelUtcTime" runat="server" Text="Label"></asp:Label></td>
                </tr>
            </tbody>
        </table>
    </form>

</body>
    
</html>
