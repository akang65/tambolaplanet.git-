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

$(document).ready(function () {
    gettime();
});

$(document).ready(function () {
    gettime();
});

setInterval(function () {
    gettime();
}, 3000);

//function gettime() {
//    $.ajax({
//        url: '../Pages/Agent/agentpanel.aspx/passTime',
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        type: "POST",
//        success: function (data) {
//            var Array = data.d;
//            var jsVariable = $.parseJSON('[' + Array + ']');
//            var numbers = jsVariable[0];
//            var countDownDate = new Date(numbers).getTime();
//            var x = setInterval(function () {

//                // Get today's date and time
//                var now = new Date().getTime();

//                // Find the distance between now and the count down date
//                var distance = countDownDate - now;
//                if (distance < 0) {
//                    BookingClosed();
//                }
//            }, 1000);

//        }
//    });

//}
function gettime() {
    $.ajax({
        url: '../Pages/Agent/agentpanel.aspx/passTime',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "POST",
        success: function (data) {
            var Array = data.d;
            var jsVariable = $.parseJSON('[' + Array + ']');
            var numbers = jsVariable[0];
            var myarray = numbers[0].Status;
            var date = numbers[0].Date;
            var countDownDate = new Date(date).getTime();
            var x = setInterval(function () {

                //// Get today's date and time
                //var now = new Date().getTime();

                //// Find the distance between now and the count down date
                //var distance = countDownDate - now;
                if (/*distance < 0 ||*/ myarray == 1) {
                    BookingClosed();
                }
            }, 1000);

        }
    });

}

function updateDate(number) {
    var countDownDate = new Date(number).getTime();
    var x = setInterval(function () {
        // Get today's date and time
        var now = new Date().getTime();
        var distance = countDownDate - now;
        if (distance < 0) {
            BookingClosed();
        }
    }, 1000);
}

function BookingClosed() {
    document.getElementById("stickyButton").disabled = true;
    if (document.getElementById("PanelFull") != null || document.getElementById("PanelFull") != undefined) {
        document.getElementById("PanelFull").style.display = "block";
    }
    if (document.getElementById("PanelHalf") != null || document.getElementById("PanelHalf") != undefined) {
        document.getElementById("PanelHalf").style.display = "block";
    }
    if (document.getElementById("GridViewFullsheet") != null || document.getElementById("GridViewFullsheet") != undefined) {
        document.getElementById("GridViewFullsheet").style.display = "none";
    }
    if (document.getElementById("GridViewHalfSheet") != null || document.getElementById("GridViewHalfSheet") != undefined) {
        document.getElementById("GridViewHalfSheet").style.display = "none";
    }
    if (document.getElementById("GridViewTickets") != null || document.getElementById("GridViewTickets") != undefined) {
        document.getElementById("GridViewTickets").style.display = "none";
    }
    if (document.getElementById("card-tickets") != null || document.getElementById("card-tickets") != undefined) {
        document.getElementById("card-tickets").style.display = "none";
    }
    if (document.getElementById("card-full") != null || document.getElementById("card-full") != undefined) {
        document.getElementById("card-full").style.display = "none";
    }
    if (document.getElementById("card-half") != null || document.getElementById("card-half") != undefined) {
        document.getElementById("card-half").style.display = "none";
    } 
}

document.addEventListener('DOMContentLoaded', (event) => {
    var fullsheetSoldOut = document.getElementById("GridViewFullsheet");
    var halfsheetsheetSoldOut = document.getElementById("GridViewHalfSheet");
    if (fullsheetSoldOut == null || undefined) {
        document.getElementById("PanelFull").style.display = "";
    }
    if (halfsheetsheetSoldOut == null || undefined) {
        document.getElementById("PanelHalf").style.display = "";
    }
});
function editProfile() {
    window.location.href="../pages/Agent/AgentEditProfile.aspx";
}