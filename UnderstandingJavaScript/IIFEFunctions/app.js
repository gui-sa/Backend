function greet(name) { //function statement
    console.log('Hello ' + name);
};

greet();

var greetFunc = function (name) {  //function expression
    console.log("Hello " + name);
};

greetFunc();


var greeting = function (name) {
    console.log("Hello " + name);
}(); //Immeadiatily Invoked Funtion Expression (IIFE)

console.log(greeting());