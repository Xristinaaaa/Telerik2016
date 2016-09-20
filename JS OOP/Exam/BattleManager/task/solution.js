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
    const validator = {
        validateName(name) {
            const invalidType = typeof name !== 'string';

            if (invalidType) {
                throw new Error(ERROR_MESSAGES.INVALID_NAME_TYPE);
            }

            validator.validateRange(name.length, 2, 20, ERROR_MESSAGES.INVALID_NAME_LENGTH);

            const invalidSymbols = /[^a-zA-Z ]/.test(name);

            if (invalidSymbols) {
                throw new Error(ERROR_MESSAGES.INVALID_NAME_SYMBOLS);
            }
        },
        validateMana(manaValue) {
            const invalidType = isNaN(manaValue),
                invalidRange = manaValue < 0;

            if (invalidType || invalidRange) {
                throw new Error(ERROR_MESSAGES.INVALID_MANA);
            }
        },
        validateAlignment(alignment) {
            const invalidAlignment = ['good', 'neutral', 'evil'].indexOf(alignment) === -1;

            if (invalidAlignment) {
                throw new Error(ERROR_MESSAGES.INVALID_ALIGNMENT);
            }
        },
        validateRange(value, min, max, message) {

            if ((value < min) || (max < value)) {
                throw new Error(message);
            }
        },
        validateEffect(effect) {
            const invalidType = typeof effect !== 'function';

            if (invalidType || (effect.length !== 1)) {
                throw new Error(ERROR_MESSAGES.INVALID_EFFECT);
            }
        },
        validateNonNull(value, message) {
            if (value === null) {
                throw new Error(message);
            }
        },
        validateCastManaCost(mana, manaCost) {
            if (mana < manaCost) {
                throw new Error(ERROR_MESSAGES.NOT_ENOUGH_MANA);
            }
        },
        validateBattleUnit(unit, message) {
            const invalidDamage = isNaN(unit.damage),
                invalidHealth = isNaN(unit.health),
                invalidCount = isNaN(unit.count);

            if (invalidDamage || invalidCount || invalidHealth) {
                throw new Error(message);
            }
        }
    };
    const generateId = (function () {
        var id = 0;

        return function () {
            id += 1;
            return id;
        };
    })();
    class Spell {
        constructor(name, manaCost, effect) {
            this.name = name;
            this.manaCost = manaCost;
            this.effect = effect;
        }

        get name() {
            return this._name;
        }
        set name(name) {
            validator.validateName(name);

            this._name = name;
        }

        get manaCost() {
            return this._manaCost;
        }
        set manaCost(manaCost) {
            validator.validateMana(manaCost);

            this._manaCost = manaCost;
        }

        get effect() {
            return this._effect;
        }
        set effect(func) {
            validator.validateEffect(func);

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
            validator.validateName(name);

            this._name = name;
        }

        get alignment() {
            return this._alignment;
        }
        set alignment(alignment) {
            validator.validateAlignment(alignment);

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

        get id() {
            return this._id;
        }

        get damage() {
            return this._damage;
        }
        set damage(damage) {
            validator.validateRange(damage, 0, 100, ERROR_MESSAGES.INVALID_DAMAGE);

            this._damage = damage;
        }

        get health() {
            return this._health;
        }
        set health(health) {
            validator.validateRange(health, 0, 200, ERROR_MESSAGES.INVALID_HEALTH);

            this._health = health;
        }

        get count() {
            return this._count;
        }
        set count(count) {
            validator.validateRange(value, 0, Infinity, ERROR_MESSAGES.INVALID_COUNT);

            this._count = count;
        }

        get speed() {
            return this._speed;
        }
        set speed(speed) {
            validator.validateRange(speed, 0, 100, ERROR_MESSAGES.INVALID_SPEED);

            this._speed = speed;
        }

    }

    class Commander extends Unit {
        constructor(name, alignment, mana) {
            super(name, alignment);
            this.mana = mana;
            this.spellbook = [];
            this.army = [];
        }

        get mana() {
            return this._mana;
        }
        set mana(mana) {
            validator.validateMana(mana);

            this._mana = mana;
        }
    }

    const battlemanager = (function () {
        function meetsRequirements(object, requirements) {
            for (const req in requirements) {
                if (object[req] !== requirements[req]) {
                    return false;
                }
            }
            return true;
        }

        function compareStrings(first, second) {
            return Number(first > second) - 0.5;
        }

        function bySpeed(first, second) {
            if (second.speed - first.speed) {
                return second.speed - first.speed;
            }
            return compareStrings(first.name, second.name);
        }

        const commanders = [];

        return {
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
            addCommanders(...commanders) {
                commanders.push(commanders);
                return this;
            },
            addArmyUnitTo(commanderName, armyUnit) {
                const com = this.findCommanders({ name: commanderName })[0];
                com.army.add(armyUnit);
                return this;
            },
            addSpellsTo(commanderName, ...newSpells) {
                const com = this.findCommanders({ name: commanderName })[0];

                for(const spell of newSpells) {
                    try {
                        validator.validateName(spell.name);
                        validator.validateMana(spell.manaCost);
                        validator.validateEffect(spell.effect);
                    } catch (error) {
                        error.message = ERROR_MESSAGES.INVALID_SPELL_OBJECT;
                        throw error;
                    }
                }

                com.spellbook.push(newSpells);

                return this;
            },
            findCommanders(query) {
                return commanders.filter(x => meetsRequirements(x, query))
                    .sort((c1, c2) => compareStrings(c1.name, c2.name));
            },
            findArmyUnitBy(id) {
                for (let commander of commanders) {
                    let armyunit = commander.army.find(x => x.id === id);

                    if(armyunit){
                        return armyunit;
                    }
                }
            },
            findArmyUnits(query){
                let result = [];

                for (let commander of commanders) {
                    let units = commander.army.filter(x => meetsRequirements(x, query));
                    if (units.length) {
                        result.push(units);
                    }
                }

                return result.sort(bySpeed);
            },
            spellcast(casterName, spellName, targetUnitId){
                let caster = this.findCommanders({ name: casterName })[0];
                validator.validateNonNull(caster, 'Cannot cast ' + casterName);

                let spell = caster.spellbook.find(s => s.name === spellName);
                validator.validateNonNull(spell, casterName + ' does not know ' + spellName);
                validator.validateCastManaCost(caster.mana, spell.manaCost);

                let target = this.findArmyUnitById(targetUnitId);
                validator.validateNonNull(target, ERROR_MESSAGES.TARGET_NOT_FOUND);

                spell.effect(target);

                caster.mana -= spell.manaCost;

                return this;
            },
            battle(attacker, defender) {
                
                validator.validateBattleUnit(attacker, ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
                validator.validateBattleUnit(defender, ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
                let defenderCountAfterBattle = Math.ceil(((defender.health * defender.count) - (attacker.damage * attacker.count)) / defender.health);

                if(defenderCountAfterBattle < 0) {
                    defender.count = 0;
                } else {
                    defender.count = defenderCountAfterBattle;
                }

                return this;
            }
        };
    })();

    return battlemanager;
}

module.exports = solve;