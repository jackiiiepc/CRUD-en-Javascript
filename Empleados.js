/// <reference path="SubCategoriaCRUD.js" />
$(document).ready(function () {
     GetAll();
     
     //Add();
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:26351/api/empleado/GetAll', // '@Url.Action("GetAll", "SubCategoria")',     
        success: function (result) { //200 OK
            $('#Empleados tbody').empty();
            $.each(result.Objects, function (i, empleado) {
                var filas =
                    '<tr>'
                        + '<td class="text-center"> '
                            + '<a href="#" onclick="GetById(' + empleado.IdEmpleado + ')">'
                                + '<img  style="height: 25px; width: 25px;" src="../imagen/editar.png" />'
                            + '</a> '
                        + '</td>'
                        + "<td  id='id' class='text-center'>" + empleado.IdEmpleado + "</td>"
                        + "<td class='text-center'>" + empleado.Nombre + "</td>"
                        + "<td class='text-center'>" + empleado.ApellidoPaterno + "</ td>"
                        + "<td class='text-center'>" + empleado.ApellidoMaterno + "</ td>"
                         + "<td class='text-center'>" + empleado.NumeroNomina + "</ td>"
                        + "<td class='text-center'>" + empleado.Entidad.IdEntidad + "</td>"
                        //+ '<td class="text-center">  <a href="#" onclick="return Eliminar(' + subCategoria.IdSubCategoria + ')">' + '<img  style="height: 25px; width: 25px;" src="../img/delete.png" />' + '</a>    </td>'
                        + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + empleado.IdEmpleado + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#Empleados tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function EstadoGetAll() {
    $("#ddlEstados").empty();
    $.ajax({
        type: 'GET',
        url: 'http://localhost:26351/api/estado/GetAll',
        success: function (result) {
            $("#ddlEstados").append('<option value="' + 0 + '">' + 'Seleccione una opción' + '</option>');
            $.each(result.Objects, function (i, estado) {
                $("#ddlEstados").append('<option value="'
                                           + estado.IdEntidad + '">'
                                           + estado.Estado + '</option>');
            });
        }
    });
}

function ShowModal() {
    $('#modalForm').modal('show');
    EstadoGetAll();
    InitializeControls();
    $('#lblTitulo').text("Agregar Empleado");

}
function Add(empleado) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:26351/api/empleado/Add',
        dataType: 'json',
        data: empleado,
        success: function (result) {
            $('#myModal').modal();
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function InitializeControls() {
    $('#txtIdEmpleado').val("");
    $('#txtNumeroNomina').val("");
    $('#txtNombre').val("");
    $('#txtApellidoPaterno').val("");
    $('#txtApellidoMaterno').val("");
    $('#txtIdEntidad').val(0);
}

function GetById(IdEmpleado) {
    EstadoGetAll();

    $.ajax(
        {
        type: 'GET',
        url: 'http://localhost:26351/api/empleado/GetById/' + IdEmpleado,
        success: function (result) {
           
            $('#modalForm').modal('show');
            $('#lblTitulo').text("Actualizar Empleado");

            $('#txtIdEmpleado').val(result.Object.IdEmpleado);
            $('#txtNumeroNomina').val(result.Object.NumeroNomina);
            $('#txtNombre').val(result.Object.Nombre);
            $('#txtApellidoPaterno').val(result.Object.ApellidoPaterno);
            $('#txtApellidoMaterno').val(result.Object.ApellidoMaterno);           
            $('#ddlEstados').val(result.Object.Entidad.IdEntidad);

           // $('#modalForm').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });

}

function Guardar() {
    var txtIdEmpleado = $('#txtIdEmpleado').val();
    var txtNumeroNomina = $('#txtNumeroNomina').val(); //GetElementById

    var empleado = {
        IdEmpleado: txtIdEmpleado,
        NumeroNomina: txtNumeroNomina,
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApellidoPaterno').val(),
        ApellidoMaterno: $('#txtApellidoMaterno').val(),
        Entidad: {
            IdEntidad: $('#ddlEstados').val()
        }
    }
        
    if ($('#txtIdEmpleado').val() == "")
    {
        Add(empleado)
    }
    else
    {
        Update(empleado)
    }
}




function Update(empleado) {

    $.ajax({
        type: 'POST',
        url: 'http://localhost:26351/api/empleado/Update',
        datatype: 'json',
        data: empleado,
        success: function (result) {
            $('#myModal').modal();
            $('#modalForm').modal('hide');
            GetAll();
            Console(respond);
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });

};

function Eliminar(IdEmpleado) {

    if (confirm("¿Estas seguro de eliminar el empleado seleccionado?")) {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:26351/api/empleado/Delete/' + IdEmpleado,
            success: function (result) {
                $('#myModal').modal();
                GetList();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });

    };
};