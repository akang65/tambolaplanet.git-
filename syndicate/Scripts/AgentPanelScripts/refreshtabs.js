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
$.connection.agentHub.client.getdata = function (data) {
    updateTable(data);

}
function updateTable(data) {
    var Array = data;
    var SoldTickets = [];
    var unsoldtickets = [];
    for (let i = 0; i < Array.length; i++) {
        var ticket = Array[i].TicketNumber;
        var _ticket = ticket.replace('TicketNo', '');
        var TicketNo = "cell_" + _ticket;

        if (Array[i].sold == 1) {
            document.getElementById(TicketNo).style.backgroundColor = "#FFC107";
            SoldTickets.push(_ticket);
        } else {
            document.getElementById(TicketNo).style.backgroundColor = "#5EBA7D";
            unsoldtickets.push(_ticket);
        }
    }
    var FullsheetNo = [];
    let temp = 0;
    for (let x = 0; x < SoldTickets.length; x++) {
        var sheetno = Math.floor(SoldTickets[x] / 6);
        if (SoldTickets[x] % 6 != 0) {
            sheetno++;
        }
        if (sheetno != temp) {
            FullsheetNo.push(sheetno);
            temp = sheetno;
        }
    }
    var fsindex = "fullsheetserial_";
    for (let l = 0; l < 150; l++) {
        var rowName = document.getElementById(fsindex + l);
        if (rowName != null || rowName != undefined) {
            console.log(fsindex + l);
            rowName.style.display = '';
        }
    }

    for (let v = 0; v <= FullsheetNo.length; v++) {
        var no = FullsheetNo[v];

        var rowName = document.getElementById(fsindex + no);
        if (rowName != null || rowName != undefined) {
            rowName.style.display = 'none';
        }

    }
    //Halfsheet
    var HalfsheetNo = [];
    let temph = 0;
    for (let x = 0; x < SoldTickets.length; x++) {
        var sheetno = Math.floor(SoldTickets[x] / 3);
        if (SoldTickets[x]%3 != 0) {
            sheetno++;
        }
        if (sheetno != temph) {
            HalfsheetNo.push(sheetno);
            temph = sheetno;
        }
    }
    var fsindex = "Halfsheetserial_";
    for (let l = 0; l < 300; l++) {
        var rowNameh = document.getElementById(fsindex + l);
        if (rowNameh != null || rowNameh != undefined) {
            console.log(fsindex + l);
            rowNameh.style.display = '';
        }
    } for (let hs = 0; hs < HalfsheetNo.length; hs++) {
        var Hno = HalfsheetNo[hs];
        var rowNameh = document.getElementById(fsindex + Hno);
        if (rowNameh != null || rowNameh != undefined) {
            rowNameh.style.display = 'none';
        }
    }

}
