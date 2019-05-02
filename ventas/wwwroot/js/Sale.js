contador = 0;
total = 0;

class Sale {

    constructor() {

    }

    cargarSelects() {
        this.selectClients();
        this.selectArticles();
        $(".select2").select2();
    }

    selectClients() {
        let action = "Sale/GetClients";
        $.ajax({
            type: "Post",
            url: action,
            data: null,
            success: (response) => {
                let count = 1;
                for (var i = 0; i < response.length; i++) {
                    document.getElementById('Cliente').options[count] = new Option(
                        response[i].nombre, response[i].personaID);
                    count++;
                }
                document.getElementById('Cliente').selectedIndex = 0; 
                
                
            }
        });
    }


    selectArticles() {
        let action = "Sale/GetArticles";
        $.ajax({
            type: "Get",
            url: action,
            data: null,
            success: (response) => {
                let count = 1;
                for (var i = 0; i < response.length; i++) {
                    document.getElementById('Articulo').options[count] = new Option(
                        response[i].nombre, response[i].articuloID);
                    count++;
                }
                document.getElementById('Articulo').selectedIndex = 0;

            
            }
        });
    }


    addDetalles() {
        let articuloID = $('#Articulo').val();
        let articulo = $('#Articulo option:selected').text();
        let cantidad = $('#Cantidad').val();
        let precioVenta = $('#PrecioVenta').val(); 

        let fila = "<tr id='" + contador + "," + articuloID + "," + cantidad + "," + precioVenta + "'>" +
                        "<td> <a class='btn btn-warning' onclick='deleteRow(this)'>X</a> </td>" +
                        "<td>" + articulo + "</td>" +
                        "<td>" + cantidad + "</td>" +
                        "<td>" + precioVenta + "</td>" +
                        "<td> <p id='subtotal_" + contador + "' > 0 </p> </td>"
                    "</tr>";
        $('#tbodyDetalles').append(fila);
        this.cargarSubtotal(contador, cantidad, precioVenta)
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
        $('#PrecioVenta').val("");
    }

    calcularTotal() {
        let valores = [];
        $('#tablaDetails tbody tr').each(function () {
            let nombre = $(this).attr("id");
            valores.push(nombre);
        });

        let total = 0;
        for (var i = 0; i < valores.length; i++) {
            var temp = valores[i].split(",");
            total = total + (temp[2] * temp[3]);
        }

        document.getElementById('Total').innerHTML = total;

    }

    deleteRow(btn) {
        var row = btn.parentNode.parentNode;
        row.parentNode.removeChild(row);
        this.calcularTotal();
    }

    saveSale() {
        let cliente = $('#Cliente').val();
        let comprobante = $('#Comprobante').val();
        let serie = document.getElementById('Serie').value;
        let numero = document.getElementById('numero').value;
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
                PrecioVenta: temp[3],
                ArticuloID: temp[1]
            };
            detalles.push(detalle);
        }

        let venta = {
            cliente,
            comprobante,
            serie,
            numero,
            detalles: detalles
        };

        $.ajax({
            type: "POST",
            url: action,
            data: venta,
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
        $('#Cliente').val('0'); // Select the option with a value of '1'
        $('#Cliente').trigger('change'); // Notify any JS components that the value changed
        $('#Comprobante').val('0'); // Select the option with a value of '1'
        $('#Comprobante').trigger('change'); // Notify any JS components that the value changed
        $('#Articulo').val('0'); // Select the option with a value of '1'
        $('#Articulo').trigger('change'); // Notify any JS components that the value changed
        document.getElementById('Serie').value = "";
        document.getElementById('Numero').value = "";
        document.getElementById('Cantidad').value = "";
        document.getElementById('PrecioVenta').value = "";
        $("#tbodyDetalles tr").remove();
        document.getElementById('Total').value = "";

    }
}