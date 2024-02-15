function ViewFullHouseWinners(ticket) {
    var construcId = ticket.replace("TicketNo", "");
    var ticketName = "GridView" + construcId;
    var element = document.getElementById("fullhouseWinner" + construcId);
    if (typeof (element) != 'undefined' && element != null) {
        // Exists.
        document.getElementById("fullhouseWinner" + construcId).style.display = "table";
    } else {
        const table = document.getElementById(ticketName); //get tabele to be cloned
        const CloneTable = table.cloneNode(true); //cloned

        CloneTable.style.display = "table"; //display
        CloneTable.id = 'fullhouseWinner' + construcId;// set id
        var a = document.getElementById("fullhouseClone");
        a.appendChild(CloneTable);

        document.getElementById('fullhouseWinner' + construcId).rows[0].cells[2].getElementsByTagName('input')[0].id = "fullhouseWinnerBtn" + construcId;
        /* var a = document.getElementById("fullhouseClone");*/

    }
}

function searchTable() {

    if (sessionStorage.getItem("Clonedtables") != null) {
        var id = sessionStorage.getItem("Clonedtables");
        if (document.getElementById(id) != null && document.getElementById(id) != undefined) {
            document.getElementById(id).remove();
        }
    }
    var id = document.getElementById("searchbox").value;
    var tableid = "gridview" + id;
    const table = document.getElementById(tableid);
    if (table != null || table != undefined) {
    const CloneTable = table.cloneNode(true); //cloned
    CloneTable.id = "searchT" + id;
    var a = document.getElementById("Searchedtable");
    a.appendChild(CloneTable);
    document.getElementById("searchT" + id).classList.add("table-dark");
    sessionStorage.setItem("Clonedtables", "searchT" + id)
        document.getElementById("btn-clear").style.display = 'block';
    }
    
}
function removeSearchTable() {
    document.getElementById("btn-clear").style.display = 'none';
    var i = sessionStorage.getItem("Clonedtables");
    document.getElementById(i).remove();
    
}

function showbonus() {
    document.getElementById("fullhousebonus").style.display = 'block';
    document.getElementById("bonus").style.display = 'block';
    document.getElementById("buttonshowb").style.display = 'none';
}
function hidebonus() {
    document.getElementById("fullhousebonus").style.display = 'none';
    document.getElementById("bonus").style.display = 'none';
    document.getElementById("buttonshowb").style.display = 'inherit';
}
function Totalfh(total) {
    if (total == 1) {
        document.getElementById("second").remove();
        document.getElementById("r2").remove();
        document.getElementById("r3").remove();
        document.getElementById("r4").remove();
        document.getElementById("r5").remove();
        document.getElementById("r6").remove();
    
    } else if (total == 2) {
        document.getElementById("r2").remove();
        document.getElementById("r3").remove();
        document.getElementById("r4").remove();
        document.getElementById("r5").remove();
        document.getElementById("r6").remove();
    }
    else if (total ==3) {
        document.getElementById("fourth").remove();
        document.getElementById("third").colSpan=2;
        document.getElementById("r3").remove();
        document.getElementById("r4").remove();
        document.getElementById("r5").remove();
        document.getElementById("r6").remove();
    } else if (total == 4) {
        document.getElementById("r3").remove();
        document.getElementById("r4").remove();
        document.getElementById("r5").remove();
        document.getElementById("r6").remove();
    }
    else if (total == 5) {
        document.getElementById("sixth").remove();
        document.getElementById("fifth").colSpan = 2;
        document.getElementById("r4").remove();
        document.getElementById("r5").remove();
        document.getElementById("r6").remove();
    }
    else if (total == 6) {
        document.getElementById("r4").remove();
        document.getElementById("r5").remove();
        document.getElementById("r6").remove();
    }
    else if (total == 7) {
        document.getElementById("eighth").remove();
        document.getElementById("seventh").colSpan = 2;
        document.getElementById("r5").remove();
        document.getElementById("r6").remove();
    }
    else if (total == 8) {
        document.getElementById("r5").remove();
        document.getElementById("r6").remove();
    }
    else if (total == 9) {
        document.getElementById("tenth").remove();
        document.getElementById("ninth").colSpan = 2;
        document.getElementById("r6").remove();
    }
    else if (total == 10) {
        document.getElementById("r6").remove();
    }
    else if (total == 11) {
        document.getElementById("twelfth").remove();
        document.getElementById("eleventh").colSpan = 2;
    }
   
   
}