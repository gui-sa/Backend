var person = {} ; //same as new Object()

//You can set up the object inside it

var person1 = {firstname: 'Tony', lastname: "Testezinho"} ; //same as new Object() and then creating unique objects 

console.log(person1)

var person2 = {
    firstname: 'Tony',
    lastname: "Testezinho",
    adress: {
        street: "Rua do Cabana",
        city: "Udia"
    }
} ; //same as new Object() and then creating unique objects, inside it, you can create more objects.

console.log(person2);

function greet(yeah){
    console.log('hi' + yeah.firstname);

};

greet(person2);
greet({
    firstname: "Mary",
    lastname: "Teste"
}); //Creating object on the fly


