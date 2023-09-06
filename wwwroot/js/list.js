$(document).ready(function () {
    $("#endShopping").click(function () {
        var selectedItems = [];
        $("input[name='selectedItems']:checked").each(function () {
            selectedItems.push($(this).val());
        });

            $.ajax({
                url: '/Home/DeleteSelectedItems', // Silme iþlemi yapýlacak action'ýn yolunu belirtin
                type: 'POST',
                data: { selectedItems: selectedItems },
                success: function (result) {
                    // Silme iþlemi baþarýlýysa sayfayý yenileyebilirsiniz veya baþka bir iþlem yapabilirsiniz.
                    location.reload();
                },
                error: function () {
                    alert('Silme islemi sirasýnda bir hata oluþtu.');
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
    // Filtreleme butonuna týklandýðýnda

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



  

