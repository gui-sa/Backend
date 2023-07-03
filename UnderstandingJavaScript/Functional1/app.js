(function () {

    //when dealing with functional programming, you can always pass functions as parameters

    let arr1 = [1, 2, 3];
    arr1.push(4);
    console.log(arr1);
    arr1.pop();
    console.log(arr1);

    //One way > the simple way
    function dobraArray(arr) {
        let arrTemp = [];

        for (let i = 0; i < arr.length; i++) {
            arrTemp.push(arr[i] * 2);
        }
        return arrTemp;
    }
    console.log(dobraArray(arr1));


    //Another way: using firstclass
    //You create an "iterface" function by passing a function as argument
    function mapArray(arr, fn) {
        let arrTemp = [];
        for (let i = 0; i < arr.length; i++) {
            arrTemp.push(
                fn(arr[i])
            );
        }
        return arrTemp
    }
    //That way you just can use with another function (an implementation).
    console.log(mapArray(arr1, (item) => item * 5));

})();