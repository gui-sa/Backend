var http = require('http');

var obj = {
    firstName: "Guilherme",
    lastName: "Salomao Agostini"
};

var PORT= 1338;

http.createServer(function(req,res){
    res.writeHead(200,{'Content-Type':'application/json' });

    // JSON is an intern javaScript function to handle JSON.
    // JSON.stringify turns js obj into a JSON string
    res.end(JSON.stringify(obj));
}).listen(PORT,'127.0.0.1').on('listening',()=>{
    console.log(`Listening on http://127.0.0.1:${PORT}`);
} );


