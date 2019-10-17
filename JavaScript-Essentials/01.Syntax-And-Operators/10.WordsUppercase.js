function transform(text) {
    var pattern = /\w+/g,
        matches,
        words = [];

    while (matches = pattern.exec(text)) {
        words.push(decodeURIComponent(matches[0]));
    }

    return words.join(', ').toUpperCase();
}

console.log(transform('Hi, how are you?'));
