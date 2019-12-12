function countWords(input) {
    let text = input.toString();
    let textWords = text.match(/\w+/g);
    let words = {};

    for (let i = 0; i < textWords.length; i++) {
        let current = textWords[i];

        if (!words[current]) {
            words[current] = 0;
        }

        words[current]++;
    }

    console.log(JSON.stringify(words));
}

countWords("Far too slow, you're far too slow.");