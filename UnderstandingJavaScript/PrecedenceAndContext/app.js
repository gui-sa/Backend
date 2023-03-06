//Showing how variable and execution context are created
//function b(){
//    var myvar;
//    console.log(myvar);
//
//}
//
//function a(){
//    var myvar = 2;
//    console.log(myvar);
//    b();
//}
//
//var myvar = 1;
//console.log(myvar);
//a();
//console.log(myvar);

//Showing Scope Chain
function b(){
    console.log(myvar);

}

function a(){
    var myvar = 2;
    b();
}
var myvar = 1;
var myvar2 = 1;
a();

function d(){
    var myvar = 5;
    e();
    function e() {
        console.log(myvar);
        console.log(myvar2);
    }
}

d();