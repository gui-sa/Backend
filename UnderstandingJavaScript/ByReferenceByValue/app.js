//By Value
var a = 3;
var b;
b = a;

a = 2
console.log(a);
console.log(b);

var c = "It is my life";
var d;
d = c
c = "It is now or never"
console.log(c);
console.log(d);


//By reference: They are simply pointing to the same memory reference

var e = { nome: 'Gui' }
var f;
f = e;

f.nome = 'Marcos';
console.log(e.nome);
console.log(f.nome);


function changeGreating(obj) {
    obj.nome = "Camila";
}

changeGreating(e);

console.log(e.nome);
console.log(f.nome);

//Solution:
var k = { nome: 'Gui' };
var p;
p = k;
p = { nome: 'Gui' }; //Nessa ordem, ele atribui um novo endereço.
p.nome = "Poliana"

console.log(k.nome);
console.log(p.nome);