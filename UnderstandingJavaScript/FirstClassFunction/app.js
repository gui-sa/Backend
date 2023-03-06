function greet() {
    console.log("hi");
}

greet.language = "English"; //Can add a property to a function... but in JS function are objects and code are especial property called by ()

console.log(greet.language);
greet();
