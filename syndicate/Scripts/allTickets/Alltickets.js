$(document).ready(function () {
    document.addEventListener('click', (e) => {
        // Retrieve id from clicked element
        let elementId = e.target.id;
        var cells = document.getElementById(elementId);
        if (cells.style.backgroundColor != "yellow")
        {
            if (cells.style.backgroundColor == "pink") {
                cells.style.backgroundColor = "#8bc34a";
            } else {
                cells.style.backgroundColor = "pink";
            }
            
        } 
    }
    );
});
function createTable2(data) {
    var tbl = document.getElementById("tableticket");
    let Totallength = data.length;
    let Rows = Math.floor(Totallength / 6);
    let TotalRows = Rows + 1;
    for (let z = 1; z <= TotalRows; z++) {
        let numIndex = z * 6;
        numIndex -= 6;
        var row = tbl.insertRow(-1);
        row.style.backgroundColor = "#8bc34a";
        var one = row.insertCell(0);
        one.id = "one" + z;
        var two = row.insertCell(1);
        two.id = "two" + z;
        var three = row.insertCell(2);
        three.id = "three" + z;
        var four = row.insertCell(3);
        four.id = "four" + z;
        var five = row.insertCell(4);
        five.id = "five" + z;
        var six = row.insertCell(5);
        six.id = "six" + z;
        if (data[numIndex] == undefined) {
            one.innerText = "";
        }
        else {
            one.innerText = data[numIndex].TicketNo.replace("TicketNo", "");
            if (data[numIndex].Name != null) {
                one.style.backgroundColor = 'yellow';

            }

        }
        if (data[numIndex+1] == undefined) {
            two.innerText = "";
        }
        else {
            two.innerText = data[numIndex + 1].TicketNo.replace("TicketNo", "");
            if (data[numIndex + 1].Name !=null) {
                two.style.backgroundColor = 'yellow';
            }
           
        }

        if (data[numIndex+2]== undefined) {
            three.innerText = "";
        }
        else {
            three.innerText = data[numIndex + 2].TicketNo.replace("TicketNo", "");
            if (data[numIndex+2].Name != null) {
                three.style.backgroundColor = 'yellow';
            }
        }

        if (data[numIndex+3] == undefined) {
            four.innerText = "";
        }
        else {
            four.innerText = data[numIndex + 3].TicketNo.replace("TicketNo", "");
            if (data[numIndex+3].Name != null) {
                four.style.backgroundColor = 'yellow';
            }
        }

        if (data[numIndex+4]== undefined) {
            five.innerText = "";
        }
        else {
            five.innerText = data[numIndex + 4].TicketNo.replace("TicketNo", "");
            if (data[numIndex+4].Name != null) {
                five.style.backgroundColor = 'yellow';
            }
        }

        if (data[numIndex+5] == undefined) {
            six.innerText = "";
        }
        else {
            six.innerText = data[numIndex + 5].TicketNo.replace("TicketNo", "");
            if (data[numIndex+5].Name != null) {
                six.style.backgroundColor = 'yellow';
            }
        } 
        
    }
}


function get() {
    $.ajax({
        url: '../Pages/AllTickets.aspx/passArrayToJs',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "POST",
        success: function (data) {
            if (data.d.length > 0) {
                var Array = data.d;
                var jsVariable = $.parseJSON('[' + Array + ']');
                var lists = jsVariable[0];
                /*createTable(lists);*/
                createTable2(lists);
            }
        }
    });
}