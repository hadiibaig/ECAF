$(document).ready(function () {
    function UpdateEvent(EventID, EventStart, EventEnd) {
        var dataRow = {
            'Id': EventID,
            'NewEventStart': EventStart,
            'NewEventEnd': EventEnd
        }
        $.ajax({
            type: 'POST',
            url: "/Calender/UpdateEvent",
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(dataRow)
        });
    }
    function ClearPopupFormValues() {
        $('#eventTitle').val('')
        $('#eventTime').val(null)
        $('#eventDate').val(null)
        $('#eventDuration').val(0)
    }
    function ShowEventPopup(date) {
       // ClearPopupFormValues();
        $('#attached_adhocPop').show();
        $('#eventTitle').focus();
    }
    $('#btnPopupCancel').click(function () {
        $('#attached_adhocPop').hide();
    });
    $('#addTask').click(function () {
        $('#attached_adhocPop').show();
    });
    $('#btnPopupSave').click(function () {
        $('#popupEventForm').hide();
        var dataRow = {
            'Title': $('#eventTitle').val(),
            'ScheduledDate': $('#eventDate').val(),
            'ScheduledTime': $('#eventTime').val(),
            'Duration': $('#eventDuration').val(),
            'Status': $('#taskDropdown').val()

        }
        ClearPopupFormValues();
        $.ajax({
            type: 'POST',
            url: "/Calender/SaveEvents",
            data: dataRow,
            success: function (response) {
                if (response == "True") {
                    $('#calendar').fullCalendar('refetchEvents');
                    alert('New event saved!');
                    window.location.reload();
                }
                else {
                    alert('Error, could not save event!');
                }
            }
        });
    });
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
        slotMinutes: 15,
        //eventClick: function (calEvent, jsEvent, view) {
        //    alert('You clicked on event id: ' + calEvent.id
        //        + "\nSpecial ID: " + calEvent.someKey
        //        + "\nAnd the title is: " + calEvent.title);
        //},
        //eventDrop: function (event, dayDelta, revertFunc, minuteDelta, allDay) {
        //    if (confirm("Confirm move?")) {
        //        UpdateEvent(event.id, event.start);
        //    }
        //    else {
        //        revertFunc();
        //    }
        //},
        //eventResize: function (event, dayDelta, revertFunc, minuteDelta, allDay) {
        //    if (confirm("Confirm change event length?")) {
        //        UpdateEvent(event.id, event.start, event.end);
        //    }
        //    else {
        //        revertFunc();
        //    }
        //},
        dayClick: function (date, allDay, jsEvent, view) {
            $('#eventTitle').val("");
            //$('#eventDate').val($.fullCalendar.formatDate(date, 'dd/MM/yyyy'));
            //$('#eventTime').val($.fullCalendar.formatDate(date, 'HH:mm'));
            $('#eventDate').val(date);
            $('#eventTime').val(date);
            ShowEventPopup(date);
        }
    });
    $('#datepicker').datepicker({
        inline: true,
        onSelect: function (dateText, inst) {
            var d = new Date(dateText);
            $('#calendar').fullCalendar('gotoDate', d);
        }
    });
});