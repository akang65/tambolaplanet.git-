<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AudioUpdate.aspx.cs" Inherits="syndicate.Pages.AudioUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> audio Setting</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
   <link href="../../lib/font-awesome/css/all.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

       
      <div class="card">
            <div class="card-header">  
                <a href="../../admin">
        <i class="fas fa-arrow-left"></i> 
                </a>
                <h4 class="text-center">Update Custom Audio</h4></div>
                <div class="card-body">
                </div>
        <p>Note: If you Want to change Audio you have to first select and delete the desired audio and upload the new one with the same name and file extension. i.e: filename.mp3 </p>
        <p>Example : 1.mp3 or 2.mp3</p>
        <p> For fast and best perfomance keep the audio file in less then 20 kb </p>
         <p class="text-danger"> Your works, your results! don't blame me later XD </p>
                 </div>
      </div>
        <div class="container ">
            <div class="container-body ">
                <div class="card bg-dark ">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <div class="card-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="LabelInfo" CssClass="text-danger" runat="server"></asp:Label>
                                <asp:Literal ID="LiteralPlayAudio" runat="server">
                         
                                </asp:Literal>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="row">

                            <div class="col-8">
                                <%-- uploader--%>
                                <asp:FileUpload ID="FileUploadAdd" runat="server" ForeColor="#0066FF" />
                            </div>
                            <div class="col-4">
                                <%--upload button--%>
                                <asp:Button ID="ButtonUpload" CssClass="btn btn-primary text-start" runat="server" Text="Upload" OnClick="ButtonUpload_Click" />
                            </div>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-4">
                                        <%--dropDown--%>
                                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="false"></asp:DropDownList>

                                    </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="row">
                        <%-- <div class="col-2">--%>
                        <%--select button--%>
                        <%--  <div class=" flex align-item-end">
                                   <asp:Button ID="ButtonPlay"  runat="server" AutoPostBack="false" class="btn btn-success"  Text="Play" OnClick="ButtonPlay_Click" />
                              </div>
                             
                         </div>--%>
                        <div class="col-2 mt-2">
                            <%--select button--%>
                            <div class="align-item-start">
                                <asp:Button ID="ButtonDelete" runat="server" AutoPostBack="false" class="btn btn-danger" Text="Delete" OnClick="ButtonDelete_Click" />
                            </div>

                        </div>
                    </div>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
