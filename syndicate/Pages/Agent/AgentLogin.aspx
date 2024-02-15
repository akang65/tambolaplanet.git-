﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentLogin.aspx.cs" Inherits="syndicate.Pages.Agent.AgentLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <section class="vh-100 UserGradient">
  <div class="container py-5 h-100">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col-12 col-md-8 col-lg-6 col-xl-5">
        <div class="card bg-dark text-white" style="border-radius: 1rem;">
          <div class="card-body p-5 text-center">

            <div class="mb-md-5 mt-md-4 pb-5">
                <h2 class="fw-bold mb-2 text-uppercase">
                    <img src="../../Content/images/logo-no-background.png"  style="width:65%; height:50%" class="rounded mx-auto d-block" /></h2>
              <h2 class="fw-bold mb-2 text-uppercase">Login</h2>
              <p class="text-white-50 mb-5">Please enter your login and password!</p>
                <asp:Label ID="LabelWarning" class="text-Danger-50 mb-5" runat="server" Visible="false" Text="Incorrect Credentials"></asp:Label>

              <div class="form-outline form-white mb-4">
                  <asp:TextBox ID="TextBoxNumber" runat="server" class="form-control form-control-lg" placeholder="Phone Number"></asp:TextBox>     
              </div>

              <div class="form-outline form-white mb-4">
                  <asp:TextBox ID="TextBoxPassword" runat="server"  class="form-control form-control-lg" placeholder="Password" TextMode="Password"></asp:TextBox>
              </div>

             <%-- <p class="small mb-5 pb-lg-2"><a class="text-white-50" href="#!">Forgot password?</a></p>--%>
        
                <asp:Button ID="ButtonLogin" runat="server" Text="Login" class="btn btn-outline-light btn-lg px-5" OnClick="ButtonLogin_Click"  />
              <div class="d-flex justify-content-center text-center mt-4 pt-1">
                <a href="#!" class="text-white"><i class="fab fa-facebook-f fa-lg"></i></a>
                <a href="#!" class="text-white"><i class="fab fa-twitter fa-lg mx-4 px-2"></i></a>
                <a href="#!" class="text-white"><i class="fab fa-google fa-lg"></i></a>
              </div>

            </div>

            <div>
              <p class="mb-0">Don't have an account? <a href="#!" class="text-white-50 fw-bold"><%--Request one--%></a>
              </p>
                <p class="small mb-5 pb-lg-2 header-site-agent"><a class="text-white-50" href="#!">Request one at: </a></p>
            </div>

          </div>
        </div>
      </div>
    </div>
  </div>
</section>
        </div>
    </form>
</body>
</html>
