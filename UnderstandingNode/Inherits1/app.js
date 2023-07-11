// Builtin module for utilities
var util = require('util');

// Builtin module for events
// EventEmmiter is another function Constructor
var EventEmmiter = require('events');

// Import custom made object enumm
var eventConfig = require('./config')

// A function constructor
// This function is inclomplete because it doesnt initializes "EventEmmiter"
// "Inherits3" solves that problem.
function Greetr() {
    this.greeting = "Yeeaah";
}

// Adding a prototype method to Greetr class
// When this method run, it will also, trigger an event!
Greetr.prototype.greet = function(){
    console.log("Prototype Method on Greetr yeaaah");
    console.log(this.greeting);
    this.emit(eventConfig.events.GREET);
}

Greetr.prototype.greet2 = function(data){
    console.log("Prototype Method on Greetr yeaaah:  -->>> " +  data);
    // To pass arguments to .on() datas
    this.emit(eventConfig.events.GREET, data); 
}



// Greetr will extends the superclass EventEmmiter
// Event Emmiter is a module for events
util.inherits(Greetr,EventEmmiter);

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

