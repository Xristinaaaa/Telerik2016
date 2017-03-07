"use strict";
var superhero_1 = require("./models/superhero");
var beast_1 = require("./models/beast");
function hitting(first, second) {
    console.log(first.hit(second));
}
var spiderman = new superhero_1.Superhero("Spiderman", "Peter Parker", 7, 60);
var crypto = new beast_1.Beast("Crypto", 11, Number.MAX_VALUE);
hitting(crypto, spiderman);
hitting(spiderman, crypto);
