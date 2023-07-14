// Node Builtin module to read files...
// It works by using buffers
var fs = require('fs');


// readFile reads a file by using assyncronous (non-blocking) process
// Thats why, it needs a callback function!
// __dirname points to directory of app.js
// If you dont pass a 'utf8' configuration, it will return u a buffer!
// Node asks SO or external platforms to do a task and awaits it to callback!
var greet = fs.readFile(`${__dirname}/text.txt`, 'utf8', function(err, data){
    // When everything goes right: err asssumes null and data assume a buffer  if you dont pass the encoding information
    console.log(data);  
});

// Will run first because readFile is Assync and calls a callback funcition when done!
// If something goes wrong: data will return undefined and err will be a error object!
console.log("Yeah????");

// If you follow thru this usage pattern, your programm might consume a lot of memmory (buffer)