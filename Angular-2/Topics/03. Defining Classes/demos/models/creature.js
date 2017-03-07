"use strict";
var Creature = (function () {
    function Creature(name, damage, health) {
        this.name = name;
        this.damage = damage;
        this.health = health;
    }
    Object.defineProperty(Creature.prototype, "name", {
        get: function () {
            return this._name;
        },
        set: function (newName) {
            if (Creature.IsNameValid(newName) === false) {
                throw new Error("Invalid Superhero name");
            }
            this._name = newName;
        },
        enumerable: true,
        configurable: true
    });
    Creature.IsNameValid = function (name) {
        if (name === null ||
            name.length < 3 ||
            name.length > 30) {
            return false;
        }
        return true;
    };
    return Creature;
}());
exports.Creature = Creature;
