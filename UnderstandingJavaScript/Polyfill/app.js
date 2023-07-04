// In case Object.create dont exist... it will be implemented in global context
if (!Object.create) {
    Object.create = function (obj) {
        if (arguments.length > 1) {
            throw new Error("Object.create Implementation only accepts one parameter");
        }
        function F() { }
        F.prototype = obj;
        return new F();
    };
}


(function () {

    const Pessoa = {
        firstName: "",
        lastName: "",
        getFullName: function () {
            return `${this.firstName} ${this.lastName}`;
        },
        setName: function (firstName, lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
        }
    };

    const joao = Object.create(Pessoa);
    joao.setName("Joao", "Do Pé de Feijao");

    console.log(joao);
    console.log(joao.getFullName());

})();