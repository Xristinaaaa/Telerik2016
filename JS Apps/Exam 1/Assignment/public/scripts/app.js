const router = new Navigo(null, false);

let controllersInstance = controllers.get(data, loader);

router
    .on("login", controllersInstance.login)
    .on("home", controllersInstance.home)
    .on("materials", controllersInstance.materials)
    .on("users", controllersInstance.users)
    .on("profile", controllersInstance.profile)
    .on(() => {
        $("#navbar navbar-default row").addClass("active");
        router.navigate("/home");
    })
    .resolve();

data.isLoggedIn()
    .then(function(isLoggedIn) {
        if (isLoggedIn) {
            $(document.body).addClass("logged-in");
        }
    });

$("#btn-log-out").on("click", () => {
    data.logout()
        .then(() => {
            $(document.body).removeClass("logged-in");
        });
});

$(".container").on("click", "li", function(ev) {
    $(".container .active").removeClass("active");
    $(this).addClass("active");
});