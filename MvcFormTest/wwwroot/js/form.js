$(document).ready(function() {
    $('#submitButton').click(function (e) {
        e.stopImmediatePropagation();
        e.preventDefault();
        
        var formData = $('#form').serialize();
        
        $.ajax({
            url: '/Home/Submit/',
            method: 'post',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: formData,
            success: function (data, textStatus, xhr) {
                var model = JSON.parse(data);
                var isFormSuccess = model.IsFormSuccess;
                var view = model.View;
                
                var container = isFormSuccess ? '#content' : '#formContent';
                $(container).html(view);
            },
        })
    });
});
