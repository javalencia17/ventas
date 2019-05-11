
class MisIngresos{

    constructor(){
    }

    loadTableMyIncome(){

        let action = "MisIngresos/loadTable";
        $.ajax({
            type: "GET",
            url: action,
            data: null,
            success: (response) => {
                document.getElementById('tbodyMisIngresos').innerHTML = response;
                var table = $('#tableMisIngresos').DataTable({
                    responsive: true
                });
            }
        });
    }


}