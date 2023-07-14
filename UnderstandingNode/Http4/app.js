var http = require('http');

var fs = require('fs')

var PORT = 1338;

http.createServer(function(req,res){
    // To permit running dinamic index.html
    res.writeHead(200,{'Content-Type':'text/html' });
    var htmlFileString = fs.createReadStream(`${__dirname}/index.html`).pipe(res);

}).listen(PORT,'127.0.0.1').on('listening',()=>{
    console.log(`Listening on http://127.0.0.1:${PORT}`);
} );

// This example uses a simple .replace instead of a code used for placeholders
// Made using pure Node
// Gets slow if handling multiple clients because of I/O blocking action
// Uses stream so memmory dont get eaten up 
// Would have to create a custom stream to look for replacing