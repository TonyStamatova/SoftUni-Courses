function createArticle() {
	let articles = document.getElementById("articles");
	let title = document.getElementById("createTitle").value;
	let content = document.getElementById("createContent").value;

	if (title !== "" && content !== "") {
		var newArticle = document.createElement("article");
		let newArticleTitle = document.createElement("h3");
		newArticleTitle.appendChild(document.createTextNode(title));
		newArticle.appendChild(newArticleTitle);
		let newArticleContent = document.createElement("p");
		newArticleContent.appendChild(document.createTextNode(content));
		newArticle.appendChild(newArticleContent);
		articles.appendChild(newArticle);
	}
	
	document.getElementById("createTitle").value = "";
	document.getElementById("createContent").value = "";
};