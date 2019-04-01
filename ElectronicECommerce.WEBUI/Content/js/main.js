$(document).ready(function () {
    $(".navbar-nav > li:nth-child(" + $(".spanMenuIndex").text() + ")").addClass("active");
});

function functAddCart(productID, quantity) {
    $.ajax({
        type: "POST",
        url: "/AJAX/AddCart",
        data: { "productID": productID, "quantity": quantity },
        success: function () { alert('eklendi') },
        error: function (e) { alert(e.responseText) },
    });
    $(".toplam").text(parseInt($(".toplam").text()) + 1)
}
function deleteCart(productID) {
    $.ajax({
        type: "POST",
        url: "/AJAX/DeleteCart",
        data: { "productID": productID },
        success: function () { location.href = '/Cart'; },
        error: function (e) { alert(e.responseText) },
    });
}
function updateCart(productID, quantity, sender, pm) {
    if (parseInt($(sender).parent().find(".qty").val()) + parseInt(pm) != 0) {

        $.ajax({
            type: "POST",
            url: "/AJAX/UpdateCart",
            data: { "productID": productID, "quantity": parseInt($(sender).parent().find(".qty").val()) + parseInt(pm) },
            success: function () { location.href = '/Cart'; },
            error: function (e) { alert(e.responseText) },
        });
    }
}
function ilceGetir(sender) {
    $.ajax({
        url: "/AJAX/GetDistrict",
        type: "GET",
        data: { "cityID": $(sender).val() },
        success: function (veri) {
            $(".ilceler").empty();
            $(".ilceler").append("<option value=''>İlçe Seçiniz...</option>");
            $.each(veri, function (index, item) {
                $(".ilceler").append("<option value='" + item.ID + "'>" + item.Name + "</option>");
            })
        },
        error: function (hata) {
            alert(hata.responseText);
        }
    });
}
function funcAddFavorite(sender) {
    //alert($(sender).siblings(".productID").val());
    var productid = parseInt($(sender).siblings(".productID").val());
    $.ajax({
        type: "POST",
        url: "/AJAX/AddProductFavorite",
        data: { "id": productid },
        success: function (gelenVeri) {

            if (parseInt(gelenVeri) == 0) {
                alert("Favorilerden Çıkarıldı");
                $(sender).removeClass("fav");
            }
            else {
                alert("Favorilere Eklendi");
                $(sender).addClass("fav");
            }
        },
        error: function (e) { alert(e.responseText) },
    });
}