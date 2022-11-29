$(document).ready(function () {
    console.log("rodou");
    if ($("#p1").val() != null && $("#p1").val() != "") {
        $(".p1").html($("#p1").val());
        $("#escala").removeClass("d-none");
    }
    if ($("#p2").val() != null && $("#p2").val() != "") {
        $(".p2").html($("#p2").val());
        $("#escala").removeClass("d-none");
    }
    if ($("#p3").val() != null && $("#p3").val() != "") {
        $(".p3").html($("#p3").val());
        $("#escala").removeClass("d-none");
    }
    if ($("#p4").val() != null && $("#p4").val() != "") {
        $(".p4").html($("#p4").val());
        $("#escala").removeClass("d-none");
    }
    if ($("#p5").val() != null && $("#p5").val() != "") {
        $(".p5").html($("#p5").val());
        $("#escala").removeClass("d-none");
    }
});
