$(function () {

    var skipRow = 1;
    $(document).on('click', '#loadmore', function () {
        console.log("here")
        $.ajax({
            method: "GET",
            url: "/home/loadmore",
            data: {
                skipRow: skipRow
            },
            success: function (result) {
                $('#recentWorkComponents').append(result);
                skipRow++;
            }
        })

    })

    var skipRowSecond = 0;
    $(document).on('click', '#load', function () {
        console.log("salam")
        $.ajax({
            method: "GET",
            url: "/pricing/loadmore",
            data: {
                skipRowSecond: skipRowSecond
            },
            success: function (result) {
                $('#pricingcomponent').append(result);
                skipRowSecond++;
            }
        })
    })


})