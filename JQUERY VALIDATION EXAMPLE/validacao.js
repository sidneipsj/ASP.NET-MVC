//================================= AZIONE FORM
$('#submit').click(function() {
    $('#mailer').submit();
    return false;
});

//================================= VALIDAZIONE FORM
$('#mailer').validate({
    focusInvalid: false,
    debug: true,
    rules: {
        name: {
            required: true
        },
        email_address: {
            required: true,
            email: true
        },
        request: {
            required: true
        }
    },
    messages: {
        name: {
            required: 'name required'
        },
        email_address: {
            required: 'email required',
            email: 'email address is not valid'
        },
        request: {
            required: 'request required'
        }
    }
});