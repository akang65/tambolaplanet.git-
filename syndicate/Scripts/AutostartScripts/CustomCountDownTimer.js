
var countDownDate;
var status;
function updateDate(date,_status) {
    //var datetime = new Date(date).getTime();
        status = _status;
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

    // Output the result in an element with id="demo"
    document.getElementById("Timer").innerHTML = days + "days " + hours + "hours "
        + minutes + "min " + seconds + "sec ";

    // If the count down is over, write some text 
    if (distance < 0) {
        clearInterval(x);
        document.getElementById("statusTimer").innerHTML = "Game started, Good Luck!!"
        document.getElementById("Timer").innerHTML = ""

        var speech = new SpeechSynthesisUtterance();

        // Set the text and voice attributes.
        speech.text = "Game is Live";
        speech.volume = 1;
        speech.rate = 1;
        speech.pitch = 1;

        window.speechSynthesis.speak(speech);

    } else if (status!=1 && distance > 300000) {
        window.location.href = "../home";
    }
}, 1000);
