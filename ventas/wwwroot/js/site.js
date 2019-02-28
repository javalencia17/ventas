// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$().ready(() => {
    var URLactual = window.location;
    switch (URLactual.pathname) {
        case "/Categoria":
            cargarDatos();
            break;
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

