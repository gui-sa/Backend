(function () {

    // Prototype Inheritance
    // SUPERCLASS
    const person = {
        firstName: "Default",
        lastName: "Default",
        fullName: function () {
            return this.firstName + " " + this.lastName;
        }
    };

    console.log(person.fullName());

    //DONT EVER DO THIS as it is shown in this example:

    const pedro = {
        firstName: "Pedro",
        lastName: "Cabrero"
    };

    pedro.__proto__ = person;

    // Now, pedro has a superclass method
    console.log(pedro.fullName());

    const joaquim = {
        firstName: "Pedro"
    };

    //more than one object can point to a same superclass object
    joaquim.__proto__ = person;
    //all methods and properties that werent overriden: will be maintained as said in superclass
    console.log(joaquim.fullName());


})();