
function refresh() {
   /* $('#WholeTable').remove();*/
    get();
}
function removesession() {
    if (sessionStorage.getItem("selected") != null) {
        var list = JSON.parse(sessionStorage.getItem("selected"));
        for (let x = 0; x < list.length; x++) {
            var id = "cell_" + list[x];
            document.getElementById(id).style.backgroundColor ="#5EBA7D";
        }
        sessionStorage.removeItem("selected");
    }
  
}

var TicketsData;
function get() {
    $.ajax({
        url: '../Pages/Agent/agentpanel.aspx/gettickets',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "POST",
        success: function (data) {
            if (data.d.length > 0) {
                var Array = data.d;
                var jsVariable = $.parseJSON('[' + Array + ']');
                var lists = jsVariable[0];
                createTable(lists);
                TicketsData = lists;
               /* createTable2(lists);*/
            }
        }
    });
}
function createTable(data) {
    var tbl = document.getElementById("WholeTable");
    let Totallength = data.length;
    let Rows = Math.floor(Totallength / 6);
    let TotalRows = Rows + 1;//12
    for (let z = 1; z <= TotalRows; z++) { 
        let numIndex = z * 6; //2 * 6=12
        numIndex -= 6;//12-5=6
        var row = tbl.insertRow();
        for (let x = 0; x < 6; x++) {
            if (data[numIndex + x] != null && data[numIndex + x]!= undefined) {
                row.style.backgroundColor = "#5EBA7D";
                var btncell = row.insertCell(x);
                var btn = document.createElement('input');
                btn.type = "button";
               
                if (data[numIndex + x].Name != null) {
                    btn.className = "btn btn-warning btn-sm  border-warning text-dark fw-bold";
                } else {
                    btn.className = "btn btn-primary btn-sm transparentBg border-warning text-dark fw-bold";
                }
            
                btn.value = data[numIndex + x].TicketNo.replace("TicketNo", "");
                let idIc = x + 1;
                btn.id = "cell_" + [numIndex + idIc];
                btncell.appendChild(btn);
                btn.onclick = function () { click(data[numIndex + x].TicketNo.replace("TicketNo", ""),data)};
            }
         
        }
       
    }
 /*   changecolor(data);*/
}

function click(ticketNo, data) {
    var index = ticketNo - 1;
    var cellid = "cell_" + ticketNo;
    if (data[index].Name == null) {
        if (sessionStorage.getItem("selected") == null) {
            document.getElementById(cellid).style.backgroundColor = "#0D6EFD";
            //save 
            var saveticket = [ticketNo];
            sessionStorage.setItem('selected', JSON.stringify(saveticket));
        } else {
            var list = JSON.parse(sessionStorage.getItem("selected"));
            //check //verify//push
            if (list.includes(ticketNo)) {
                document.getElementById(cellid).style.backgroundColor = "#5EBA7D";
                var removeitem = list.indexOf(ticketNo);
                list.splice(removeitem, 1);
                sessionStorage.setItem('selected', JSON.stringify(list));
            } else {
                list.push(ticketNo);
                sessionStorage.setItem('selected', JSON.stringify(list));
                document.getElementById(cellid).style.backgroundColor = "#0D6EFD";
            }
           
        }
    } 
}
function setArray() {

    let dataLength = TicketsData.length;
    let totalRows = Math.floor( dataLength / 6);
    let remainder = dataLength % 6;

    var lists = [];
    if (remainder != 0) {
        totalRows++;
        for (let i = 1; i <= totalRows; i++) {
            var innerList = [];
            let e = i * 6;
            let m = e - 5;
            if (i > totalRows - 1) {
                for (let re = 0; re < remainder; re++) {
                    let ticketno = m + re;
                    innerList.push(ticketno);
                }
                lists.push(innerList);
            } else {
                for (let e = 0; e < 6; e++) {
                    let ticketno = m + e;
                    innerList.push(ticketno);
                }
                lists.push(innerList);
            }
        }
    } else if (remainder == 0) {
        for (let i = 1; i <= totalRows; i++) {
            var innerList = [];
            let e = i * 6;
            let m = e - 5;
            for (let j = 0; j < 6; j++) {
            let ticketno = m + j;
            innerList.push(ticketno);
            }
            lists.push(innerList);
        }
    }
    var intAr = [];
    if (sessionStorage.getItem("selected") != null) {
        var selectedTickets = JSON.parse(sessionStorage.getItem("selected"));
        intAr = selectedTickets.map(Number)
    }
    //save on global variable;
    ticketDatas = intAr;

    //step 2
    var fullsheet = [];
    
    for (let xxx = 0; xxx < lists.length; xxx++) {
        if (lists[xxx].every(elem => intAr.includes(elem)) == true) {
            if (lists[xxx].length >= 6) {
                fullsheet.push(xxx + 1);
            }
        }
    }
    //step 2
    var hlists = half(lists);
    var halfsheet = [];
    for (let xxx = 0; xxx < lists.length; xxx++) {
        if (hlists[xxx].every(elem => intAr.includes(elem)) == true) {
            halfsheet.push(xxx+1);        }
    }
    //step 2 unused numbers
    var fsNumbers = [];
    for (let f = 0; f < fullsheet.length; f++) {
        let m = fullsheet[f]; //fs 1
        let v = (m * 6) - 5;
        for (let c = 0; c < 6; c++) {
            let a = v + c;
            fsNumbers.push(a);
        }
    }
    var hsNumbers = [];
    for (let f = 0; f < halfsheet.length; f++) {
        let m = halfsheet[f]; //fs 1
        let v = (m * 3) - 2;
        for (let c = 0; c < 3; c++) {
            let a = v + c;
            hsNumbers.push(a);
        }
    }

    //final half
    // sort out harlf sheet arrays that is already present in fullsheet
    var halfArray = [];
   
    for (let y = 0; y < halfsheet.length; y++) {
        var checkhalf = [];
        var mango = halfsheet[y];
        for (let z = 0; z < 3; z++) {
            var num = (mango * 3) - 2;
            var apple = num + z;
            checkhalf.push(apple);
        }
        halfArray.push(checkhalf);
    }
    var finalhalf = [];
    for (let xxx = 0; xxx < halfArray.length; xxx++) {
        if (halfArray[xxx].every(elem => fsNumbers.includes(elem)) != true) {
            if (halfArray[xxx].length >= 3) {
                finalhalf.push(halfsheet[xxx]);
            }
        }
    }

    let usedNumbers = fsNumbers.concat(hsNumbers);
    usedNumbers = usedNumbers.filter((item, index) => {
        return (usedNumbers.indexOf(item) == index)
    })
        passToMoadal(fullsheet, finalhalf, usedNumbers);
}



