(function (global, jquery) {
        "use strict";

        const supportedLanguages = ['en', 'br', 'es'];

        const informalGreets = {
                en: "Hi",
                br: "Eae",
                es: "Hola"
        };

        const formalGreets = {
                en: "Greetings",
                br: "Olá",
                es: "Saludo"
        };


        const logMessages = {
                en: "Logged in",
                br: "Conectado",
                es: "Inicio Sesion"
        };

        // Create a new Function Constructor of Greetr.init object type... It is a class basicaly and Greetr is a function that does "new" to you
        var Greetr = function (firstName, lastName, language) {
                return new Greetr.init(firstName, lastName, language)
        }

        // Actual Function Constructor
        Greetr.init = function (firstName, lastName, language) {
                //avoids conflicts with future 'this' 
                let self = this;
                self.setFirstName(firstName || '');
                self.setLastName(lastName || '');
                self.setLang(language || 'en');
        }

        Greetr.prototype = {
                getFirstName: function () {
                        return this.firstName;
                },
                getLastName: function () {
                        return this.lastName;
                },
                getFullName: function () {
                        return `${this.firstName} ${this.lastName}`;
                },
                getLang: function () {
                        return this.language;
                },
                validateLang: function (lang) {
                        if (supportedLanguages.indexOf(lang) === -1) {
                                throw new Error(`The language '${lang}' is not supported.`);
                        }
                        return lang;
                },
                setLang: function (lang) {
                        this.language = this.validateLang(lang);
                        return this;
                },
                setFirstName: function (firstName) {
                        this.firstName = firstName;
                        return this;
                },
                setLastName: function (lastName) {
                        this.lastName = lastName;
                        return this;
                },
                greet: function () {
                        return `${informalGreets[this.getLang()]} ${this.getFirstName()}`;
                },
                greetFullName: function () {
                        return `${informalGreets[this.getLang()]} ${this.getFullName()}`;
                }
        };

        // After building to it an object, we assign it to the actual class so they are point to the same reference in memory
        Greetr.init.prototype = Greetr.prototype

        // To make it available everywhere, you need to link it to window object and thats why you created "global" and attached it to window.
        // By this tecnique it is also possible to append thing to a strange alias such G$...
        // Internally, you use Greetr;
        global.Greetr = global.G$ = Greetr;
        // Now it is possible to create an object using G$() or Greetr() in the app.js







})(window, jQuery);