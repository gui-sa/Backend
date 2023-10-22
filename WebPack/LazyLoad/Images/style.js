const blurDivs = document.querySelectorAll(".blur-load");

blurDivs.forEach(div=>{
    div.style.setProperty('--animation-set',"pulse 2.5s infinite");
    const img = div.querySelector("img");
    img.style.opacity = 0;

    function loaded(){
        div.classList.add("loaded");
        img.style.opacity = 1;
    }

    if(img.complete){
        loaded();
    }else{
        img.addEventListener("load",loaded);
    }
});