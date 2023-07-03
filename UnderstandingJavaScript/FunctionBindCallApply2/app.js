(function () {
        //random function to test
        function soma(x, y) {
                return x + y
        }
        console.log(soma(10, 10));
        //You can also use bind to create a currying function
        let soma10 = soma.bind(this, 10);
        console.log(soma10(10));

})();