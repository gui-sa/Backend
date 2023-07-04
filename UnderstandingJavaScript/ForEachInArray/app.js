(function () {

    const listTest = [1, 2, 3, 4, 5];

    for (let x in listTest) {
        console.log(listTest[x]);
    }

    //however as Array is an object it is highly recommended to use instead:

    for (let i = 0; i < listTest.length; i++) {
        console.log(listTest[i]);
    }

    //and that is why... just look as it is after...
    Array.prototype.algoMais = "Testezinho Basico"

    for (let x in listTest) {
        console.log(listTest[x]);
    }

    // You might forget and mix up the indexes!
    //That usage is totally wrong and you are getting the keys, acctually
    for (let x in listTest) {
        console.log(x);
    }
    console.log(listTest);
})();