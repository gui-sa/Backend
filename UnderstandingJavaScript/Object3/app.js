var greet = 'Hello';
var greet = 'Hola';

console.log(greet); //They will colide and Hola will be choosen sincronously

var english = {} ; //creating container as namespaces
var spanish = {} ; //creating container as namespaces

english.greet = 'Hello';
spanish.greet = 'Hola';

console.log(english.greet);
console.log(spanish.greet);

//english.greetings.greet = "Hello"; // Will Throu an error. because under the hood : undefined.greet dont exist

//However you can do

english.greeting = {};
english.greeting.greet = "Hello";
console.log(english.greeting.greet);

//or
var basinga = {
    basic: "Hello",
    greetings: {
        spanish: "Hola"
    }
};

console.log(basinga.basic);
console.log(basinga.greetings.spanish);