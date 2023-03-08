function greet(firstname, lastname, language) {

    console.log(`Hello ${firstname} ${lastname}! It is a pleasure to talk with you in ${language}`)
    console.log(arguments);

}
greet(); //you can simply dont passa any parameter rs rs... It will just coerce undefined do undefined and so things will get strange
greet("John"); //it will assume that thas is the first name.
greet("John", "Doe");
greet("John", "Doe", "EN");


//To avoid that weirdness, you can use: language = 'en' (the most used browser);

//You can avoid it using:

function greet2(firstname, lastname, language) {
    firstname = firstname || "NOME";
    lastname = lastname || "SOBRENOME";
    language = language || "EN";

    console.log(`Hello ${firstname} ${lastname}! It is a pleasure to talk with you in ${language}`)

}
greet2();

function greet3(firstname, lastname, language) {

    if (arguments.length === 0) {
        console.log("Please, pass parameters!")
    } else {
        console.log(`Hello ${firstname} ${lastname}! It is a pleasure to talk with you in ${language}`)
    }
    //arguments is getting deprecauted and beeing substituted by spread operator
}
greet3();


function greet4(firstname, lastname, language, ...nameParameter) {

    if (arguments.length === 0) {
        console.log("Please, pass parameters!")
    } else {
        console.log(`Hello ${firstname} ${lastname}! It is a pleasure to talk with you in ${language}`)
    }
    console.log(nameParameter) //SPREAD becames an array

}
greet4("John", "Doe", "EN", "Extra1", "Extra2", "ETC");
