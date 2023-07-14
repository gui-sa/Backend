var express = require('express');
var app = express();
// Setting up midleware..
// Html file usually asks for extra files... those are statics and in this case node will handle the sending action automaticlly
// maps html path to real path

var port = process.env.PORT || 3000; //Checks for process.env.PORT ... if undefined uses 3000

app.use('/assets',express.static(`${__dirname}/public`));

// The first rout you pass actually defines WHEN MINIMALLY it will run that midleware for you.
// In other words, the express.static above runs ALWAYS, whanever the /assets is called... and in this case, browser calls for it
// You can use for downloads, analytics, loggers.
// There are LOTs of third-parties midlewares 
app.use('/',(req,res,next)=>{
    console.log(`URL: ${req.url}`);
    next(); // Next receives the next layer of function! If you dont call it! it will block you code.
})

app.get('/',(req,res)=>{
    res.send('<html><head><link rel="stylesheet" href="assets/style.css"></head><body><h1>Hello Express -- You beuty!</h1></body></html>');

});

app.get('/examples/:id',(req,res)=>{
    res.send(`<html><head></head><body><h1>Hello Express -- You beuty!</h1><p>Your id is ${req.params.id}</p></body></html>`);
});

app.get('/sapos/:id/:data',(req,res)=>{
    res.send(`<html><head></head><body><h1>Hello Express -- You beuty!</h1><p>Your id is ${req.params.id} and your data is ${req.params.data}</p></body></html>`);
});

app.get('/api',(req,res)=>{
    res.json({ firstname:"Guilherme", lastName:"SA"});
});

app.get('*',(req,res)=>{
    res.send(`<html><head></head><body><h1>Hello Express -- You beuty!</h1><p>Your URL: ${req.url} is not implemented!</p></body></html>`);
})

app.listen(port).on('listening',()=>{
    console.log(`Listening to http://127.0.0.1:${port}`);
});