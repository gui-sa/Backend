(function () {
    //Just to use namespace in js
    //It also helps to isolate this context from windows object

    //let will isolate something inside it.. So I wont sse it outside this scope.
    let something = "Hi!!"

    //to test var efect instead of let ... Even tho I used var, it wont appear on window object because of the context protection of the IIFE
    var yeah2 = "pizza"

    // setTimeout calls a funtion back after 3s ... but  when 3s passed that context is already dead!
    // However due closure, something will still be there!
    setTimeout(function () {
        console.log(something);
    }, 3000)

})();

//Just to see how it get leeked to windows object
let yeah = "pizza!"
