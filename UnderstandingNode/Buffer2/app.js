// It is node builtin and defaulty required
var buf = new ArrayBuffer(8); //8 Bytes
var view = new Int32Array(buf); // Convert buffer to a 32 bit array.. So it is possible to save 2 digits
view[0] = 1;
view[1] = 30;
console.log(view);