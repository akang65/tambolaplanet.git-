$(document).ready(function () {
    $("#TextBoxCalander").datepicker(
        {
            dtateformat: 'mm/dd/yyyy',
            showOn: 'both',
            buttonImageOnly: true,
            buttonImage: "calendar.gif",
            buttonText: "Calendar"
            
        }
    );
});
