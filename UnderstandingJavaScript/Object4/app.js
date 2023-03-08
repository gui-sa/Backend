console.log(this);

function a() {
    console.log(this);
    this.newVariable = "hello"; //will be attached to global object because this is windows object in that case.
}

a();

var b = function () {
    console.log(this);

}

b();
console.log(newVariable);




var c = {
    name: "The Object ma man", //properties
    log: function () { //method;
        this.name = 'Updated ma man!';
        console.log(this.name); // in case where the function is attached to an object, in this case, this will point to the parent object!!
    }
};

console.log(c.name);
c.log();


var d = {
    name: "The Object ma man", //properties
    log: function () { //method;
        this.name = 'Updated ma man!';
        console.log(this.name); // in case where the function is attached to an object, in this case, this will point to the parent object!!
        var setname = function (newName) { //remember that this in thata case will point to the previwws parent... so that this.name will not work properly... acctually it is bug.
            this.name = newName;
        }
        setname("Update again....");
        console.log(this.setname);
    }
};

console.log(d.name);
d.log();
console.log(this); //look at it... that bug will create that property in the WINDOW object kkkkk WTF