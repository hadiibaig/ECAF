$(document).ready(function () {
    $('#calendar').fullCalendar({
        header:
        {
            left: 'prev,today,next',
            center: 'agendaDay,agendaWeek,month,year',
            right: 'search'
        },
        buttonText: {
            today: 'Today',
            month: 'Month',
            week: 'Week',
            day: 'Day',
            year: 'Year'
        },
        events: '/Calender/GetEvents',
        //events: function (start, end, timezone, callback) {
        //    $.ajax({
        //        url: '/Calender/GetEvents',
        //        type: "GET",
        //        dataType: "JSON",

        //        success: function (result) {
        //            var events = [];

        //            //$.each(result, function (i, data) {
        //            //    events.push(
        //            //        {
        //            //            title: moment(data.Start_Date).format('h:mm A') + '\n' + data.Title,
        //            //            description: data.Title,
        //            //            start: moment(data.Start_Date).format(),
        //            //            end: moment(data.End_Date).format(),
        //            //            backgroundColor: "#95d967",
        //            //           /* borderColor: "#fc0101"*/
        //            //        });
        //            //});

        //            result.forEach(data => {

        //                events.push(
        //                    {
        //                        title: moment(data.Start_Date).format('h:mm A') + '\n' + data.Title,
        //                        description: data.Title,
        //                        start: moment(data.Start_Date).format(),
        //                        end: moment(data.End_Date).format(),
        //                        backgroundColor: "#95d967",
        //                        /* borderColor: "#fc0101"*/
        //                    });

        //            })

        //            callback(events);
        //        }
        //    });
        //},

        eventRender: function (event, element) {
            element.qtip(
                {
                    content: event.description
                });
            //element.css({
            //    'border': 'none',
            //    'border-left': '4px solid #6bad3c80',
            //    'color': 'darkgreen',
            //    'background': 'rgba(149, 217, 103, 0.5)', 
            //    'backdrop-filter': 'blur(5px)', 
            //    'font-weight': 'bold'
            //});
        },
        editable: true,
        defaultView: 'agendaWeek',
        allDaySlot: false,
        selectable: true,
        slotMinutes : 15
    });
    $('#datepicker').datepicker({
        inline: true,
        onSelect: function (dateText, inst) {
            var d = new Date(dateText);
            $('#calendar').fullCalendar('gotoDate', d);
        }
    });
});