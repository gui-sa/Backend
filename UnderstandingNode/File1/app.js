// Node Builtin module to read files...
// It works by using buffers
var fs = require('fs');


// readFileSync reads a file by using Syncronous (blocking) process
// Usually is used to set environmental variable put should be avoided when it is run multiple times by numerous costomers
// __dirname points to directory of app.js
// If you dont pass a 'utf8' configuration, it will return u a buffer!
var greet = fs.readFileSync(`${__dirname}/text.txt`, 'utf8');

// It is not a promise because it is used sincronously
console.log(greet);