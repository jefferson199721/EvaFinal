class ClasePracticas {
    constructor(Titulo, Nota, Dificultad, FechaDiseño, accion) {
        this.Titulo = Titulo;
        this.Nota = Nota;
        this.Dificultad = Dificultad;
        this.FechaDiseño = FechaDiseño;
        this.accion = accion;
    }

    Nuevo_Practica(PracticaId) {
        var Titulo = this.Titulo;
        var Nota = this.Nota;
        var Dificultad = this.Dificultad;
        var FechaDiseño = this.FechaDiseño;
        var accion = this.accion;
   
       
        if (PracticaId == '') {
            try {
                $.post(
                    accion,
                    { Titulo, Nota, Dificultad, FechaDiseño },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Practica', respuesta.description, 'success');
                            this.limpiar();
                        }
                        else {
                            swal('Practica', respuesta.description, 'Error');
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
                    { Titulo, Nota, Dificultad, FechaDiseño  },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Practica', "Se edito con exito", 'success');
                            this.limpiar();
                        }
                        else {
                            swal('Practica', respuesta.description, 'Error');
                        }
                    });
            }
            catch (e) {
                alert(e.message);
            }
        }

    }

    Un_Practica(PracticaId) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { PracticaId },
            success: (respuesta) => {

                document.getElementById("Titulo").value = respuesta.nombre;
                document.getElementById("Nota").value = respuesta.nombre;
                document.getElementById("Dificultad").value = respuesta.nombre;
                document.getElementById("FechaDiseño").value = respuesta.nombre;
                document.getElementById("PracticaId").value = respuesta.profesorId;
            }
        });
    }

    eliminar_profesor(PracticaId) {
        swal({
            title: "¿Eliminar Practicas?",
            text: "Esta seguro que desea eliminar la practica..!",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    var accion = this.accion;
                    $.post(accion, { PracticaId },
                        (respuesta) => {
                            if (respuesta.code == "ok") {
                                swal('Practica', respuesta.description, 'success');
                                this.limpiar();
                            }
                            else {
                                swal('Practica', respuesta.description, 'Error');
                            }
                        });
                } else {
                    swal('Practica', 'Usted a cancelo la accion', 'warning');
                }
            });
    }


    listaPractica() {
        var accion = this.accion;
        $.post(
            accion,
            {},
            (respuesta) => {

                $.each(respuesta, (index, val) => {
                    $('#Cuerpo_Practica').html(val[0])
                });

            }
        );
    }




    limpiar() {
        document.getElementById("Titulo").value = '';
        document.getElementById("Nota").value = '';
        document.getElementById("Dificultad").value = '';
        document.getElementById("FechaDiseño").value = '';
        document.getElementById("PracticaId").value = '';
        $('#Ingreso_Practica').modal('hide');
        listaProfesor();
    }




}