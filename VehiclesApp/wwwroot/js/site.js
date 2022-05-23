// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.delMake').click(function () {
    var element = $(this);
    var makeToDeleteId = element.attr('id').split('_')[1];
    $.ajax({
        url: '/VehicleMake/GetVehicleMakeById?vehicleId=' + makeToDeleteId,
        cache: false,
        dataType: "text",
        success: function (result) {
            obj = JSON.parse(result);
            if (confirm("Are you sure you want to delete make " + obj.name + "?")) {
                $.ajax({
                    url: '/VehicleMake/DeleteVehicleMake?vehicleId=' + makeToDeleteId,
                    cache: false,
                    dataType: "text",
                    success: function (result) {
                        element.parent().parent().remove();
                    },
                    error: function (result) {
                        alert("Could not delete make " + obj.name);
                    }
                });
            }
        }
    });
    return false;
});
$('#sort_make_name_asc').click(function () {
    location = '/VehicleMake/Index?sort=name&direction=ascending';
    return false;
});
$('#sort_make_name_desc').click(function () {
    location = '/VehicleMake/Index?sort=name&direction=descending';
    return false;
});
$('#sort_make_abrv_asc').click(function () {
    location = '/VehicleMake/Index?sort=abrv&direction=ascending';
    return false;
});
$('#sort_make_abrv_desc').click(function () {
    location = '/VehicleMake/Index?sort=abrv&direction=descending';
    return false;
});