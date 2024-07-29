//$(function () {
//    debugger;
//    
//    var connection = new signalR.HubConnectionBuilder().withUrl("/signalr").build();

//   
//    connection.start().then(function () {
//        console.log("SignalR connected.");
//    }).catch(function (err) {
//        return console.error(err.toString());
//    });

//   
//    connection.on("broadcastNotification", function (message) {
//        var notification = $('<div class="notification"></div>').text(message);
//        $('#notificationContainer').append(notification);

//      
//        setTimeout(function () {
//            notification.fadeOut(500, function () {
//                $(this).remove();
//            });
//        }, 5000);
//    });
//});

$(function () {
    console.log("Document ready function...");
    // Reference the auto-generated proxy for the hub
    var notificationHub = $.connection.notificationHub;


    notificationHub.client.broadcastNotification = function (message) {
        console.log("Received notification: " + message);
        alertify.success(message);
    };

    // Start the connection
    $.connection.hub.start().done(function () {
        console.log("SignalR connected.");
    }).fail(function (err) {
        console.error("SignalR connection failed: " + err.toString());
    });



});