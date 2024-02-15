<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentsLists.aspx.cs" Inherits="syndicate.Pages.AgentsLists" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../lib/font-awesome/css/all.css" rel="stylesheet" />
    <title> Booking Agents</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container py-5">
                <div class="card">
                    <div class="card-header bg-dark text-light">
                        <h6 class="text-center">Booking Agents</h6>
                    </div>
                    <div class="card-body bg-success">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tambolastars %>" SelectCommand="SELECT [AgentPhoneNumber], [AgentName] FROM [Agents]"></asp:SqlDataSource>
                        <asp:GridView ID="GridView1" class="table table-borderless border-0 text-center text-light"  runat="server" AutoGenerateColumns="False" DataKeyNames="AgentPhoneNumber" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                 <asp:BoundField DataField="AgentName" HeaderText="Name" SortExpression="AgentName" />
                                <asp:BoundField DataField="AgentPhoneNumber" HeaderText="Number" ReadOnly="True" SortExpression="AgentPhoneNumber" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButtonCall" ImageUrl="../Content/images/call.png" runat="server" Height="24px" Width="25px"  CommandName="Call" CommandArgument="<%# Container.DataItemIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButtonWhatsapp" runat="server" ImageUrl="../Content/images/large%20whatsapp.png" Height="30px" Width="30px" CommandName="Whatsapp" CommandArgument="<%# Container.DataItemIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>
