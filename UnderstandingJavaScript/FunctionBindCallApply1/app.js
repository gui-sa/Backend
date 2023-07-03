(function () {

        //Creating a classical object with a function as an atribute
        let person1 = {
                firstName: "Guilherme",
                lastName: "Salomao",
                fullName: function () {
                        return `${this.firstName} ${this.lastName}`;
                }
        }
        console.log(person1.firstName);
        console.log(person1.lastName);
        console.log(person1.fullName());

        //Example of bind usage:
        // This function for itself doesnt have fullname properties... this is pointing to window
        function logName(extra1, extra2) {
                if ((extra1 === undefined) || (extra2 === undefined)) {
                        console.log(`Logged: ${this.fullName()}`);
                } else {
                        console.log(`Logged: ${this.fullName()} with ${extra1} and ${extra2}`);
                }
        }

        //logName(); will throw an error.
        //However, if we bind... link or merge logName to person1 object...
        logName.bind(person1)("chave", "carteira");
        // It is perceptable that person1 is not permanently binded to logName
        //logName(); will throw an error... again. The linkage is only up to that line.
        logName.call(person1, "relogio", "celular"); //It runs with person1 binded. proceeding is their atributes

        logName.apply(person1, ["colar", "truck-kun"]); //It runs with person1 binded. proceeding is their atributes




}())