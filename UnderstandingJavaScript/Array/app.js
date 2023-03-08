var arr1 = new Array(); //mesma coisa que o de baixo
var arr2 = []; //literal sintax 

var arr = [1, 2, 3];
var exe = [
    1,
    false,
    {
        name: "Tony",
        add: "Rua das bananas"
    },
    function (name) {
        name = name || " SEU NOME";
        var greeting = "Hello";
        console.log(greeting + name);
    },
    "YEAH, arrays"
];

console.log(exe);
exe[3](); 
