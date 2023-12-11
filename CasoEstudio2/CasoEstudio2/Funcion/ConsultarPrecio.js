

function ConsultarPrecio() {

    let idCasa = $("#IdCasa").val();

    if (idCasa.length > 0) {

        $.ajax({
            url: 'https://localhost:44314/ConsultaCasa?IdCasa=' + idCasa,
            type: "GET",
            success: function (data) {
                $("#PrecioCasa").val(data.precio);
            }
        });

    } else {
        $("#PrecioCasa").val("");
    }

}
        
