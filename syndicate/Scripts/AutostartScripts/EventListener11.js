/* Events Listener*/

$(document).ready(function () {
    document.addEventListener('click', (e) => {
        // Retrieve id from clicked element
        let elementId = e.target.id;
        var buttonName = elementId + "";
        if (elementId != '' && buttonName.match(/fullhouseWinnerBtn/)) {
            var createid = buttonName.replace("fullhouseWinnerBtn", "");
            var CreateTableId = "fullhouseWinner" + createid;
            document.getElementById(CreateTableId).style.display = "none";
            

        } else if (elementId != '' && buttonName.match(/toplineWinnerBtn/)) {
            var createid = buttonName.replace("toplineWinnerBtn", "");
            var CreateTableId = "toplineWinner" + createid;
            document.getElementById(CreateTableId).style.display = "none";
           
        }
        else if (elementId != '' && buttonName.match(/middlelineWinnerBtn/)) {
            var createid = buttonName.replace("middlelineWinnerBtn", "");
            var CreateTableId = "middlelineWinner" + createid;
            document.getElementById(CreateTableId).style.display = "none";
            
        }
        else if (elementId != '' && buttonName.match(/bottomlineWinnerBtn/)) {
            var createid = buttonName.replace("bottomlineWinnerBtn", "");
            var CreateTableId = "bottomlineWinner" + createid;
            document.getElementById(CreateTableId).style.display = "none";
            
        }
        else if (elementId != '' && buttonName.match(/quickfiveWinnerBtn/)) {
            var createid = buttonName.replace("quickfiveWinnerBtn", "");
            var CreateTableId = "quickfiveWinner" + createid;
            document.getElementById(CreateTableId).style.display = "none";
            
        }
        else if (elementId != '' && buttonName.match(/quicksevenWinnerBtn/)) {
            var createid = buttonName.replace("quicksevenWinnerBtn", "");
            var CreateTableId = "quicksevenWinner" + createid;
            document.getElementById(CreateTableId).style.display = "none";
            
        }
        else if (elementId != '' && buttonName.match(/starWinnerBtn/)) {
            var createid = buttonName.replace("starWinnerBtn", "");
            var CreateTableId = "starWinner" + createid;
            document.getElementById(CreateTableId).style.display = "none";
            
        }
        else if (elementId != '' && buttonName.match(/fullsheetWinnerBtn/)) {
            var createid = buttonName.replace("fullsheetWinnerBtn", "");
            var CreateTableId = "fullsheetWinner_TicketNo" + createid;
            document.getElementById(CreateTableId).style.display = "none";
            
        }
        else if (elementId != '' && buttonName.match(/halfsheetWinnerBtn/)) {
            var createid = buttonName.replace("halfsheetWinnerBtn", "");
            var CreateTableId = "halfsheetWinner_TicketNo" + createid;
            document.getElementById(CreateTableId).style.display = "none";
           
        }
        var removeChar = buttonName.replace(/[A-Za-z]/g, ""); //1_1_0
        if (elementId != '' && buttonName.match(/GridView/)) {
            const TablePrefix = "GridView";
            if (buttonName.length == 19) {
                var buttonId = removeChar[0];
                HideButtonsTicket(TablePrefix, buttonId);
                /*  HideButtonsTicket(TablePrefix, buttonId);*/
            } else if (buttonName.length == 21) {
                var buttonId = removeChar.slice(0, 2);
                HideButtonsTicket(TablePrefix, buttonId);
            } else if (buttonName.length == 23) {
                var buttonId = removeChar.slice(0, 3);
                HideButtonsTicket(TablePrefix, buttonId);
            }
        }

    }
    );
});
function ViewFullHouseWinners(ticket,asd) {
    var construcId = ticket.replace("TicketNo", "");
    var ticketName = "GridView" + construcId;
    var element = document.getElementById("fullhouseWinner" + construcId);
    if (typeof (element) != 'undefined' && element != null) {
        // Exists.
        document.getElementById("fullhouseWinner" + construcId).style.display="table";
    } else {
        const table = document.getElementById(ticketName); //get tabele to be cloned
        const CloneTable = table.cloneNode(true); //cloned

        CloneTable.style.display = "table"; //display
        CloneTable.id = 'fullhouseWinner' + construcId;// set id
        var a = document.getElementById(asd);
        a.appendChild(CloneTable);
        updateSession('fullhouseWinner' + construcId);
        updatecolor('fullhouseWinner' + construcId);
        document.getElementById('fullhouseWinner' + construcId).rows[0].cells[2].getElementsByTagName('input')[0].id = "fullhouseWinnerBtn" + construcId;
       /* var a = document.getElementById("fullhouseClone");*/

    }
}
function ViewSheetWinners(sheetno, categoty,fsw) {
    if (categoty == "fs") {
        var m = sheetno * 6;
        let s = m - 5;
        
        for (let i = 0; i < 6; i++) {
            var temp = i + s;
            var clonetarget = "GridView" + temp;
            var element = document.getElementById('fullsheetWinner_TicketNo' + temp);
            if (typeof (element) != 'undefined' && element != null) {
                document.getElementById('fullsheetWinner_TicketNo' + temp).style.display = "table";
            } else {
                const table = document.getElementById(clonetarget);
                const CloneTable = table.cloneNode(true);
                CloneTable.style.display = "table"; 
                CloneTable.id = 'fullsheetWinner_TicketNo' + temp;
                var a = document.getElementById(fsw);
                a.appendChild(CloneTable);
                document.getElementById('fullsheetWinner_TicketNo' + temp).rows[0].cells[2].getElementsByTagName('input')[0].id = "fullsheetWinnerBtn" + temp;
                updateSession('fullsheetWinner_TicketNo' + temp);
                updatecolor('fullsheetWinner_TicketNo' + temp);

            }
        }
    } else if (categoty = "hs") {
        var m = sheetno * 3;
        let s = m - 2;

        for (let i = 0; i < 3; i++) {
            var temp = i + s;
            var clonetarget = "GridView" + temp;
            var element = document.getElementById('halfsheetWinner_TicketNo' + temp);
            if (typeof (element) != 'undefined' && element != null) {
                document.getElementById('halfsheetWinner_TicketNo' + temp).style.display = "table";
            } else {
                const table = document.getElementById(clonetarget);
                const CloneTable = table.cloneNode(true);
                CloneTable.style.display = "table";
                CloneTable.id = 'halfsheetWinner_TicketNo' + temp;
                var a = document.getElementById(fsw);
                a.appendChild(CloneTable);
                document.getElementById('halfsheetWinner_TicketNo' + temp).rows[0].cells[2].getElementsByTagName('input')[0].id = "halfsheetWinnerBtn" + temp;
                updateSession('halfsheetWinner_TicketNo' + temp);
                updatecolor('halfsheetWinner_TicketNo' + temp);
            }
        }
    }
}
function ViewWinners(ticket, category,tk) {
    var construcId = ticket.replace("TicketNo", "");
    var clonetarget = "GridView" + construcId;

    if (category == "ff") {    //first five
        var tableName = "quickfiveWinner" + construcId;
        var element = document.getElementById(tableName);
        if (typeof (element) != 'undefined' && element != null) {
            document.getElementById(tableName).style.display = "table";
        } else {
            const table = document.getElementById(clonetarget);
            const CloneTable = table.cloneNode(true); //cloned
            CloneTable.style.display = "table"; //display
            CloneTable.id = 'quickfiveWinner' + construcId;// set id
            var a = document.getElementById(tk);
            a.appendChild(CloneTable);
            document.getElementById(tableName).rows[0].cells[2].getElementsByTagName('input')[0].id = "quickfiveWinnerBtn" + construcId;
            updateSession(tableName);
            updatecolor(tableName);
        }
    } else if (category == "fs") {
        var tableName = "quicksevenWinner" + construcId;
        var element = document.getElementById(tableName);
        if (typeof (element) != 'undefined' && element != null) {
            document.getElementById(tableName).style.display = "table";
        } else {
            const table = document.getElementById(clonetarget);
            const CloneTable = table.cloneNode(true); //cloned
            CloneTable.style.display = "table"; //display
            CloneTable.id = 'quicksevenWinner' + construcId;// set id
            var a = document.getElementById(tk);
            a.appendChild(CloneTable);
            document.getElementById(tableName).rows[0].cells[2].getElementsByTagName('input')[0].id = "quicksevenWinnerBtn" + construcId;
            updateSession(tableName);
            updatecolor(tableName);
        }
    } else if (category == "s") {
        var tableName = "starWinner" + construcId;
        var element = document.getElementById(tableName);
        if (typeof (element) != 'undefined' && element != null) {
            document.getElementById(tableName).style.display = "table";
        } else {
            const table = document.getElementById(clonetarget);
            const CloneTable = table.cloneNode(true); //cloned
            CloneTable.style.display = "table"; //display
            CloneTable.id = 'starWinner' + construcId;// set id
            var a = document.getElementById(tk);
            a.appendChild(CloneTable);
            document.getElementById(tableName).rows[0].cells[2].getElementsByTagName('input')[0].id = "starWinnerBtn" + construcId;
            updateSession(tableName);
            updatecolor(tableName);
        }
    }
    else if (category == "tl") {
        var tableName = "toplineWinner" + construcId;
        var element = document.getElementById(tableName);
        if (typeof (element) != 'undefined' && element != null) {
            document.getElementById(tableName).style.display = "table";
        } else {
            const table = document.getElementById(clonetarget);
            const CloneTable = table.cloneNode(true); //cloned
            CloneTable.style.display = "table"; //display
            CloneTable.id = 'toplineWinner' + construcId;// set id
            var a = document.getElementById(tk);
            a.appendChild(CloneTable);
            document.getElementById(tableName).rows[0].cells[2].getElementsByTagName('input')[0].id = "toplineWinnerBtn" + construcId;
            updateSession(tableName);
            updatecolor(tableName);
        }
    }
    else if (category == "ml") {
        var tableName = "middlelineWinner" + construcId;
        var element = document.getElementById(tableName);
        if (typeof (element) != 'undefined' && element != null) {
            document.getElementById(tableName).style.display = "table";
        } else {
            const table = document.getElementById(clonetarget);
            const CloneTable = table.cloneNode(true); //cloned
            CloneTable.style.display = "table"; //display
            CloneTable.id = 'middlelineWinner' + construcId;// set id
            var a = document.getElementById(tk);
            a.appendChild(CloneTable);
            document.getElementById(tableName).rows[0].cells[2].getElementsByTagName('input')[0].id = "middlelineWinnerBtn" + construcId;
            updateSession(tableName);
            updatecolor(tableName);
        }
    }
    else if (category == "bl") {
        var tableName = "bottomlineWinner" + construcId;
        var element = document.getElementById(tableName);
        if (typeof (element) != 'undefined' && element != null) {
            document.getElementById(tableName).style.display = "table";
        } else {
            const table = document.getElementById(clonetarget);
            const CloneTable = table.cloneNode(true); //cloned
            CloneTable.style.display = "table"; //display
            CloneTable.id = 'bottomlineWinner' + construcId;// set id
            var a = document.getElementById(tk);
            a.appendChild(CloneTable);
            document.getElementById(tableName).rows[0].cells[2].getElementsByTagName('input')[0].id = "bottomlineWinnerBtn" + construcId;
            updateSession(tableName);
            updatecolor(tableName);
        }
    }

}
function updateSession(data) {
    if (sessionStorage.getItem('Tickets') == null) {
        var Vticket = [data];
        sessionStorage.setItem('Tickets', JSON.stringify(Vticket));
    } else {
        var VisibleTickets = JSON.parse(sessionStorage.getItem("Tickets"));
        let len = VisibleTickets.length;
        VisibleTickets[len] = data;
        sessionStorage.setItem('Tickets', JSON.stringify(VisibleTickets));
    }
}
function RemoveFromSession(item) {
    if (sessionStorage.getItem('Tickets') != null) {
        var array = JSON.parse(sessionStorage.getItem("Tickets"));
        var index = array.indexOf(item);
        if (index !== -1) {
            array.splice(index, 1);
        }
        sessionStorage.setItem('Tickets', JSON.stringify(array));
    }
}
function updatecolor(table) {
    var Tablename = document.getElementById(table);
    var UpdateColor = JSON.parse(sessionStorage.getItem("CalledNumbers"));
    for (let y = 0; y < UpdateColor.length; y++) {
        for (var i = 1, row; row = Tablename.rows[i]; i++) {
            //iterate trough columns
            for (var j = 0, col; col = row.cells[j]; j++) {
                // do something 
                var tabInnertext = col.innerText;
                if (tabInnertext == "0") {
                    col.innerText = "";
                } else if (UpdateColor != null && tabInnertext == UpdateColor[y]) {
                    if (col.innerText != "" && col.innerText != '0') {
                        col.style.backgroundColor = "#fd7e14";
                    }
                }
            }
        }
    }
}