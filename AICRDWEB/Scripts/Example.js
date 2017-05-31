$(document).ready(function () {

    $('#IdCircuito').change(function () {
        $("#IdIglesia").empty();
        $.ajax({
            type: 'GET',
            url: 'http://localhost/AICRDWEB/Iglesias/IglesiasbyCircuito',
            dataType: 'json',
            data: { id: $("#IdCircuito").val() },
            success: function (iglesias) {

                $.each(iglesias.Iglesias, function (i, iglesias) {
                    $("#IdIglesia").append('<option value="'
                                               + iglesias.IdIglesia + '">'
                                         + iglesias.NombreIglesia + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed.' + ex);
            }
        });
        return false;
    })

});