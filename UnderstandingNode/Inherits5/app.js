
var Greetr = require('./Greetr')

// Import custom made object enumm
var eventConfig = require('./config')

// Creating new Greetr object 
var greeter1 = new Greetr();

// Setting up an event on "greeter1" object
greeter1.on(eventConfig.events.GREET, (data)=>{
    if(typeof data === 'string'){
        console.log("Yeahh event was sucessfully triggered:  -->> " + data);
    } else{
        console.log("Yeahh event was sucessfully triggered");
    }
});

// Calling method that triggers everything:
greeter1.greet();
greeter1.greet2("extra data bitches");

