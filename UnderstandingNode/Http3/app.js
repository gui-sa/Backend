var http = require('http');

var fs = require('fs')

var PORT = 1338;

http.createServer(function(req,res){
    // To permit running dinamic index.html
    var htmlFileString = fs.readFileSync(`${__dirname}/index.html`, 'utf8');
    htmlFileString = htmlFileString.replace('{route}', req.url);
    res.writeHead(200,{'Content-Type':'text/html' });
    res.end(htmlFileString);

}).listen(PORT,'127.0.0.1').on('listening',()=>{
    console.log(`Listening on http://127.0.0.1:${PORT}`);
} );

// This example uses a simple .replace instead of a code used for placeholders
// Made using pure Node
// Gets slow if handling multiple clients because of I/O blocking action
// Dont use Stream and so large files consumes lots of memmory