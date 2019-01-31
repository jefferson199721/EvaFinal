
﻿$().ready(
    () => {
        listaAlumnos();
        listaProfesor();
        listaPractica();
    
    });

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

var nuevo_Profesor = () => {
    var Nombre = document.getElementById('Nombre').value;    

    var ProfesorId = document.getElementById('ProfesorId').value;
    if (ProfesorId == '') {
        var accion = '../Profesores/Nuevo_Profesor_Controller';
    } else {
        var accion = '../Profesores/Editar_Profesor_Controller';
    }

    var clasepro = new ClaseProfesores(Nombre, accion);
    clasepro.Nuevo_Profesor(ProfesorId);
    
}


var nuevo_Practica = () => {
    var Nombre = document.getElementById('Titulo').value;
    var Nota = document.getElementById('Nota').value;
    var Dificultad = document.getElementById('Dificultad').value;
    var FechaDiseño = document.getElementById('FechaDiseño').value;

    var PracticaId = document.getElementById('PracticaId').value;
    if (PracticaId == '') {
        var accion = '../Practicas/Nuevo_Practica_Controller';
    } else {
        if (Titulo == '') {
            $('#control_Titulo').removeClass('hidden');
        } else {
            $('#control_Titulo').addClass('hidden');
            if (Nota == '') {
                $('#control_Nota').removeClass('hidden');
            } else {
                $('#control_Nota').addClass('hidden');
                if (Dificultad == '') {
                    $('#control_Dificultad').removeClass('hidden');
                } else {
                    $('#control_Dificultad').addClass('hidden');
                    if (FechaDiseño == '') {
                        $('#control_FechaDiseño').removeClass('hidden');
                    } else {
                        $('#control_FechaDiseño').addClass('hidden');
                        var accion = '../Practicas/Editar_Practica_Controller';
                    }
                }
            }
        }
        
    }

    var clasepra = new ClasePracticas(Titulo, Nota, Dificultad, FechaDiseño, accion);
    clasepra.Nuevo_Practica(PracticaId);

}

////Ingreso de Un/////
var Un_Alumno = (NumMatricula) => {
    var accion = "Alumnos/Un_Alumno_Controller";
    var alumnos = new ClaseAlumnos(' ',' ',' ', accion);
    alumnos.Un_Alumnos(NumMatricula);
}


var Un_Profesor = (ProfesorId) => {
    var accion = "Profesores/Un_Profesor_Controller";
    var profesor = new ClaseProfesores('', accion);
    profesor.Un_Profesor(ProfesorId);
}


var Un_Practica = (PracticaId) => {
    var accion = "Practicas/Un_Practica_Controller";
    var practica = new ClasePracticas('', '', '', '', accion);
    practica.Un_Practica(PracticaId);
}




////Ingreso de Eliminar/////
var eliminar_alumnos = (NumMatricula) => {
    var accion = "Alumnos/Eliminar_Alumnos_Controller";
    var alumnos = new ClaseAlumnos(' ', ' ', ' ', accion);

    cliente.eliminar_cliente(NumMatricula);
}

var eliminar_profesor = (ProfesorId) => {
    var accion = "Profesores/Eliminar_Profesor_Controller";
    var profesor = new ClaseProfesores('', accion);
    profesor.eliminar_profesor(ProfesorId);
}

var eliminar_practica = (PracticaId) => {
    var accion = "Practicas/Eliminar_Practica_Controller";
    var practica = new ClasePracticas('', accion);
    practica.eliminar_practica(PracticaId);
}

////Ingreso de Listas/////
var listaAlumnos = () => {
    var accion = '../Alumnos/Lista_Alumnos_Controller';
    var alumnos = new ClaseAlumnos('', '', '', accion);
    alumnos.listaAlumnos();
}

var listaProfesor = () => {
    var accion = 'Profesores/Lista_Profesor_Controller';
    var profesor = new ClaseProfesores('', accion);
    profesor.listaProfesor();
}

var listaPractica = () => {
    var accion = 'Practicas/Lista_Practica_Controller';
    var practicas = new ClasePracticas('','','','', accion);
    practicas.listaPractica();
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
}
