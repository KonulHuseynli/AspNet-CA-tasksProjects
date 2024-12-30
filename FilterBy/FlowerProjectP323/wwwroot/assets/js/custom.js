jQuery(document).ready(function ($) {
    $(document).on('click', '#tab-title-description', function () {
        $('#tab-description').css("display", "block");
        $("#tab-additional_information").css("display", "none");
        $(this).addClass('active');
        $("#tab-title-additional_information").removeClass('active');
    })

    $(document).on('click', '#tab-title-additional_information', function () {
        $("#tab-additional_information").css("display", "block");
        $('#tab-description').css("display", "none");
        $(this).addClass('active');
        $("#tab-title-description").removeClass('active');
    })
    var skipRow = 1;
    $(document).on('click', '#loadMore', function () {

        $.ajax({
            method: "GET",
            url: "/product/loadmore",
            data: {
                skipRow: skipRow
            },
            success: function (result) {
                //[...result].forEach(products => {
                //    console.log(products);
                $('#products').append(result);
                skipRow++;

            }

        })
    })
    $(document).on('click', '#addToCart', function () {
        var id = $(this).data('id');
        $.ajax({
            method: "POST",
            url: "/basket/add",
            data: {
                id: id
            },
            success: function (result) {
                console.log(result);
            }
        })
    })
    $(document).on('click', 'deleteButton', function () {
        var id = $(this).data('id');
        $.ajax({
            method: "POST",
            url: "/basket/delete",
            data: {
                id: id
            },
            success: function (result) {
                $(`.basket-product[id=${id}]`).remove();
            }
        })
    })

    $(document).on('click', '#deleteButton', function () {
        var id = $(this).data('id');
        $.ajax(
            {
                method: "POST",
                url: "/basket/delete",
                data:
                {
                    id:id
                },
                success: function (result) {
                    $(`.basket-product[data-id=${id}]`).remove();
                }
            })
        
    })
});
