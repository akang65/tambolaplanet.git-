
$(document).ready(function () {
    getbookingClosed();
    getGameTime();
});
setInterval(function () {
    getbookingClosed();
    getGameTime();
}, 8000);

/*passGameTime*/

function getbookingClosed() {

    $.ajax({
        url: '../pages/Homebeforegame.aspx/passTime',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "POST",
        success: function (data) {
            var Array = data.d;
            var jsVariable = $.parseJSON('[' + Array + ']');
            var numbers = jsVariable[0];
            var countDownDate = new Date(numbers[0].Date).getTime();
            var x = setInterval(function () {

                var now = new Date().getTime();

                var distance = countDownDate - now;
                if (distance < 0) {
                    clearInterval(x);
                    window.location.href = "../pages/AutostartGame.aspx";
                }
            }, 1000);

        }
    });
}
function getGameTime() {

    $.ajax({
        url: '../pages/Homebeforegame.aspx/passGameTime',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "POST",
        success: function (data) {
            var Array = data.d;
            var jsVariable = $.parseJSON('[' + Array + ']');
            var numbers = jsVariable[0];
            var countDownDate = new Date(numbers).getTime();
            
            var x = setInterval(function () {

                var now = new Date().getTime();

                var distance = countDownDate - now;

                // Time calculations for days, hours, minutes and seconds
                var days = Math.floor(distance / (1000 * 60 * 60 * 24));
                var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
                var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
                var seconds = Math.floor((distance % (1000 * 60)) / 1000);

                // Output the result in an element with id="demo"
            /*    document.getElementById("Timer").innerHTML = days + "days " + hours + "hours "*/
                    + minutes + "min " + seconds + "sec ";
                document.getElementById("days").innerHTML = days;
                document.getElementById("hours").innerHTML = hours;
                document.getElementById("min").innerHTML = minutes;
                document.getElementById("sec").innerHTML = seconds;
                // If the count down is over, write some text 
                if (distance < 0) {
                    clearInterval(x);
                    window.location.href = "../pages/AutostartGame.aspx";
                }
            }, 1000);

        }
    });
}



//var countDownDate;
//function updateDate(date) {
//    countDownDate = new Date(date).getTime();
//}

//// Update the count down every 1 second
//var x = setInterval(function () {

//    // Get today's date and time
//    var now = new Date().getTime();

//    // Find the distance between now and the count down date
//    var distance = countDownDate - now;

//    // Time calculations for days, hours, minutes and seconds
//    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
//    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
//    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
//    var seconds = Math.floor((distance % (1000 * 60)) / 1000);

//    // Output the result in an element with id="demo"
//    document.getElementById("Timer").innerHTML = days + "days " + hours + "hours "
//        + minutes + "min " + seconds + "sec ";

//    // If the count down is over, write some text 
//    if (distance < 0) {
//        clearInterval(x);
//        window.location.href = "AutostartGame.aspx";
//    }
//}, 1000);
