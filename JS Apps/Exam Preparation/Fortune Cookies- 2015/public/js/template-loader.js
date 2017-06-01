var handlebars = handlebars || Handlebars;

const loader = (() => {
    const cache = {};

    function get(templateName) {
        return new Promise((resolve, reject) => {
            if (cache[templateName]) {
                resolve(handlebars.compile(cache[templateName]));
            }

            $.get(`./templates/${templateName}.handlebars`, template => {
                cache[templateName] = template;
                resolve(handlebars.compile(template));
            });
        });
    }

    return {
        get
    };
})();

export { loader };