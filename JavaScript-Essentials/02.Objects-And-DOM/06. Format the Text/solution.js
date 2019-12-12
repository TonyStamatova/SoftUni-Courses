function solve() {
  let text = document.getElementById("input").innerHTML;
  let sentences = text.split(/(?<=[.])[ ]/g);
  
  for (let i = 0; i < sentences.length; i+=3) {
    let paragraph = "";

    for (let j = i; j <= i + 2; j++) {
      if (sentences[j]) {
        paragraph += sentences[j] + " ";
      }
    }

    let newParagraph = document.createElement("p");
    newParagraph.appendChild(document.createTextNode(paragraph));
    let output = document.getElementById("output");
    output.appendChild(newParagraph);
  }
}