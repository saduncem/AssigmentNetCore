"use strict";

$('document').ready(function () {
    var list = document.getElementById("list");
    document.getElementById("headers").style.width = list.offsetWidth;
});

function RenderData(data) {
    console.log(data);
    var html = "";
    $.each(data, function (key, value) {
        html += "<div class=\"list-group-item list-group-item-action flex-column align-items-start\">";
        html += "<div class=\"d-flex w-100\">";
        html += "<div class=\"p-2 bd-highlight\">";
        html += "<span class=\"d-block p-2 bg-info  text-white\">KALKIŞ</span><span class=\"d-block p-2 bg-secondary text-white\">" + getdate(value["journey"]["departure"]) +"</span></div>";
        html += "<div class=\"d-block p-2\" style=\"position: relative; padding: 29px; \">";
        html += "<i class=\"fas fa-arrow-right\"></i> </div >";
        html += "<div class=\"p-2 bd-highlight\">";
        html += "<span class=\"d-block p-2 bg-info text-white\">VARIŞ</span>";
        html += "<span class=\"d-block p-2 bg-secondary text-white\">" + getdate(value["journey"]["arrival"]) + "</span></div>";
        html += "<div class=\"p-2 bd-highlight\">";
        html += "<div class=\"ml-auto p-2 bd-highlight\"><button type=\"button\" class=\"btn btn-danger\">" + value["journey"]["original-price"] +" TL </button></div></div></div>";
        html += "<p class=\"mb-1\">" + value["journey"]["origin"] +"-"+ value["journey"]["destination"]+"</p> </div>";
    });
    return html;
}
function getdate(date) {
    var odate = new Date(date);
    return odate.toLocaleTimeString('tr-TR');
}

function ChangeLocaiton() {
    var OutDestination = document.getElementById("OutDestination");
    var InDestination = document.getElementById("InDestination");

    var oldinex = InDestination.selectedIndex;
   
    InDestination.selectedIndex = OutDestination.selectedIndex;
    OutDestination.selectedIndex = oldinex;
}

function today(i) {
    var today = new Date();
    var dd = today.getDate() + 1;
    var mm = today.getMonth() + 1;
    var yyyy = today.getFullYear();

    today = dd + '/' + mm + '/' + yyyy;

    return today;
}
function MainAction() {
    var indexpage = document.getElementById("indexpage");
    if (indexpage.classList.contains("d-flex")) {
        document.getElementById("indexpage").classList.remove('d-flex');
        document.getElementById("indexpage").classList.add('indexpageclass');
    } else {
        document.getElementById("indexpage").classList.remove('indexpageclass');
        document.getElementById("indexpage").classList.add('d-flex');
    }
    var journeypage = document.getElementById("journeypage");
    if (journeypage.classList.contains("d-flex")) {
        document.getElementById("journeypage").classList.remove('d-flex');
        document.getElementById("journeypage").classList.add('journeypageclass');
    } else {
        document.getElementById("journeypage").classList.remove('journeypageclass');
        document.getElementById("journeypage").classList.add('d-flex');
    }
}

function Tommorrow(i) {
    var today = new Date();
    var dd = today.getDate() + 1;
    var mm = today.getMonth() + 1;
    var yyyy = today.getFullYear();

    today = dd + '/' + mm + '/' + yyyy;

    return today;
}

function GetTicket() {

    var modal = document.getElementById("exampleModal");
    modal.style.display = "block";
    var myForm = document.getElementById("myForm");
    var formData = new FormData();

    formData.append("transferdate", myForm["transferdate"].value);
    formData.append("OutDestination", myForm["OutDestination"].value);
    formData.append("InDestination", myForm["InDestination"].value);
    var request = new XMLHttpRequest();
    request.open("POST", "/Home/Journeys");
    request.send(formData);


    request.onreadystatechange = function () {
        if (this.readyState !== 4) return;
        if (this.status === 200) {
            MainAction();
            modal.style.display = "none";
            var data = JSON.parse(this.responseText);
            var dataobjce = JSON.parse(data);
            var htmllist = RenderData(dataobjce.data);
            $("#journeylist").html(htmllist);
        }
    };
}
function GetToday() {

    var modal = document.getElementById("exampleModal");
    modal.style.display = "block";
    var myForm = document.getElementById("myForm");
    var formData = new FormData();
    formData.append("transferdate", today());
    formData.append("OutDestination", myForm["OutDestination"].value);
    formData.append("InDestination", myForm["InDestination"].value);
    var request = new XMLHttpRequest();
    request.open("POST", "/Home/Journeys");
    request.send(formData);

    request.onreadystatechange = function () {
        if (this.readyState !== 4) return;

        if (this.status === 200) {
            MainAction();
            modal.style.display = "none";
            var data = JSON.parse(this.responseText);
            var dataobjce = JSON.parse(data);
            var htmllist = RenderData(dataobjce.data);
            $("#journeylist").html(htmllist);
        }
    };
}
function GetTommorrow() {
    var modal = document.getElementById("exampleModal");
    modal.style.display = "block";
    var myForm = document.getElementById("myForm");
    var formData = new FormData();
    formData.append("transferdate", Tommorrow());
    formData.append("OutDestination", myForm["OutDestination"].value);
    formData.append("InDestination", myForm["InDestination"].value);
    var request = new XMLHttpRequest();
    request.open("POST", "/Home/Journeys");
    request.send(formData);

    request.onreadystatechange = function () {
        if (this.readyState !== 4) return;

        if (this.status === 200) {
            MainAction();
            modal.style.display = "none";
            var data = JSON.parse(this.responseText);
            var dataobjce = JSON.parse(data);
            var htmllist = RenderData(dataobjce.data);
            $("#journeylist").html(htmllist);
        }
    };
}

$(function () {

    var configs = {
        datetime: {
            enableTime: false,
            dateFormat: "d/m/Y",
            minDate: "today",
            defaultDate: "today"
        }
    };
    var examples = document.querySelectorAll(".flatpickr");
    for (var i = 0; i < examples.length; i++) {
        flatpickr(examples[i], configs["datetime"] || {});
    }
   
});

