"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.start().then(function () {
    if (localStorage.getItem('user')) {//get ele eger user varsatrue eks halda false qaytarir
        ShowChatSection();
    }
}).catch(function (err) {
    return console.error(err.toString());
});

let joinGroupForm = document.getElementById('joinGroupForm');
let joinGroupSection = document.getElementById('joinGroupSection');
let chatSection = document.getElementById('chatSection');
let leaveGroupBtn = document.getElementById('leaveGroupBtn');
let sendMessageForm = document.getElementById('sendMessageForm');

joinGroupForm.addEventListener("submit", function (element) {
    element.preventDefault();  //default gorduyu is gorunmur(sorgu gondermek ve refresh)

    var user = {
        name: document.getElementById('username').value,
        group: document.getElementById('group').value
    }
        connection.invoke("AddToGroup", user.group).catch(function (err) {
        return console.error(err.toString());
    });
    localStorage.setItem('user', JSON.stringify(user));//stringfy=js objecti jsona cevirir
    ShowChatSection();
})


leaveGroupBtn.addEventListener('click', function () {
    var user = JSON.parse(localStorage.getItem('user')); //jsonu usere cevirir(useri burda saxlamaq lazimdiki
    //huba muraciet edende leave elediyin desin//  serverde lazim olacaq)
    connection.invoke("RemoveFromGroup", user.group).catch(function (err) {
        return console.error(err.toString());
    });
    localStorage.removeItem('user');
    ShowJoinGroupSection();
})

sendMessageForm.addEventListener("submit", function (element) {
    element.preventDefault();
    var user = JSON.parse(localStorage.getItem('user'));
    var message = document.getElementById('message').value;
        connection.invoke("SendMessage", user.group,user.name, message).catch(function (err) {
        return console.error(err.toString());
    });
   document.getElementById('message').value = '';
})

connection.on("ReceiveMessage", function (user, message) {
    var li = `<li class="list-grop-item">
        <b>${user}</b>
        <p>${message}</p>
    </li>`
    document.getElementById("messages").innerHTML+=li;
   
});

function ShowChatSection() {
    joinGroupSection.classList.add('d-none');
    chatSection.classList.remove('d-none');
}
function ShowJoinGroupSection() {
    chatSection.classList.add('d-none');
    joinGroupSection.classList.remove('d-none');
}

//var runtime(application run olan) zamani teyin olunur,let qoyuldugu setre catanda oxunur
//addeventlistener-her hansi actionu goturmeknucun use
//document.getElementById("sendButton").disabled = true;

//connection.on("ReceiveMessage", function (user, message) {
//    var li = document.createElement("li");
//    document.getElementById("messagesList").appendChild(li);
//    li.textContent = `${user} says ${message}`;
//});


//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});