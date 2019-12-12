function growingWord() {
  let color = document.querySelector("#exercise p").style.color;

  if (!color) {
    document.querySelector("#exercise p").style.color = "blue";
    document.querySelector("#exercise p").style.fontSize = "1px";
  } else if(color === "blue") {
    document.querySelector("#exercise p").style.color = "green";
  } else if(color === "green") {
    document.querySelector("#exercise p").style.color = "red";
  } else {
    document.querySelector("#exercise p").style.color = "blue";
  }

  document.querySelector("#exercise p").style.fontSize 
  = parseFloat(document.querySelector("#exercise p").style.fontSize) * 2 + "px";
}