'use strict';

const mongoose = require('mongoose'),
    Schema = mongoose.Schema;

const phoneRegex = '[0-9 ]+',
    emailRegex = '/^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i';

var ContactSchema = new Schema({
    phoneNumber: {
        type: String,
        match: phoneRegex
    },
    email: {
        type: String,
        required: true,
        trim: true,
        lowercase: true,
        match: emailRegex
    },
    workroomNumber: {
        type: Number,
        required: true,
        min: 100,
        max: 999
    }
});

module.exports = ContactSchema;