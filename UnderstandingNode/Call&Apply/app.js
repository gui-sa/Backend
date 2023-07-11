
var obj = {
    name: "John Canelinha",
    greet: function(){
        console.log(`Hello ${this.name}`);
    },
    greet2: function(data){
        console.log(`Hello ${this.name}, ${data}`);
    }
}

// Will Simply run it!
obj.greet();

// If nothing is passed it will run with an empty object
obj.greet.call();

//However what is passed inside call is arguments or another object to assume as 'this'
obj.greet.call({name: "Abobrinhas Ambulantes"});

//Nothing changes in the source obj...
obj.greet();

//With more arguments
obj.greet2();

obj.greet2.call({name: "Abobrinhas Ambulantes"},"extra info!!!");

// For apply, the diference is that you pass a list in the params
obj.greet2.call({name: "Abobrinhas Ambulantes"},["extra info!!!"]);
