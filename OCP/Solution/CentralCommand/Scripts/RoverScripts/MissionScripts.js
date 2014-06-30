﻿

function pagePrep() {

    $(".terrainMap img").click(function () {
        var element = this;
        var location = element.id;

        $("#newObstacles").append('<li>' + location + '</li>');
    });

    $("#addObstacles").click(function () {
        var element = $("#newObstacles");
        var itemsToSend = new Array();
        var callback = function (index, element) { itemsToSend[index] = $(element).text(); };

        iterateListItems(callback, element);
        UpdateObstaclesOnServer(itemsToSend, locationUpdateSuccess, wtf);
    });


    $("input[type='image']").click(function () {
        var element = this;
        var value = element.value;
        var field = $(this).data('field');

        $("#newCommands").append('<li data-field="' + field + '" >' + value + '</li>');
    });

    $("#sendCommands").click(function () {
        var element = $("#newCommands");
        var itemsToSend = new Array();
        var callback = function (index, element) { itemsToSend[index] = $(element).data('field'); };

        iterateListItems(callback, element);
        //UpdateObstaclesOnServer(itemsToSend, locationUpdateSuccess, wtf);
    });


    function locationUpdateSuccess(result)
    {
        if (result.Success)
        {
            var locationsToUpdate = result.LocationUpdates;

            $(locationsToUpdate).each(updateMapLocation);
            emptyListElement($("#newObstacles"));
        }
    }

    function emptyListElement(element)
    {
        element.empty();
    }



    function updateMapLocation(index, element)
    {
        $("img[id='" + element + "']").attr('src', '/Images/Obstacle.png');
    }

    //"Obstacle.png"
    //"Rover.png"
    //"Ground.png"

    function wtf()
    {
        alert("Something went wrong with updating obstacles or sending commands! WTF!");
    }

    function iterateListItems(callback, element)
    {
        $("li", element).each(function(index, element){
            callback(index, element);
        });
    }

    function SendCommandsToServer(itemsToSend, callback, wtf)
    {
        $.ajax({
            type: 'post',
            datatype: 'json',
            url: "../Mission/SendCommands",
            data: JSON.stringify({ locations: itemsToSend }),
            contentType: 'application/json; charset=utf-8',
            cache: false,
            success: callback,
            error: wtf
        });
    }

    function UpdateObstaclesOnServer(itemsToSend, callback, wtf)
    {
        $.ajax({
            type: 'post',
            datatype: 'json',
            url: "../Mission/UpdateObstacles",
            data: JSON.stringify({ locations: itemsToSend }),
            contentType: 'application/json; charset=utf-8',
            cache: false,
            success: callback,
            error: wtf
        });
    }

}
