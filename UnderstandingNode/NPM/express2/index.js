var express = require('express');
var app = express();

var port = process.env.PORT || 3000; //Checks for process.env.PORT ... if undefined uses 3000

app.get('/',(req,res)=>{
    res.send('<html><head></head><body><h1>Hello Express -- You beuty!</h1></body></html>');

});

// This patter :<name> is taken from express documentation
// Accessed via req.params.<name>
app.get('/examples/:id',(req,res)=>{
    res.send(`<html><head></head><body><h1>Hello Express -- You beuty!</h1><p>Your id is ${req.params.id}</p></body></html>`);
});

//In this case, the info needs to come, otherwise it will fall into default conditions
app.get('/sapos/:id/:data',(req,res)=>{
    res.send(`<html><head></head><body><h1>Hello Express -- You beuty!</h1><p>Your id is ${req.params.id} and your data is ${req.params.data}</p></body></html>`);
});

app.get('/api',(req,res)=>{
    res.json({ firstname:"Guilherme", lastName:"SA"});
});

//default route
app.get('*',(req,res)=>{
    res.send(`<html><head></head><body><h1>Hello Express -- You beuty!</h1><p>Your URL: ${req.url} is not implemented!</p></body></html>`);
})

//listening event is listed on documentation
app.listen(port).on('listening',()=>{
    console.log(`Listening to http://127.0.0.1:${port}`);
});