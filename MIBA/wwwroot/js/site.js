﻿let btns = document.querySelectorAll("*[data-modal-btn]");

for (let i = 0; i < btns.length; i++) {
    btns[i].addEventListener('click', function () {
        let name = btns[i].getAttribute('data-modal-btn');
        let modal = document.querySelector("[data-modal-window='" + name + "']");
        modal.style.display = "block";
        document.getElementById("temp").classList.add("body-stop-scroll");
        let close = modal.querySelector(".close_modal_window");
        close.addEventListener('click', function () {
            modal.style.display = "none";
            document.getElementById("temp").classList.remove("body-stop-scroll");
        });
    });
}

window.onclick = function (event) {
    if (event.target.hasAttribute('data-modal-window')) {
        let modals = document.querySelectorAll('*[data-modal-window]');
        for (let i = 0; i < modals.length; i++) {
            modals[i].style.display = "none";
            document.getElementById("temp").classList.remove("body-stop-scroll");
        }
    }
}

function close_pop_up(id) {
    let modal = document.querySelector("[data-modal-window= 'modal_change_" + id + "']");
    modal.style.display = "none";
    document.getElementById("temp").classList.remove("body-stop-scroll");
}

function addTextToEditor(id) {
    var elem = document.getElementById(id).innerText;
    var sec_id = "placeholder_" + id;
    document.getElementById(sec_id).value = elem.trim();
}

function addTextToMain(id) {
    var sec_id = "placeholder_" + id;

    var div_main = document.getElementById(id);
    var div = document.createElement("div");
    div.classList.add("nav");
    div.classList.add("chapter-div");
    div.id = id;
    var li = document.createElement("li");
    li.classList.add("chapter");
    li.id = id + "li";
    li.innerHTML = document.getElementById(sec_id).value;
    var d = document.createElement("div");
    d.className = "btns";
    d.innerHTML = '<a onclick="addTextToEditor(' + id + ')" data-modal-btn="modal_change_' + id + '"> <div class="text-decoration-none btn btn-warning"> <svg xmlns="http://www.w3.org/2000/svg" width="25" height="25" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16"> <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" /> <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" /> </svg> </div> </a>'
    d.innerHTML += '<a onclick="addHidden(' + id + ')"><svg xmlns = "http://www.w3.org/2000/svg" width = "30" height = "30" fill = "red" class= "bi bi-x-circle-fill" viewBox = "0 0 16 16" > <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM5.354 4.646a.5.5 0 1 0-.708.708L7.293 8l-2.647 2.646a.5.5 0 0 0 .708.708L8 8.707l2.646 2.647a.5.5 0 0 0 .708-.708L8.707 8l2.647-2.646a.5.5 0 0 0-.708-.708L8 7.293 5.354 4.646z" /></svg ></a>';
    d.innerHTML += '<div data-modal-window="modal_change_' + id + '" class="modal1"> <div class="modal_edit_content"> <input id="placeholder_' + id + '" placeholder="Программа курса"> <div onclick="addTextToMain(' + id + ')" class="close_modal_window">Сохранить</div> <div class="close_modal_window">Отмена</div>  </div> </div>'
    div.appendChild(li);
    div.appendChild(d);
    div_main.innerHTML = div.innerHTML;
    let a_btns = document.querySelectorAll("*[data-modal-btn]");

    for (let i = 0; i < a_btns.length; i++) {
        a_btns[i].addEventListener('click', function () {
            let name = a_btns[i].getAttribute('data-modal-btn');
            let modal = document.querySelector("[data-modal-window='" + name + "']");
            modal.style.display = "block";
            document.getElementById("temp").classList.add("body-stop-scroll");
            let close = modal.querySelector(".close_modal_window");
            close.addEventListener('click', function () {
                modal.style.display = "none";
                document.getElementById("temp").classList.remove("body-stop-scroll");
            });
        });
    }
    let modals = document.querySelectorAll('*[data-modal-window]');
    for (let i = 0; i < modals.length; i++) {
        modals[i].style.display = "none";
        document.getElementById("temp").classList.remove("body-stop-scroll");
    }
}

