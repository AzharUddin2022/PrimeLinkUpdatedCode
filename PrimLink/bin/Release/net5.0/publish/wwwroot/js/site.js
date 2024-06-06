// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    setupAJAX();

    //$(function () {
    //  $('.nav-sidebar li a').filter(function () { return this.href == location.href }).parent().addclass('test-ovais').siblings().removeclass('test-ovais')
    //$('.nav-sidebar li a').click(function () {
    //  $(this).parent().addclass('test-ovais').siblings().removeclass('test-ovais')
    //})
    //})

});
function setupAJAX() {
    htmlLoader = '<div class="k-loading-mask" style="width: 100%; height: 100%; top: 0px; left: 0px;"><span class="k-loading-text">Loading...</span><div class="k-loading-image"></div><div class="k-loading-color"></div></div>';

    $.ajaxSetup({
        cache: false   // Disable caching of AJAX responses wrapper
    });

    $(document).ajaxStart(function () {
        $("#divLoader").append(htmlLoader);
    });

    $(document).ajaxSuccess(function () {
        //$("#divLoader").html("");
        $('[data-toggle="tooltip"]').tooltip();
    });

    $(document).ajaxError(function (x, e) {
        $("#divLoader").html("");
        if (e.status == 401) {
            window.location.href = "/account/login";
        }
    });
    $(document).ajaxStop(function (x, e) {
        $("#divLoader").html("");
    });
    $(document).ajaxComplete(function () {
        $("#divLoader").html("");
        $('[data-toggle="tooltip"]').tooltip();

    });

}