var http = require('http');

var fs = require('fs')

http.createServer(function(req,res){
    var htmlFile = fs.readFileSync(`${__dirname}/index.html`);
    res.writeHead(200,{'Content-Type':'text/plain' });
    res.end('Hello World!!!!!\n')
}).listen(1338,'127.0.0.1').on('listening',()=>{
    console.log(`Listening on http://127.0.0.1:1337`);
} );

