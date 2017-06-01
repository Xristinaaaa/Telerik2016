let controllers = {
    get(data, loader) {
        return {
            home() {

                data.isLoggedIn()
                    .then(isLoggedIn => {
                        if (isLoggedIn) {
                            loader.get("profile")
                                .then((template) => {
                                    $("#content").html(template);

                                    $("#btn-create").on("click", function() {
                                        let title = $("#title").val();
                                        let description = $(".material").val();
                                        data.addMaterial({ title, description });
                                    });

                                    $("#btn-leave").on('click', function() {
                                        let comment = $(".comment").val();
                                        data.addCommentToMaterial(comment);
                                    });
                                });
                        } else {
                            return;
                        }
                    });
            },
            users() {
                loader.get("users")
                    .then((template) => {
                        $("#content").html(template);

                        data.getUsers();
                    });

            },
            materials() {
                loader.get("materials")
                    .then((template) => {
                        $("#content").html(template);

                        $("btn-search").on('click', function() {
                            let material = $("#specific-search").val();

                            Validator.validateString(material.title);
                            Validator.validateLengthOfString(material.title, 6, 100);
                            Validator.validateString(material.description);

                            data.getMaterials()
                                .find(x => x.id == material.id);
                        });

                        data.getMaterials();
                    });
            },
            profile() {
                data.isLoggedIn()
                    .then(isLoggedIn => {
                        if (isLoggedIn) {
                            loader.get("profile")
                                .then((template) => {
                                    $("#content").html(template);

                                    let username = $("#tb-username").val();
                                    data.getUserProfile(username);
                                })
                                .then(
                                    data.getUserMaterials()
                                );
                        } else {
                            return;
                        }
                    });
            },
            login() {
                data.isLoggedIn()
                    .then(isLoggedIn => {
                        if (isLoggedIn) {
                            window.location = "#/home";
                            return;
                        }

                        loader.get("login")
                            .then((template) => {
                                $("#content").html(template);

                                $("#btn-login").on("click", (ev) => {
                                    let user = {
                                        username: $("#tb-username").val(),
                                        passHash: $("#tb-password").val()
                                    };

                                    Validator.validateString(username);
                                    Validator.validateString(passHash);
                                    Validator.validateLengthOfString(username, 6, 30);
                                    Validator.validateLatinLetters(username);
                                    Validator.validateLengthOfString(passHash, 6, 30);
                                    Validator.validateLatinLetters(passHash);

                                    data.loginUser(user)
                                        .then((respUser) => {
                                            $(document.body).addClass("logged-in");
                                            document.location = "#/home";
                                        });
                                    $("#tb-password").text('');
                                    $("#tb-password").text('');

                                    ev.preventDefault();
                                    return false;
                                });

                                $("#btn-register").on("click", (ev) => {
                                    let user = {
                                        username: $("#tb-username").val(),
                                        passHash: $("#tb-password").val()
                                    };

                                    Validator.validateString(username);
                                    Validator.validateString(passHash);
                                    Validator.validateLengthOfString(username, 6, 30);
                                    Validator.validateLatinLetters(username);
                                    Validator.validateLengthOfString(passHash, 6, 30);
                                    Validator.validateLatinLetters(passHash);

                                    data.registerUser(user)
                                        .then((respUser) => {
                                            return data.login(user);
                                        })
                                        .then((respUser) => {
                                            $(document.body).addClass("logged-in");
                                            document.location = "#/home";
                                        });

                                    $("#tb-password").text('');
                                    $("#tb-password").text('');

                                    ev.preventDefault();
                                    return false;
                                });

                            });
                    });
            }
        };
    }
};