// register page
$(function () {
    $("#showPassword").change(function () {
        const checked = $(this).is(":checked");
        if (checked) {
            $("#password").attr("type", "text");
            const metin = document.getElementById("showText").innerHTML;

            // Belirli bir metni deðiþtir
            const yeniMetin = metin.replace("Þifreyi Göster ", "Þifreyi Gizle ");

            // Metni güncelle
            document.getElementById("showText").innerHTML = yeniMetin;
        } else {
            $("#password").attr("type", "password");
            const metin = document.getElementById("showText").innerHTML;

            const yeniMetin = metin.replace("Þifreyi Gizle ", "Þifreyi Göster ");

            // Metni güncelle
            document.getElementById("showText").innerHTML = yeniMetin;
        }
    });
});
$(function () {
    $("#showPassword").change(function () {
        const checked = $(this).is(":checked");
        if (checked) {
            $("#repassword").attr("type", "text");
            const metin = document.getElementById("showText").innerHTML;

            // Belirli bir metni deðiþtir
            const yeniMetin = metin.replace("Þifreyi Göster ", "Þifreyi Gizle ");

            // Metni güncelle
            document.getElementById("showText").innerHTML = yeniMetin;
        } else {
            $("#repassword").attr("type", "password");
            const metin = document.getElementById("showText").innerHTML;

            const yeniMetin = metin.replace("Þifreyi Gizle ", "Þifreyi Göster ");

            // Metni güncelle
            document.getElementById("showText").innerHTML = yeniMetin;
        }
    });
});