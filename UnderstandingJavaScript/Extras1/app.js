(function () {
    //Creating a literalll class...! With Properties (inside 'this')
    class Person {
        //constructor is a reserved key Word
        constructor(firstName, lastName) {
            this.firstName = firstName || "Default";
            this.lastName = lastName || "Default";
        }
        //methods...
        getFullName() {
            return `${this.firstName} ${this.lastName}`;
        }
    }

    const john = new Person("John", "Carneirone");

    class Engineer extends Person {
        constructor(firstName, lastName, role) {
            super(firstName, lastName);
            this.role = role || "Default";
        }

        createSomething() {
            console.log("Yeaaaaah Created!");
        }
    }

    const maicon = new Engineer("Maicon", "Douglas", "Civil")

    console.log(typeof john); //  it is weird...
    console.log(typeof maicon);
    console.log(john instanceof Person);
    console.log(john instanceof Engineer);
    console.log(maicon instanceof Person);
    console.log(maicon instanceof Engineer);

})();