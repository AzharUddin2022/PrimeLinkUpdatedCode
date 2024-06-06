
/*wow Animation*/
$(document).ready(function () {
});
// When the user clicks on the button, scroll to the top of the document
function topFunction() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}
$(document).ready(function () {
    $('body').removeClass('hide-bodyScroll');
    $("#toggle").prop("checked", false);
});

function ClosePopup() {
    //$('body').removeClass('hide-bodyScroll');
    $("#toggle").prop("checked", false);
}

function AlertSuccess(message, redirectionUrl) {
    swal({
        title: "Success!",
        text: message,
        icon: "success",
        button: "Ok",
        confirmButtonColor: '#f46930',
    }).then(function () {
        if (redirectionUrl != undefined && redirectionUrl != null) {
            window.location = redirectionUrl;
        }
    });
}

function AlertError(message) {
    swal({
        title: "Error!",
        text: message,
        icon: "error",
        button: "Ok",
        confirmButtonColor: '#f46930',
    });
}

function AlertValidation(message) {
    swal({
        title: "Validation Error!",
        text: message,
        icon: "warning",
        button: "Ok",
        confirmButtonColor: '#f46930',
    });
}

//window.onload = onPageLoad();
//function onPageLoad() {
//    if (document.getElementById("toggle").checked == true) {
//        document.getElementById("toggle").checked = true;
//    } else {
//        document.getElementById("toggle").checked = false;
//    }
//}

$(window).on('popstate', function (event) {
    /*alert("pop");*/
});

function onSuccess(response) {
    AlertSuccess(response.message);
}

function onFailure(response) {
    AlertError(response.message);
}

$('.popup-btn').modal({
    backdrop: 'static',
    keyboard: false
})

function onClickVideo() {
    debugger
}