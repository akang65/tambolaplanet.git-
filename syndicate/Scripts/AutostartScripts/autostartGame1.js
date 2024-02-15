 
/*No time to optimise hopefully in the future i will do something about it*/
$.connection.hub.disconnected(function () {
    setTimeout(function () {
        $.connection.hub.start();
    }, 5000); // Restart connection after 5 seconds.
});
$.connection.hub.start()
    .done(function () {
        /*$.connection.hub.logging = true;*/
        console.log("connected to Hub");
        //$.connection.myHub2.server.announce("something test");
    });
$.connection.myHub2.client.getdata = function (data) {
    getData(data);

}

function showPanels() {
    document.getElementById("PanelAnnouncement").style.display = "none";
    document.getElementById("PanelRandomGenerated").style.display = "block";
    document.getElementById("PanelTicketControls").style.display = "block";
    document.getElementById("PanelTickets").style.display = "block";
    document.getElementById("PanelWinners").style.display = "block";
    document.getElementById("rsT").style.display = "block";
}
function getarray() {
    sessionStorage.removeItem("CurrentNumber");
    sessionStorage.removeItem("CalledNumbers");
    sessionStorage.removeItem("RandomSequence");
    sessionStorage.removeItem("Tickets");
    sessionStorage.removeItem("pitymewinners");
    $.ajax({
        url: 'AutostartGame.aspx/passArrayToJs',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "POST",
        success: function (data) {
            if (data.d.length > 0) {
                var Array = data.d;
                var jsVariable = $.parseJSON('[' + Array + ']');
                var numbers = jsVariable[0];
                sessionStorage.setItem('RandomSequence', JSON.stringify(numbers));
                var count = numbers.length;
                for (let l = 0; l < count; l++) {
                    var table = document.getElementById("TableRandomNum");
                    //iterate trough rows
                    for (var i = 1, row; row = table.rows[i]; i++) {
                        //iterate trough columns
                        for (var j = 0, col; col = row.cells[j]; j++) {
                            // do something 
                            var tabInnertext = col.innerText;
                            var num = numbers[l];
                            if (tabInnertext == num) {
                                col.style.backgroundColor = "#9B5EED";
                               /* col.style.color = "red";*/
                            }
                        }
                    }
                }
            }
      
        }
    });
}
function populatefields() {
    $.ajax({
        url: 'AutostartGame.aspx/CRandom',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "POST",
        success: function (data) {
    
            if (data.d.length > 0) {
                var Array = data.d;
                var reConstruct = [];
                var obj = $.parseJSON('[' + Array + ']');
                var length = obj[0].length;
                for (let i = 0; i < length; i++) {
                    reConstruct.push(obj[0][i]);
                }
                getData(reConstruct,"PageLoad");
            }
        }
    });
}//hide un-ticked winner table
function hideWinningTable(){
    $.ajax({
        url: 'AutostartGame.aspx/HideWinnerTable',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "POST",
        success: function (data) {
            var fullsheet = document.getElementById("FullSheet");
            var halfsheet = document.getElementById("Halfsheet");
            var quickfive = document.getElementById("QuickFive");
            var quickseven = document.getElementById("QuickSeven");
            var star = document.getElementById("Star");
            var topline = document.getElementById("TopLine");
            var middleline = document.getElementById("MiddleLine");
            var bottomline = document.getElementById("BottomLine");
            var Array = data.d;
            var obj = $.parseJSON('[' + Array + ']');
            if (obj[0][0].fullsheet.replace(/\s+/g, '') == "0") {
                fullsheet.style.display = "none";
                document.getElementById("fs").style.display="none";
            }
            if (obj[0][0].halfsheet.replace(/\s+/g, '') == "0") {
                halfsheet.style.display = "none";
                document.getElementById("hs").style.display = "none";
            }
            if (obj[0][0].quickfive.replace(/\s+/g, '') == "0") {
                quickfive.style.display = "none";
                document.getElementById("qf").style.display = "none";
            }
            if (obj[0][0].quickseven.replace(/\s+/g, '') == "0") {
                quickseven.style.display = "none";
                document.getElementById("qs").style.display = "none";
            }
            if (obj[0][0].star.replace(/\s+/g, '') == "0") {
                star.style.display = "none";
                document.getElementById("s").style.display = "none";
            }
            if (obj[0][0].topLine.replace(/\s+/g, '') == "0") {
                topline.style.display = "none";
                document.getElementById("tl").style.display = "none";
            }
            if (obj[0][0].middleLine.replace(/\s+/g, '') == "0") {
                middleline.style.display = "none";
                document.getElementById("ml").style.display = "none";
            }
            if (obj[0][0].bottomLine.replace(/\s+/g, '') == "0") {
                bottomline.style.display = "none";
                document.getElementById("bl").style.display = "none";
            }
        }
    });
}
function showTable() {
    var textboxField = document.getElementById("TextBoxEnterTicketNo").value;
    var MakeTableID = "GridView" + textboxField;
    var listOftables = [];
    var Tablename = document.getElementById(MakeTableID);
    if (typeof (Tablename) != 'undefined' && Tablename != null) {
        document.getElementById("UpdatePanel1").style = "inherit";
        //Sorry NO *****ng jquery!!
        var CustomerName = Tablename.rows[0].cells[0].innerText;
        if (CustomerName == "Not Booked") {
            Tablename.style.display = "table";
            var UpdateColor = JSON.parse(sessionStorage.getItem("CalledNumbers"));
            var ite = 0;
            do {
                for (var i = 1, row; row = Tablename.rows[i]; i++) {
                    //iterate trough columns
                    for (var j = 0, col; col = row.cells[j]; j++) {
                        // do something 
                        var tabInnertext = col.innerText;
                        if (tabInnertext == "0") {
                            col.innerText = "";
                        } else if (UpdateColor != null && tabInnertext == UpdateColor[ite]) {
                            if (col.innerText != "" && col.innerText != '0') {
                                col.style.backgroundColor = "#fd7e14";
                            }
                        }
                    }
                }
                ite++;
            }
            while (UpdateColor != null && UpdateColor.length > ite);
            //update to session
            if (sessionStorage.getItem('Tickets') == null) {
                var Vticket = [MakeTableID];
                sessionStorage.setItem('Tickets', JSON.stringify(Vticket));
            } else if (sessionStorage.getItem('Tickets') != null) {
                var VisibleTickets = JSON.parse(sessionStorage.getItem("Tickets"));
                if (VisibleTickets.includes(MakeTableID) != true) {
                    var length = VisibleTickets.length;
                    VisibleTickets[length] = MakeTableID;
                    sessionStorage.setItem('Tickets', JSON.stringify(VisibleTickets));
                }    
            }
            
        } else {
            //check all tables with same Name
            for (let l = 1; l <= 840; l++) {
                var MaketableId = "GridView" + l
                var tablename = document.getElementById(MaketableId);
                if (typeof (tablename) != 'undefined' && tablename != null) {
                    var name = tablename.rows[0].cells[0].innerText;
                    if (name != "Not Booked" && name == CustomerName) {
                        listOftables.push(MaketableId); //<--- new
                        tablename.style.display = "table";

                        var UpdateColor = JSON.parse(sessionStorage.getItem("CalledNumbers"));
                        var ite = 0;
                        do {
                            for (var i = 1, row; row = tablename.rows[i]; i++) {
                                //iterate trough columns
                                for (var j = 0, col; col = row.cells[j]; j++) {
                                    // do something 
                                    var tabInnertext = col.innerText;
                                    if (tabInnertext == "0") {
                                        col.innerText = "";
                                    } else if (UpdateColor != null && tabInnertext == UpdateColor[ite]) {
                                        if (col.innerText != "" && col.innerText != '0') {
                                            col.style.backgroundColor = "#fd7e14";
                                        }
                                    }
                                }
                            }
                            ite++;
                        }
                        while (UpdateColor != null && UpdateColor.length > ite);
                    }
                }
            }
            //update to session
            if (sessionStorage.getItem('Tickets') == null) {
                var Vticket = listOftables;
                sessionStorage.setItem('Tickets', JSON.stringify(Vticket));
            } else if (sessionStorage.getItem('Tickets') != null) {
                var VisibleTickets = JSON.parse(sessionStorage.getItem("Tickets"));
                var BuildArray = VisibleTickets.concat(listOftables);
                BuildArray = BuildArray.filter((item, index) => {
                    return (BuildArray.indexOf(item) == index)
                })
                sessionStorage.setItem('Tickets', JSON.stringify(BuildArray));
            }
        }
        var textboxField = document.getElementById("TextBoxEnterTicketNo").value="";
    } else {
        alert('Invalid Ticket Number');
    }
}
//hide all Table
function hideAllTable() {
    var panel = document.getElementById("UpdatePanel1");
    panel.style.display = "none";
    var VisibleTickets = JSON.parse(sessionStorage.getItem("Tickets"));
    for (let i = 0; i < VisibleTickets.length; i++) {
        document.getElementById(VisibleTickets[i]).style.display="none";
    }
    sessionStorage.removeItem('Tickets');
    //sessionStorage.removeItem('Tickets');
    //for (var k = 1; k < 840; k++) {
    //    var tablename = document.getElementById("GridView" + k);
    //    if (typeof (tablename) != 'undefined' && tablename != null) {
    //        tablename.style.display = "none";
    //    }
        
    //}
}


