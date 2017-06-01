const HTTP_HEADER_KEY = "x-auth-key",
    KEY_STORAGE_USERNAME = "username",
    KEY_STORAGE_AUTH_KEY = "authKey";

var data = {
    getUsers() {
        return requester.getJSON("/api/users");
    },

    registerUser(user) {
        return requester.postJSON("/api/users", user);
    },

    loginUser(user) {
        return requester.putJSON("/api/users/auth/", user)
            .then(respUser => {
                localStorage.setItem("username", respUser.result.username);
                localStorage.setItem("authKey", respUser.result.authKey);
            });
    },


    getUserProfile(username) {
        return requester.getJSON(`/api/profiles/${username}`);
    },

    getMaterials() {
        return requester.getJSON("/api/materials");
        // .then(res => {
        //     res.sort((a, b) => {
        //         a.createdOn > b.createdOn;
        //     });
        // });
    },

    addMaterial(material) {
        let options = {
            headers: {
                [HTTP_HEADER_KEY]: localStorage.getItem(KEY_STORAGE_AUTH_KEY)
            }
        };
        return requester.postJSON("/api/materials", material, options);
    },

    getSpecificMaterial() {
        return requester.getJSON(`/api/materials/${id}`);
    },

    addCommentToMaterial(commentText) {
        let options = {
            headers: {
                [HTTP_HEADER_KEY]: localStorage.getItem(KEY_STORAGE_AUTH_KEY)
            }
        };
        return requester.putJSON(`/api/materials/${id}/comments`, commentText, options)
            .then(comment => {
                comment.text = commentText;
            });
    },

    getUserMaterials() {
        let options = {
            headers: {
                [HTTP_HEADER_KEY]: localStorage.getItem(KEY_STORAGE_AUTH_KEY)
            }
        };
        return requester.getJSON("/api/user-materials", options);
    },

    getWatchedMaterials() {
        let options = {
            headers: {
                [HTTP_HEADER_KEY]: localStorage.getItem(KEY_STORAGE_AUTH_KEY)
            }
        };
        return requester.getJSON("/api/user-materials/watched", options);
    },

    getWatchingMaterials() {
        let options = {
            headers: {
                [HTTP_HEADER_KEY]: localStorage.getItem(KEY_STORAGE_AUTH_KEY)
            }
        };
        return requester.getJSON("/api/user-materials/watching", options);
    },

    getWantToWatchMaterials() {
        let options = {
            headers: {
                [HTTP_HEADER_KEY]: localStorage.getItem(KEY_STORAGE_AUTH_KEY)
            }
        };
        return requester.getJSON("/api/user-materials/want-to-watch", options);
    },

    assignCategoryToMaterial(material) {
        let options = {
            headers: {
                [HTTP_HEADER_KEY]: localStorage.getItem(KEY_STORAGE_AUTH_KEY)
            }
        };
        return requester.postJSON("/api/user-materials", material, options)
            .then(respMaterial => {
                respMaterial.category = material.category;
            });
    },

    changeStatusOfMaterial(material) {
        let options = {
            headers: {
                [HTTP_HEADER_KEY]: localStorage.getItem(KEY_STORAGE_AUTH_KEY)
            }
        };
        return requester.putJSON("/api/user-materials", material, options)
            .then(respMaterial => {
                respMaterial.category = material.category;
            });
    },

    logout() {
        return Promise.resolve()
            .then(() => {
                localStorage.removeItem("username");
                localStorage.removeItem("authKey");
            });
    },

    isLoggedIn() {
        return Promise.resolve()
            .then(() => {
                return !!localStorage.getItem("username");
            });
    }
};