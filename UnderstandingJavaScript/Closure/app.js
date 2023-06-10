function greetFactory(language) {
    language = language || "en";
    return function (firstName, lastName) {
        switch (language) {
            case "en":
                console.log(`Hello ${firstName}!`);
                break;

            case "es":
                console.log(`Hola ${firstName}`);
                break;
            default:
                throw new Error("Language not found!");
                break;
        }
    }
}

//When context was created, it knew language... However it ended and rememberer language because of object persistence.
//It is CLOSURE

let enGreet = greetFactory("en");
enGreet("Felipe", "Lima");

let esGreet = greetFactory("es");
esGreet("Felipe", "Lima");


