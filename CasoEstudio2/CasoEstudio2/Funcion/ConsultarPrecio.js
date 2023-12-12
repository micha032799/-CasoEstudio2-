

function ConsultarPrecio() {

    let idCasa = $("#DescripcionCasa").val();

    if (idCasa.length > 0) {

        $.ajax({
            url: '/Casas/ConsultaCasa',
            data: {
                'IdCasa': idCasa
            },
            type: "GET",
            success: function (data) {
                $("#PrecioCasa").val(data);
            }
        });

    } else {
        $("#PrecioCasa").val("");
    }

}
        
