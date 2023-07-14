// Node Builtin module to read files...
// It works by using buffers
var fs = require('fs');

// utf8 interprets the buffer in text... 
// highWaterMark defines in Bytes the chunk size
// When chunk is completed it generates an event emittion! Triggering our inclusion
var readableStream = fs.createReadStream(__dirname + '/text.txt', {encoding:'utf8', highWaterMark: 10 * 1024});

// Creating a new event for readable stream emittion!
readableStream.on('data',function(chunk){
    console.log(chunk.length);
});

//So beutifull!