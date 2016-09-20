function solve() {
    'use strict';

    const ERROR_MESSAGES = {
        INVALID_NAME_TYPE: 'Name must be string!',
        INVALID_NAME_LENGTH: 'Name must be between between 2 and 20 symbols long!',
        INVALID_NAME_SYMBOLS: 'Name can contain only latin symbols and whitespaces!',
        INVALID_MANA: 'Mana must be a positive integer number!',
        INVALID_EFFECT: 'Effect must be a function with 1 parameter!',
        INVALID_DAMAGE: 'Damage must be a positive number that is at most 100!',
        INVALID_HEALTH: 'Health must be a positive number that is at most 200!',
        INVALID_SPEED: 'Speed must be a positive number that is at most 100!',
        INVALID_COUNT: 'Count must be a positive integer number!',
        INVALID_SPELL_OBJECT: 'Passed objects must be Spell-like objects!',
        NOT_ENOUGH_MANA: 'Not enough mana!',
        TARGET_NOT_FOUND: 'Target not found!',
        INVALID_BATTLE_PARTICIPANT: 'Battle participants must be ArmyUnit-like!'
    };

    // your implementation goes here

    const generateId = (function () {
        var id = 0;

        return function () {
            id++;
            return id;
        };
    })();
    class Spell {
        constructor(name, manaCost, effect) {
            this.name = name;
            this.manaCost = manaCost;
            this.effect = effect = function (ArmyUnit) { };
        }

        get name() {
            return this._name;
        }
        set name(name) {
            if (typeof name !== 'string') {
                throw ERROR_MESSAGES.INVALID_NAME_TYPE;
            }
            if (name.length < 2 || 20 < name.length) {
                throw ERROR_MESSAGES.INVALID_NAME_LENGTH;
            }
            if (!name.match(/^\w@.-/)) {
                throw ERROR_MESSAGES.INVALID_NAME_SYMBOLS;
            }

            this._name = name;
        }

        get manaCost() {
            return this._manaCost;
        }
        set manaCost(manaCost) {
            if (typeof manaCost !== 'number' || manaCost < 0) {
                throw ERROR_MESSAGES.INVALID_MANA;
            }
            this._manaCost = manaCost;
        }

        get effect() {
            return this._effect;
        }
        set effect(func) {
            if (!(func instanceof Function) || func.arguments.length === 0) {
                throw ERROR_MESSAGES.INVALID_EFFECT;
            }

            this._effect = func;
        }
    }

    class Unit {
        constructor(name, alignment) {
            this.name = name;
            this.alignment = alignment;
        }

        get name() {
            return this._name;
        }
        set name(name) {
            if (typeof name !== 'string') {
                throw ERROR_MESSAGES.INVALID_NAME_TYPE;
            }
            if (name.length < 2 || 20 < name.length) {
                throw ERROR_MESSAGES.INVALID_NAME_LENGTH;
            }
            if (!name.match(/^\w@.-/)) {
                throw ERROR_MESSAGES.INVALID_NAME_SYMBOLS;
            }

            this._name = name;
        }

        get alignment() {
            return this._alignment;
        }
        set alignment(alignment) {
            if (typeof alignment !== 'string') {
                throw new Error(alignment + ' is not a string.');
            }
            if (alignment !== 'good' || alignment !== 'neutral' || alignment !== 'evil') {
                throw new Error('Alignment must be good, neutral or evil!');
            }

            this._alignment = alignment;
        }
    }

    class ArmyUnit extends Unit {
        constructor(name, alignment, damage, health, count, speed) {
            super(name, alignment);
            this.id = generateId();
            this.damage = damage;
            this.health = health;
            this.count = count;
            this.speed = speed;
        }

        get damage() {
            return this._damage;
        }
        set damage(damage) {
            if (damage < 0 || 100 < damage) {
                throw ERROR_MESSAGES.INVALID_DAMAGE;
            }
            this._damage = damage;
        }

        get health() {
            return this._health;
        }
        set health(health) {
            if (health < 0 || 200 < health) {
                throw ERROR_MESSAGES.INVALID_HEALTH;
            }

            this._health = health;
        }

        get count() {
            return this._count;
        }
        set count(count) {
            if (count < 0) {
                throw ERROR_MESSAGES.INVALID_COUNT;
            }
            this._count = count;
        }

        get speed() {
            return this._speed;
        }
        set speed(speed) {
            if (speed < 0 || 100 < speed) {
                throw ERROR_MESSAGES.INVALID_SPEED;
            }
            this._speed = speed;
        }

    }

    class Commander extends Unit {
        constructor(name, alignment, mana, spellbook, army) {
            super(name, alignment);
            this.mana = mana;
            this.spellbook = spellbook;
            this.army = army;
        }

        get mana() {
            return this._mana;
        }
        set mana(mana) {
            if (typeof mana !== 'number' || mana < 0) {
                throw ERROR_MESSAGES.INVALID_MANA;
            }
            this._mana = mana;
        }

        get spellbook() {
            return this._spellbook;
        }
        set spellbook(spellbook) {
            for (var item of spellbook) {
                if (!(item instanceof Spell)) {
                    throw ERROR_MESSAGES.INVALID_SPELL_OBJECT;
                }
            }

            this._spellbook = spellbook;
        }

        get army() {
            return this._army;
        }
        set army(army) {
            for (var item of army) {
                if (!(item instanceof ArmyUnit)) {
                    throw ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT;
                }
            }
            this._army = army;
        }
    }

    const battlemanager = {
        getCommander(name, alignment, mana) {
            return new Commander(name, alignment, mana);
        },
        getArmyUnit(options) {
            return new ArmyUnit(options.name, options.alignment, options.damage, options.health,
                options.count, options.speed);
        },
        getSpell(name, manaCost, effect) {
            return new Spell(name, manaCost, effect);
        },
        addCommanders(commanders) {
            var commandersOnBoard = [];
            var commanderToAdd;

            for (var i = 0, len = commanders.length; i < len; i += 1) {
                commanderToAdd = getCommander();
                commandersOnBoard.push(commanderToAdd);
            }

            return this;
        },
        addArmyUnitTo(commanderName, armyUnit) {
            var com = new Commander(commanderName);
            var armyUnitCreation = getArmyUnit(armyUnit);
            com.army.add(armyUnitCreation);
            return this;
        },
        addSpellsTo(...options) {
            var first = options[0];
            var second = options[1];

            var com = new Commander(first);

            for (var i = 0, len = second.length; i < len; i += 1) {
                if (!(options[i] instanceof Spell)) {
                    throw ERROR_MESSAGES.INVALID_SPELL_OBJECT;
                }
                com.spellbook.add(options[i]);                
            }
            return this;
        }
    };

    return battlemanager;
}

module.exports = solve;