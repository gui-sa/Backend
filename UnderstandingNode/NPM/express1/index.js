var express = require('express');
var app = express();

var port = process.env.PORT || 3000; //Checks for process.env.PORT ... if undefined uses 3000

app.get('/',(req,res)=>{
    res.send('<html><head></head><body><h1>Hello Express -- You beuty!</h1></body></html>');

});

app.get('/api',(req,res)=>{
    res.json({ firstname:"Guilherme", lastName:"SA"});
});

//listening event is listed on documentation
app.listen(port).on('listening',()=>{
    console.log(`Listening to http://127.0.0.1:${port}`);
});