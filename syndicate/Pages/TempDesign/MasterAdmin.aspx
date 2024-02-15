<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MasterAdmin.aspx.cs" Inherits="syndicate.Pages.TempDesign.MasterAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-3.4.1.js"></script>
     <script src="../../Scripts/bootstrap.js"></script>
    <link href="../../Content/OldStyles/styles.css" rel="stylesheet" />
    <script src="../../Scripts/MasterAdminTemp/masteradmin.js"></script>

    <title>Admin</title>
</head>
<body style="background-color: #9CC7DA">
    <form id="form1" runat="server">
            <script type="text/javascript">
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                prm.add_beginRequest(beginRequest);

                function beginRequest() {
                    prm._scrollPosition = null;
                }
            </script>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div id="mainDiv" style="border: 0px solid grey;">
            <!---main div start-->
            <div class="titleDiv header-site" id="websiteTitle">
             
            </div>
            <br>

            <center>
                <div class="btnDiv100" style="font-size: 21px; background-color: transparent;">
                        <asp:Button ID="Button1" runat="server" Text="Start Game" class="startgame" style="font-size: 38px; background-color: #f06e4b; color: #fff; border-radius: 60px; padding: 10px 20px 10px 20px; border: none; box-shadow: 0px 4px 8px 0px #444 !important;" OnClick="Button1_Click"/>
                </div>
            </center>

            <br>

            <div id="menuDiv" style="display: grid; grid-template-columns: auto auto auto">
                <asp:Button ID="Buttonhome" runat="server" Text="Home" class="winTypeBtn1" style="outline: none; color: black; background: yellow;" OnClick="Buttonhome_Click"/>
                <asp:Button ID="ButtonManageTickets" runat="server" Text="Manage Tickets" class="winTypeBtn1" style="outline: none; color: black; background: yellow;" OnClick="ButtonManageTickets_Click" />
                <asp:Button ID="Buttonmanageagent" runat="server" Text="Manage Agents" class="winTypeBtn1" style="outline: none; color: black; background: yellow;" OnClick="Buttonmanageagent_Click"/>

            </div>

            <center>
                <div class="menubottom"><span>Set Date and Time</span></div>
            </center>
            <div class="row">
                <asp:Label ID="Labeldate" BackColor="#283241" runat="server" Text="Select Date" class="dateTimelabel text-center"></asp:Label>
                <asp:Label ID="Labeltime" BackColor="#283241" runat="server" Text="Select Time" class="dateTimelabel text-center"></asp:Label>
            </div>
            <div class="row">
                <asp:TextBox ID="TextBoxDate"  runat="server" TextMode="Date" class="dateTime text-center"></asp:TextBox>
             <asp:TextBox ID="TextBoxTime"  runat="server" TextMode="Time" class="dateTime text-center" ></asp:TextBox>
            </div>
            <center>
                <div class="menubottom"><span>Set Dividends</span></div>
            </center>

            <div style="background: cyan; width: 100%;" name="themeColorEl">
                <button class="transBtn2" style="outline: none;">Number Of Housefull</button>
            </div>

            <asp:DropDownList ID="DropDownListFullHouse" ClientIDMode="Static" CssClass="" class="dropDown" runat="server">
                <asp:ListItem Value="1">select</asp:ListItem>
                <asp:ListItem Value="1">House Full 1</asp:ListItem>
                <asp:ListItem Value="2">House Full 2</asp:ListItem>
                <asp:ListItem Value="3">House Full 3 </asp:ListItem>
                <asp:ListItem Value="4">House Full 4</asp:ListItem>
                <asp:ListItem Value="5">House Full 5</asp:ListItem>
                <asp:ListItem Value="6">House Full 6</asp:ListItem>
                <asp:ListItem Value="7">House Full 7</asp:ListItem>
                <asp:ListItem Value="8">House Full 8</asp:ListItem>
                <asp:ListItem Value="9">House Full 9</asp:ListItem>
                <asp:ListItem Value="10">House Full 10</asp:ListItem>
                <asp:ListItem Value="11">House Full 11</asp:ListItem>
                <asp:ListItem Value="12">House Full 12</asp:ListItem>
            </asp:DropDownList>
            <div style="background: cyan; width: 100%;" name="themeColorEl">
                <button class="transBtn2" style="outline: none;">Select Dividend</button>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
        <asp:DropDownList ID="DropDownListGameBonus" ClientIDMode="Static" CssClass="" class="dropDown" runat="server" OnSelectedIndexChanged="DropDownListGameBonus_SelectedIndexChanged" AutoPostBack="true">
               <asp:ListItem Selected="True" Value="0">Select Bonus</asp:ListItem>    
                <asp:ListItem Value="fs">Full Sheet</asp:ListItem>
                <asp:ListItem Value="hs">Half sheet</asp:ListItem>
                <asp:ListItem Value="T">Top Line </asp:ListItem>
                <asp:ListItem Value="M">Middle Line</asp:ListItem>
                <asp:ListItem Value="B">Bottom Line</asp:ListItem>
                <asp:ListItem Value="S">Star </asp:ListItem>
                <asp:ListItem Value="Qf">Quick Five</asp:ListItem>
                <asp:ListItem Value="Qs">Quick Seven</asp:ListItem>
            </asp:DropDownList>
                    </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanelBonusDivident" runat="server" style="background: cyan; width: 100%;" name="themeColorEl">
                <ContentTemplate>
                    <asp:Panel ID="Panelfs" runat="server" Visible="false">
                        <asp:Button ID="Buttonfsb" runat="server" Text="Full Sheet Bonus" class="inp" style="width:74%;text-align:left;"/>
                        <asp:Button ID="ButtonfsbR" OnClick="ButtonfsbR_Click" runat="server" Text="Remove" class="inp" style="width:23.5%;text-align:center;background-color: #f06e4b; color: #fff;" />
                    </asp:Panel>
                      <asp:Panel ID="Panelhs" runat="server" Visible="false">
                        <asp:Button ID="Buttonhsb" runat="server" Text="Half Sheet Bonus" class="inp" style="width:74%;text-align:left;"/>
                        <asp:Button ID="ButtonhsbR" OnClick="ButtonhsbR_Click" runat="server" Text="Remove" class="inp" style="width:23.5%;text-align:center;background-color: #f06e4b; color: #fff;" />
                    </asp:Panel>
                      <asp:Panel ID="PanelT" runat="server" Visible="false">
                        <asp:Button ID="ButtonT" runat="server" Text="Top Line" class="inp" style="width:74%;text-align:left;"/>
                        <asp:Button ID="ButtonTR" OnClick="ButtonTR_Click" runat="server" Text="Remove" class="inp" style="width:23.5%;text-align:center;background-color: #f06e4b; color: #fff;" />
                    </asp:Panel>
                      <asp:Panel ID="PanelM" runat="server" Visible="false">
                        <asp:Button ID="ButtonM" runat="server" Text="Middle Line" class="inp" style="width:74%;text-align:left;"/>
                        <asp:Button ID="ButtonMR" OnClick="ButtonMR_Click" runat="server" Text="Remove" class="inp" style="width:23.5%;text-align:center;background-color: #f06e4b; color: #fff;" />
                    </asp:Panel>
                      <asp:Panel ID="PanelB" runat="server" Visible="false">
                        <asp:Button ID="ButtonB" runat="server" Text="Bottom Line" class="inp" style="width:74%;text-align:left;"/>
                        <asp:Button ID="ButtonBR" OnClick="ButtonBR_Click" runat="server" Text="Remove" class="inp" style="width:23.5%;text-align:center;background-color: #f06e4b; color: #fff;" />
                    </asp:Panel>
                      <asp:Panel ID="PanelS" runat="server" Visible="false">
                        <asp:Button ID="ButtonS" runat="server" Text="Star" class="inp" style="width:74%;text-align:left;"/>
                        <asp:Button ID="ButtonSR" OnClick="ButtonSR_Click" runat="server" Text="Remove" class="inp" style="width:23.5%;text-align:center;background-color: #f06e4b; color: #fff;" />
                    </asp:Panel>
                      <asp:Panel ID="PanelQf" runat="server" Visible="false">
                        <asp:Button ID="ButtonQf" runat="server" Text="Quick Five " class="inp" style="width:74%;text-align:left;"/>
                        <asp:Button ID="ButtonQfR" OnClick="ButtonQfR_Click" runat="server" Text="Remove" class="inp" style="width:23.5%;text-align:center;background-color: #f06e4b; color: #fff;" />
                    </asp:Panel>
                      <asp:Panel ID="PanelQs" runat="server" Visible="false">
                        <asp:Button ID="ButtonQs" runat="server" Text="Quick Seven" class="inp" style="width:74%;text-align:left;"/>
                        <asp:Button ID="ButtonQsR" OnClick="ButtonQsR_Click" runat="server" Text="Remove" class="inp" style="width:23.5%;text-align:center;background-color: #f06e4b; color: #fff;" />
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="timeDateDiv" style="grid-template-columns: auto; width: 100%;" name="themeColorEl">
                 <asp:Button ID="ButtonSaveGameSettings" runat="server" Text="Save Game Settings" class="savesetting" style="outline: none; background: yellow" OnClick="ButtonSaveGameSettings_Click"/>
            </div>

            <br>
            <center>
                <div class="menubottom"><span>Set Admin Password</span></div>
            </center>
          
            <div class="adminInfo" style="background: cyan; width: 100%;" name="themeColorEl">
                <!---------------adminInfo-->
                 
                <div class="timeDateDiv" style="grid-template-columns: auto">
                    <button class="transBtn1" style="outline: none;" name="themeColorEl">Admin Name</button>
                </div>

                <div class="timeDateDiv" style="margin-left: 0%; grid-template-columns: auto">
                    <asp:TextBox ID="TextBoxAdminName" runat="server" class="inp" placeholder="Admin Name" style="margin-left: 0%;"></asp:TextBox>
                </div>

                <div class="timeDateDiv" style="grid-template-columns: auto">
                    <button class="transBtn1" style="outline: none;" name="themeColorEl">Admin Password</button>
                </div>

                <div class="timeDateDiv" style="margin-left: 0%; grid-template-columns: auto">
                  <asp:TextBox ID="TextBoxAdminPassword" runat="server" class="inp" placeholder="Admin Name" style="margin-left: 0%;"></asp:TextBox>
                </div>
                 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <div class="timeDateDiv" style="grid-template-columns: auto">
                    <asp:Button ID="ButtonSaveAdmin" OnClick="ButtonSaveAdmin_Click" runat="server" Text="Save" class="savesetting" style="outline: none; background: yellow"/>
                </div>
                 </ContentTemplate>
            </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                          <div class="timeDateDiv" name="themeColorEl" style="margin-top:10px;margin-bottom:10px;">
                <asp:Label ID="SetTicketPrice" runat="server" class="inp" Style="outline: none;" Text="Set Ticket Price"></asp:Label>
                <asp:TextBox ID="TextBoxTicketPrice" runat="server" class="inp" placeholder="Ticket price" TextMode="Number" Style="outline: none;"></asp:TextBox>
                <asp:Button ID="ButtonSaveTicketPrice" runat="server" class="inp"  Style="outline: none;background:#568D46;color:aliceblue" Text="Save Ticket Price" OnClick="ButtonSaveTicketPrice_Click"></asp:Button>
                     </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="adminInfo text-center" style="background: cyan; width: 100%;">
                    <!---------------Total ticket-->
                    <div class="timeDateDiv" style="grid-template-columns: auto">
                       
                        <asp:Label ID="LabelTotalTickets" runat="server" Text="Total Tickets in sale 0" class="transBtn2" style="outline: none;" name="themeColorEl"></asp:Label>
                    </div>

                    <div class="timeDateDiv" style="grid-template-columns: auto">
                        <asp:Button ID="ButtonCreateNewTicket" runat="server" Text="Create New set of Ticket" class="changemode" style="outline: none; background: yellow" OnClick="ButtonCreateNewTicket_Click"/>
                     </div>

                </div>
                    <div class="adminInfo text-center" style="background: cyan; width: 100%;">
                    <!---------------Total ticket-->
                    <div class="timeDateDiv" style="grid-template-columns: auto">
                       
                        <asp:Label ID="LabelCreateFlyer" runat="server" Text="Create Game flyers" class="transBtn2" style="outline: none;" name="themeColorEl"></asp:Label>
                    </div>

                    <div class="timeDateDiv" style="grid-template-columns: auto">
                        <asp:Button ID="Buttonflyer" runat="server" Text="Create flyer" class="changemode" style="outline: none; background: yellow" OnClick="Buttonflyer_Click"/>
                     </div>

                </div>
                <br>
                  
                <div class="adminInfo text-center" style="background: cyan; width: 100%;">
                    <!---------------Booking mode-->
                     <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <div class="timeDateDiv" style="grid-template-columns: auto">
                        <asp:Label ID="LabelBookingMode" runat="server" Text="Booking Mode is On" class="transBtn2" style="outline: none;" name="themeColorEl"></asp:Label>
                    </div>
                   
                    <div class="timeDateDiv" style="grid-template-columns: auto">
                        <asp:Button ID="ButtonChangeBookingMode" runat="server" Text="Change Mode" class="changemode" style="outline: none; background: yellow" OnClick="ButtonChangeBookingMode_Click"/>
                    </div>
                      </ContentTemplate>
                  </asp:UpdatePanel>
                </div>

                         <br>
                <div class="adminInfo text-center" style="background: cyan; width: 100%;">
                    <!---------------Restart-->
                    <div class="timeDateDiv" style="grid-template-columns: auto">
                        <asp:Label ID="LabelRestart" runat="server" Text="This Restarts the Game (Same Random Sequence)" class="transBtn2" style="outline: none;" name="themeColorEl"></asp:Label>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <div class="timeDateDiv" style="grid-template-columns: auto">
                        <asp:Button ID="ButtonRestart" runat="server" Text="Restart" class="changemode" style="outline: none; background: yellow" OnClick="ButtonRestart_Click"/>
                    </div>
                     </ContentTemplate>
                  </asp:UpdatePanel>
                </div>
                         <br>
                <div class="adminInfo text-center" style="background: cyan; width: 100%;">
                    <!---------------Reset-->
                    <div class="timeDateDiv" style="grid-template-columns: auto">
                        <asp:Label ID="LabelReset" runat="server" Text="This Resets the Game (Generate new Random sequence)" class="transBtn2" style="outline: none;" name="themeColorEl"></asp:Label>
                    </div>
                     <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <div class="timeDateDiv" style="grid-template-columns: auto">
                        <asp:Button ID="ButtonReset" runat="server" Text="Reset" class="changemode" style="outline: none; background: yellow" OnClick="ButtonReset_Click"/>
                    </div>
                     </ContentTemplate>
                  </asp:UpdatePanel>
                </div>
                         <br>
                <div class="adminInfo text-center" style="background: cyan; width: 100%;">
                    <!---------------Whatsapp-->
                    <div class="timeDateDiv" style="grid-template-columns: auto">
                        <asp:Label ID="Labelwhatsapp" runat="server" Text=" Add Whats app group link " class="transBtn2" style="outline: none;" name="themeColorEl"></asp:Label>
                    </div>

                    <div class="timeDateDiv" style="grid-template-columns: auto">
                        <asp:Button ID="ButtonWhatsapp" runat="server" Text="Add link" class="changemode" style="outline: none; background: yellow" OnClick="ButtonWhatsapp_Click"/>
                    </div>

                </div>
                         <br>
                <div class="adminInfo text-center" style="background: cyan; width: 100%;">
                    <!---------------Logout-->
                    <div class="timeDateDiv" style="grid-template-columns: auto">
                        <asp:Label ID="Label4" runat="server" Text="Logout session" class="transBtn2" style="outline: none;" name="themeColorEl"></asp:Label>
                    </div>

                    <div class="timeDateDiv" style="grid-template-columns: auto">
                        <asp:Button ID="ButtonLogout" runat="server" Text="Log out" class="changemode" style="outline: none; background: yellow" OnClick="ButtonLogout_Click"/>
                    </div>

                </div>

                <br>
                <div class="timeDateDiv" style="grid-template-columns: auto">
                    <button class="transBtn" style="outline: none; background: blueviolet; color: black;" onclick='{window.location="previewGame.html"}' name="ticketColorEl">Check Game Preview</button>
                </div>

            </div>
            <!---main div end-->
        </div>
    </form>
</body>
</html>