function filterNewCourse(filter) {
    document.querySelector(".filter.active").classList.remove("active");
    document.querySelector("." + filter).classList.add("active");

    /*var btns = document.querySelectorAll(".btn-secondary");
    btns.forEach(element => {
        if (!element.classList.contains("hidden"))
            element.classList.add("hidden")
    });
    if (document.querySelector(".btn." + filter) != null)
        document.querySelector(".btn." + filter).classList.remove("hidden");*/

    var table = document.querySelector("table");
    var tr = table.getElementsByTagName("tr");
    for (var i = 1; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td.className == "false" && filter == "IsChecked") {
            if (!tr[i].classList.contains("hidden"))
                tr[i].classList.add("hidden");
        } else if (td.className == "true" && filter == "NotChecked") {
            if (!tr[i].classList.contains("hidden"))
                tr[i].classList.add("hidden");
        } else {
            tr[i].classList.remove("hidden");
        }
    }
}

function reveal() {
    var reveals = document.querySelectorAll(".main-block");
    for (var i = 0; i < reveals.length; i++) {
        var windowHeight = window.innerHeight;
        var elementTop = reveals[i].getBoundingClientRect().top;
        var elementVisible = 100;
        if (elementTop < windowHeight - elementVisible) {
            reveals[i].classList.add("active");
        } else {
            reveals[i].classList.remove("active");
        }
    }
};

window.addEventListener("scroll", reveal);

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
            document.getElementById("outer-programs").value += "<li><b>Раздел " + (number).toString() + "</b>. " + arrayCh[i].innerHTML + "</li>";
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
    var a1 = document.createElement("div");
    a1.className = "btns";
    a1.innerHTML = '<a onclick="addTextToEditor(' + (chapters + 1000).toString() + ')" data-modal-btn="modal_change_' + (chapters + 1000).toString() + '"> <div class="text-decoration-none btn btn-warning"> <svg xmlns="http://www.w3.org/2000/svg" width="25" height="25" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16"> <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" /> <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" /> </svg> </div> </a>'
    a1.innerHTML += '<a onclick="addHidden(' + (chapters + 1000).toString() + ')"><svg xmlns = "http://www.w3.org/2000/svg" width = "30" height = "30" fill = "red" class= "bi bi-x-circle-fill" viewBox = "0 0 16 16" > <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM5.354 4.646a.5.5 0 1 0-.708.708L7.293 8l-2.647 2.646a.5.5 0 0 0 .708.708L8 8.707l2.646 2.647a.5.5 0 0 0 .708-.708L8.707 8l2.647-2.646a.5.5 0 0 0-.708-.708L8 7.293 5.354 4.646z" /></svg ></a>';
    a1.innerHTML += '<div data-modal-window="modal_change_' + (chapters + 1000).toString() + '" class="modal1"> <div class="modal_edit_content"> <input id="placeholder_' + (chapters + 1000).toString() + '" placeholder="Программа курса"> <div onclick="addTextToMain(' + (chapters + 1000).toString() + ')" class="close_modal_window">Сохранить</div> <div class="close_modal_window">Отмена</div>  </div> </div>'
    div.appendChild(li);
    div.appendChild(a1);
    ul.appendChild(div);
    document.getElementById("chapter").value = "";


    let a_btns = document.querySelectorAll("*[data-modal-btn]");

    for (let i = 0; i < a_btns.length; i++) {
        a_btns[i].addEventListener('click', function () {
            let name = a_btns[i].getAttribute('data-modal-btn');
            let modal = document.querySelector("[data-modal-window='" + name + "']");
            modal.style.display = "block";
            document.getElementById("temp").classList.add("body-stop-scroll");
            let close = modal.querySelector(".close_modal_window");
            close.addEventListener('click', function () {
                modal.style.display = "none";
                document.getElementById("temp").classList.remove("body-stop-scroll");
            });
        });
    }
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

