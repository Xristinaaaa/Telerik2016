'use strict';

const employeeSchema = require('./models/employee-model');
const importer = require('./data/data-importer');

const mongoose = require('mongoose');
require('./config/mongoose')(mongoose);

const db = mongoose.connection;

db.once('open', () => {
    console.log('Connection is open');
});

let Employee = mongoose.model('Employee', employeeSchema);
const employee1 = new Employee({
    firstName: 'Ivan',
    lastName: "Petkanov"
});

// let employees = importer('./data/data.json');

// employees.forEach((employee) => {
//     console.log(employee);
//     let empl = new Employee(employee);
//     empl.save((err, savedEmployee) => {
//         if (err) {
//             console.log(err);
//         } else {
//             console.log(savedEmployee);
//         }
//     });
// });