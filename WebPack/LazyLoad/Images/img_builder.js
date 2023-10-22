
const sharp = require("sharp");
const fs = require("fs");

const pathBuild = "./img_build/";
const dirAssets = fs.readdirSync(__dirname + "/assets/");
const dirBuild = fs.readdirSync(__dirname + "/img_build");

dirBuild.forEach( img =>{
    fs.unlinkSync(__dirname+"/img_build/"+img);
});

dirAssets.forEach( img =>{
    sharp("./assets/" + img)
    .resize(20,null, {
        fit:"contain"
    })
    .toFile(pathBuild + "mini-thumb-"+img);
});

dirAssets.forEach( img =>{
    sharp("./assets/" + img)
    .resize(720,430, {
        fit:"cover"
    })
    .toFile(pathBuild + "large-size-"+img);
});

