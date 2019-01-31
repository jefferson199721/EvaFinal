//$().ready(
//    ()=>    {
//        listaAlumnos();
//    });
var nuevo_Alumno = () => {
    var Nombres = document.getElementById('Nombres').value;
    var Apellidos = document.getElementById('Apellidos').value;
    var CursoParalelo = document.getElementById('CursoParalelo').value;

    var NumMatricula = document.getElementById('NumMatricula');

    if (NumMatricula == '') {
        var accion = '../Alumnos/Nuevo_Alumno_Controller';
    } else {
        var accion = '../Alumnos/Editar_Alumno_Controller';
    }
    if (Nombres == '') {
       
    } else {
       
        if (Apellidos == '') {
            $('#control_Nombre').removeClass('hidden');
        } else {
            $('#control_Nombre').addClass('hidden');
            if (CursoParalelo == '') {
                $('#control_Apellido').removeClass('hidden');
            } else {
                $('#control_Apellido').addClass('hidden');
                
            }
        }
    }
}


////Ingreso de Un/////
var Un_Alumno = (NumMatricula) => {
    var accion = "Alumnos/Un_Alumno_Controller";
    var alumnos = new ClaseAlumnos(' ',' ',' ', accion);
    alumnos.Un_Alumnos(NumMatricula);
}




////Ingreso de Eliminar/////
var eliminar_alumnos = (NumMatricula) => {
    var accion = "Alumnos/Eliminar_Alumnos_Controller";
    var alumnos = new ClaseAlumnos(' ', ' ', ' ', accion);
    alumnos.eliminar_cliente(NumMatricula);
}

////Ingreso de Listas/////
var listaAlumnos = () => {
    var accion = '../Alumnos/Lista_Alumnos_Controller';
    var alumnos = new ClaseAlumnos('', '', '', accion);
    alumnos.listaAlumnos();
}
var listaProfesor = () => {
    var accion = '../Proveedors/Lista_Proveedor_Controller';
    var profesor = new ClaseProfesores('', '', '', accion);
    profesor.listaProfesor();
}
////Imprimir////// 
var Imprimir_Alumnos = () => {
    var contenido = document.getElementById('Imprimir_Alumnos').innerHTML;
    var contenidopaginaoriginal = document.body.innerHTML;
    document.body.innerHTML = contenido;
    window.print();
    document.body.innerHTML = contenidopaginaoriginal;
    $('#Reporte').modal('hide');
}

////Quitar Botones al rato de Imprimir////
    var quitar_Botones = () => {
        var contador = 0;
        $('#Cuerpo_Alumnos tr').each(function () {
            var celdas = $(this).find('td');

            $(celdas[5]).addClass('hidden');

        });
    }
