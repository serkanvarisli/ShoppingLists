$(document).ready(function () {
    $(".addProductDetailRadio").click(function () {
        var targetId = $(this).data("target");
        $("#" + targetId).toggle();
    });
});