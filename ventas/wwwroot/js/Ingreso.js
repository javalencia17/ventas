let contador = 0;

class Ingreso {

    constructor() {

    }

    cargarSelects() {
        this.getProveedores();
        this.getComprobantes();
        this.getArticulos();

    }

    getProveedores() {
        let action = "Ingresos/GetProveedores";
        $.ajax({
            type: "Post",
            url: action,
            data: null,
            success: (response) => {
                let count = 1;
                for (let i = 0; i < response.length; i++) {
                    document.getElementById('Proveedor').options[count] = new Option(
                        response[i].nombre, response[i].personaID);
                    count++;
                }
                document.getElementById('Proveedor').selectedIndex = 0;

              
            }
        });
    }

    getComprobantes() {
        let action = "Ingresos/GetComprobantes";
        $.ajax({
            type: "Post",
            url: action,
            data: null,
            success: (response) => {
                let count = 1;
                for (let i = 0; i < response.length; i++) {
                    document.getElementById('Comprobante').options[count] = new Option(
                        response[i].tipo, response[i].comprobanteID);
                    count++;
                }
                document.getElementById('Comprobante').selectedIndex = 0;
            }
        });
    }

    getArticulos() {
        let action = "Ingresos/GetArticulos";
        $.ajax({
            type: "Post",
            url: action,
            data: null,
            success: (response) => {
                let count = 1;
                for (let i = 0; i < response.length; i++) {
                    document.getElementById('Articulo').options[count] = new Option(
                        response[i].nombre, response[i].articuloID);
                    count++;
                }

                document.getElementById('Articulo').selectedIndex = 0;
            }
        });
    }

    addDetails() {
        let articuloID = $('#Articulo').val();
        let articulo = $('Articulo option:selected').text();
        let cantidad = document.getElementById('Cantidad').value;
        let precioCompra = document.getElementById('PrecioCompra').value;
        let precioVenta = document.getElementById('PrecioVenta').value;

        //validaciones
        if (articuloID == 0) { $('#Articulo').focus(); return false; }
        if (cantidad == "") { document.getElementById('Cantidad').focus(); return false; }
        if (precioCompra == "") { document.getElementById('PrecioCompra').focus(); return false; }  
        if (precioVenta == "") { document.getElementById('PrecioVenta').focus(); return false; }  

        let fila = "<tr id='fila_"+ contador +"'>" +
                     "<td> <a class='btn btn-warning' onclick='eliminar("+contador+")' >X</a> </td>" +
                     "<td><input type='hidden' name='ArticuloID[]' value='" + articuloID + "'>" + articulo + "</td>" +
                    "<td> <input type='number' name='cantidad[]' value='" + cantidad + "'> </td>" +
                    "<td> <input type='number' name='Pcompra[]' value='" + precioCompra + "'> </td>" +
                    "<td> <input type='number' name='Pventa[]' value='" + precioVenta + "'> </td>" +
            "</tr>";
        contador++;
        $('#tbodyDetalles').append(fila);
    }
}
