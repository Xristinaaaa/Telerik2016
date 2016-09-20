function solve() {
	const itemNameMin = 2,
		itemNameMax = 40,
		bookGenreMin = 2,
		bookGenreMax = 20,
		catalogNameMin = 2,
		catalogNameMax = 40;
	const getId = (function () {
		let id = 0;

		return function () {
			id += 1;
			return id;
		};
	})();

	class Validator {
		validateString(stringToValidate) {
			if (stringToValidate === null || typeof stringToValidate !== 'string') {
				throw new Error(stringToValidate + ' cannot be null.');
			}
		}

		validateStringLength(stringToValidate, minLength, maxLength) {
			if (stringToValidate.length < minLength || maxLength < stringToValidate.length) {
				throw new Error(stringToValidate + ' length is out of range.');
			}
		}

		validateStringOfDigits(stringToValidate) {
			let ismatch = stringToValidate.match(/^[0-9]+$/);
			if (!ismatch) {
				throw new Error(stringToValidate + ' does not contain only digits.');
			}
		}

		validateInputIsNumber(stringToValidate) {
			if (typeof stringToValidate !== 'number') {
				throw new Error(stringToValidate + ' should be a number');
			}
		}
	}

	class Item {
		constructor(description, name) {
			this.id = getId();
			this.description = description;
			this.name = name;
		}

		get description() {
			return this._description;
		}
		set description(value) {
			Validator.validateString(value);
			this._description = value;
		}

		get name() {
			return this._name;
		}
		set name(value) {
			Validator.validateStringLength(value, itemNameMin, itemNameMax);
			this._name = value;
		}
	}

	class Book extends Item {
		constructor(description, name, isbn, genre) {
			super(description, name);
			this.isbn = isbn;
			this.genre = genre;
		}

		get isbn() {
			return this._isbn;
		}
		set isbn(value) {
			Validator.validateInputIsNumber(value);

			if (value.length != 10 && value.length != 13) {
				throw new Error('Isbn length is not valid.');
			}

			Validator.validateStringOfDigits(value);
			this._isbn = value;
		}

		get genre() {
			return this._genre;
		}
		set genre(value) {
			Validator.validateStringLength(value, bookGenreMin, bookGenreMax);
			this._genre = value;
		}
	}

	class Media extends Item {
		constructor(description, name, duration, rating) {
			super(description, name);
			this.duration = duration;
			this.rating = rating;
		}

		get duration() {
			return this._duration;
		}
		set duration(value) {
			Validator.validateInputIsNumber(value);
			if (value <= 0) {
				throw new Error('Duration cannot be less or equal to 0.');
			}

			this._duration = value;
		}

		get rating() {
			return this._rating;
		}
		set rating(value) {
			Validator.validateInputIsNumber(value);
			if (value < 1 || value > 5) {
				throw new Error('Rating is out of range.');
			}

			this._rating = value;
		}
	}

	class Catalog {
		constructor(name) {
			this.id = getId();
			this.name = name;
			this.items = [];
		}

		get name() {
			return this._name;
		}
		set name(value) {
			Validator.validateStringLength(value, catalogNameMin, catalogNameMax);
			this._name = value;
		}

		add(...items) {
			if (Array.isArray(items[0])) {
				items = items[0];
			}
			if (items.length === 0) {
				throw new Error('No items are passed.');
			}

			this.items.push(...items);
			return this;
		}

		find(x) {
			if (typeof x === 'number') {
				for (var item of this.items) {
					if (item.id === x) {
						return item;
					}
				}

				return null;
			}

			if (Array.isArray(x[0])) {
				x = x[0];

				return this.items.filter(function (item) {
					return Object.keys(x).every(function (prop) {
						return x[prop] === item[prop];
					});
				});
			}

			throw 'Invalid options or id.';
		}

		search(pattern) {
			if (pattern.length === 0 || typeof pattern !== 'string') {
				throw new Error('Pattern should be at least 1 character string.');
			}

			pattern = pattern.toLowerCase();

			return this.items.filter(function (item) {
				return item.name.indexOf(pattern) >= 0 || item.description.indexOf(pattern) > 0;
			});
		}
	}

	class BookCatalog extends Catalog {
		constructor(name) {
			super(name);
		}

		add(...books) {
			if (Array.isArray(books[0])) {
				books = books[0];
			}

			books.forEach(function (book) {
				if (!(book instanceof Book)) {
					throw new Error('This item is not an instance of Book.');
				}
			});

			return super.add(...books);
		}

		getGenres() {
			let genres = {};
			
			for(var book of books){
				if(genres.indexOf(book.genre)<0){
					genres.push(book.genre);
				}
			}

			return genres;
		}

		find(options) {
			return super.find(options);
		}
	}

	class MediaCatalog extends Catalog {
		constructor(name) {
			super(name);
		}

		add(...medias) {
			if (Array.isArray(medias[0])) {
				medias = medias[0];
			}

			medias.forEach(function (media) {
				if (!(media instanceof Media)) {
					throw new Error('This item is not an instance of Media.');
				}
			});

			return super.add(...medias);
		}

		getTop(count) {
			Validator.validateInputIsNumber(count);
			if(count<1){
				throw new Error('Count must be greater than 1.');
			}

			this.items.sort((a, b) => {
				return a.rating < b.rating;
			});		

			var topMedias=[];
			var itemToAdd;
			for(var i=0; i<count; i+=1){
				itemToAdd= {
					id: this.items[i].id,
					name: this.items[i].name
				};
				topMedias.push(itemToAdd);
			}

			return topMedias;
		}

		getSortedByDuration() {
			return this.items.sort((a, b) => {
				if (a.duration === b.duration) {
					return a.id < b.id;
				}
				return a.duration > b.duration;
			});
		}
	}

	return {
		getBook: function (name, isbn, genre, description) {
			return new Book(description, name, isbn, genre);
		},
		getMedia: function (name, rating, duration, description) {
			return new Media(description, name, duration, rating);
		},
		getBookCatalog: function (name) {
			return new BookCatalog(name);
		},
		getMediaCatalog: function (name) {
			return new MediaCatalog(name);
		}
	};
}

module.exports = solve;
