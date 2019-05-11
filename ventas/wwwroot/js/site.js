// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$().ready(() => {
    var URLactual = window.location;
    switch (URLactual.pathname) {
        case "/Categoria":
            cargarDatos();
            break;
        case "/Articulo":
            listarArticulos();
            break;
        case "/Persona":
            listarPersonas();
            break;
        case "/Ingresos":
            cargarSelects();
            break;
        case "/Sale":
            loadSelects();
        case "/MisIngresos":
            loadTableMyIncome();
    }
});



cargarDatos = () => {
    categoria = new Categoria();
    categoria.cargarDatos();
}

editarCategoria = (idCategoria, funcion) => {
    categoria = new Categoria();
    categoria.editarCategoria(idCategoria, funcion);
}

editarEstadoCategoria = (idCategoria) => {
    categoria = new Categoria();
    categoria.editarEstadoCategoria(idCategoria);
}

guardarCategoria = () => {
    categoria = new Categoria();
    var nombre = document.getElementById("Nombre").value;
    var descripcion = document.getElementById("Descripcion").value;
    action = "Categoria/Crear";
    categoria.guardarCategoria(nombre, descripcion, action);
}

eliminarCategoria = (id) => {
    categoria = new Categoria();
    categoria.eliminarCategoria(id);

}

/*------------------------------------
    Articulos
-----------------------------------*/

getCategorias = () => {
    var articulo = new Articulo();
    articulo.getCategorias();
}

guardarArticulo = () => {

    var articulo = new Articulo();
    let codigo = document.getElementById('Codigo').value;
    let nombre = document.getElementById('Nombre').value;
    let stock = document.getElementById('Stock').value;
    let categoriaID = $('#CategoriaArticulos').val();
    let descripcion = document.getElementById('Descripcion').value;

    let data = {
        codigo,
        nombre,
        stock,
        categoriaID,
        descripcion
    };
    articulo.guardarArticulo(data);
}

listarArticulos = () => {
    var articulo = new Articulo();
    articulo.listarArticulos();
}

editarArticulo = (id, funcion) => {
    var articulo = new Articulo()
    articulo.editarArticulo(id, funcion)
}

restablecerModalArticulo = () => {
    var articulo = new Articulo()
    articulo.restablecer();
}

modalArticulo = () => {
    var articulo = new Articulo()
    articulo.modalArticulo()
}

eliminarArticulo = (id) => {
    swal({
        title: "Esta seguro?",
        text: "Una vez, Eliminado no podra recuperar el archivo!",
        icon: "warning",
        buttons: ["Cancelar", "Eliminar"],
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                var articulo = new Articulo()
                articulo.eliminarArticulo(id)
            }
        });
} 


//=============================
//  PERSONAS
//=============================


guardarPersona = () => {
    persona = new Persona();

    let nombre = document.getElementById('Nombre').value;
    let tipoPersona = document.getElementById('TipoPersona').value;
    let tipoDocumento = document.getElementById('TipoDocumento').value;
    let documento = document.getElementById('Documento').value;
    let direccion = document.getElementById('Direccion').value;
    let telefono = document.getElementById('Telefono').value;
    let email = document.getElementById('Email').value;

    data = {
        nombre,
        tipoPersona,
        tipoDocumento,
        NumeroDocumento: documento,
        direccion,
        telefono,
        email
    };

        
    persona.guardarPersona( data );
}


listarPersonas = () => {

    persona = new Persona();
    persona.listarPersonas()
}

modalEditar = (id) => {
    persona = new Persona();
    persona.modalEditar(id);
}

editarPersona = () => {
    persona = new Persona();

    let personaID = document.getElementById('idOculto').value;
    let nombre = document.getElementById('MNombre').value;
    let tipoPersona = document.getElementById('MTipoPersona').value;
    let tipoDocumento = document.getElementById('MTipoDocumento').value;
    let documento = document.getElementById('MDocumento').value;
    let direccion = document.getElementById('MDireccion').value;
    let telefono = document.getElementById('MTelefono').value;
    let email = document.getElementById('MEmail').value;

    data = {
        personaID,
        nombre,
        tipoPersona,
        tipoDocumento,
        NumeroDocumento: documento,
        direccion,
        telefono,
        email
    };


    persona.editarPersona(data);
}

eliminarPersona = (id) => {

    swal({
        title: "Esta seguro?",
        text: "Una vez, Eliminado no podra recuperar el archivo!",
        icon: "warning",
        buttons: ["Cancelar", "Eliminar"],
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                persona = new Persona();
                persona.eliminarPersona(id)
            }
        });
   

}



//=============================
//  Ingresos
//=============================


cargarSelects = () => {
    ingreso = new Ingreso();
    ingreso.cargarSelects();
}

addDetails = () => {
    ingreso = new Ingreso();
    ingreso.addDetails();
}

eliminarFila = (fila) => {
    ingreso = new Ingreso();
    ingreso.eliminarFila( fila  );
}


guardarIngresos = () => {
    ingreso = new Ingreso();
    ingreso.guardarIngresos();
}

//=============================
//  Ventas
//=============================

loadSelects = () => {
    sale = new Sale();
    sale.cargarSelects();
}

addDetalles = () => {
    sale = new Sale();
    sale.addDetalles();
}

deleteRow = (row) => {
    sale = new Sale();
    sale.deleteRow(row);
}

saveSale = () => {
    sale = new Sale();
    sale.saveSale()
}

//=============================
//  Mis ingresos
//=============================

loadTableMyIncome = () => {
    income = new MisIngresos();
    income.loadTableMyIncome();
}

modalDetalles = () => {
}













