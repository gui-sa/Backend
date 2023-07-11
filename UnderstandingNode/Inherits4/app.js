'use strict';

// Builtin module for utilities
var util = require('util');

// A class from ES6
class Person{
    constructor(firstName, lastName){
        this.firstName = firstName||'';
        this.lastName = lastName||'';
    }

    //Adding methods to prototype
    greet (){
        console.log(`Hello ${this.firstName} ${this.lastName}`);
    }
}

class Policeman extends Person{
    constructor(firstName,lastName,badgeNumber){
        super(firstName,lastName);
        this.badgeNumber = badgeNumber || '';
    }
}

var police1 = new Policeman("John","Canelinha","1233");
police1.greet();
console.log(police1 instanceof Person);


// In this case, it is not possible to use .call to construct super()
// You will be forced to work with Sintactic Sugar
/**class Policeman2{
    constructor(firstName,lastName, badgeNumber){
        Person.call(this,firstName,lastName);
        this.badgeNumber = badgeNumber || '';
    }
}

util.inherits(Policeman2,Person);

var police2 = new Policeman2("Janaiba","Paranaiba","3333");
police2.greet();
console.log(police2 instanceof Person);
 */


