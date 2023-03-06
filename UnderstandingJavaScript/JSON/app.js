var objectLiteral = {
    firstname: "Camila",
    isAProgrammer: true
}

console.log(objectLiteral);
//You can parse objects like:
// <object>
//    <firstname> Mary </firstname>
//    <isAProgrammer> true </isAProgrammer>
// </object>
// However this way of sending object dont use network because you send name twice.

//This is JSON: need to be wrapped in curly braces
// {
//    firstname: "Camila",
//    isAProgrammer: true
//} 
 

console.log(JSON.stringify(objectLiteral)) ; //will convert object into JSON string
JSONValue = JSON.stringify(objectLiteral)

var nowObject = JSON.parse(JSONValue) // gets JSON STRING and transforms it back to object
console.log(nowObject);

