function greet(firstname, lastname, language) {
    language = language || "EN";
    if (language === "EN") {
        console.log(`Hello ${firstname} ${lastname}`);
    }
    if (language === "ES") {
        console.log(`Hola ${firstname} ${lastname}`);
    }

}
greet("John", "Doe", "EN");
greet("Bia", "Deo", "ES");


//Some Work arounds

function greetEnglish(firstname, lastname) {
    greet(firstname, lastname, "EN");

}

function greetSpanish(firstname, lastname) {
    greet(firstname, lastname, "ES");

}

greetEnglish("John", "Doe");
greetSpanish("Bia", "Deo");

//There others patterns to solve that problem