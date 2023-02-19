function addHidden(id) {
    document.getElementById(id).classList.add("hidden");
    document.getElementById(id.toString() + "li").classList.add("hidden");
}

function addFinalData() {
    document.getElementById("outer-programs").value = "";
    var arrayCh = document.querySelectorAll(".chapter");
    var number = 1;
    for (var i = 0; i < arrayCh.length; i++) {
        if (!arrayCh[i].classList.contains("hidden")) {
            document.getElementById("outer-programs").value += "<li>Раздел " + (number).toString() + ". " + arrayCh[i].innerHTML + "</li>";
            number++;
        }
    }
    document.getElementById("outer-lectors").value = "";
    var arrayLect = document.querySelectorAll(".lector");
    var count = 0;
    for (var i = 0; i < arrayCh.length; i++) {
        if (count != 0)
            document.getElementById("outer-lectors").value += " ";
        if (!arrayLect[i].classList.contains("hidden")) {
            document.getElementById("outer-lectors").value += arrayLect[i].id;
            count++;
        }
    }
};

function addChapter() {
    var chapters = document.querySelectorAll(".chapter").length;
    var ul = document.getElementById("programs");
    var div = document.createElement("div");
    div.classList.add("nav");
    div.classList.add("chapter-div");
    div.id = (chapters + 1000).toString();
    var text = document.getElementById("chapter").value;
    var li = document.createElement("li");
    li.classList.add("chapter");
    li.id = (chapters + 1000).toString() + "li";
    li.innerHTML = text;
    var a = document.createElement("a");
    a.innerHTML = '<a onclick="addHidden(' + (chapters + 1000).toString() + ')" style="margin-top: 20px; margin-left: 20px;"><svg xmlns = "http://www.w3.org/2000/svg" width = "30" height = "30" fill = "red" class= "bi bi-x-circle-fill" viewBox = "0 0 16 16" > <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM5.354 4.646a.5.5 0 1 0-.708.708L7.293 8l-2.647 2.646a.5.5 0 0 0 .708.708L8 8.707l2.646 2.647a.5.5 0 0 0 .708-.708L8.707 8l2.647-2.646a.5.5 0 0 0-.708-.708L8 7.293 5.354 4.646z" /></svg ></a>';
    div.appendChild(li);
    div.appendChild(a);
    ul.appendChild(div);
    document.getElementById("chapter").value = "";
}

function addLector() {
    if (document.querySelectorAll(".lector").length == 0)
        document.getElementById("outer-lectors").value = "";
    var ul = document.getElementById("lectors");
    var div = document.createElement("div");
    div.classList.add("nav");
    div.classList.add("lectors-div");
    var li = document.createElement("li");
    li.classList.add("lector");
    var select = document.getElementById("lector");
    var value = select.value;
    var text = select.options[select.selectedIndex].text;
    li.appendChild(document.createTextNode(text));
    var a = document.createElement("a");
    a.innerHTML = '<a onclick="addHidden(' + value + ')"  style="margin-top: 20px; margin-left: 20px;"><svg xmlns = "http://www.w3.org/2000/svg" width = "30" height = "30" fill = "red" class= "bi bi-x-circle-fill" viewBox = "0 0 16 16" > <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM5.354 4.646a.5.5 0 1 0-.708.708L7.293 8l-2.647 2.646a.5.5 0 0 0 .708.708L8 8.707l2.646 2.647a.5.5 0 0 0 .708-.708L8.707 8l2.647-2.646a.5.5 0 0 0-.708-.708L8 7.293 5.354 4.646z" /></svg ></a>';
    li.id = value.toString() + "li";
    div.id = value;
    div.appendChild(li);
    div.appendChild(a);
    ul.appendChild(div);
}