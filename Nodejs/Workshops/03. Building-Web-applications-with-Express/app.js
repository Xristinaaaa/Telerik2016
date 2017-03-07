'use strict';

const mongoose = require('mongoose');
require('./config/mongoose')(mongoose);

const db = mongoose.connection;

db.once('open', () => {
    console.log('Connection is open');
});