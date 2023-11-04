const _ = require('lodash');

function component() {
    const element = document.createElement('h1');
    element.innerHTML = _.join(['Hello', 'WebPack'], ' ');
    return element;
}

document.body.appendChild(component());
