var Emmiter = require('events');
var eventConfig = require('./config');

var emtr = new Emmiter();

emtr.on(eventConfig.GREET, ()=>{
    console.log("Yeahh emmiter 1");
});
emtr.on(eventConfig.GREET, ()=>{
    console.log("Yeahh emmiter 2");
});

console.log("mannual one");
emtr.emit(eventConfig.GREET);
