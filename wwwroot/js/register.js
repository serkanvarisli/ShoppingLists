// register page
$(function () {
    $("#showPassword").change(function () {
        const checked = $(this).is(":checked");
        if (checked) {
            $("#password").attr("type", "text");
            const metin = document.getElementById("showText").innerHTML;

            // Belirli bir metni de�i�tir
            const yeniMetin = metin.replace("�ifreyi G�ster ", "�ifreyi Gizle ");

            // Metni g�ncelle
            document.getElementById("showText").innerHTML = yeniMetin;
        } else {
            $("#password").attr("type", "password");
            const metin = document.getElementById("showText").innerHTML;

            const yeniMetin = metin.replace("�ifreyi Gizle ", "�ifreyi G�ster ");

            // Metni g�ncelle
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

            // Belirli bir metni de�i�tir
            const yeniMetin = metin.replace("�ifreyi G�ster ", "�ifreyi Gizle ");

            // Metni g�ncelle
            document.getElementById("showText").innerHTML = yeniMetin;
        } else {
            $("#repassword").attr("type", "password");
            const metin = document.getElementById("showText").innerHTML;

            const yeniMetin = metin.replace("�ifreyi Gizle ", "�ifreyi G�ster ");

            // Metni g�ncelle
            document.getElementById("showText").innerHTML = yeniMetin;
        }
    });
});