class ClaseExamen {
    constructor(NPreguntas, Fecha, accion) {
        this.NPreguntas = NPreguntas;
        this.Fecha = Fecha;
        this.accion = accion;
    }

    Nuevo_Examen(ExamenId) {
        var NPreguntas = this.NPreguntas;
        var Fecha = this.Fecha;
        var accion = this.accion;

        if (ExamenId == '') {
            try {
                $.post(
                    accion,
                    { NPreguntas,
                    Fecha},
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Examen', respuesta.description, 'success');
                            this.limpiar();
                        }
                        else {
                            swal('Examen', respuesta.description, 'Error');
                        }
                    });
            }
            catch (e) {
                alert(e.message);
            }
        }
        else {
            try {
                $.post(
                    accion,
                    { Nombre },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Examen', respuesta.description, 'success');
                            this.limpiar();
                        }
                        else {
                            swal('Examen', respuesta.description, 'Error');
                        }
                    });
            }
            catch (e) {
                alert(e.message);
            }
        }

    }

    Un_Examen(ExamenId) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { ExamenId },
            success: (respuesta) => {
                document.getElementById("Npreguntas").value = respuesta.NPreguntas;
                document.getElementById("Fecha").value = respuesta.Fecha;
                document.getElementById("ExamenId").value = respuesta.ProfesorId;
            }
        });
    }

    eliminar_Examen(ExamenId) {
        swal({
            title: "¿Eliminar Examen?",
            text: "Esta seguro que desea eliminar el Examen..!",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    var accion = this.accion;
                    $.post(accion, { ExamenId },
                        (respuesta) => {
                            if (respuesta.code == "ok") {
                                swal('Examen', respuesta.description, 'success');
                                this.limpiar();
                            }
                            else {
                                swal('Examen', respuesta.description, 'Error');
                            }
                        });
                } else {
                    swal('Examen', 'Usted a cancelo la accion', 'warning');
                }
            });



    }


    listaExamen() {
        var accion = this.accion;
        $.post(
            accion,
            {},
            (respuesta) => {

                $.each(respuesta, (index, val) => {
                    $('#Cuerpo_Examen').html(val[0])
                });
                // $('#cuerpo_Cliente').html(respuesta);
            }
        );
    }




    limpiar() {
        document.getElementById("Npreguntas").value = '';
        document.getElementById("Fecha").value = '';
        document.getElementById("ExamenId").value = '';
        $('#Ingreso_Examen').modal('hide');
        listaExamen();
    }




}