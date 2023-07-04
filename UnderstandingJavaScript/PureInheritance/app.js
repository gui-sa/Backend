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