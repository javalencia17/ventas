class Categoria {

    constructor() {

    }

    cargarDatos() {
        var action = "Categoria/Listar";
        $.ajax({
            type: "GET",
            url: action,
            data: null,
            success: (response) => {
                document.getElementById("cargarCategorias").innerHTML = response;
            }
        });
    }

    editarCategoria(id, funcion) {
        var action = "Categoria/GetCategoria";
        $.ajax({
            type: "POST",
            url: action,
            data: { id },
            success: (response) => {
                //console.log(response);
                if (funcion == 1) {
                    $('#modalCategoria').modal('show');
                    document.getElementById('Nombre').value = response[0].nombre;
                    document.getElementById('Descripcion').value = response[0].descripcion;
                    document.getElementById('boton').innerHTML = "<button type='button' class='btn btn-primary' onclick='editarCategoria(" + id + ",0)'>Modificar</button>";

                } else {
                    this.editar(id);
                }
            }
        });
    }

    editar(id) {
        let action = "Categoria/Editar";
        let nombre = document.getElementById('Nombre').value;
        let descripcion = document.getElementById('Descripcion').value;
        $.ajax({
            type: "POST",
            url: action,
            data: { id, nombre, descripcion },
            success: (response) => {
                $('#modalCategoria').modal('hide');
                cargarDatos();
                swal("buen Trabajo!", "Datos editados correctamente!", "success");
            }
        });
    }

    editarEstadoCategoria(idCategoria) {
        var action = "Categoria/EditarEstado";
        $.ajax({
            type: "POST",
            url: action,
            data: { idCategoria },
            success: (response) => {
                if (response[0].code = "Save") {
                    cargarDatos();
                } else {
                    alert("Error");
                    console.log("Error: " + response);
                }
            }
        });
    }

    guardarCategoria(nombre, descripcion, action) {

        // validaciones 
        if (nombre == "") {
            swal({
                title: "Campo sin diligenciar!",
                text: "ingrese informacion en el camopo nombre",
                button: "Cancelar",
            }); return false;
        }
        if (descripcion == "") {
            swal({
                title: "Campo sin diligenciar!",
                text: "ingrese informacion en el campo descripción",
                button: "Cancelar",
            }); return false;
        }

        $.ajax({
            type: "POST",
            url: action,
            data: { nombre, descripcion },
            success: (response) => {
                if (response[0].code = "Save") {
                    $("#modalCategoria").modal('hide');
                    cargarDatos();
                    swal("Buen trabajo!", "Datos guardados con exito!", "success");
                } else {
                    alert("Error");
                    console.log("Error: " + response);
                }

            }
        });

    }

    eliminarCategoria(id) {
        var action = "Categoria/Eliminar";
        $.ajax({
            type: "POST",
            url: action,
            data: { id },
            success: (response) => {
                if (response[0].code = "Save") {
                    cargarDatos();
                    swal("buen Trabajo!", "Datos eliminados correctamente!", "success");
                } else {
                    alert("Error");
                    console.log("Error: " + response);
                }
            }
        });
    }


}