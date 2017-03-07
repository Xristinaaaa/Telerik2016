'use strict';

const mongoDbConnectionString = 'mongodb://localhost:27017/SuperheroesUniverse';

module.exports = function(mongoose) {
    mongoose.Promise = global.Promise;
    mongoose.connect(mongoDbConnectionString);
};