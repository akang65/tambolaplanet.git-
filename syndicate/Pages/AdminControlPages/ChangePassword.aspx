<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="syndicate.Pages.AdminControlPages.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
      <link href="../../lib/font-awesome/css/all.css" rel="stylesheet" />

    <script type="text/javascript">
        function formError() {
            alert("Please correct the form");
        }
        function passwordUnMatch() {
            alert("Password does not Match");
        }
    </script>
    <title>privacy</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
            <div class="container">
                <div class="card">
                    <div class="card-header"> <a href="../../admin">
             <i class="fas fa-arrow-left"></i></a> Update Details (Admin) </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-6">Name</div>
                             <div class="col-6">
                                 <asp:TextBox ID="TextBoxName" CssClass="form-control form-control-sm" runat="server"></asp:TextBox></div>
                        </div>
                          <div class="row mt-1">
                            <div class="col-6">Phone</div>
                             <div class="col-6">
                                 <asp:TextBox ID="TextBoxPhone" TextMode="Number" CssClass="form-control form-control-sm" runat="server"></asp:TextBox></div>
                        </div>
                          <div class="row mt-1">
                            <div class="col-6">Password</div>
                             <div class="col-6">
                                 <asp:TextBox ID="TextBoxPassword" CssClass="form-control form-control-sm" runat="server"></asp:TextBox></div>
                        </div>
                             <div class="row mt-1">
                            <div class="col-6"> Confirm Password</div>
                             <div class="col-6">
                                 <asp:TextBox ID="TextBoxConfirm" CssClass="form-control form-control-sm " runat="server"></asp:TextBox></div>
                        </div>
                        <div class="row mt-1">
                             <div class="col-6">
                                 <asp:Label ID="LabelSuccess" runat="server"></asp:Label>
                              </div>
                            <div class="col-6">
                                 <asp:Button ID="ButtonSave" runat="server" CssClass="text-end btn btn-success btn-sm" Text="save" OnClick="ButtonSave_Click" />
                              </div>
                        </div>
                    </div>
                </div>
            </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
