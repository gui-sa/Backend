// Your Javascript Code Goes Here

function greet(){
    console.log("YEAH");
}
greet();
// Note: The 'starter' folders that appear in this course's downloadable source code is here to give you a starting point to try out coding yourself. The 'finished' folder contains the code as it is when we finish the lecture. You can use the 'finished' folder to compare to your own code, or just examine the finished code.

function logGreeting(fn){
    fn();
}

logGreeting(greet);


var greetMe = function() {
    console.log("Hi Guilherme");
}

greetMe();

logGreeting(greetMe);

logGreeting(function(){
    console.log("Vacas comendo grama");
});