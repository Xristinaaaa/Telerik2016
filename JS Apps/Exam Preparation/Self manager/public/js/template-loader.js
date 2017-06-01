const loader = (() => {
    const cache = {};

    function get(templateName) {
        return new Promise((resolve, reject) => {
            if (cache[templateName]) {
                resolve(Handlebars.compile(cache[templateName]));
            }

            $.get(`./templates/${templateName}.handlebars`, template => {
                cache[templateName] = template;
                resolve(Handlebars.compile(template));
            });
        });
    }

    return {
        get
    };
})();

export { loader };