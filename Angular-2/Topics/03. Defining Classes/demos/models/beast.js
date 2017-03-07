"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Creature_1 = require("./Creature");
var Beast = (function (_super) {
    __extends(Beast, _super);
    function Beast(name, power, health) {
        return _super.call(this, name, power, health) || this;
    }
    Object.defineProperty(Beast.prototype, "power", {
        get: function () {
            return this.damage;
        },
        set: function (power) {
            this.damage = power;
        },
        enumerable: true,
        configurable: true
    });
    Beast.prototype.hit = function (other) {
        var creatureHit = this.name + " hits with power " + this.power;
        other.takeHit(this.power);
        return creatureHit;
    };
    Beast.prototype.takeHit = function (damage) {
        this.health += damage;
    };
    return Beast;
}(Creature_1.Creature));
exports.Beast = Beast;
