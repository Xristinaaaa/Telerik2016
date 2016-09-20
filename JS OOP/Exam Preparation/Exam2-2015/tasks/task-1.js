'use strict';
function solve() {
    const MIN_PROP_LENGTH = 3,
        MAX_PROP_LENGTH = 25;
    var generateId = (function () {
        let id = 0;

        return function () {
            id++;
            return id;
        };
    })();

    class Validator {
        validateString(stringToValidate) {
            if (typeof stringToValidate !== 'string') {
                throw new Error(stringToValidate + ' should be a string.');
            }
        }
        validateStringLength(stringToValidate, minLength, maxLength) {
            if (stringToValidate.length < minLength || maxLength < stringToValidate.length) {
                throw new Error(stringToValidate + ' length is out of range.');
            }
        }

        validateInputNumber(stringToValidate) {
            if (typeof stringToValidate !== 'number') {
                throw new Error(stringToValidate + ' is not e number.');
            }
        }
    }

    class Player {
        constructor(name) {
            this.id=generateId();
            this.name = name;
            this.playlists=[];
        }

        get id(){
            return this._id;
        }

        get name() {
            return this._name;
        }
        set name(value) {
            Validator.validateString(value);
            Validator.validateStringLength(value, MIN_PROP_LENGTH, MAX_PROP_LENGTH);

            this._name = value;
        }

        addPlaylist(playlistToAdd) {
            Validator.validateString(playlistToAdd);
            if(!(playlistToAdd instanceof PlayList)){
                throw new Error('Object is not an instance of Playlist.');
            }

            this.playlists.push(playlistToAdd);
            return this;
        }

        getPlaylistById(id){
            if (id === 'undefined') {
                throw new Error('Parameter is not defined.');
            }
            Validator.validateInputNumber(id);

            for (var playlist in this.playlists) {
                if (playlist.id === id) {
                    return playlist;
                }
            }

            return null;
        }

        removePlaylist(param) {
            for (var i = 0, len = this.playlists.length; i < len; i += 1) {
                if (this.playlists[i].id === param.id || this.playlists[i].id === param) {
                    this.playlists.splice(i, 1);
                }
                else {
                    throw new Error('Playlists does not contain this playlist.');
                }
            }

            return this;
        }

        listPlaylists(page, size){
            
        }
    }

    class PlayList {
        constructor(name) {
            this.id = generateId();
            this.name = name;
            this.playables = [];
        }

        get name() {
            return this._name;
        }
        set name(value) {
            Validator.validateString(value);
            Validator.validateStringLength(value, MIN_PROP_LENGTH, MAX_PROP_LENGTH);

            this._name = value;
        }

        addPlayable(playable) {
            if (playable === 'undefined' || typeof playable !== 'object') {
                throw new Error(playable + ' is not an object.');
            }
            if (!(playable instanceof Playable)) {
                throw new Error('Object is not a playable.');
            }

            this.playables.push(playable);

            return this;
        }
        getPlayableById(id) {
            if (id === 'undefined') {
                throw new Error('Parameter is not defined.');
            }
            Validator.validateInputNumber(id);

            for (var playable in this.playables) {
                if (playable.id === id) {
                    return playable;
                }
            }

            return null;
        }

        removePlayable(param) {
            for (var i = 0, len = this.playables.length; i < len; i += 1) {
                if (this.playables[i].id === param.id || this.playables[i].id === param) {
                    this.playables.splice(i, 1);
                }
                else {
                    throw new Error('Playlist does not contain this playable.');
                }
            }

            return this;
        }

        listPlayables(page, size) {
            Validator.validateInputNumber(page);
            Validator.validateInputNumber(size);
            if (page < 0 || size <= 0) {
                throw new Error('Parameters are out of range.');
            }
            if(page*size > this.playables.length){
                throw new Error('Count of playables is less than expected.');
            }

            this.playables.sort(function(a, b){
                if(a.title === b.title){
                    return a.id < b.id;
                }

                return a.title < b.title;
            });

            return this.playables.splice(page*size, size);
        }
    }

    class Playable {
        constructor(title, author) {
            this.id = generateId();
            this.title = title;
            this.author = author;
        }

        get title() {
            return this._title;
        }
        set title(value) {
            Validator.validateStringLength(value, MIN_PROP_LENGTH, MAX_PROP_LENGTH);

            this._title = value;
        }

        get author() {
            return this._author;
        }
        set author(value) {
            Validator.validateStringLength(value, MIN_PROP_LENGTH, MAX_PROP_LENGTH);

            this._author = value;
        }

        play() {
            return `${this.id}. ${this.title} - ${this.author}`;
        }
    }

    class Audio extends Playable {
        constructor(title, author, length) {
            super(title, author);
            this.length = length;
        }

        get length() {
            return this._length;
        }
        set length(value) {
            if (value <= 0) {
                throw new Error('Length should be a positive number.');
            }

            this._length = value;
        }

        play() {
            return super.play() + `- ${this.length}`;
        }
    }

    class Video extends Playable {
        constructor(title, author, imdbRating) {
            super(title, author);
            this.imdbRating = imdbRating;
        }

        get imdbRating() {
            return this._imdbRating;
        }
        set imdbRating(value) {
            if (value < 1 || value > 5) {
                throw new Error('Imbd rating should be positive.');
            }

            this._imdbRating = value;
        }

        play() {
            return super.play() + `- ${this.imdbRating}`;
        }
    }

    return {
        getPlayer: function (name) {
            return new Player(name);
        },
        getPlaylist: function (name) {
            return new PlayList(name);
        },
        getAudio: function (title, author, length) {
            return new Audio(title, author, length);
        },
        getVideo: function (title, author, imdbRating) {
            return new Video(title, author, imdbRating);
        }
    };
}

module.exports = solve;