'use strict';

const item = require('./item-model');
const contact = require('./contact-model');

const mongoose = require('mongoose'),
    Schema = mongoose.Schema;

var EmployeeSchema = new Schema({
    firstName: {
        type: String,
        required: true,
        match: '/^[a-zA-Z]*$/'
    },
    middleName: {
        type: String,
        required: true,
        match: '/^[a-zA-Z]*$/'
    },
    lastName: {
        type: String,
        required: true,
        match: '/^[a-zA-Z]*$/'
    },
    insuranceNumber: {
        type: String,
        required: true,
        match: '^[A-Za-z0-9-]*$'
    },
    age: {
        type: Number,
        required: true,
        min: 0,
        max: 120
    },
    contactDetails: contact,
    itemsForSale: [item],
    itemsReceived: [String]
});

EmployeeSchema.virtual('fullname').get(function() {
    return this.firstName + ' ' + this.middleName + ' ' + this.lastName;
}).set(function(first, middle, last) {
    this.firstName = first;
    this.middleName = middle;
    this.lastName = last;
});

EmployeeSchema.methods.SellItemToFriend = function SellItemToFriend(friend, itemId) {
    var item = this.itemsForSale.find(itemId);
    this.itemsForSale.remove(item);

    this.model('Employee').find(friend).itemsReceived.add(item);
};

module.exports = EmployeeSchema;