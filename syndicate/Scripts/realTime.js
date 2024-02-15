 $.connection.hub.start()
        .done(function () {
            $.connection.hub.logging = true;
            console.log = "cONNECTED";
            //$.connection.myHub2.server.announce("something test");
        });
$.connection.myHub2.client.getdata = function (message) {
    var temp = message;
    getData(temp);
}
    
        
function getData(message) {
    var c = document.getElementById("welcomeMessages");
    c.append(message);
}


//function get() {
//    $.ajax({
//        url: 'AutostartGame.aspx/passArrayToJs',
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        type: "POST",
//        success: function (data) {
//            if (data.d.length > 0) {
//                var Array = data.d;
//                var jsVariable = $.parseJSON('[' + Array + ']');
//                var apple = jsVariable[0];
//                var count = apple.length;
//                for (let l = 0; l < count; l++) {
//                    var table = document.getElementById("TableRandomNum");
//                    //iterate trough rows
//                    for (var i = 1, row; row = table.rows[i]; i++) {
//                        //iterate trough columns
//                        for (var j = 0, col; col = row.cells[j]; j++) {
//                            // do something 
//                            var tabInnertext = col.innerText;
//                            var num = apple[l];
//                            if (tabInnertext == num) {
//                                col.style.backgroundColor = "red";
//                            }
//                        }
//                    }
//                }
//            }
//        }
//    });
//}
////Show or Hide Table
//function showTable() {
//    var textboxField = document.getElementById("TextBoxEnterTicketNo").value;
//    var tableConcate = "GridView" + textboxField;
//    var tablename = document.getElementById(tableConcate);
//    tablename.style.display = "table";
//    var panel = document.getElementById("UpdatePanel1");
//    panel.style.display = "inherit";
//    var UpdateColor = JSON.parse(sessionStorage.getItem("RandomOnTickets"));
//    if (UpdateColor != null) {
//        for (var ite = 0; ite < UpdateColor.length; ite++) {
//            for (var i = 1, row; row = tablename.rows[i]; i++) {
//                //iterate trough columns
//                for (var j = 0, col; col = row.cells[j]; j++) {
//                    // do something 
//                    var tabInnertext = col.innerText;
//                    if (tabInnertext == UpdateColor[ite]) {
//                        col.style.backgroundColor = "#730573";
//                    }
//                }
//            }

//        }
//    }
//    if (sessionStorage.getItem('Tickets') == null) {
//        var Vticket = [tableConcate];
//        sessionStorage.setItem('Tickets', JSON.stringify(Vticket));
//    }
//    else if (sessionStorage.getItem('Tickets') != null) {
//        var VisibleTickets = JSON.parse(sessionStorage.getItem("Tickets"));
//        if (VisibleTickets.includes(tableConcate) != true) {
//            var length = VisibleTickets.length;
//            VisibleTickets[length] = tableConcate;
//            sessionStorage.setItem('Tickets', JSON.stringify(VisibleTickets));
//        }
//    }
//}
//function hideAllTable() {
//    var panel = document.getElementById("UpdatePanel1");
//    panel.style.display = "none";
//    sessionStorage.removeItem('Tickets');
//    for (var k = 1; k < 840; k++) {
//        var tablename = document.getElementById("GridView" + k);
//        tablename.style.display = "none";
//    }
//}

///* Events Listener*/
//document.addEventListener('click', (e) => {
//    // Retrieve id from clicked element
//    let elementId = e.target.id;
//    var buttonName = elementId + "";
//    var removeChar = buttonName.replace(/[A-Za-z]/g, ""); //1_1_0
//    if (elementId !== '' && buttonName.match(/GridView/)) {
//        const TablePrefix = "GridView";
//        if (buttonName.length == 19) {
//            var buttonId = removeChar[0];
//            HideButtonsTicket(TablePrefix, buttonId);
//            /*  HideButtonsTicket(TablePrefix, buttonId);*/
//        } else if (buttonName.length == 21) {
//            var buttonId = removeChar.slice(0, 2);
//            HideButtonsTicket(TablePrefix, buttonId);
//        } else if (buttonName.length == 23) {
//            var buttonId = removeChar.slice(0, 3);
//            HideButtonsTicket(TablePrefix, buttonId);
//        }
//    }
//    else {
//        console.log("An element without an id was clicked.(Test)");
//    }
//}
 
