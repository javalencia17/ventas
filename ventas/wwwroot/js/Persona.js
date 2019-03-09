
class Persona {


    constructor() {

    }

    editarPersona(data) {
        let action = 'Persona/EditPersona';
        $.ajax({
            type: "POST",
            url: action,
            data: data,
            success: (response) => {
                if (response[0].code == "Save") {
                    this.listarPersonas();
                    $('#ModalEditarPersona').modal('hide');
                    swal("buen Trabajo!", "Datos editados correctamente!", "success");
                } else {
                    console.log('Error: ', response[0].descripcion);
                }
            }
        });
    }

    eliminarPersona( id ) {
        let action = 'Persona/DeletePersona';
        $.ajax({
            type: 'POST',
            url: action,
            data: { id },
            success: (response) => {
                if (response[0].code == "Save") {
                    this.listarPersonas();
                    swal("buen Trabajo!", "Datos eliminados correctamente!", "success");
                } else {
                    console.log('Error: ', response[0].descripcion);
                }
            }
        });
    }

    

    guardarPersona( data ) {
        let action = 'Persona/Save';
        $.ajax({
            type: "Post",
            url: action,
            data: data,
            success: (response) => {
                if (response[0].code == "Save") {
                    this.listarPersonas();
                    $('#ModalPersona').modal('hide');
                    swal("buen Trabajo!", "Datos guardados correctamente!", "success");
                }
            }
        });
    }

    listarPersonas() {
        let action = 'Persona/ListPerson';
        $.ajax({
            type: "POST",
            url: action,
            data: null,
            success: (response) => {
                $('#cargarPersonas').html(response[0]);
            }
        });


    }

    modalEditar(id) {
        alert("hola");
        $('#ModalEditarPersona').modal('show');
        let action = 'Persona/getPersona';
        $.ajax({
            type: "POST",
            url: action,
            data: { id },
            success: (response) => {
                document.getElementById('MNombre').value = response[0].nombre;
                document.getElementById('MTipoPersona').selectedIndex = response[0].tipoPersona;
                document.getElementById('MTipoDocumento').selectedIndex = response[0].tipoDocumento;
                document.getElementById('MDocumento').value = response[0].numeroDocumento;
                document.getElementById('MDireccion').value = response[0].direccion ;
                document.getElementById('MTelefono').value = response[0].telefono;
                document.getElementById('MEmail').value = response[0].email;
                $("#oculto").html("<input type='hidden' id='idOculto' value='" + response[0].personaID +"'>");
            }
        });
    }

    restablecer() {
        document.getElementById('Nombre').value = "";
        document.getElementById('TipoPersona').selectedIndex  = 0;
        document.getElementById('TipoDocumento').selectedIndex = 0;
        document.getElementById('Documento').value = "";
        document.getElementById('Direccion').value = "" ;
        document.getElementById('Telefono').value = "";
        document.getElementById('Email').value = "";
    }
}
