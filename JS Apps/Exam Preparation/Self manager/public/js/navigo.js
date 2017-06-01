import { data } from './data.js';
import { loader } from './template-loader.js';

var routing = (() => {
    var router;

    function showMsg(msg, type, cssClass) {
        loader.get('alert')
            .then((alertTemplate) => {
                let container = $(alertTemplate).clone(true)
                    .addClass(cssClass).text(`${type}: ${msg}`)
                    .appendTo(root);
            });
    }

    function initCall() {
        router= new Navigo(null, false);
        router
            .on('/home', () => {
                Promise.all()
                    .catch((err) => showMsg(err, 'Error', 'Alert'));
            })
            .on('/todos', () => {

            })
            .on('/events', () => {

            })
            .resolve();
    }

    return {
        initCall,
        showMsg
    };
})();

export { routing };