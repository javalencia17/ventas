let contador = 0;
let total = 0;
let sub = [];
var arrayTipo = [];

class Ingreso {

    constructor() {

    }

    cargarSelects() {
        this.getProveedores();
        //this.getComprobantes();
        this.getArticulos();
        $('.select2').select2();

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
        let articulo = $('#Articulo option:selected').text();
        let cantidad = document.getElementById('Cantidad').value;
        let precioCompra = document.getElementById('PrecioCompra').value;
        let precioVenta = document.getElementById('PrecioVenta').value;
        

        //validaciones
        if (articuloID == 0) { $('#Articulo').focus(); return false; }
        if (cantidad == "") { document.getElementById('Cantidad').focus(); return false; }
        if (precioCompra == "") { document.getElementById('PrecioCompra').focus(); return false; }  
        if (precioVenta == "") { document.getElementById('PrecioVenta').focus(); return false; }  

        let fila = "<tr id='" + contador + "," + articuloID + "," + cantidad + "," + precioCompra +
                    "," + precioVenta +"'>" +
                    "<td> <a class='btn btn-warning' onclick='eliminarFila(this)' >X</a> </td>" +
                    "<td>" + articulo + "</td>" +
                    "<td> " + cantidad + "</td>" +
                    "<td> " + precioCompra + " </td>" +
                    "<td> " + precioVenta + "</td>" +
                    "<td> <p id='subtotal_"+ contador +"'> 0 </p> </td>" +
                    "</tr>";
        $('#tbodyDetalles').append(fila);
        this.cargarSubtotal(contador, cantidad, precioCompra)
        contador++;
        this.cleanDetails();
    }

    cargarSubtotal(fila, cantidad, precio) {
        let subtotal = cantidad * precio;
        sub[fila] = subtotal;
        document.getElementById('subtotal_' + fila).innerHTML = subtotal;
        this.calcularTotal();
    }


    cleanDetails() {
        document.getElementById('Articulo').selectedIndex = 0;
        $('#Cantidad').val("");
        $('#PrecioCompra').val("");
        $('#PrecioVenta').val("");
    }

 


    eliminarFila(btn) {
        var row = btn.parentNode.parentNode;
        row.parentNode.removeChild(row);
        this.calcularTotal();
    }

    calcularTotal() {
        let valores = [];
        $('#tablaDetails tbody tr').each(function () {
            let nombre = $(this).attr("id");
            valores.push(nombre);
        });
    
        let total = 0;
        for (var i = 0; i < valores.length ; i++) {
            var temp = valores[i].split(",");
            total = total + (temp[2] * temp[3]); 
        }
        
        document.getElementById('Total').innerHTML = total;
        
    }

    guardarIngresos() {
        let action = 'Ingresos/GuardarIngresos';
        let proveedor = $('#Proveedor').val();
        let comprobante = $('#Comprobante').val();
        let serie = document.getElementById('Serie').value;
        let numero = document.getElementById('Numero').value;
        let items = [];
        let detalles = [];

        $('#tablaDetails tbody tr').each(function () {
            let nombre = $(this).attr("id");
            items.push(nombre);
        });


        for (let i = 0; i < items.length; i++) {
            let temp = items[i].split(",");

            var detalle = {
                Cantidad: temp[2],
                PrecioCompra: temp[3],
                PrecioVenta: temp[4],
                ArticuloID: temp[1]
            };

            detalles.push(detalle);
        }

        let ingreso = {
            proveedor,
            comprobante,
            serie,
            numero,
            detalles: detalles
        };

        
        
       
        $.ajax({
            type: "POST",
            url: action,
            data: ingreso,
            success: (response) => {
                console.log(response);
                if (response[0].code == "SAVE") {
                    this.ClearInputs();
                    swal("buen Trabajo!", "Datos guardados correctamente!", "success");
                } else {
                    console.log(response[0].description);
                }
            }
        });
    }

    ClearInputs() {
        $('#Proveedor').val('0'); // Select the option with a value of '1'
        $('#Proveedor').trigger('change'); // Notify any JS components that the value changed
        $('#Comprobante').val('0'); // Select the option with a value of '1'
        $('#Comprobante').trigger('change'); // Notify any JS components that the value changed
        $('#Articulo').val('0'); // Select the option with a value of '1'
        $('#Articulo').trigger('change'); // Notify any JS components that the value changed
        document.getElementById('Serie').value = "";
        document.getElementById('Numero').value = "";
        document.getElementById('Cantidad').value = "";
        document.getElementById('PrecioCompra').value = "";
        document.getElementById('PrecioVenta').value = "";
        $("#tbodyDetalles tr").remove();
        document.getElementById('Total').value = "";

    }


}
