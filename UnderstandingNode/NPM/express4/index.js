var express = require('express');
var app = express();
var port = process.env.PORT || 3000;

//Setting up midleware to css and js extra file style sending automaticly
app.use('/assets',express.static(`${__dirname}/public`));

//Setting up template engine
app.set('view engine','ejs');

app.get('/',(req,res)=>{
    res.render('index');
});

app.get('/person/:id',(req,res)=>{
    res.render('person',{ idPerson: req.params.id});
});


app.listen(port).on('listening',()=>{
    console.log(`Listening on http://127.0.0.1:${port}`);
});