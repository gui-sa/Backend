//Runs normally:
//
//a = "YEAAH";
//
//function b (){
//    console.log("Function B ran!")
//}
//
//b();
//console.log(a);


//Will Work, however, a variable will be undefined due to hoisting
//b();
//console.log(a);
//
//var a = "YEAAH";
//
//function b (){
//    console.log("Function B ran!")
//}


//Now, it will throw me an error... because I hadnt defined a anywhere in this context...
//b();
//console.log(a);
//
//
//function b (){
//    console.log("Function B ran!")
//
//
//}


var a;
console.log(a);
if (a=== undefined){
    console.log("a is undefined MTFK");
}
else{
    console.log("a is defined MTFK");
}