class ClaseAlumnos {
    constructor(Nombres, Apellidos, CursoParalelo, accion) {
        this.Nombres = Nombres;
        this.Apellidos = Apellidos;
        this.CursoParalelo = CursoParalelo;
        this.accion = accion;
    }

    Nuevo_Alumno(NumMatricula) {
        var Nombres = this.Nombres;
        var Apellidos = this.Apellidos;
        var CursoParalelo = this.CursoParalelo;
        var accion = this.accion;

        if (NumMatricula == '') {
            try {
                $.post(
                    accion,
                    { Nombres, Apellidos, CursoParalelo },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Alumnos', respuesta.description, 'success');
                            this.limpiar();
                        }
                        else {
                            swal('Alumnos', respuesta.description, 'Error');
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
                    { Nombres, Apellidos, CursoParalelo },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Alumnos', respuesta.description, 'success');
                            this.limpiar();
                        }
                        else {
                            swal('Alumnos', respuesta.description, 'Error');
                        }
                    });
            }
            catch (e) {
                alert(e.message);
            }
        }

    }

    Un_Alumno(NumMatricula) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { NumMatricula },
            success: (respuesta) => {
                document.getElementById("Nombres").value = respuesta.Nombres;
                document.getElementById("Apellidos").value = respuesta.Apellidos;
                document.getElementById("CursoParalelo").value = respuesta.CursoParalelo;

                document.getElementById("NumMatricula").value = respuesta.NumMatricula;
            }
        });
    }

    eliminar_alumnos(NumMatricula) {
        swal({
            title: "¿Eliminar Alumnos?",
            text: "Esta seguro que desea eliminar el alumno..!",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    var accion = this.accion;
                    $.post(accion, { NumMatricula },
                        (respuesta) => {
                            if (respuesta.code == "ok") {
                                swal('Alumnos', respuesta.description, 'success');
                                this.limpiar();
                            }
                            else {
                                swal('Alumnos', respuesta.description, 'Error');
                            }
                        });
                } else {
                    swal('Alumnos', 'Usted a cancelo la accion', 'warning');
                }
            });



    }


    listaAlumnos() {
        var accion = this.accion;
        $.post(
            accion,
            {},
            (respuesta) => {
                $.each(respuesta, (Index, val) => {
                    $('#Cuerpo_Alumno').html(val[0])
                });

            }
        );
    }




    limpiar() {
        document.getElementById("Nombres").value = '';
        document.getElementById("Apellidos").value = '';
        document.getElementById("CursoParalelo").value = '';

        document.getElementById("NumMatricula").value = '';
        $('#Ingreso_Alumnos').modal('hide');
        listaAlumnos();
    }




}
