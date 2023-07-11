// Builtin module for events
// EventEmmiter is another function Constructor
var EventEmmiter = require('events');

// Import custom made object enumm
var eventConfig = require('./config')

// Using ES6 Class Sintactic Sugar
// Much Cleaner
module.exports = class Greetr extends EventEmmiter{
    constructor(greetingMessage){
        super();
        this.greeting = greetingMessage||"Yeeaah";
    }
    
    // Adding a prototype method to Greetr class
    // When this method run, it will also, trigger an event!
    greet(){
        console.log("Prototype Method on Greetr yeaaah");
        console.log(this.greeting);
        this.emit(eventConfig.events.GREET);
    }

    greet2(data){
        console.log("Prototype Method on Greetr yeaaah:  -->>> " +  data);
        // To pass arguments to .on() datas
        this.emit(eventConfig.events.GREET, data); 
    }
}