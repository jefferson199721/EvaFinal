class ClaseProfesores {
    constructor(Nombre, accion) {
        this.Nombre = Nombre;       
        this.accion = accion;
    }

    Nuevo_Profesor(ProfesorId) {
        var Nombre = this.Nombre;        
        var accion = this.accion;

        if (ProfesorId == '') {
            try {
                $.post(
                    accion,
                    { Nombre },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Profesor', respuesta.description, 'success');
                            this.limpiar();
                        }
                        else {
                            swal('Profesor', respuesta.description, 'Error');
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
                            swal('Profesor', respuesta.description, 'success');
                            this.limpiar();
                        }
                        else {
                            swal('Profesor', respuesta.description, 'Error');
                        }
                    });
            }
            catch (e) {
                alert(e.message);
            }
        }

    }

    Un_Profesor(ProfesorId) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { ProfesorId },
            success: (respuesta) => {
                document.getElementById("Nombre").value = respuesta.Nombre;  
                document.getElementById("ProfesorId").value = respuesta.ProfesorId;
            }
        });
    }

    eliminar_profesor(ProfesorId) {
        swal({
            title: "¿Eliminar Profesores?",
            text: "Esta seguro que desea eliminar el profesor..!",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    var accion = this.accion;
                    $.post(accion, { ProfesorId },
                        (respuesta) => {
                            if (respuesta.code == "ok") {
                                swal('Profesor', respuesta.description, 'success');
                                this.limpiar();
                            }
                            else {
                                swal('Profesor', respuesta.description, 'Error');
                            }
                        });
                } else {
                    swal('Profesor', 'Usted a cancelo la accion', 'warning');
                }
            });



    }


    listaProfesor() {
        var accion = this.accion;
        $.post(
            accion,
            {},
            (respuesta) => {

                $.each(respuesta, (index, val) => {
                    $('#Cuerpo_Profesor').html(val[0])
                });
                // $('#cuerpo_Cliente').html(respuesta);
            }
        );
    }




    limpiar() {
        document.getElementById("Nombre").value = '';
        document.getElementById("ProfesorId").value = '';
        $('#Ingreso_Profesor').modal('hide');
        listaProfesor();
    }




}