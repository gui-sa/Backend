var bodyParser = require('body-parser');
var express = require('express');
var app = express();
var port = process.env.PORT || 3000;

// Midleware to understand forms and things in HTML
var urlEncodedParser = bodyParser.urlencoded({ extended:false });

var jsonParser = bodyParser.json();

app.use('/assets',express.static(`${__dirname}/public`));

app.set('view engine','ejs');

app.get('/',(req,res)=>{
    res.render('index');
});

// To deal with queryString just use req.query.variableName
// type in /person/100?queryA=100&queryB=200 to test it!
app.get('/person/:id',(req,res)=>{
    res.render('person',{idPerson:req.params.id, 
                        queryA: req.query.queryA,
                        queryB:req.query.queryB});
});

app.get('/form',(req,res)=>{
    res.render('form');
});

// Post methods using midleware to deal with data comming from HTML form
app.post('/person',urlEncodedParser,(req,res)=>{
    res.send("Obrigado por enviar o formulario!")
    console.log(req.body.firstName);
    console.log(req.body.lastName);
});

app.get('/personjson',urlEncodedParser,(req,res)=>{
    res.render('json');
});

// Post method by receiving an JSON
app.post('/personjson',jsonParser,(req,res)=>{
    res.send("Obrigado por enviar o json!")
    console.log(req.body.firstName);
    console.log(req.body.lastName);
});

app.listen(port).on('listening',()=>{
    console.log(`Listening on http://127.0.0.1:${port}`);
});