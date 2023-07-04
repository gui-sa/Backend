(function () {

    function Pessoa(firstName, lastName) {
        this.firstName = firstName || "Default";
        this.lastName = lastName || "Default";
    }

    const pessoa1 = new Pessoa("Marcos", "Paulo");
    const pessoa2 = new Pessoa("Marcos");
    console.log(pessoa1);
    console.log(pessoa2);

    //Just look... the objects are already created and I will add a method to its .prototype!
    Pessoa.prototype.getFullName = function () {
        return `${this.firstName} ${this.lastName}`;
    };

    console.log(pessoa1.getFullName());

})();