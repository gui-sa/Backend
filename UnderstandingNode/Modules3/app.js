var util = require('util');

var name = "Gobinha"

// Usefull for formating strings, numbers, etc
var teste = util.format('Hello, %s', name);

// It puts a ("TIMESTAMP -"+"STR")
util.log(teste);