function solve() {
    return function() {
        var template = `
        <ul class="nav">
            {{#if logo}}
                {{#logo}}
                    <li class="nav-item logo">
                        <a href="{{url}}">
                            <img src="./{{image}}">
                        </a>
                    </li>
                {{/logo}}
            {{/if}}
            {{#items}}            
                <li class="nav-item">
                    <a href="{{url}}">{{title}}</a>
                </li>
                {{#if items}}
                    <ul class="subnav">
                        {{#items}}
                            <li class="nav-item">
                                <a href="{{url}}">{{title}}</a>
                            </li>
                        {{/items}}
                    </ul>
                {{/if}}
            {{/items}}
        </ul>
        `;
        return template;
    };
}

module.exports = solve;