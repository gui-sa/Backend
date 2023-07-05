// Function Statement
function greet(){
    console.log("Yeaah - I am an object!");
}

//Functions in Js are first class.. in other words: it can be passed and used as an argument
function log(fn){
    fn(); // in this case no argument is passed to it.
}

// Function Expression
var log2 = function(fn){
    fn(10, 20); 
}

//Passing a Function as argument - first class function
log(greet);

//Passing a Function as argument - first class function, and creating it on the fly
log(function(){
    console.log("running inside it!");
})

log(()=>{console.log("running inside it! Arrow function");});

//How passing arguments in first class works! with default function statement
log2(function(x,y){
    console.log(x*y);
});

//Using arrow function!
log2((x,y)=>{console.log(x+y);});


