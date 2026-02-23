$(document)(function () {
    $('#createCarWorkshopServiceModal form').on('submit', function (event) {
        event.preventDefault();
        var form = $(this);
        $.ajax({
            url: form.attr('action'),
            method: form.attr('method'),
            data: form.serialize(),
            success: function (data) {
                toastr["success"]("Created carworkshop service")
            },
            error: function () {
                toastr["error"]("Something went wrong")
            }
        })
    }); 
});
