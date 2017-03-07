'use strict';

const mongoose = require('mongoose'),
    Schema = mongoose.Schema;

const itemNameRegex = '(?=.*[A-Z])(?=.*[a-z]).*';

var ItemSchema = new Schema({
    itemName: {
        type: String,
        match: itemNameRegex,
        required: true
    },
    price: {
        type: Number
    },
    offerType: {
        type: String,
        enum: ['Give away', 'For Sale'],
        required: true
    },
    offerStartDate: {
        type: Date,
        default: Date.now,
        required: true
    },
    offerEndDate: {
        type: Date,
        default: Date.now,
        required: true
    }
});

module.exports = ItemSchema;