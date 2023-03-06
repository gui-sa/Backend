
//This is dynamic type to access and create object thru strings
var person = new Object();

person["firstname"] = "Tony";

person["lastname"] = "Baguncinha";

var firstnameProperty = "firstname";

console.log(person);
console.log(person[firstnameProperty]);

//Dot Operator

console.log(person.firstname)


person.address = new Object();
person.address.street = "Rua das Palmeiras";
person.address.city = "SJRP";
person.address.state = "SP";

console.log(person.address.state);
console.log(person.address.street);
console.log(person.address.city);
console.log(person['address']['city']);
