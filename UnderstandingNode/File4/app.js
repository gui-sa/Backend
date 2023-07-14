// To see what has happened pls, erase textCopy.txt content!

// Node Builtin module to read files...
// It works by using buffers
var fs = require('fs');

// utf8 interprets the buffer in text... 
// highWaterMark defines in Bytes the chunk size
// When chunk is completed it generates an event emittion! Triggering our inclusion
var readableStream = fs.createReadStream(__dirname + '/text.txt', {encoding:'utf8', highWaterMark: 10 * 1024});

var writableStream = fs.createWriteStream(__dirname + '/textCopy.txt');

// Creating a new event for readable stream emittion!
// It copies to another file!
readableStream.on('data',function(chunk){
    console.log(chunk);
    writableStream.write(chunk);
});