window.onload = function () {
    $(document).ready(function () {
        $(".owl-carousel").owlCarousel({
            loop: true,
            margin: 50,
            autoplay: true,
            smartSpeed: 1000,
            autoplayTimeout: 3000,
            autoplayHoverPause: true
        });
    });

    /*var width = window.innerWidth;
    var arr = document.querySelectorAll(".img-block");
    arr.forEach(item => {
        item.style.width = (width / 1920 * 400).toString() + "px";
        item.style.height = (width / 1920 * 400).toString() + "px";
    });
    document.querySelector(".first-image .img-block").style.width = (width / 1920 * 800).toString() + "px";
    document.querySelector(".first-image .img-block").style.height = (width / 1920 * 800).toString() + "px";
    document.querySelector(".fourth-image .img-block").style.width = (width / 1920 * 800).toString() + "px";
    document.querySelector(".fourth-image .img-block").style.height = (width / 1920 * 400).toString() + "px";*/
}

/*window.addEventListener("resize", function () {
    var width = window.innerWidth;
    var arr = document.querySelectorAll(".img-block");
    arr.forEach(item => {
        item.style.width = (width / 1920 * 400).toString() + "px";
        item.style.height = (width / 1920 * 400).toString() + "px";
    });
    document.querySelector(".first-image .img-block").style.width = (width / 1920 * 800).toString() + "px";
    document.querySelector(".first-image .img-block").style.height = (width / 1920 * 800).toString() + "px";
    document.querySelector(".fourth-image .img-block").style.width = (width / 1920 * 800).toString() + "px";
    document.querySelector(".fourth-image .img-block").style.height = (width / 1920 * 400).toString() + "px";
});*/

document.addEventListener('DOMContentLoaded', function () {
    const modalController = ({ modal, btnOpen, btnClose, time = 300 }) => {
        const buttonElems = document.querySelectorAll(btnOpen);
        const modalElem = document.querySelector(modal);

        modalElem.style.cssText = `
    display: flex;
    visibility: hidden;
    opacity: 0;
    transition: opacity ${time}ms ease-in-out;
  `;

        const closeModal = event => {
            const target = event.target;

            if (
                target === modalElem ||
                (btnClose && target.closest(btnClose)) ||
                event.code === 'Escape'
            ) {

                modalElem.style.opacity = 0;
                document.getElementById("temp").classList.remove("body-stop-scroll");
                setTimeout(() => {
                    modalElem.style.visibility = 'hidden';
                }, time);

                window.removeEventListener('keydown', closeModal);
            }
        }

        const openModal = () => {
            document.getElementById("temp").classList.add("body-stop-scroll");
            modalElem.style.visibility = 'visible';
            modalElem.style.opacity = 1;
            window.addEventListener('keydown', closeModal)
        };

        buttonElems.forEach(btn => {
            btn.addEventListener('click', openModal);
        });

        modalElem.addEventListener('click', closeModal);
    };

    modalController({
        modal: '.modal_reg',
        btnOpen: '.section__button_reg',
        btnClose: '.modal__close',
    });

    modalController({
        modal: '.modal_reg_anons',
        btnOpen: '.modal_reg_anons_open',
        btnClose: '.modal_reg__close'
    });

    modalController({
        modal: '.modal_rev_anon',
        btnOpen: '.modal_rev_anon',
        btnClose: 'modal_rev__close'
    });

    modalController({
        modal: '.modal_doc',
        btnOpen: '.modal_doc_open',
        btnClose: '.modal_doc__close'
    });
}, false);

function AddTag(tag) {
    var input = document.getElementById("for-add");
    if (tag == "strong")
        input.value += "<strong>Текст</strong>";
    else if (tag == "curs")
        input.value += "<i>Текст</i>";
    else if (tag == "br")
        input.value += "<br>";
    else if (tag == "href")
        input.value += '<a href="Ссылка">Текст</a>';
    else if (tag == "img")
        input.value += '<img width="Ширина" height="Высота" src="Ссылка" />';
}