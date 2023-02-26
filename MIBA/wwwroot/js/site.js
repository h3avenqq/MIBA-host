let btns = document.querySelectorAll("*[data-modal-btn]");

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
}

window.addEventListener("resize", function () {
    var width = window.innerWidth;
    document.querySelector(".info h1").style.fontSize = (width / 1920 * 45).toString() + "px";
    var arr = document.querySelectorAll(".img-block");
    arr.forEach(item => {
        item.style.width = (width / 1920 * 300).toString() + "px";
        item.style.height = (width / 1920 * 300).toString() + "px";
        item.style.padding = (width / 1920 * 1).toString() + "rem";
    });
    document.querySelector(".first-image .img-block").style.width = (width / 1920 * 600).toString() + "px";
    document.querySelector(".first-image .img-block").style.height = (width / 1920 * 600).toString() + "px";
});

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
}, false);