//);
///* Hide Ticket Method*/
//function HideButtonsTicket(Tprefix, bId) {
//    var tablename = document.getElementById(Tprefix + bId);
//    tablename.style.display = "none";
//    var VisibleTickets = JSON.parse(sessionStorage.getItem("Tickets"));
//    var TicketIndex = VisibleTickets.indexOf(Tprefix + bId);
//    VisibleTickets.splice(TicketIndex, 1);
//    sessionStorage.setItem('Tickets', JSON.stringify(VisibleTickets));
//}
      
//function getData() {
//  //  var $tbl = $('#tbl');
//    var row1 = document.getElementById("TableRandomNum").rows[1];
//    var row2 = document.getElementById("TableRandomNum").rows[2];
//    var row3 = document.getElementById("TableRandomNum").rows[3];
//    var row4 = document.getElementById("TableRandomNum").rows[4];
//    var row5 = document.getElementById("TableRandomNum").rows[5];
//    var row6 = document.getElementById("TableRandomNum").rows[6];
//    var row7 = document.getElementById("TableRandomNum").rows[7];
//    var row8 = document.getElementById("TableRandomNum").rows[8];
//    var row9 = document.getElementById("TableRandomNum").rows[9];
//    var fullhouse = document.gElemtById("FullHouse");
//    var fullsheet = document.gElemtById("FullSheet");
//    var halfsheet = document.gElemtById("HalfSheet");
//    var quickfive = document.getemenyId("QuickFive");
//    var quickseven = dumengetElementById("Quickseven");
//    var star = dumengetElementById("Star");
//    var topline = document.gElemtById("TopLine");
//    var middleline = document.getEmentId("MiddleLine");
//    var btomline = docunt.getElementById("BottomLine");
//    var count = row1.cells.length;
//    $.ajax({
//        url: 'AutostartGame.aspx/GetData',
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        type: "POST",
//        success: function (data) {
//            if (data.d.length > 0)
//            {
//                var newdata = data.d;
//            }
//            var countlength= newdata.length;
//            var randomNumber = newdata[countlength - 1].CurrentRandom;
//            var num = '' + randomNumber;
//            var AudioName = num + '.mp3';
//            var source = '../Audio/' + AudioName;
//            var selectRow = randomNumber;

//            if (sessionStorage.getItem('CurrentNumber') == null)
//            {
//                sessionStorage.setItem('CurrentNumber', '0')
//            }

//            var sessionNumber = parseInt(sessionStorage.getItem('CurrentNumber'));
//            if (selectRow != sessionNumber) {
//                for (var w = 0; w < countlength; w++) {
//                    if (newdata[w].WinningName == 'FULLHOUSE' && selectRow != sessionNumber) {
//                        $("#FullHouse").find("tr:gt(0).remove();");
//                        for (let loop = 0; loop < countlength; loop++) {
//                            if (newdata[loop].WinningName = "FULLHOUSE") {
//                                var row = fuhouse.insertw(-1);
//                                var Cname = row.insertCe(0);
//                                var TNumber = row.insertll(1);
//                                var Place = row.inseCell(2);
//                                Cname.innerText = newdata[w].CustorName;
//                                TNumber.innerText = newdata[w].TicketNumber;
//                                Place.innerxt = newdata[w].Place;
//                            }
//                        }
//                    }
//                }

//            /* Random Table*/
//            if (selectRow > 0 && selectRow <= 10)
//            {
//                if (selectRow != sessionNumber) {
               
