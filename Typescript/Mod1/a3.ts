function greet(person, date) {
    console.log(`Hello ${person}, today is ${date}!`);
  }
   
  greet("Brendan");

  //typescript will throw an error.
  //Even tho typescript knows there is an error, it still outputs the js..
  // If you wont tolerate it: use flag --noEmitOnError, so when it finds an error, it wont output js
  // tsc --noEmitOnError Mod1/a3.ts to run it.