
class Articulo {

    constructor() {

    }

    getCategorias() {
        let action = "Articulos/GetCategorias";
        let count = 1;
        $.ajax({
            type: "GET",
            url: action,
            data: null,
            success: (response) => {
                //console.log(response);
                for (var i = 0; i < response.length; i++) {
                    document.getElementById('CategoriaArticulos').options[count] = new Option(
                        response[i].nombre, response[i].categoriaID);
                    document.getElementById('CategoriaArticulos').selectedIndex = 0;
                    count++;
                }
            }
        });
    }

    guardarArticulo() {

        let action = "Articulos/GuardarArticulo";
        let codigo = document.getElementById('Codigo').value;
        let nombre = document.getElementById('Nombre').value;
        let stock = document.getElementById('Stock').value;
        let categoria = $('#CategoriaArticulos').val();
        let descripcion = document.getElementById('Descripcion').value;

        //validaciones
        if (codigo == "") { document.getElementById('Codigo').focus(); return; }
        if (nombre == "") { document.getElementById('Nombre').focus(); return; }
        if (stock == "") { document.getElementById('Stock').focus(); return; }
        if (categoria == 0) { document.getElementById('CategoriaArticulos').focus(); return; }
        if (descripcion == "") { document.getElementById('Descripcion').focus(); return; }
        if (!this.fileValidation()) { return; }

        //información del formulario
        let formData = new FormData(jQuery("#formularioArchivo")[0]);
        formData.append('codigo', codigo);
        formData.append('nombre', nombre);
        formData.append('stock', stock);
        formData.append('categoria', categoria);
        formData.append('descripcion', descripcion);

        //hacemos la petición ajax  
        jQuery.ajax({
            url: action,
            type: 'POST',
            //datos del formulario
            data: formData,
            //necesario para subir archivos via ajax
            cache: false,
            contentType: false,
            processData: false,
            //una vez finalizado correctamente 
            success: function (responseText) {

            },
            error: function (responseText) {
                alert("Error admin/#479 " + responseText)

            }
        });
    }

    fileValidation() {
        let fileInput = document.getElementById('archivosSubir');
        let filePath = fileInput.value;
        let allowedExtensions = /(.jpg|.jpeg|.png|.gif)$/i;
        if (!allowedExtensions.exec(filePath)) {
            swal("Oops", "Ingrese archivo con extencion .jpeg/.jpg/.png/.gif !", "error");
            fileInput.value = '';
            return false;
        } else {
            //Si hay imagenes
            if (fileInput.files && fileInput.files[0]) {
                return true;
            }
        }
    }

}
