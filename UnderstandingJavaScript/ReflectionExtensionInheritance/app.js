
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


    //To make it pays off:
    const joaquim = {}
    _.extend(joaquim, person);
    joaquim.firstName = "Joaquim"
    joaquim.lastName = "Pinto"
    console.log(joaquim.fullName());
})();