function Emmiter (){
    this.events = {}
}

// listener is the function that will run as soon as event happens
// type is an enumm referencing a list of objects
Emmiter.prototype.on = function(type, listener){
    //if it doesnt exist, so it should be an empty list
    this.events[type] = this.events[type] || [];
    // push inside the list of that type a new listener
    this.events[type].push(listener); 
}

// Runs every listener from that type!
Emmiter.prototype.emit = function(type) {
    // Checks the existance
    if (this.events[type]){
        // Runs tru the list running all existing listenner functions
        this.events[type].forEach(function(listener){
            listener();
        });
    }
}

// exports the Function Constructor instead of building it to permit multiples objects from the same class.
module.exports = Emmiter;

