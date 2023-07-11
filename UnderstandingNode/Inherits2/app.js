
// Here it will explore that util.inherits doesnt construct back its super in function constructor
// You will need to construct it by using ".call"
var util = require('util');

var Person = function(firstName, lastName){
    this.name =  firstName||"John";
    this.lastname =  lastName||"Canelinha";
}

Person.prototype.greet = function(){
        console.log(`Hello ${this.name} ${this.lastname}`);
    };

var Policeman = function(badgeNumber){
    this.badgeNumber = badgeNumber|| "1234";
}

util.inherits(Policeman,Person);

var police = new Policeman();
police.greet(); // everything from Person will be undefined

//Instead, use .call as constructor

var Policeman2 = function(firstName, lastName, badgeNumber){
    //.call replaces the source object with another... that is why this works!
    Person.call(this,firstName, lastName);
    this.badgeNumber =  badgeNumber||"1234";
};

util.inherits(Policeman2,Person);

var police2 = new Policeman2();
police2.greet(); 

var police3 = new Policeman2("Amanda","Para o Bucho","8888");
police3.greet(); 

police2.greet();


console.log(police2 instanceof Person);