/* Hide Ticket Method*/
function HideButtonsTicket(Tprefix, bId) {
    var tablename = document.getElementById(Tprefix + bId);
    tablename.style.display = "none";
}



function getData(data,status) {
    var row1 = document.getElementById("TableRandomNum").rows[1];
    var row2 = document.getElementById("TableRandomNum").rows[2];
    var row3 = document.getElementById("TableRandomNum").rows[3];
    var row4 = document.getElementById("TableRandomNum").rows[4];
    var row5 = document.getElementById("TableRandomNum").rows[5];
    var row6 = document.getElementById("TableRandomNum").rows[6];
    var row7 = document.getElementById("TableRandomNum").rows[7];
    var row8 = document.getElementById("TableRandomNum").rows[8];
    var row9 = document.getElementById("TableRandomNum").rows[9];
    var fullhouse = document.getElementById("FullHouse");
    var fullsheet = document.getElementById("FullSheet");
    var halfsheet = document.getElementById("Halfsheet");
    var quickfive = document.getElementById("QuickFive");
    var quickseven = document.getElementById("QuickSeven");
    var star = document.getElementById("Star");
    var topline = document.getElementById("TopLine");
    var middleline = document.getElementById("MiddleLine");
    var bottomline = document.getElementById("BottomLine");
    var count = row1.cells.length;

    if (data.length > 0) {
        var newdata = data;

        var countlength = newdata.length;
        var randomNumber = newdata[countlength - 1].CurrentRandom;
        var num = '' + randomNumber;
        var AudioName = num + '.mp3';
        var source = '../Audio/' + AudioName;
        var selectRow = randomNumber;

        //if (sessionStorage.getItem('CurrentNumber') != null) {
        //    /*sessionStorage.setItem('CurrentNumber', '0')*/
        //}

        var sessionNumber = parseInt(sessionStorage.getItem('CurrentNumber'));
        /* Random Table Update*/
        if (selectRow > 0 && selectRow <= 10) {
            if (selectRow != sessionNumber) {
                for (let i = 0; i < row1.cells.length; i++) {
                    if (row1.cells[i].innerText == randomNumber) {
                        row1.cells[i].style.backgroundColor = "#9B5EED";
                        if (status != "PageLoad") {
                            var audio = new Audio(source);
                            audio.autoplay = true;
                            audio.play();
                        }
                        sessionStorage.setItem('CurrentNumber', num)
                    }
                }
            }
        }
        else if (selectRow > 10 && selectRow <= 20) {
            if (selectRow != sessionNumber) {
                for (let i = 0; i < row2.cells.length; i++) {
                    if (row2.cells[i].innerText == randomNumber) {
                        row2.cells[i].style.backgroundColor = "#9B5EED";
                        if (status != "PageLoad") {
                            var audio = new Audio(source);
                            audio.autoplay = true;
                            audio.play();
                        }
                        sessionStorage.setItem('CurrentNumber', num)
                    }
                }
            }
            
        }
        else if (selectRow > 20 && selectRow <= 30) {
            if (selectRow != sessionNumber) {
                for (let i = 0; i < row3.cells.length; i++) {
                    if (row3.cells[i].innerText == randomNumber) {
                        row3.cells[i].style.backgroundColor = "#9B5EED";
                        if (status != "PageLoad") {
                            var audio = new Audio(source);
                            audio.autoplay = true;
                            audio.play();
                        }
                        sessionStorage.setItem('CurrentNumber', num)
                    }
                }
            }
            
        }
        else if (selectRow > 30 && selectRow <= 40) {
            if (selectRow != sessionNumber) {
                for (let i = 0; i < row4.cells.length; i++) {
                    if (row4.cells[i].innerText == randomNumber) {
                        row4.cells[i].style.backgroundColor = "#9B5EED";
                        if (status != "PageLoad") {
                            var audio = new Audio(source);
                            audio.autoplay = true;
                            audio.play();
                        }
                        sessionStorage.setItem('CurrentNumber', num)
                    }
                }
            }
            
        }
        else if (selectRow > 40 && selectRow <= 50) {
            if (selectRow != sessionNumber) {
                for (let i = 0; i < row5.cells.length; i++) {
                    if (row5.cells[i].innerText == randomNumber) {
                        row5.cells[i].style.backgroundColor = "#9B5EED";
                        if (status != "PageLoad") {
                            var audio = new Audio(source);
                            audio.autoplay = true;
                            audio.play();
                        }
                        sessionStorage.setItem('CurrentNumber', num)
                    }
                }
            }
            
        }
        else if (selectRow > 50 && selectRow <= 60) {
            if (selectRow != sessionNumber) {
                for (let i = 0; i < row6.cells.length; i++) {
                    if (row6.cells[i].innerText == randomNumber) {
                        row6.cells[i].style.backgroundColor = "#9B5EED";
                        if (status != "PageLoad") {
                            var audio = new Audio(source);
                            audio.autoplay = true;
                            audio.play();
                        }
                        sessionStorage.setItem('CurrentNumber', num)
                    }
                }
            }
            
        }
        else if (selectRow > 60 && selectRow <= 70) {
            if (selectRow != sessionNumber) {
                for (let i = 0; i < row7.cells.length; i++) {
                    if (row7.cells[i].innerText == randomNumber) {
                        row7.cells[i].style.backgroundColor = "#9B5EED";
                        if (status != "PageLoad") {
                            var audio = new Audio(source);
                            audio.autoplay = true;
                            audio.play();
                        }
                        sessionStorage.setItem('CurrentNumber', num)
                    }
                }
            }
            
        }
        else if (selectRow > 70 && selectRow <= 80) {
            if (selectRow != sessionNumber) {
                for (let i = 0; i < row8.cells.length; i++) {
                    var test = row8.cells[i].innerText;
                    if (row8.cells[i].innerText == randomNumber) {
                        row8.cells[i].style.backgroundColor = "#9B5EED";
                        if (status != "PageLoad") {
                            var audio = new Audio(source);
                            audio.autoplay = true;
                            audio.play();
                        }
                        sessionStorage.setItem('CurrentNumber', num)
                    }
                }
            }
            
        }
        else if (selectRow > 80 && selectRow <= 90) {
            if (selectRow != sessionNumber) {
                for (let i = 0; i < row9.cells.length; i++) {
                    if (row9.cells[i].innerText == randomNumber) {
                        row9.cells[i].style.backgroundColor = "#9B5EED";
                        if (status != "PageLoad") {
                            var audio = new Audio(source);
                            audio.autoplay = true;
                            audio.play();
                        }
                        sessionStorage.setItem('CurrentNumber', num)
                    }
                }
            }
            
        }
        if (sessionStorage.getItem('CalledNumbers') == null) {
            var CalledNumbers = [selectRow];
            sessionStorage.setItem('CalledNumbers', JSON.stringify(CalledNumbers));
        } else if (sessionStorage.getItem('CalledNumbers') != null) {
            var CalledNumbers = JSON.parse(sessionStorage.getItem("CalledNumbers"));
            if (CalledNumbers.includes(selectRow) != true) {
                var len = CalledNumbers.length;
                CalledNumbers[len] = selectRow;
                sessionStorage.setItem('CalledNumbers', JSON.stringify(CalledNumbers));
            }
        }
        for (var w = 0; w < countlength; w++) {
            if (newdata[w].WinningName == 'FULLHOUSE') {
                // $("#FullHouse").find("tr:gt(0)").remove();
                var Temp = "";
                var Place = "";
                for (let loop = 0; loop < countlength; loop++) {
                    if (newdata[loop].WinningName == "FULLHOUSE" && (Temp != newdata[loop].Name || newdata[loop] !== Place)) {
                        Temp = newdata[loop].Name;
                        Place = newdata[loop].Place;

                        var name = newdata[loop].CustomerName;
                        var TNumber = newdata[loop].TicketNumber.replace("TicketNo", "");
                        var name_tk = "Ticket No:" + TNumber + " (By " + name + " )";

                        var tableIteration = document.getElementById("FullHouse");
                        for (var i = 0, row; row = tableIteration.rows[i]; i++) {
                            var constructRowId = "Fh_TableId_" + TNumber;
                            var rowID = document.getElementById(constructRowId);
                            if (rowID == null || rowID == undefined) {
                                var row = fullhouse.insertRow(-1);

                                var innertable = document.createElement('table');
                                innertable.id = "Fh_TableId_" + TNumber;
                                innertable.className = "table table-sm table-borderless p-0 m-0"
                                var body = document.createElement('tbody');

                                innertable.appendChild(body);
                                row.appendChild(innertable);

                                var rowNameplace = innertable.insertRow(-1);
                                var rowNameT = innertable.insertRow(-1);
                                var rowbtncell = innertable.insertRow(-1);
                                var rowTicket = innertable.insertRow(-1);
                                rowTicket.id = "fhw" + loop;


                                var cellplaceName = rowNameplace.insertCell(0);
                                var cellNameT = rowNameT.insertCell(0);
                                cellNameT.className = "p-0 m-0";
                                var nam = document.createElement('span');
                                let sup = "th";
                                if (Place == "1") {
                                    sup = "st"
                                } else if (Place == "2") {
                                    sup = "nd"
                                } else if (Place == "3") {
                                    sup = "rd"
                                }
                                cellplaceName.innerHTML = Place + sup.sup() + " FullHouse";
                                cellplaceName.className = "text-light p-0 m-0";
                                nam.innerText = name_tk;
                                nam.className = "btn-block-xl rounded-pill bg-light text-dark box";
                                cellNameT.appendChild(nam);


                                var cellBtn = rowbtncell.insertCell(0);
                                var btn = document.createElement('input');
                                btn.type = "button";
                                btn.className = " btn-block-xl rounded-pill text-light";
                                btn.value = "view";
                                btn.id = "FullHouse" + loop;
                                cellBtn.appendChild(btn);
                                btn.onclick = function () { ViewFullHouseWinners(newdata[loop].TicketNumber, "fhw" + loop) };
                            }

                        }
                    }
                }
            }
            else if (newdata[w].WinningName == 'FULLSHEET') {
                if (checkwinnersSession('FULLSHEET') == false) {
                    /*   $("#FullSheet").find("tr:gt(0)").remove();*/
                    var Temp = "";
                    var names = [];
                    for (let loop = 0; loop < countlength; loop++) {
                        if (newdata[loop].WinningName == "FULLSHEET" && Temp != newdata[loop].CustomerName) {
                            if (names.includes(newdata[loop].CustomerName) != true) {
                                Temp = newdata[loop].Name;
                                names.push(newdata[loop].CustomerName);
                                var Fullsheet = document.getElementById("FullSheet");

                                var row = Fullsheet.insertRow(-1);

                                var innertable = document.createElement('table');
                                innertable.className = "table table-sm  table-borderless p-0 m-0"
                                var body = document.createElement('tbody');

                                innertable.appendChild(body);
                                row.appendChild(innertable);

                                var rowNameT = innertable.insertRow(-1);
                                var rowbtncell = innertable.insertRow(-1);
                                var rowTicket = innertable.insertRow(-1);
                                rowTicket.id = "fsw" + loop;

                                var cellNameT = rowNameT.insertCell(0);
                                cellNameT.className = "p-0 m-0";
                                var nam = document.createElement('span');

                                nam.innerText = "Sheet No:" + newdata[loop].TicketNumber + " ( By " + newdata[loop].CustomerName + " )";
                                nam.className = "btn-block-xl rounded-pill bg-light text-dark";
                                cellNameT.appendChild(nam);

                                var btncell = rowbtncell.insertCell(0);
                                var btn = document.createElement('input');
                                btn.type = "button";
                                btn.className = " btn btn-xs-long rounded-pill bg-success text-light";
                                btn.value = "view";
                                btn.id = "fullsheet" + loop;
                                btncell.appendChild(btn);
                                btn.onclick = function () { ViewSheetWinners(newdata[loop].TicketNumber, "fs", "fsw" + loop) };
                            }
                        }
                    }
                }
            }
            else if (newdata[w].WinningName == 'HALFSHEET') {
                if (checkwinnersSession('HALFSHEET') == false) {
                    /*$("#Halfsheet").find("tr:gt(0)").remove();*/
                    var Temp = "";
                    var names = [];
                    for (let loop = 0; loop < countlength; loop++) {
                        if (newdata[loop].WinningName == "HALFSHEET" && Temp != newdata[loop].CustomerName) {
                            if (names.includes(newdata[loop].CustomerName) != true) {
                                Temp = newdata[loop].CustomerName;
                                names.push(newdata[loop].CustomerName);
                                var Halfsheet = document.getElementById("Halfsheet");
                                var row = Halfsheet.insertRow(-1);

                                var innertable = document.createElement('table');
                                innertable.className = "table table-sm  table-borderless p-0 m-0"
                                var body = document.createElement('tbody');

                                innertable.appendChild(body);
                                row.appendChild(innertable);

                                var rowNameT = innertable.insertRow(-1);
                                var rowbtncell = innertable.insertRow(-1);
                                var rowTicket = innertable.insertRow(-1);
                                rowTicket.id = "hsw" + loop;

                                var cellNameT = rowNameT.insertCell(0);
                                cellNameT.className = "p-0 m-0";
                                var nam = document.createElement('span');

                                nam.innerText = "Sheet No:" + newdata[loop].TicketNumber + " ( By " + newdata[loop].CustomerName + " )";
                                nam.className = "btn-block-xl rounded-pill bg-light text-dark";
                                cellNameT.appendChild(nam);

                                var btncell = rowbtncell.insertCell(0);
                                var btn = document.createElement('input');
                                btn.type = "button";
                                btn.className = " btn btn-xs-long rounded-pill bg-success text-light";
                                btn.value = "view";
                                btn.id = "halfsheet" + loop;
                                btncell.appendChild(btn);
                                btn.onclick = function () { ViewSheetWinners(newdata[loop].TicketNumber, "hs", "hsw" + loop) };
                            }

                        }
                    }
                }
            }
            else if (newdata[w].WinningName == 'FIRSTFIVE') {
                if (checkwinnersSession('FIRSTFIVE') == false) {
                    /*$("#QuickFive").find("tr:gt(0)").remove();*/
                    for (let loop = 0; loop < countlength; loop++) {
                        if (newdata[loop].WinningName == "FIRSTFIVE") {
                            var row = quickfive.insertRow(-1);
                            var innertable = document.createElement('table');
                            innertable.className = "table table-sm table-borderless p-0 m-0"
                            var body = document.createElement('tbody');

                            innertable.appendChild(body);
                            row.appendChild(innertable);

                            var rowNameT = innertable.insertRow(-1);
                            var rowbtncell = innertable.insertRow(-1);
                            var rowTicket = innertable.insertRow(-1);
                            rowTicket.id = "ffw" + loop;

                            var cellNameT = rowNameT.insertCell(0);
                            cellNameT.className = "p-0 m-0";
                            var nam = document.createElement('span');

                            nam.innerText = "Ticket No:" + newdata[loop].TicketNumber.replace("TicketNo", "") + " ( By " + newdata[loop].CustomerName + " )";
                            nam.className = "btn-block-xl rounded-pill bg-light text-dark";
                            cellNameT.appendChild(nam);


                            var btncell = rowbtncell.insertCell(0);
                            var btn = document.createElement('input');
                            btn.type = "button";
                            btn.className = " btn btn-xs-long rounded-pill bg-success text-light";
                            btn.value = "view";
                            btn.id = "quickfive" + loop;
                            btncell.appendChild(btn);
                            btn.onclick = function () { ViewWinners(newdata[loop].TicketNumber, "ff", "ffw" + loop) };
                        }
                    }
                }
            }
            else if (newdata[w].WinningName == 'FIRSTSEVEN') {
                /*$("#QuickSeven").find("tr:gt(0)").remove();*/
                if (checkwinnersSession('FIRSTSEVEN') == false) {
                    for (let loop = 0; loop < countlength; loop++) {
                        if (newdata[loop].WinningName == "FIRSTSEVEN") {
                            var row = quickseven.insertRow(-1);
                            var innertable = document.createElement('table');
                            innertable.className = "table table-sm  table-borderless p-0 m-0"
                            var body = document.createElement('tbody');

                            innertable.appendChild(body);
                            row.appendChild(innertable);

                            var rowNameT = innertable.insertRow(-1);
                            var rowbtncell = innertable.insertRow(-1);
                            var rowTicket = innertable.insertRow(-1);
                            rowTicket.id = "fsw" + loop;

                            var cellNameT = rowNameT.insertCell(0);
                            cellNameT.className = "p-0 m-0";
                            var nam = document.createElement('span');

                            nam.innerText = "Ticket No:" + newdata[loop].TicketNumber.replace("TicketNo", "") + " ( By " + newdata[loop].CustomerName + " )";
                            nam.className = "btn-block-xl rounded-pill bg-light text-dark";
                            cellNameT.appendChild(nam);

                            var btncell = rowbtncell.insertCell(0);
                            var btn = document.createElement('input');
                            btn.type = "button";
                            btn.className = " btn btn-xs-long rounded-pill bg-success text-light";
                            btn.value = "view";
                            btn.id = "quickseven" + loop;
                            btncell.appendChild(btn);
                            btn.onclick = function () { ViewWinners(newdata[loop].TicketNumber, "fs", "fsw" + loop) };
                        }
                    }
                }
            }
            else if (newdata[w].WinningName == 'STAR') {
                /*   $("#Star").find("tr:gt(0)").remove();*/
                if (checkwinnersSession('STAR') == false) {
                    for (let loop = 0; loop < countlength; loop++) {
                        if (newdata[loop].WinningName == "STAR") {
                            var row = star.insertRow(-1);
                            var innertable = document.createElement('table');
                            innertable.className = "table table-sm  table-borderless p-0 m-0"
                            var body = document.createElement('tbody');

                            innertable.appendChild(body);
                            row.appendChild(innertable);

                            var rowNameT = innertable.insertRow(-1);
                            var rowbtncell = innertable.insertRow(-1);
                            var rowTicket = innertable.insertRow(-1);
                            rowTicket.id = "sw" + loop;

                            var cellNameT = rowNameT.insertCell(0);
                            cellNameT.className = "p-0 m-0";
                            var nam = document.createElement('span');

                            nam.innerText = "Ticket No:" + newdata[loop].TicketNumber.replace("TicketNo", "") + " ( By " + newdata[loop].CustomerName + " )";
                            nam.className = "btn-block-xl rounded-pill bg-light text-dark";
                            cellNameT.appendChild(nam);

                            var btncell = rowbtncell.insertCell(0);
                            var btn = document.createElement('input');
                            btn.type = "button";
                            btn.className = " btn btn-xs-long rounded-pill bg-success text-light";
                            btn.value = "view";
                            btn.id = "star" + loop;
                            btncell.appendChild(btn);

                            btn.onclick = function () { ViewWinners(newdata[loop].TicketNumber, "s", "sw" + loop) };
                        }
                    }
                }
            }
            else if (newdata[w].WinningName == 'TOPLINE') {
                if (checkwinnersSession('TOPLINE') == false) {
                    /*$("#TopLine").find("tr:gt(0)").remove();*/
                    for (let loop = 0; loop < countlength; loop++) {
                        if (newdata[loop].WinningName == "TOPLINE") {
                            var row = topline.insertRow(-1);
                            var innertable = document.createElement('table');
                            innertable.className = "table table-sm  table-borderless p-0 m-0"
                            var body = document.createElement('tbody');

                            innertable.appendChild(body);
                            row.appendChild(innertable);

                            var rowNameT = innertable.insertRow(-1);
                            var rowbtncell = innertable.insertRow(-1);
                            var rowTicket = innertable.insertRow(-1);
                            rowTicket.id = "tlw" + loop;

                            var cellNameT = rowNameT.insertCell(0);
                            cellNameT.className = "p-0 m-0";
                            var nam = document.createElement('span');

                            nam.innerText = "Ticket No:" + newdata[loop].TicketNumber.replace("TicketNo", "") + " ( By " + newdata[loop].CustomerName + " )";
                            nam.className = "btn-block-xl rounded-pill bg-light text-dark";
                            cellNameT.appendChild(nam);

                            var btncell = rowbtncell.insertCell(0);
                            var btn = document.createElement('input');
                            btn.type = "button";
                            btn.className = " btn btn-xs-long rounded-pill bg-success text-light";
                            btn.value = "view";
                            btn.id = "topline" + loop;
                            btncell.appendChild(btn);

                            btn.onclick = function () { ViewWinners(newdata[loop].TicketNumber, "tl", "tlw" + loop) };
                        }
                    }
                }
            }
            else if (newdata[w].WinningName == 'MIDDLELINE') {
                if (checkwinnersSession('MIDDLELINE') == false) {
                    /*  $("#MiddleLine").find("tr:gt(0)").remove();*/
                    for (let loop = 0; loop < countlength; loop++) {
                        if (newdata[loop].WinningName == "MIDDLELINE") {
                            var row = middleline.insertRow(-1);
                            var innertable = document.createElement('table');
                            innertable.className = "table table-sm  table-borderless p-0 m-0"
                            var body = document.createElement('tbody');

                            innertable.appendChild(body);
                            row.appendChild(innertable);

                            var rowNameT = innertable.insertRow(-1);
                            var rowbtncell = innertable.insertRow(-1);
                            var rowTicket = innertable.insertRow(-1);
                            rowTicket.id = "mlw" + loop;

                            var cellNameT = rowNameT.insertCell(0);
                            cellNameT.className = "p-0 m-0";
                            var nam = document.createElement('span');

                            nam.innerText = "Ticket No:" + newdata[loop].TicketNumber.replace("TicketNo", "") + " ( By " + newdata[loop].CustomerName + " )";
                            nam.className = "btn-block-xl rounded-pill bg-light text-dark";
                            cellNameT.appendChild(nam);

                            var btncell = rowbtncell.insertCell(0);
                            var btn = document.createElement('input');
                            btn.type = "button";
                            btn.className = " btn btn-xs-long rounded-pill bg-success text-light";
                            btn.value = "view";
                            btn.id = "middleLine" + loop;
                            btncell.appendChild(btn);

                            btn.onclick = function () { ViewWinners(newdata[loop].TicketNumber, "ml", "mlw" + loop) };
                        }
                    }
                }
            }
            else if (newdata[w].WinningName == 'BOTTOMLINE') {
                /*$("#BottomLine").find("tr:gt(0)").remove();*/
                if (checkwinnersSession('BOTTOMLINE') == false) {
                    for (let loop = 0; loop < countlength; loop++) {
                        if (newdata[loop].WinningName == "BOTTOMLINE") {
                            var row = bottomline.insertRow(-1);
                            var innertable = document.createElement('table');
                            innertable.className = "table table-sm  table-borderless p-0 m-0"
                            var body = document.createElement('tbody');

                            innertable.appendChild(body);
                            row.appendChild(innertable);

                            var rowNameT = innertable.insertRow(-1);
                            var rowbtncell = innertable.insertRow(-1);
                            var rowTicket = innertable.insertRow(-1);
                            rowTicket.id = "blw" + loop;

                            var cellNameT = rowNameT.insertCell(0);
                            cellNameT.className = "p-0 m-0";
                            var nam = document.createElement('span');

                            nam.innerText = "Ticket No:" + newdata[loop].TicketNumber.replace("TicketNo", "") + " ( By " + newdata[loop].CustomerName + " )";
                            nam.className = "btn-block-xl rounded-pill bg-light text-dark";
                            cellNameT.appendChild(nam);

                            var btncell = rowbtncell.insertCell(0);
                            var btn = document.createElement('input');
                            btn.type = "button";
                            btn.className = " btn btn-xs-long rounded-pill bg-success text-light";
                            btn.value = "view";
                            btn.id = "bottomline" + loop;
                            btncell.appendChild(btn);

                            btn.onclick = function () { ViewWinners(newdata[loop].TicketNumber, "bl", "blw" + loop) };
                        }
                    }
                }
            }
        }
        //end of Winner

        //Create Random Sequence Table
        var CalledNumbers = JSON.parse(sessionStorage.getItem("CalledNumbers"));
        var RandomSequence = JSON.parse(sessionStorage.getItem("RandomSequence"));
        let RandomLength = RandomSequence.length;
        for (let add = 0; add < CalledNumbers.length; add++) {
            if (RandomSequence.includes(CalledNumbers[add]) != true) {
                RandomSequence[RandomLength] = CalledNumbers[add];
                sessionStorage.setItem('RandomSequence', JSON.stringify(RandomSequence));
                RandomLength++;
            }
        }
        var tableID = document.getElementById('RandomSequenceTable');
        $("#rsTable").remove();
        const tbl = document.createElement("table");
        tbl.setAttribute("id", "rsTable")
        const tblBody = document.createElement("tbody");
        let Totallength = RandomSequence.length;
        let TotalRows = Math.floor(Totallength / 10); // 22/10=2
        let remainingRows = TotalRows + 1;
        for (let z = 1; z <= remainingRows; z++) {
            let numIndex = z * 10;//1*10=10; 2*10=20;
            numIndex -= 10; //10-10=0; 20-10=10;
            const row = document.createElement("tr");
            for (let y = 0; y < 10; y++) {
                const cell = document.createElement("td");
                let index = numIndex + y; //10+0=10; 
                if (RandomSequence[index] == undefined) {
                    const cellText = document.createTextNode("");
                    cell.appendChild(cellText);
                    cell.setAttribute("class", "badge bg-success rounded-pill");
                    row.appendChild(cell);
                } else {
                    var num = RandomSequence[index];
                    if (num <= 9 && num>=1) {
                        num = "0" + num;
                    } 
                    const cellText = document.createTextNode(num);
                    
                    cell.appendChild(cellText);
                    cell.setAttribute("class", "badge bg-success rounded-pill");
                    row.appendChild(cell);
                }

            }
            tblBody.appendChild(row);
        }
        tbl.appendChild(tblBody);
        document.body.appendChild(tbl);
        tbl.setAttribute("class", "table");
        tableID.appendChild(tbl);



        // Update Ticket color
        if (sessionStorage.getItem('Tickets') != null) {
            var VisibleTickets = JSON.parse(sessionStorage.getItem("Tickets"));
            for (let v = 0; v < VisibleTickets.length; v++) {
                var TicketName = VisibleTickets[v];
                var TableName = document.getElementById(TicketName);
                for (var i = 1, row; row = TableName.rows[i]; i++) {
                    for (var j = 0, col; col = row.cells[j]; j++) {
                        if (col.innerText == selectRow) {
                            col.style.backgroundColor = "#fd7e14";
                        }
                    }
                }
            }
        }

        //Announce Winners
        if (newdata.length >= 1) {
            var length = newdata.length;
            var winningNames = [];
            let count = 0;
            for (let n = 0; n < length; n++) {
                if (newdata[n].CurrentRandom == newdata[length - 1].CurrentRandom) {

                    if (newdata[n].WinningName == "HALFSHEET") {
                        winningNames[count] = "Half Sheet";
                        n += 2;
                        count++;
                    }
                    else if (newdata[n].WinningName == "FULLSHEET") {
                        winningNames[count] = "Full Sheet";
                        n += 5;
                        count++;
                    }
                    else if (newdata[n].WinningName == "TOPLINE") {
                        winningNames[count] = "Top line";
                        count++;
                    } else if (newdata[n].WinningName == "MIDDLELINE") {
                        winningNames[count] = "Middle line";
                        count++;
                    } else if (newdata[n].WinningName == "BOTTOMLINE") {
                        winningNames[count] = "Bottom Line";
                        count++;
                    } else if (newdata[n].WinningName == "STAR") {
                        winningNames[count] = "Star";
                        count++;
                    } else if (newdata[n].WinningName == "FIRSTFIVE") {
                        winningNames[count] = "Quick Five";
                        count++;
                    } else if (newdata[n].WinningName == "FIRSTSEVEN") {
                        winningNames[count] = "Quick Seven";
                        count++;
                    } else if (newdata[n].WinningName == "FULLHOUSE") {
                        winningNames[count] = "Full House";
                        count++;
                    } else if (newdata[n].WinningName == "Default") {
                        winningNames[count] = "Default";
                        count++;
                    } else if (newdata[n].WinningName == "GameOver") {
                        winningNames[count] = "GameOver";
                        count++;
                    }

                }
            }
            speak(winningNames, newdata, status);
        }
        /*}*/
    }
}

