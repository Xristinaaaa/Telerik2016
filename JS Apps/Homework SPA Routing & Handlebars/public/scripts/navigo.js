import { data } from './data.js';
import { loader } from './template-loader.js';

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
            .on('/threads/:id', (params) => {
                let threadId = params.id;
                Promise.all([data.threads.getById(threadId), loader.get('messages')])
                    .then(([data, template]) => {
                        $('#content').append(template(data));
                    })
                    .catch((err) => showMsg(err, 'Error', 'Alert'));
            })
            .on('/threads', () => {
                Promise.all([data.threads.get(), loader.get('thread')])
                    .then(([data, template]) => {
                        $('#content').html(template(data));
                    })
                    .catch((err) => showMsg(err, 'Error', 'Alert'));
            })
            .on('/gallery', () => {
                Promise.all([data.gallery.get(), loader.get('gallery')])
                    .then(([data, template]) => {
                        $('#content').html(template(data));
                    })
                    .catch((err) => showMsg(err, 'Error', 'Alert'));
            })
            .resolve();
    }

    return {
        initCall,
        showMsg
    };
})();

export { routing };