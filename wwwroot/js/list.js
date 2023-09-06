$(document).ready(function () {
    $("#endShopping").click(function () {
        var selectedItems = [];
        $("input[name='selectedItems']:checked").each(function () {
            selectedItems.push($(this).val());
        });

            $.ajax({
                url: '/Home/DeleteSelectedItems', // Silme i�lemi yap�lacak action'�n yolunu belirtin
                type: 'POST',
                data: { selectedItems: selectedItems },
                success: function (result) {
                    // Silme i�lemi ba�ar�l�ysa sayfay� yenileyebilirsiniz veya ba�ka bir i�lem yapabilirsiniz.
                    location.reload();
                },
                error: function () {
                    alert('Silme islemi siras�nda bir hata olu�tu.');
                }
            });
        window.location.href = "/Home/List?listId=" + productToDelete.ListId;
    });


    $('#startShopping').click(function () {
        $('.beforeShopping').hide();
        $('#addPruductNav').hide();
        $('#addProduct').hide();
        $('.afterShopping').show();
        $('.removeProduct').hide();
        $('#arama').hide();
        $('.bought').show();
        $('#endShopping').show();
        $('#startShopping').hide();
    });

    $('#endShopping').click(function () {
        $('.beforeShopping').show();
        $('#addPruductNav').show();
        $('#addProduct').show();
        $('.afterShopping').hide();
        $('.removeProduct').show();
        $('arama').show();
        $('.bought').hide();
        $('#endShopping').hide();
        $('#endShopping').hide();
        $('#startShopping').show();
    });
    // Filtreleme butonuna t�kland���nda

});

$('.detailbutton').click(function () {
    $(this).siblings('.hiddendetails').show();
    $(this).hide();
    $(this).siblings('.kapat').show();
});

$('.kapat').click(function () {
    $(this).siblings('.hiddendetails').hide();
    $(this).hide();
    $(this).siblings('.detailbutton').show();
});



  

