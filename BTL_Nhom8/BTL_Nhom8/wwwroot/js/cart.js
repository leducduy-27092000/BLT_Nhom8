$(document).ready(function () {
    $(".qty-minus").click(function () {

        var id = $(this).attr("data-id");
        var quantity = parseInt($('#' + id).val()) - 1;
        if (quantity <= 0) {
            quantity = 0;
            document.getElementById(id).value = 0;
        }

        else document.getElementById(id).value = quantity;
        tinhtien(id, quantity);
    });

    $(".qty-plus").click(function () {

        var id = $(this).attr("data-id");

        var quantity = parseInt($('#' + id).val()) + 1;
        document.getElementById(id).value = quantity;
        tinhtien(id, quantity);
    });
    function tinhtien(id, quantity) {
        $.ajax({
            type: 'GET',
            data: { id: id, quantity: quantity },
            url: '/Cart/EditItem',
            success: function (ketqua) {
                if (ketqua.status == true) {
                    document.getElementById("tongtien_" + id).innerHTML = ketqua.sl;
                }
            }
        });
    }

    $(".action").click(function () {
        var id = $(this).attr("data-id");
        $.ajax({
            type: 'GET',
            data: { id: id },
            url: '/Cart/DeleteItem',
            success: function (ketqua) {
                if (ketqua.status == true) {
                    $('#row_' + id).remove();
                }
            }
        });
    })
});