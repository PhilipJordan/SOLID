
function pagePrep() {

    $.ajax({
        url: '/Mission/Index',
        success: function (data) {
            var map = $('.terrainMap');
            for (var rowIndex = data.Map.length - 1; rowIndex >= 0; rowIndex--) {
                var row = data.Map[rowIndex];
                for (var columnIndex = 0; columnIndex < row.length; columnIndex++) {
                    var id = columnIndex + "_" + rowIndex;
                    var imagePath = "/Images/" + row[columnIndex];
                    map.append('<img id="' + id + '" class="mapImage" src="' + imagePath + '" alt="Image" />');
                }
            }
        }
    });

    $(".terrainMap").on('click', 'img', function () {
        var element = this;
        var location = element.id;

        $("#newObstacles").append('<li class="rock">' + location + '</li>');
    }).on("contextmenu", 'img', function () {
        var element = this;
        var location = element.id;

        $("#newObstacles").append('<li class="alien">' + location + '</li>');
        return false; // Disable default context menu behavior
    });

    $("#addObstacles").click(function () {
        var element = $("#newObstacles");
        var itemsToSend = new Array();
        var callback = function(index, element) {
            var jqElement = $(element);
            itemsToSend[index] = {
                Coordinates: jqElement.text(),
                Type: jqElement.attr('class')
            };
        };

        iterateListItems(callback, element);
        UpdateObstaclesOnServer(itemsToSend, obstacleUpdateSuccess, wtf);
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
        SendCommandsToServer(itemsToSend, commandUpdateSuccess, wtf);
    });

    function commandUpdateSuccess(result) {
        if (result.Success) {
            var locationToUpdate = result.RoverLocation;
            var oldRoverLocation = result.PreviousRoverLocation;
            var roverFacing = result.RoverFacing;

            setOldRoverLocationToGround(oldRoverLocation);

            obstacleUpdateSuccess(result);

            $("img[id='" + locationToUpdate + "']").attr('src', '/Images/Rover-' + roverFacing + '.png');

            emptyListElement($("#newCommands"));
        }
        else { alert("Unable to send commands. Did you enter any?"); }
    }

    function obstacleUpdateSuccess(result)
    {
        if (result.Success) {
            $(result.RemovedObstacles).each(updateMapLocation);
            $(result.Obstacles).each(updateMapLocation);
            emptyListElement($("#newObstacles"));
        }
        else { alert("Unable to update obstacles. Did you click on the map to add any?");}
    }

    function emptyListElement(element)
    {
        element.empty();
    }

    function setOldRoverLocationToGround(oldLocation)
    {
        $("img[id='" + oldLocation + "']").attr('src', '/Images/Ground.png');
    }

    function updateMapLocation(index, element)
    {
        $("img[id='" + element.Location + "']").attr('src', '/Images/' + element.Image);
    }

    function wtf()
    {
        alert("Something went wrong with communicating to the server! WTF!");
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
            data: JSON.stringify({ commands: itemsToSend }),
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
            data: JSON.stringify(itemsToSend),
            contentType: 'application/json; charset=utf-8',
            cache: false,
            success: callback,
            error: wtf
        });
    }

}
