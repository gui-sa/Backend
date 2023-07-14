// It is node builtin and defaulty required
var buf = new Buffer("Yeah",'utf8');

console.log(buf);
console.log(buf.toJSON());
console.log(buf.toString());
console.log(buf[2]);

buf.write("wo");
console.log(buf.toString());