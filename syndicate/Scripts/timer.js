
    var inputElement = document.getElementById("inputDateTime");
    var buttonElement = document.getElementById("saveDateTime");
    buttonElement.addEventListener("click", function () {
        console.log(inputElement.value.toString());
    var unparsedDate = inputElement.value.toString();
    //Split into data and time and store into an Array
    console.log(unparsedDate.split("T"));
    var tempArray = unparsedDate.split("T");
    var date = tempArray[0];
    var time = tempArray[1];
    localStorage.setItem("date", date);
    localStorage.setItem("time", time);
    console.log(date, time);
    });
    //Getting Current Date and Time
    var currentDateString = moment().format();
    var tempArray2 = currentDateString.split("T");
    var currentDate = tempArray2[0];
    var currentTime = tempArray2[1].slice(0, 5);
    console.log(currentDate, currentTime);
    setInterval(function () {
        currentDateString = moment().format();
    console.log(currentDateString);
    tempArray2 = currentDateString.split("T");
    currentDate = tempArray2[0];
    currentTime = tempArray2[1].slice(0, 5);
    console.log("CD: ", currentDate, currentTime);
    //Bringing date and time from LocalStorage (which is the input date)
    localStorageDate = localStorage.getItem("date");
    localStorageTime = localStorage.getItem("time");
    console.log("LS: ", localStorageDate, localStorageTime);
    if (currentDate == localStorageDate && currentTime == localStorageTime) {
        console.log("Event Reached");
    localStorage.clear();
        window.location.replace("https://localhost:44326/Pages/HomeBeforeGame.aspx");
      }
    }, 1000);
