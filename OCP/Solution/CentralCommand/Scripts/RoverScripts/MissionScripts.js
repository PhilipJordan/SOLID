

function pagePrep() {

    $(".terrainMap img").click(function () {
        var element = this;
        var location = element.id;

        $("#newObstacles").append('<li>' + location + '</li>');
    });

    $("#addObstacles").click(function () {
        var itemsToSend = new Array();
        var callback = function (index, element) { itemsToSend[index] = $(element).text(); };

        iterateObstacleItems(callback);
        UpdateObstaclesOnServer(itemsToSend, locationUpdateSuccess, wtf);
    });


    $("#forward").click(function () {
        var element = this;

        $("#newCommands").append('<li>' + location + '</li>');
    });


    function locationUpdateSuccess(result)
    {
        if (result.Success)
        {
            var locationsToUpdate = result.LocationUpdates;

            $(locationsToUpdate).each(updateMapLocation);
            emptyObstacleList();
        }
    }

    function emptyObstacleList()
    {
        $("#newObstacles").empty();
    }

    function updateMapLocation(index, element)
    {
        $("img[id='" + element + "']").attr('src', '/Images/Obstical.png');
    }

    //"Obstical.png"
    //"Rover.png"
    //"Ground.png"

    function wtf()
    {
        alert("Something went wrong with updating obstacles!");
    }

    function iterateObstacleItems(callback)
    {
        $("#newObstacles li").each(function(index, element){
            callback(index, element);
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

function Foo()
{
    var moreFoo = "The most foo";
}