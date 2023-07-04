
(function () {
    // Prototype Inheritance using underscore
    // SUPERCLASS
    const person = {
        firstName: "Default",
        lastName: "Default",
        fullName: function () {
            return this.firstName + " " + this.lastName;
        }
    };

    console.log(person.fullName());

    const pedro = {
        firstName: "Pedro",
        lastName: "Cabrero"
    };


    _.extend(pedro, person);
    // Now, pedro has persons methods and properties, however, persons properties overrides its owns.
    console.log(pedro.fullName());


    //To make it pays off.. Create a new object extending from a superclass
    const joaquim = _.extend(new Object(), person);
    // Especialize it overriding what is needed
    joaquim.firstName = "Joaquim"
    joaquim.lastName = "Pinto"
    console.log(joaquim.fullName());


    // Reflection... 

    const maria = {
        firstName: "Maria",
        lastName: "EscritoErrado"
    }

    function cleanObj(obj) {
        for (const prop in obj) {
            obj[prop] = "Default";
        }
    }
    cleanObj(maria);
    console.log(maria);

})();