function passToMoadal(full, half, usedNum) {
    $("#TTable").remove();
    $("#FTable").remove();
    $("#HTable").remove();
    if ((full.length == 0 && half.length == 0) && sessionStorage.getItem("selected") == null) {
        document.getElementById("modalticketsTicketNo").innerText = " ";
        document.getElementById("modalsell").disabled = true;
    } else {
        var selectedTickets = JSON.parse(sessionStorage.getItem("selected"));
        var unusedNum = selectedTickets.map(Number)
        document.getElementById("modalsell").disabled = false;
        unusedNum = unusedNum.filter(val => !usedNum.includes(val));
        //unused Tickets
        if (unusedNum != null) {
            var ticketTd = document.getElementById("modalticketsTicketNo");
            $("#TTable").remove();
            var tbl = document.createElement("table");
            tbl.setAttribute("id", "TTable")
            const tblBody = document.createElement("tbody");
            let length = unusedNum.length;
            var total_rows = Math.floor(length / 6);
            if ((length % 6) != 0) {
                total_rows++;
            }
            let count = 0;
            for (let r = 1; r <= total_rows; r++) {
                var row = document.createElement("tr");
                for (let c = 0; c < 6; c++) {
                    var cell = document.createElement("td");
                    if (count < length) {
                        var data = unusedNum[(r * 6) - 6 + c];
                        const cellText = document.createTextNode(data);
                        cell.appendChild(cellText);
                        cell.setAttribute("class", "badge bg-primary rounded-pill");
                        row.appendChild(cell);
                    } count++;
                }
                tbl.appendChild(row);
            }
            tblBody.appendChild(tbl);
            ticketTd.appendChild(tblBody);

        }
        //full Sheet
        if (full != null) {
            var id = document.getElementById("LabelmodalFullSheet");
            $("#FTable").remove();
            var tbl = document.createElement("table");
            tbl.setAttribute("id", "FTable")
            const tblBody = document.createElement("tbody");
            const rows = document.createElement("tr");
            for (let i = 0; i < full.length; i++) {
                const cells = document.createElement("td");
                var celltext = document.createTextNode(full[i]);
                cells.appendChild(celltext);
                cells.setAttribute("class", "badge bg-success rounded-pill");
                rows.appendChild(cells);
            }
            tblBody.appendChild(rows);
            tbl.appendChild(tblBody);
            id.appendChild(tbl);
        }
        //half sheet
        if (half != null) {
            var id = document.getElementById("LabelmodalHalfSheet");
            $("#HTable").remove();
            var tbl = document.createElement("table");
            tbl.setAttribute("id", "HTable")
            const tblBody = document.createElement("tbody");
            const rows = document.createElement("tr");
            for (let i = 0; i < half.length; i++) {
                const cells = document.createElement("td");
                cells.setAttribute("class", "badge bg-warning rounded-pill");
                var celltext = document.createTextNode(half[i]);
                cells.appendChild(celltext);
                rows.appendChild(cells);
            }
            tblBody.appendChild(rows);
            tbl.appendChild(tblBody);
            id.appendChild(tbl);
        }
    }
    removesession();

}

var ticketDatas = [];

function passTicketData() {
    var name = document.getElementById("TextBoxmodalName").value;
    var phone = document.getElementById("TextBoxmodalNumber").value;
    $.ajax({
        url: '../Pages/Agent/agentpanel.aspx/getTicketData',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ arrayt: ticketDatas, nameT: name, phoneT: phone }),
        success: function () {
            window.location = "../agent";
        }
    });
}


function half(fullLists) {
    var length = fullLists.length;
    var containsHel = false;
    var lists = [];
    if (fullLists[length - 1].length >= 3) {
        containsHel = true;
    }
    if (containsHel == false) {
        
        for (let i = 0; i < length; i++) {
            var temp = fullLists[i];
            const middleInd = Math.ceil(6 / 2);
            const firstH = temp.slice().splice(0, middleInd);
            const secondH = temp.slice().splice(-middleInd);
            lists.push(firstH);
            lists.push(secondH);
        }
    } else {

        for (let i = 0; i < length; i++) {
            var temp = fullLists[i];
            var last = [];
            if (i > length - 2) {
                for (let xxx = 0; xxx < 3; xxx++) {
                    var test = temp[i];
                    last.push(temp[xxx]);
                }
                lists.push(last);
            }
            else {
                const middleInd = Math.ceil(6 / 2);
                const firstH = temp.slice().splice(0, middleInd);
                const secondH = temp.slice().splice(-middleInd);
                lists.push(firstH);
                lists.push(secondH);
            }
           
        }
     
    }
    return lists;
}
