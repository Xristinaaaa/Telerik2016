import { requester } from './requester.js';
import { routing } from './navigo.js';

const HTTP_HEADER_KEY = "x-auth-key",
    KEY_STORAGE_USERNAME = "username",
    KEY_STORAGE_AUTH_KEY = "authKey";

const data = (() => {
    function getUsers() {
        return requester.getJSON('api/users');
    }

    function registerUser(user) {
        return requester.postJSON('api/users', user);
    }

    function loginUser(user) {
        return requester.putJSON('api/auth', user)
            .then((loggedUser) => {
                localStorage.setItem("username", loggedUser.result.username);
                localStorage.setItem("authKey", loggedUser.result.authKey);
            });
    }

    function logout() {
        return Promise.resolve()
            .then(() => {
                localStorage.removeItem("username");
                localStorage.removeItem("authKey");
            });
    }

    function isLoggedIn() {
        return Promise.resolve()
            .then(() => {
                return !!localStorage.getItem("username");
            });
    }

    function getCookies() {
        return requester.getJSON('api/cookies');
    }

    function shareCookie(cookie) {
        let options = {
            headers: {
                [HTTP_HEADER_KEY]: localStorage.getItem(KEY_STORAGE_AUTH_KEY)
            }
        };
        return requester.postJSON('api/cookies', cookie, options);
    }

    function rateCookie(cookieId, cookieType) {
        let options = {
            headers: {
                [HTTP_HEADER_KEY]: localStorage.getItem(KEY_STORAGE_AUTH_KEY)
            }
        };
        return requester.putJSON(`api/cookies/${cookieId}`, { cookieType }, options);
    }

    function getMyCookie() {
        return requester.getJSON('api/my-cookie');
    }

    function getCattegories() {
        return requester.get('api/categories');
    }

    return {
        users: {
            getUsers,
            registerUser,
            loginUser,
            logout,
            isLoggedIn
        },
        cookies: {
            getCookies,
            getMyCookie,
            shareCookie,
            rateCookie
        },
        cattegories: {
            getCattegories
        }
    };
});

export { data };