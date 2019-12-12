
/**
 * 
 * @param {string} text 
 */
function extractAllWords(text){
    let results = text.match(/\w+/g);
    console.log(results.map(x => x.toUpperCase()).join(", "));
}

extractAllWords('Hi, how are you?');