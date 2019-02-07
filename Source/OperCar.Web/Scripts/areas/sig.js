document.addEventListener("DOMContentLoaded", function () {
    // Handler when all assets (including images) are loaded
    $('.collapse').collapse();
    $('.lista-ultimo-subArea').on("click", HabilitarActive);
    $('.lista-ultimo-subArea').on("click", HabilitarActive);
    $('.lista-ultimo-subArea.subAreaTodo').on("click", MostarTodosDocumentos);
});

function HabilitarActive() {
    var clase = $(this).data("id");
    $(this).parent().find(".active").each(function () {
        $(this).removeClass("active");
    });
    $(this).addClass("active");
    $(".card-subArea").hide();
    $("."+clase).show();

}

function MostarTodosDocumentos() {
    $(".card-subArea").show();
}