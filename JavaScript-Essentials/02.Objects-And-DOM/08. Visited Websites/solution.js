function solve() {
  let elements = document.getElementsByClassName("link-1");

  for (let i = 0; i < elements.length; i++) {
    elements[i].addEventListener('click', (e) => {
      let current = e.currentTarget;
      let paragraph = current.getElementsByTagName("p")[0];
      let textWords = paragraph.textContent.split(" ");
      textWords[1]++;
      paragraph.textContent = textWords.join(" ");
    });
  }
}