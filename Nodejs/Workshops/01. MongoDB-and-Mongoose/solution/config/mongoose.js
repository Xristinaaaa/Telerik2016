'use strict';

const mongoDbConnectionString = 'mongodb://localhost:27017/TelerikFriends';

module.exports = function(mongoose) {
    mongoose.Promise = global.Promise;
    mongoose.connect(mongoDbConnectionString);
};