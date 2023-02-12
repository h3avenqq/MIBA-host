var chapters = 1;

function addChapter() {
    if (document.querySelectorAll(".chapter").length == 0)
        chapters = 1;
    var ul = document.getElementById("programs");
    var li = document.createElement("li");
    li.classList.add("chapter");
    var text = document.getElementById("chapter").value;
    li.appendChild(document.createTextNode("Раздел " + chapters + ". " + text));
    document.getElementById("outer-programs").value += "<li>Раздел " + chapters + ". " + text + "</li>";
    chapters++;
    ul.appendChild(li);
    document.getElementById("chapter").value = "";
}

function addLector() {
    if (document.querySelectorAll(".lector").length == 0)
        document.getElementById("outer-lectors").value = "";
    var ul = document.getElementById("lectors");
    var li = document.createElement("li");
    li.classList.add("lector");
    var select = document.getElementById("lector");
    var value = select.value;
    var text = select.options[select.selectedIndex].text;
    li.appendChild(document.createTextNode(text));
    if (document.getElementById("outer-lectors").value != "") {
        document.getElementById("outer-lectors").value += " ";
    }
    document.getElementById("outer-lectors").value += value;
    ul.appendChild(li);
}