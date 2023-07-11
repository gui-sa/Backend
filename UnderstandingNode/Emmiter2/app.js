var Emmiter = require('events');

var emtr = new Emmiter();

emtr.on("yeah", ()=>{
    console.log("Yeahh emmiter 1");
});

emtr.on("yeah", ()=>{
    console.log("Yeahh emmiter 2");
});

console.log("mannual one");
emtr.emit("yeah");
