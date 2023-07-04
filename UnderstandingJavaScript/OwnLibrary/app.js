(function () {

    const g = G$("Guilherme", "SA");
    console.log(g);
    console.log(g.getFullName());
    console.log(g.setLang('es'));
    console.log(g.greet());
    console.log(g.setLang('br').greet());
    console.log(g.setLang('en').greetFullName());

})();