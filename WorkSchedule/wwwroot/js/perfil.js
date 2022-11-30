$(document).ready(function () {
    var role = $("#role").val();
    if (role != null && role != "") {
        if (role == "empresa") {
            $("#empresario").prop("checked", true);
            $("#empresario").attr('disabled', true);
            $("#funcionario").attr('disabled', true);
        }
        if (role == "funcionario") {
            $("#funcionario").prop("checked", true);
            $("#empresario").attr('disabled', true);
            $("#funcionario").attr('disabled', true);
        }
    }

    $('input[type=radio][name=tipo_pessoa]').change(function () {
        if ($("#funcionario").is(":checked")) {
            $("#suaEmpresa").removeClass("d-none");
        }
        if ($("#empresario").is(":checked")) {
            $("#suaEmpresa").addClass("d-none");
        }
    }); 

    if ($("#nomeCompleto").val() == "" || $("#nomeCompleto").val() == null) {
        $("#titlePage").html("Complete seu perfil agora!")
    }
    else {
        $("#titlePage").html("Perfil")
    }
});