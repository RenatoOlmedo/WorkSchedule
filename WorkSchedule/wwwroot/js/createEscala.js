$(document).ready(function () {
    $("#geraEscala").click(function () {
        if ($("#mes").val() != "" && $("#mes").val() != null && $("#padrao").val() != "" && $("#padrao").val() != null && $("#funcionario").val() != "" && $("#funcionario").val() != null) {
            if (parseInt($("#p1").children("option:selected").val()) > 0) {
                $(".p1").html($("#p1").children("option:selected").text());
                $("#formFunc1").val($("#p1").children("option:selected").val())
            }
            if (parseInt($("#p2").children("option:selected").val()) > 0) {
                $(".p2").html($("#p2").children("option:selected").text());
                $("#formFunc2").val($("#p2").children("option:selected").val())
            }
            if (parseInt($("#p3").children("option:selected").val()) > 0) {
                $(".p3").html($("#p3").children("option:selected").text());
                $("#formFunc3").val($("#p3").children("option:selected").val())
            }
            if (parseInt($("#p4").children("option:selected").val()) > 0) {
                $(".p4").html($("#p4").children("option:selected").text());
                $("#formFunc4").val($("#p4").children("option:selected").val())
            }
            if (parseInt($("#p5").children("option:selected").val()) > 0) {
                $(".p5").html($("#p5").children("option:selected").text());
                $("#formFunc5").val($("#p5").children("option:selected").val())
            }


            $("#escala").removeClass("d-none");
            $("#btnSubmit").removeClass("d-none");
        }
        else {
            $("#modalAlert").modal("show");
        }
    });

    $("#closeModal").click(function () {
        $("#modalAlert").modal("hide");
    });
});

function qntFuncionarios() {
    $("#div-p1").addClass("d-none");
    $("#div-p2").addClass("d-none");
    $("#div-p3").addClass("d-none");
    $("#div-p4").addClass("d-none");
    $("#div-p5").addClass("d-none");

    var qnt = parseInt($("#funcionario").children("option:selected").val());
    switch (qnt) {
        case 1:
            $("#div-p1").removeClass("d-none");
            break;
        case 2:
            $("#div-p1").removeClass("d-none");
            $("#div-p2").removeClass("d-none");
            break;
        case 3:
            $("#div-p1").removeClass("d-none");
            $("#div-p2").removeClass("d-none");
            $("#div-p3").removeClass("d-none");
            break;
        case 4:
            $("#div-p1").removeClass("d-none");
            $("#div-p2").removeClass("d-none");
            $("#div-p3").removeClass("d-none");
            $("#div-p4").removeClass("d-none");
            break;
        case 5:
            $("#div-p1").removeClass("d-none");
            $("#div-p2").removeClass("d-none");
            $("#div-p3").removeClass("d-none");
            $("#div-p4").removeClass("d-none");
            $("#div-p5").removeClass("d-none");
            break;
        default:
            break;
    }
    $("#formQntFuncionarios").val(qnt);
};