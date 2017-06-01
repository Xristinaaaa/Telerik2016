import { loader } from './template-loader.js';
import { data } from './data.js';

const routing = (() => {
    const router = new Navigo(null, false);

    function showMsg(msg, type, cssClass) {
        loader.get('alert')
            .then((alertTemplate) => {
                let container = $(alertTemplate).clone(true)
                    .addClass(cssClass).text(`${type}: ${msg}`)
                    .appendTo(root);
            });
    }

    function initCall() {
        router
            .on('#/home', () => {
                Promise.all([data.cookies.getCookies, loader.get('home')])
                    .then(([data, template]) => {
                        $('#content').html(template(data));
                    })
                    .catch((err) => showMsg(err, 'Error', 'Alert'));
            })
            .on('#/home?:query', (params) => {
                console.log(params);
            })
            .on('#/my-cookie', () => {
                Promise.all([data.cookies.getMyCookie, loader.get('cookie')])
                    .then(([data, template]) => {
                        $('#content').html(template(data));
                    })
                    .catch((err) => showMsg(err, 'Error', 'Alert'));
            })
            .on(() => {
                router.navigate('#/home');
            })
            .resolve();
    }

    return {
        initCall,
        showMsg
    };
})();

export { routing };