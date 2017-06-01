import { data } from './data.js';
import { routing } from './navigo.js';

$(() => {
    routing.initCall();

    dataService.isLoggedIn()
        .then(function(isLoggedIn) {
            if (isLoggedIn) {
                $(document.body).addClass("logged-in");
            }
        });

    $(".btn-nav-logout").on("click", () => {
        dataService.logout()
            .then(() => {
                $(document.body).removeClass("logged-in");
            });
    });

    $("#main-nav").on("click", "li", function(ev) {
        $("#main-nav .active").removeClass("active");
        $(this).addClass("active");
    });

    $(function() {
        $("#main-nav .active").removeClass("active");
        let $currentPageNavButton = $(`#main-nav a[href="${window.location.hash}"]`).parents("li");
        $currentPageNavButton.addClass("active");
    });
});