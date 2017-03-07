"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Creature_1 = require("./Creature");
var Superhero = (function (_super) {
    __extends(Superhero, _super);
    function Superhero(name, secretIdentity, damage, health) {
        var powers = [];
        for (var _i = 4; _i < arguments.length; _i++) {
            powers[_i - 4] = arguments[_i];
        }
        var _this = _super.call(this, name, damage, health) || this;
        _this.secretIdentity = secretIdentity;
        _this.powers = powers;
        return _this;
    }
    Superhero.prototype.usePower = function (powerName, target) {
        var power = this.powers.find(function (p) { return p.name.toLowerCase() == powerName.toLowerCase(); });
        if (!power) {
            throw new Error(this.name + " cannot user " + powerName);
        }
        if (target) {
            target.takeHit(power.damage);
        }
        return this.name + " uses " + power.name;
    };
    Superhero.prototype.hit = function (other) {
        other.takeHit(this.damage);
        return this.name + " hits";
    };
    Superhero.prototype.takeHit = function (damage) {
        this.health -= damage;
    };
    return Superhero;
}(Creature_1.Creature));
exports.Superhero = Superhero;