function speak(message, datas, status) {
    if (status != "PageLoad") {
        var checkSameValue = "";
        let totalW = 0;
        for (let c = 0; c < message.length; c++) {
            if (checkSameValue != message[c]) {
                checkSameValue = message[c];
                totalW++;
            }
        }
        var random = datas[datas.length - 1].CurrentRandom;
        var speech = new SpeechSynthesisUtterance();
        if (message != null && message[0] != "Default") {
            var stringMsg = "";
            if (message.length == 1 && message[0] == "GameOver") {
                stringMsg = "Game over!. Congratulations to all the winners. see you in the next Game";
            } else if (totalW == 1) {
                var array = [];
                var ticketno = [];
                var temp = "";
                var ticket = "";
                var Wplace = "";
                for (let n = 0; n < datas.length; n++) {
                    if (datas[n].CurrentRandom == random) {
                        if ((temp != datas[n].WinningName && ticket != datas[n].TicketNumber) || datas[n].Place != Wplace) {
                            temp = datas[n].WinningName;
                            ticket = datas[n].TicketNumber;
                            var remove = ticket;
                            var newS = remove.replace("TicketNo", "");
                            ticketno.push(newS);
                            array.push(temp);
                        }
                    }
                }
                if (array.length == 1) {
                    if (message[0] == "Full Sheet" || message[0] == "Half Sheet") {
                        stringMsg = "we have a new " + message[0] + " winner with Sheet number " + ticketno[0];
                    } else if (message[0] == "Full House") {
                        if (datas[datas.length - 1].Place == "1") {
                            stringMsg = "we have a First " + message[0] + " winner with Ticket Number " + ticketno[0];
                        } else if (datas[datas.length - 1].Place == "2") {
                            stringMsg = "we have a second " + message[0] + " winner with Ticket Number " + ticketno[0];
                        }
                        else if (datas[datas.length - 1].Place == "3") {
                            stringMsg = "we have a third " + message[0] + " winner with Ticket Number " + ticketno[0];
                        }
                        else if (datas[datas.length - 1].Place == "4") {
                            stringMsg = "we have a fourth " + message[0] + " winner with Ticket Number " + ticketno[0];
                        }
                        else if (datas[datas.length - 1].Place == "5") {
                            stringMsg = "we have a fifth " + message[0] + " winner with Ticket Number " + ticketno[0];
                        }
                        else if (datas[datas.length - 1].Place == "6") {
                            stringMsg = "we have a sixth " + message[0] + " winner with Ticket Number " + ticketno[0];
                        }
                        else if (datas[datas.length - 1].Place == "7") {
                            stringMsg = "we have a seventh " + message[0] + " winner with Ticket Number " + ticketno[0];
                        }
                        else if (datas[datas.length - 1].Place == "8") {
                            stringMsg = "we have a eighth " + message[0] + " winner with Ticket Number " + ticketno[0];
                        }
                        else if (datas[datas.length - 1].Place == "9") {
                            stringMsg = "we have a ninth " + message[0] + " winner with Ticket Number " + ticketno[0];
                        }
                        else if (datas[datas.length - 1].Place == "10") {
                            stringMsg = "we have a tenth " + message[0] + " winner with Ticket Number " + ticketno[0];
                        }
                        else if (datas[datas.length - 1].Place == "11") {
                            stringMsg = "we have a eleventh " + message[0] + " winner with Ticket Number " + ticketno[0];
                        }
                        else if (datas[datas.length - 1].Place == "12") {
                            stringMsg = "we have a twelfth " + message[0] + " winner with Ticket Number " + ticketno[0];
                        }

                    } else {
                        stringMsg = "we have a new " + message[0] + " winner with ticket number " + ticketno[0];
                    }

                } else if (array.length == 2) {
                    if (message[0] == "Full Sheet" || message[0] == "Half Sheet") {
                        stringMsg = "we have a new " + message[0] + " winners with Sheet number " + ticketno[0] + " and " + "  sheet number " + ticketno[1];
                    } else if (message[0] == "Full House") {
                        if (datas[datas.length - 1].Place == "1") {
                            stringMsg = "we have a First " + message[0] + " winner with Ticket Number " + ticketno[0] + " and ticket number " + ticketno[1];
                        } else if (datas[datas.length - 1].Place == "2") {
                            stringMsg = "we have a second " + message[0] + " winner with Ticket Number " + ticketno[0] + " and ticket number " + ticketno[1];
                        }
                        else if (datas[datas.length - 1].Place == "3") {
                            stringMsg = "we have a third " + message[0] + " winner with Ticket Number " + ticketno[0] + " and ticket number " + ticketno[1];
                        }
                        else if (datas[datas.length - 1].Place == "4") {
                            stringMsg = "we have a fourth " + message[0] + " winner with Ticket Number " + ticketno[0] + " and ticket number " + ticketno[1];
                        }
                        else if (datas[datas.length - 1].Place == "5") {
                            stringMsg = "we have a fifth " + message[0] + " winner with Ticket Number " + ticketno[0] + " and ticket number " + ticketno[1];
                        }
                        else if (datas[datas.length - 1].Place == "6") {
                            stringMsg = "we have a sixth " + message[0] + " winner with Ticket Number " + ticketno[0] + " and ticket number " + ticketno[1];
                        }
                        else if (datas[datas.length - 1].Place == "7") {
                            stringMsg = "we have a seventh " + message[0] + " winner with Ticket Number " + ticketno[0] + " and ticket number " + ticketno[1];
                        }
                        else if (datas[datas.length - 1].Place == "8") {
                            stringMsg = "we have a eighth " + message[0] + " winner with Ticket Number " + ticketno[0] + " and ticket number " + ticketno[1];
                        }
                        else if (datas[datas.length - 1].Place == "9") {
                            stringMsg = "we have a ninth " + message[0] + " winner with Ticket Number " + ticketno[0] + " and ticket number " + ticketno[1];
                        }
                        else if (datas[datas.length - 1].Place == "10") {
                            stringMsg = "we have a tenth " + message[0] + " winner with Ticket Number " + ticketno[0] + " and ticket number " + ticketno[1];
                        }
                        else if (datas[datas.length - 1].Place == "11") {
                            stringMsg = "we have a eleventh " + message[0] + " winner with Ticket Number " + ticketno[0] + " and ticket number " + ticketno[1];
                        }
                        else if (datas[datas.length - 1].Place == "12") {
                            stringMsg = "we have a twelfth " + message[0] + " winner with Ticket Number " + ticketno[0] + " and ticket number " + ticketno[1];
                        }
                    } else {
                        stringMsg = "we have a new " + message[0] + " winners with ticket number " + ticketno[0] + " and ticket number " + ticketno[1];
                    }
                } else if (array.length == 3) {
                    if (message[0] == "Full Sheet" || message[0] == "Half Sheet") {
                        stringMsg = "we have a new " + message[0] + " winners with  sheet number " + ticketno[0] + ", " + ticketno[1] + " and " + ticketno[2];
                    } else if (message[0] == "Full House") {
                        if (datas[datas.length - 1].Place == "1") {
                            stringMsg = "we have a First " + message[0] + " winner with Ticket Number " + ticketno[0] + ", " + ticketno[1] + "and " + ticketno[2];
                        } else if (datas[datas.length - 1].Place == "2") {
                            stringMsg = "we have a second " + message[0] + " winner with Ticket Number " + ticketno[0] + ", " + ticketno[1] + "and " + ticketno[2];
                        }
                        else if (datas[datas.length - 1].Place == "3") {
                            stringMsg = "we have a third " + message[0] + " winner with Ticket Number " + ticketno[0] + ", " + ticketno[1] + "and " + ticketno[2];
                        }
                        else if (datas[datas.length - 1].Place == "4") {
                            stringMsg = "we have a fourth " + message[0] + " winner with Ticket Number " + ticketno[0] + ", " + ticketno[1] + "and " + ticketno[2];
                        }
                        else if (datas[datas.length - 1].Place == "5") {
                            stringMsg = "we have a fifth " + message[0] + " winner with Ticket Number " + ticketno[0] + ", " + ticketno[1] + "and " + ticketno[2];
                        }
                        else if (datas[datas.length - 1].Place == "6") {
                            stringMsg = "we have a sixth " + message[0] + " winner with Ticket Number " + ticketno[0] + ", " + ticketno[1] + "and " + ticketno[2];
                        }
                        else if (datas[datas.length - 1].Place == "7") {
                            stringMsg = "we have a seventh " + message[0] + " winner with Ticket Number " + ticketno[0] + ", " + ticketno[1] + "and " + ticketno[2];
                        }
                        else if (datas[datas.length - 1].Place == "8") {
                            stringMsg = "we have a eighth " + message[0] + " winner with Ticket Number " + ticketno[0] + ", " + ticketno[1] + "and " + ticketno[2];
                        }
                        else if (datas[datas.length - 1].Place == "9") {
                            stringMsg = "we have a ninth " + message[0] + " winner with Ticket Number " + ticketno[0] + ", " + ticketno[1] + "and " + ticketno[2];
                        }
                        else if (datas[datas.length - 1].Place == "10") {
                            stringMsg = "we have a tenth " + message[0] + " winner with Ticket Number " + ticketno[0] + ", " + ticketno[1] + "and " + ticketno[2];
                        }
                        else if (datas[datas.length - 1].Place == "11") {
                            stringMsg = "we have a eleventh " + message[0] + " winner with Ticket Number " + ticketno[0] + ", " + ticketno[1] + "and " + ticketno[2];
                        }
                        else if (datas[datas.length - 1].Place == "12") {
                            stringMsg = "we have a twelfth " + message[0] + " winner with Ticket Number " + ticketno[0] + ", " + ticketno[1] + "and " + ticketno[2];
                        }
                    }
                    else {
                        stringMsg = "we have a new " + message[0] + " winners with ticket number " + ticketno[0] + ", " + ticketno[1] + " and " + ticketno[2];
                    }
                } else {
                    stringMsg = "We have a multiple " + message[0] + " winners";
                }

            } else if (totalW > 1) {
                var tempString = "";
                var ArrayMsg = [];
                for (let i = 0; i < message.length; i++) {
                    if (tempString != message[i]) {
                        tempString = message[i];
                        ArrayMsg.push(tempString);
                    }
                }
                var tempAMsg = " ";
                for (let j = 0; j < ArrayMsg.length; j++) {
                    if (j == ArrayMsg.length - 1 && ArrayMsg.length != 1) {
                        tempAMsg += " and a " + ArrayMsg[j] + " Winner";
                    } else {
                        tempAMsg += ArrayMsg[j] + ", ";
                    }
                }
                stringMsg = "we have a new " + tempAMsg;
            }
            setTimeout(function () {
                speech.text = stringMsg;
                speech.volume = 1;
                speech.rate = 1;
                // speech.voice = voices[4];
                speech.pitch = 1;
                window.speechSynthesis.speak(speech);
                var audio = new Audio("../Audio/Applause.mp3");
                audio.autoplay = true;
                audio.volume = 0.8;
                audio.play();
                confetti.start();
                setTimeout(function () {
                    confetti.stop()
                }, 2000);
            }, 3000);
        }
    }
}
function checkwinnersSession(name) {
    var wName = name + "";
    var arrwinners = JSON.parse(sessionStorage.getItem("pitymewinners"));
    if (arrwinners == null) {
        var arr = [wName];
        sessionStorage.setItem('pitymewinners', JSON.stringify(arr));
        return false;
    } else {
        if (arrwinners.includes(wName) != true) {
            arrwinners.push(wName);
            sessionStorage.setItem('pitymewinners', JSON.stringify(arrwinners));
            return false;
        } else {
            return true;
        }
    }
}