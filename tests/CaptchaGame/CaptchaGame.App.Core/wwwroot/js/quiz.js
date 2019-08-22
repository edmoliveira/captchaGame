let saveBtn = $('#saveButton').get(0);

$(saveBtn).prop('disabled', true);
$(saveBtn).addClass('btn-secondary');
$(saveBtn).removeClass('btn-primary');


saveBtn.cptChange = (ok) => {
    if (ok) {
        $(saveBtn).prop('disabled', false);
        $(saveBtn).removeClass('btn-secondary');
        $(saveBtn).addClass('btn-primary');
    }
}

$(window).resize(function () {
    saveBtn.cptRefresh();
})

$(document).ready(() => {
    if ($('#erroLabel').text() != '') {
        $('.captchaError').slideDown().delay(1500).slideUp();
    }
});
