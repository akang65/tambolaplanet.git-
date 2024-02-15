 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AutostartGame.aspx.cs" Inherits="syndicate.Pages.AutostartGame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../lib/font-awesome/css/all.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Sofia&effect=neon|outline|emboss|shadow-multiple"/>
    <script src="../Scripts/AutostartScripts/CustomCountDownTimer.js"></script>
    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../Scripts/jquery.signalR-2.2.2.min.js"></script>
    <script src="/signalR/hubs"></script>
    <script src="../Scripts/AutostartScripts/autostartGame.js"></script>
    <script src="../Scripts/AutostartScripts/EventListener.js"></script>
    

    
</head>
<body onload="getarray();populatefields();hideWinningTable();" class="gradient-syndicateAutoPage" <%--oncontextmenu="return false;"--%> >
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
         <%--  announcement--%>
        <asp:Panel ID="PanelAnnouncement" runat="server">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
              <div class="container py-5 h-100">
               <div class=" container-body border-gradientR">
                   <div class="card" style="background-color:#141414">
                  
                       <div class="card-body text-light">
                         
                           <img src="../Content/images/logo-no-background.png"  style="width:50%; height:50%" class="rounded mx-auto d-block"/>
                          <%-- <h6 class="text-center" style="font-family:'Thank You So Much'">Welcome to VIP Tambola</h6>--%>
                             <div class="text-center mt-3">
                                 <button type="button" class="btn btn-dark border border-light text-light text-center" onclick="showPanels();">Enter Game</button>
                             </div>
                              
                       </div>
                   </div>            
               </div>
           </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>

        <asp:Panel ID="PanelRandomGenerated" style="display:none" runat="server">
        <%-- <asp:UpdatePanel ID="UpdatePanelRandomGenerated" runat="server">
            <ContentTemplate>--%>
           
            <div class="text-center mt-3">
           <h2 class="font-effect-outline"> <img src="../Content/images/logo-no-background.png"  style="width:30%; height:50%" class="rounded mx-auto d-block"/></h2>
            </div>
  
                <div class="container"> 
                     <h6 id="statusTimer" class="text-center fw-light text-warning">Prepare your tickets the game Starts in:</h6>
                    <p id="Timer" class="text-light text-center"></p>
                                <div class="text-center">
                    <table id="TableRandomNum" class="table table-bordered text-light table-sm border border-3 fs-6 fw-light border-Gold" style="background:#2c3b7f">
                        <tr>
                            <th colspan="10" class="text-light">Random Number Table</th>
                        </tr>
                        <tr>
                            <td>1</td>
                            <td>2</td>
                            <td>3</td>
                            <td>4</td>
                            <td>5</td>
                            <td>6</td>
                            <td>7</td>
                            <td>8</td>
                            <td>9</td>
                            <td>10</td>
                        </tr>
                          <tr>
                            <td>11</td>
                            <td>12</td>
                            <td>13</td>
                            <td>14</td>
                            <td>15</td>
                            <td>16</td>
                            <td>17</td>
                            <td>18</td>
                            <td>19</td>
                            <td>20</td>
                        </tr>
                          <tr>
                            <td>21</td>
                            <td>22</td>
                            <td>23</td>
                            <td>24</td>
                            <td>25</td>
                            <td>26</td>
                            <td>27</td>
                            <td>28</td>
                            <td>29</td>
                            <td>30</td>
                        </tr>
                          <tr>
                            <td>31</td>
                            <td>32</td>
                            <td>33</td>
                            <td>34</td>
                            <td>35</td>
                            <td>36</td>
                            <td>37</td>
                            <td>38</td>
                            <td>39</td>
                            <td>40</td>
                        </tr>
                          <tr>
                            <td>41</td>
                            <td>42</td>
                            <td>43</td>
                            <td>44</td>
                            <td>45</td>
                            <td>46</td>
                            <td>47</td>
                            <td>48</td>
                            <td>49</td>
                            <td>50</td>
                        </tr>
                          <tr>
                            <td>51</td>
                            <td>52</td>
                            <td>53</td>
                            <td>54</td>
                            <td>55</td>
                            <td>56</td>
                            <td>57</td>
                            <td>58</td>
                            <td>59</td>
                            <td>60</td>
                        </tr>
                          <tr>
                            <td>61</td>
                            <td>62</td>
                            <td>63</td>
                            <td>64</td>
                            <td>65</td>
                            <td>66</td>
                            <td>67</td>
                            <td>68</td>
                            <td>69</td>
                            <td>70</td>
                        </tr>
                          <tr>
                            <td>71</td>
                            <td>72</td>
                            <td>73</td>
                            <td>74</td>
                            <td>75</td>
                            <td>76</td> 
                            <td>77</td>
                            <td>78</td>
                            <td>79</td>
                            <td>80</td>
                        </tr>
                          <tr>
                            <td>81</td>
                            <td>82</td>
                            <td>83</td>
                            <td>84</td>
                            <td>85</td>
                            <td>86</td>
                            <td>87</td>
                            <td>88</td>
                            <td>89</td>
                            <td>90</td>
                        </tr>
                    </table>
                            
                    </div>
                </div>
               <%--     </ContentTemplate>
        </asp:UpdatePanel>--%>
            </asp:Panel>
    
        <div class="container" id="rsT" style="display:none">
            <h6 class="text-light text-center">Random number sequence:</h6>
            <div id="RandomSequenceTable" class="text-center"></div>
        </div>
         <!-- Show tickets || single || FullSheet|| Halfsheet-->
        <asp:Panel ID="PanelTicketControls" Visible="true" style="display:none" runat="server">
        <asp:UpdatePanel ID="UpdatePanelShowtickets" runat="server" visible="true"  UpdateMode="Conditional">
            <ContentTemplate>
                <div class="container mt-2">
                    <div class="container-body border-gradient">
                        <h6 class="text-light text-center fs-6 fw-light">Enter Ticket Number To View</h6>
                        <div class="text-center">
                            <asp:Label ID="LabelTicketShowStatus" runat="server" Visible="false"></asp:Label>
                            <div class="row mb-2">
                                <div class="col-6 ms-2">
                                    <asp:TextBox ID="TextBoxEnterTicketNo" class="form-control form-control-sm" Visible="true" TextMode="Number" placeholder=" Enter Ticket Number" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-2">
                                    <asp:Button ID="ButtonShowTickets" BackColor="#dee2e6" CssClass="btn btn-sm" Visible="true" runat="server" Text="View" OnClientClick="showTable(); return false;" />
                                </div>
                                <div class="col-3">
                                    <asp:Button ID="ButtonDeleteAll" CssClass="btn btn-warning btn-sm mb-1" runat="server" Text="Hide All" OnClientClick="hideAllTable(); return false;" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
            </asp:Panel>
         <%-- Delete tickets--%>

        <%--Tickets and timer--%>
        <asp:UpdatePanel ID="UpdatePanelAudio" runat="server">
            <ContentTemplate>
                <asp:Literal ID="LiteralAudio" runat="server"></asp:Literal>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Panel ID="PanelTickets" visible="true" style="display:none" runat="server">
        <div class="container">        
                    <asp:UpdatePanel ID="UpdatePanel1" class="text-center" runat="server">
                        <ContentTemplate>
                              <div class="mt-2" id="grid1" runat="server"></div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
              
        </div>  
        </asp:Panel>
                   <%-- winning person--%>
       <%-- New Table--%>
        <asp:Panel ID="PanelWinners" style="display:none" runat="server">
        <div class="container">
            <div class="card transparentBg">
                 <div class="card-header">
                        <h5 class="text-center text-light">Winners</h5>
                    </div>
                 <div class="card-body text-center">
                     <h6 class="text-center text-warning" id="fh">Full House Winners</h6>
                     <table id="FullHouse" class="table table-sm transparentBg text-light table-borderless">
                         <tbody>
                              <tr>
                        </tr>
                         </tbody>
                     </table>
                     <div id="fullhouseClone"></div>
                  <div class="row mt-2">
                         <h6 class="text-center text-warning"id="tl">Top Line  Winners</h6>
                           <table id="TopLine" class="table table-sm transparentBg text-light table-borderless">
                        <tr>
                        </tr>
                     </table>
                     </div>
                       <div class="row mt-2">
                         <h6 class="text-center text-warning"id="ml">Middle Line Winners</h6>
                           <table id="MiddleLine" class="table table-sm transparentBg text-light table-borderless">
                        <tr>
                        </tr>
                     </table>
                     </div>
                       <div class="row mt-2">
                         <h6 class="text-center text-warning"id="bl">Bottom Line Winners</h6>
                           <table id="BottomLine" class="table table-sm transparentBg text-light table-borderless">
                        <tr>
                        </tr>
                     </table>
                     </div>
                       <div class="row mt-2">
                         <h6 class="text-center text-warning"id="qf">Quick Five Winners</h6>
                           <table id="QuickFive" class="table table-sm transparentBg text-light table-borderless">
                        <tr>
                        </tr>
                     </table>
                     </div>
                       <div class="row mt-2">
                         <h6 class="text-center text-warning"id="qs">Quick Seven Winners</h6>
                           <table id="QuickSeven"  class="table table-sm transparentBg text-light table-borderless">
                        <tr>
                        </tr>
                     </table>
                     </div>
                       <div class="row mt-2">
                         <h6 class="text-center text-warning"id="s">Star Winners</h6>
                           <table id="Star" class="table table-sm transparentBg text-light table-borderless">
                        <tr>
                        </tr>
                     </table>
                     </div>
                      
                        <div class="row mt-2">
                         <h6 class="text-center text-warning"id="hs">Half Sheet Winners</h6>
                           <table id="Halfsheet" class="table table-sm transparentBg text-light table-borderless">
                        <tr>
                        </tr>
                     </table>
                     </div>
                         <div class="row mt-2">
                         <h6 class="text-center text-warning"id="fs">Full Sheet Winners</h6>
                           <table id="FullSheet" class="table table-sm transparentBg text-light table-borderless">
                        <tr>
                            
                        </tr>
                     </table>      
                     </div>
                 </div>
            </div>
        </div>
      </asp:Panel>
    </form>

</body>
<script src="../Scripts/confetti.js"></script>
</html>
