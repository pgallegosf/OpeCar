document.addEventListener("DOMContentLoaded", function () {
    // Handler when all assets (including images) are loaded
    $('.collapse').collapse();
    $('.lista-ultimo-subArea').on("click", HabilitarActive);
});

function HabilitarActive() {
    $(this).parent().find(".active").each(function () {
        $(this).removeClass("active");
    });
    $(this).addClass("active");
}