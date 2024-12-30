$(function () {
    var skipRow = 1;
    $(document).on('click', '#loadMore', function () {
        $.ajax({
            method: 'GET',
            url: "/home/loadmore",
            data: {
                skipRow : skipRow
            },
            success: function (result) {
                $('#recentWorkComponents').append(result);
                skipRow++;
            }
        })
    })
})
$(function () {
    var skipRow = 0;
    $(document).on('click', '#loadMore', function () {
        $.ajax({
            method: 'GET',
            url: "/pricing/loadmore",
            data: {
                skipRow: skipRow
            },
            success: function (result) {
                $('#pricingComponents').append(result);
                skipRow++;
            }
        })
    })
})