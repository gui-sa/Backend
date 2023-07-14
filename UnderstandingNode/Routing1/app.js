var http = require('http');

var fs = require('fs')

var PORT = 1338;

var obj = {
    firstName: "Guilherme",
    lastName: "Salomao Agostini"
};

http.createServer(function(req,res){
    if (req.url === '/'){
        res.writeHead(200,{'Content-Type':'text/html' });
        var htmlFileString = fs.createReadStream(`${__dirname}/index.html`).pipe(res);    
    }
    else if(req.url === '/api'){
        res.writeHead(200,{'Content-Type':'application/json' });
        // JSON is an intern javaScript function to handle JSON.
        // JSON.stringify turns js obj into a JSON string
        res.end(JSON.stringify(obj));
    }else{
        var htmlFileString = fs.readFileSync(`${__dirname}/error.html`, 'utf8');
        htmlFileString = htmlFileString.replace('{route}', req.url);
        res.writeHead(200,{'Content-Type':'text/html' });
        res.end(htmlFileString);
    }

}).listen(PORT,'127.0.0.1').on('listening',()=>{
    console.log(`Listening on http://127.0.0.1:${PORT}`);
} );

