
class Articulo {

    constructor() {

    }

    editarArticulo(id, funcion) {
        if (funcion == 0) {
            this.getArticulo(id);
        } else {
            this.edit(id);
        }
    }

    edit(id) {

        let action = 'Articulo/EditarArt';

        let codigo = document.getElementById('Codigo').value;
        let nombre = document.getElementById('Nombre').value;
        let stock = document.getElementById('Stock').value;
        let categoriaID = $('#CategoriaArticulos').val();
        let descripcion = document.getElementById('Descripcion').value;

        let data = {
            articuloID: id,
            codigo,
            nombre,
            stock,
            categoriaID,
            descripcion
        };

        $.ajax({
            type: 'POST',
            url: action,
            data: data,
            success: (response) => {
                if (response[0].code == "Save") {
                    $('#modalArticulo').modal('hide');
                    this.restablecer();
                    listarArticulos();
                    swal({
                        text: "Modificado correctamente!",
                    });
                } else {
                    swal("Oops", "No fue posible al modificacion!", "error")
                    console.log('Error', Error);
                }
            }
        });

    }

    getArticulo(id) {
        var action = "Articulo/GetArticulo";
        let count = 1;
        $.ajax({
            type: "Post",
            url: action,
            data: { id },
            success: (response) => {
                $('#modalArticulo').modal('show');
                document.getElementById('Codigo').value = response[0].codigo;
                document.getElementById('Nombre').value = response[0].nombre;
                document.getElementById('Stock').value = response[0].stock;
                document.getElementById('Descripcion').value = response[0].descripcion;
                this.modalEditarArticulo(response[0].articuloID);
                let id = response[0].categoriaID;
                this.getCategorias(response[0].categoriaID, 1);
            }
        });
    }

    getCategorias(id, funcion) {
        let action = "Articulo/GetCategorias";
        let count = 1;
        $.ajax({
            type: "GET",
            url: action,
            data: null,
            success: (response) => {
                console.log('getCategorias => id', id);
                console.log('getCategorias => funcion', funcion);

                for (var i = 0; i < response.length; i++) {
                    if (funcion == 0) {
                        document.getElementById('CategoriaArticulos').options[count] = new Option(
                            response[i].nombre, response[i].categoriaID);
                        
                        count++;
                    } else {
                        
                        if (id == response[i].categoriaID) {

                            document.getElementById('CategoriaArticulos').options[0] = new Option(
                                response[i].nombre, response[i].categoriaID);

                        } else {

                            document.getElementById('CategoriaArticulos').options[count] = new Option(
                                response[i].nombre, response[i].categoriaID);
                            count++;

                        }
                        

                        document.getElementById('CategoriaArticulos').selectedIndex = 0;

                    }

                    
                }
            }
        });
    }

    guardarArticulo(articulo) {
        let action = "Articulo/GuardarArticulo";

        //validaciones
        if (articulo.codigo == "") { document.getElementById('Codigo').focus(); return; }
        if (articulo.nombre == "") { document.getElementById('Nombre').focus(); return; }
        if (articulo.stock == "") { document.getElementById('Stock').focus(); return; }
        if (articulo.categoria == 0) { document.getElementById('CategoriaArticulos').focus(); return; }
        if (articulo.descripcion == "") { document.getElementById('Descripcion').focus(); return; }

        $.ajax({
            type: "POST",
            url: action,
            data: articulo,
            success: (response) => {
                console.log(response);
                if (response[0].code == "Save") {
                    $('#modalArticulo').modal('hide');
                    this.listarArticulos();
                    this.restablecer();
                    swal("buen Trabajo!", "Datos guardados correctamente!", "success");
                }
            }
        });
    }

    listarArticulos() {
        let action = "Articulo/ListarArticulos";
        $.ajax({
            type: "GET",
            url: action,
            data: null,
            success: (response) => {
                document.getElementById('tbodyArticle').innerHTML = response;
                var table = $('#tableArticle').DataTable({
                    responsive: true
                });
            }
        });

    }

    modalArticulo() {
        let guardar = "<button  type='button' class='btn btn-primary pull-left' onclick='guardarArticulo()'>Guardar</button>";
        document.getElementById('botonModalArticulo').innerHTML = guardar;
        this.getCategorias(0,0);
    }
    modalEditarArticulo(id) {
        let guardar = "<button  type='button' class='btn btn-primary pull-left' onclick='editarArticulo("+ id +", 1)'>Modificar</button>";
        document.getElementById('botonModalArticulo').innerHTML = guardar;
    }


    eliminarArticulo(id) {

        var action = "Articulo/Delete";

        $.ajax({
            type: "POST",
            url: action,
            data: { id },
            succes: (response) => {
                console.log(response);
                if (response[0].code == "Save") {
                    this.listarArticulos();
                    swal("buen Trabajo!", "Datos eliminados correctamente!", "success");
                }
            }
        });
    }

    

    restablecer() {
        document.getElementById('Codigo').value = "";
        document.getElementById('Nombre').value = "";
        document.getElementById('Stock').value = "";
        $('#CategoriaArticulos').val(0);
        document.getElementById('Descripcion').value = "";
        $('#modalArticulo').modal('hide');
    } 

    //fileValidation() {
    //    let fileInput = document.getElementById('archivosSubir');
    //    let filePath = fileInput.value;
    //    let allowedExtensions = /(.jpg|.jpeg|.png|.gif)$/i;
    //    if (!allowedExtensions.exec(filePath)) {
    //        swal("Oops", "Ingrese archivo con extencion .jpeg/.jpg/.png/.gif !", "error");
    //        fileInput.value = '';
    //        return false;
    //    } else {
    //        //Si hay imagenes
    //        if (fileInput.files && fileInput.files[0]) {
    //            return true;
    //        }
    //    }
    //}

  

}
