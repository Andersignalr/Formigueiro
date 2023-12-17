
var focoAutomaticoNovasMensagens = true;

document.addEventListener('DOMContentLoaded', function () {
    var div = document.querySelector('.chat-area');
    div.scrollTop = div.scrollHeight;
    console.log("DOM carregado");
});

function focusById(elementId) {
    var element = document.getElementById(elementId);
    if (element) {
        element.focus();
    }
}


function pressButton(buttonId) {
    var element = document.getElementById(buttonId);
    if (element) {
        element.click();
    }
}


function enableAutoScroll() {
    focoAutomaticoNovasMensagens = true;
}

function chatScrolled(){
    var div = document.querySelector(".chat-area");

    var estaNoFinal = div.scrollHeight - div.scrollTop - 10 <= div.clientHeight;

    if (estaNoFinal) {
        focoAutomaticoNovasMensagens = true;
    console.log("ta no final");
    } else {
        focoAutomaticoNovasMensagens = false;
    console.log("nao ta no final");
    }

}

function autoScrollEnd(){
    if (focoAutomaticoNovasMensagens) {
        var div = document.querySelector(".chat-area");

        div.scrollTop = div.scrollHeight;
    }

    console.log("foi chamado");
}