// Importing node builtin server module
var http = require('http');


// When an event happens, it will do that...
// That function returns an object server that must listen to a Port and an IP
// req --> Comes from client from server (node as server)
// res --> goes to client in chunks from server
http.createServer(function(req,res){
    // Writes MIME Type and its HTTP type
    //'' in ContentType just because its name is not proper
    // text/plain... just text
    res.writeHead(200,{'Content-Type':'text/plain' });
    // ends response sending text
    res.end('Hello World!!!!!\n')
}).listen(1337,'127.0.0.1').on('listening',()=>{
    console.log(`Listening on http://127.0.0.1:1337`);
} );