//                    for (let i = 0; i < row1.cells.length; i++)
//                    {
//                    if (row1.cells[i].innerText == randomNumber)
//                    {       
//                        row1.cells[i].style.backgroundColor = "red";
//                        var audio = new Audio(source);
//                        audio.autoplay = true;
//                        audio.play();     
//                        sessionStorage.setItem('CurrentNumber', num)
//                    }
//                    }
//                }
//            } else if (selectRow > 10 && selectRow <= 20) {
//                if (selectRow != sessionNumber) {
//                    for (let i = 0; i < row2.cells.length; i++) {
//                        if (row2.cells[i].innerText == randomNumber) {
//                            row2.cells[i].style.backgroundColor = "red";
//                            var audio = new Audio(source);
//                            audio.autoplay = true;
//                            audio.play();
//                            sessionStorage.setItem('CurrentNumber', num)
//                        }
//                    }
//                }
//            }
//            else if (selectRow > 20 && selectRow <= 30) {
//                if (selectRow != sessionNumber) {
//                    for (let i = 0; i < row3.cells.length; i++) {
//                        if (row3.cells[i].innerText == randomNumber) {
//                            row3.cells[i].style.backgroundColor = "red";
//                            var audio = new Audio(source);
//                            audio.autoplay = true;
//                            audio.play();
//                            sessionStorage.setItem('CurrentNumber', num)
//                        }
//                    }
//                }
//            }
//            else if (selectRow > 30 && selectRow <= 40) {
//                if (selectRow != sessionNumber) {
//                    for (let i = 0; i < row4.cells.length; i++) {
//                        if (row4.cells[i].innerText == randomNumber) {
//                            row4.cells[i].style.backgroundColor = "red";
//                            var audio = new Audio(source);
//                            audio.autoplay = true;
//                            audio.play();
//                            sessionStorage.setItem('CurrentNumber', num)
//                        }
//                    }
//                }
//            }
//            else if (selectRow > 40 && selectRow <= 50) {
//                if (selectRow != sessionNumber) {
//                    for (let i = 0; i < row5.cells.length; i++) {
//                        if (row5.cells[i].innerText == randomNumber) {
//                            row5.cells[i].style.backgroundColor = "red";
//                            var audio = new Audio(source);
//                            audio.autoplay = true;
//                            audio.play();
//                            sessionStorage.setItem('CurrentNumber', num)
//                        }
//                    }
//                }
//            }
//            else if (selectRow > 50 && selectRow <= 60) {
//                if (selectRow != sessionNumber) {
//                    for (let i = 0; i < row6.cells.length; i++) {
//                        if (row6.cells[i].innerText == randomNumber) {
//                            row6.cells[i].style.backgroundColor = "red";
//                            var audio = new Audio(source);
//                            audio.autoplay = true;
//                            audio.play();
//                            sessionStorage.setItem('CurrentNumber', num)
//                        }
//                    }
//                }
//            }
//            else if (selectRow > 60 && selectRow <= 70) {
//                if (selectRow != sessionNumber) {
//                    for (let i = 0; i < row7.cells.length; i++) {
//                        if (row7.cells[i].innerText == randomNumber) {
//                            row7.cells[i].style.backgroundColor = "red";
//                            var audio = new Audio(source);
//                            audio.autoplay = true;
//                            audio.play();
//                            sessionStorage.setItem('CurrentNumber', num)
//                        }
//                    }
//                }
//            }
//            else if (selectRow > 70 && selectRow <= 80) {
//                if (selectRow != sessionNumber) {
//                    for (let i = 0; i < row8.cells.length; i++) {
//                        var test = row8.cells[i].innerText;
//                        if (row8.cells[i].innerText == randomNumber) {
//                            row8.cells[i].style.backgroundColor = "red";
//                            var audio = new Audio(source);
//                            audio.autoplay = true;
//                            audio.play();
//                            sessionStorage.setItem('CurrentNumber', num)
//                        }
//                    }
//                }
//            }
//            else if (selectRow > 80 && selectRow <= 90) {
//                if (selectRow != sessionNumber) {
//                    for (let i = 0; i < row9.cells.length; i++) {
//                        if (row9.cells[i].innerText == randomNumber) {
//                            row9.cells[i].style.backgroundColor = "red";
//                            var audio = new Audio(source);
//                            audio.autoplay = true;
//                            audio.play();
//                            sessionStorage.setItem('CurrentNumber', num)
//                        }
//                    }
//                }
//            }
            
//        }
//    });
//}