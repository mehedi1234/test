var availableDates = ["29-2-2016", "2-3-2016"];

function available(date) {
    dmy = date.getDate() + "-" + (date.getMonth() + 1) + "-" + date.getFullYear();


    if ($.inArray(dmy, availableDates) == -1) {// && $.datepicker.noWeekends(date)[0]) {
        return false; //[true, ""];
    } else {
        return true;//[false, "", "Unavailable"];
    }
}

$(document).ready(function () {

    var dates = ['01/01/2016', '01/02/2016']; //
    //tips are optional but good to have
    var tips = ['some description', 'some other description'];

    $('#datepicker').datepicker({
        dateFormat: 'dd/mm/yy',
        beforeShowDay: highlightDays
        //showOtherMonths: true,
        //numberOfMonths: 3,
    });

    function highlightDays(date) {
        for (var i = 0; i < dates.length; i++) {
            if (new Date(dates[i]).toString() == date.toString()) {
                return [true, 'highlight', tips[i]];
            }
        }
        return [true, ''];
    }

});


//var SelectedDates = {};
//SelectedDates[new Date('01/01/2015')] = new Date('01/01/2015');
//SelectedDates[new Date('01/02/2015')] = new Date('01/02/2015');
//SelectedDates[new Date('01/03/2015')] = new Date('01/03/2015');
//$(document).ready(function () {
//$('#datepicker').datepicker({
//    beforeShowDay: function(date) {
//        var Highlight = SelectedDates[date];
//        if (Highlight) {
//            return [true, "Highlighted", Highlight];
//        }
//        else {
//            return [true, '', ''];
//        }
//    }
//});
//});

//$(document).ready(function () {
//    $("#datepicker").datepicker({
//        dateFormat: 'dd MM yy',
//        beforeShowDay: available
//    });
//});

//$('#iDate, .date-picker input').datepicker({
//    dateFormat: 'dd MM yy',
//    beforeShowDay: unavailable
//});
//$('.date-picker').datepicker({
//    rtl: Metronic.isRTL(),
//    autoclose: true,
//    endDate: '-d'
//    //beforeShowDay: unavailable
//});