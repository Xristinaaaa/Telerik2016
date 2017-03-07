'use strict';
const fs = require('fs');

const importer = (filePath) => {
    let content = fs.readdirSync(filePath, 'utf8');
    return JSON.parse(content);
};

module.exports = importer;