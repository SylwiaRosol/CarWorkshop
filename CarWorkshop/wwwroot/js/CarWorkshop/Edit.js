$(document).ready(function () {


    LoadCarWorkshopServices();

    $('#createCarWorkshopServiceModal form').on('submit', function (event) {
        event.preventDefault();
        var form = $(this);
        $.ajax({
            url: form.attr('action'),
            type: form.attr('method'),
            data: form.serialize(),
            success: function (data) {
                toastr["success"]("Created carworkshop service")
                LoadCarWorkshopServices();
            },
            error: function () {
                toastr["error"]("Something went wrong")
            }
        })
    }) 
})
