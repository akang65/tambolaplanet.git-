function loadModal() {
    $('#EditAgentModal').modal('show');
}
function loadModalAlert() {
    alert("Please enter Customer Name");
}
function closeModal() {
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
    $('body').css('overflow', 'auto');
}
function alertBoughtAlready() {
    alert("Too Slow! Another Agent bought it 1 sec ago");
}
function searchbyTicket() {
    var key = document.getElementById("TextBoxsearchTicket").value;
    document.getElementById("ButtonShowAll").style.display = "block";
    if (key != "") {
        var table = document.getElementById("GridViewBooking");
        for (var i = 0, row; row = table.rows[i]; i++) {
            var col = row.cells[0];
            if (col.innerText != key) {
                row.style.display = "none";
            } else {
                row.style.display = "";
            }

        }
    }
    document.getElementById("TextBoxsearchTicket").value="";
  
}
function searchbyName() {
    var key = document.getElementById("TextBoxsearchTicket").value;
    document.getElementById("ButtonShowAll").style.display="block";
    if (key != "") {
        var table = document.getElementById("GridViewBooking");
        for (var i = 0, row; row = table.rows[i]; i++) {
            var col = row.cells[1];
            if (col.innerText != key) {
                row.style.display = "none";
            } else {
                row.style.display = "";
            }
        }
    }
    document.getElementById("TextBoxsearchTicket").value = "";
}
function showAll() {
    document.getElementById("ButtonShowAll").style.display = "none";
        var table = document.getElementById("GridViewBooking");
        for (var i = 0, row; row = table.rows[i]; i++) {
          row.style.display = ""; 
        }
}