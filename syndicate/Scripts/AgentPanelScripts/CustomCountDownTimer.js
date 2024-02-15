
var countDownDate;
function updateDate(date) {
    countDownDate = new Date(date).getTime();
}

// Update the count down every 1 second
var x = setInterval(function () {

    // Get today's date and time
    var now = new Date().getTime();

    // Find the distance between now and the count down date
    var distance = countDownDate - now;

    // Time calculations for days, hours, minutes and seconds
    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);

    // If the count down is over, write some text 
    if (distance < 0) {
        clearInterval(x);
        getarray();
    }
}, 1000);


function getarray() {
    sessionStorage.removeItem("RandomSequence");
    $.ajax({
        url: '../Pages/Agent/agentpanel.aspx/DisableTickets',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "POST",
        success: function (data) {
       //nothing to do Just Calling serverside function
        }
    });
}