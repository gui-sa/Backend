var fs = require('fs');
var zlib = require('zlib');

var readableStream = fs.createReadStream(__dirname + '/text.txt', {encoding:'utf8', highWaterMark: 10 * 1024});

var writableStream = fs.createWriteStream(__dirname + '/textCopy.txt');

var compressedStream = fs.createWriteStream(__dirname + '/textCompressedCopy.txt.gz');

var gCompressor = zlib.createGzip()

// Connecting readableStream TO writableStream using PIPE
readableStream.pipe(writableStream);

// Connecting TO gCompressor that connects TO compressedStream!
readableStream.pipe(gCompressor).pipe(compressedStream);
