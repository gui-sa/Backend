(function () {

    //Default object
    const boloTeste = {
        nome: "Floresta Negra",
        preco: 190.00
    };
    console.log(boloTeste);


    function Bolo() {
        this.nome = "Floresta Negra";
        this.preco = 190.00;
    }
    // Bolo object created... by a class? 
    const bolo1 = new Bolo();
    console.log(bolo1);

    function Pessoa(firstName, lastName) {
        this.firstName = firstName || "Default";
        this.lastName = lastName || "Default";
    }

    const pessoa1 = new Pessoa("Marcos", "Paulo");
    const pessoa2 = new Pessoa("Marcos");
    console.log(pessoa1);
    console.log(pessoa2);

})();