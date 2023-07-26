// Gets the first message
function firstBotMessage() {
    let firstMessage = "How's it going?"
    document.getElementById("botStarterMessage").innerHTML = '<p class="botText"><span>' + firstMessage + '</span></p>';

    document.getElementById("userInput").scrollIntoView(false);
}
firstBotMessage();


//Получает ответ
function getHardResponse(userText) {
    let botResponse = getBotResponse(userText);
    let botHtml = '<p class="botText"><span>' + botResponse + '</span></p>';
    $("#chatbox").append(botHtml);

    document.getElementById("chat-bar-bottom").scrollIntoView(true);
}

//Получает текстовый текст из поля ввода и обрабатывает его
function getResponse() {
    let userText = $("#textInput").val();

    if (userText.trim().length !== 0) {
        let userHtml = '<p class="userText"><span>' + userText + '</span></p>';

        $("#textInput").val("");
        $("#chatbox").append(userHtml);
        document.getElementById("chat-bar-bottom").scrollIntoView(true);

        setTimeout(() => {
            getHardResponse(userText);
        }, 1000)
    }
}

//Обрабатывает отправку текста с помощью нажатия кнопки
function buttonSendText(sampleText) {
    let userHtml = '<p class="userText"><span>' + sampleText + '</span></p>';

    $("#textInput").val("");
    $("#chatbox").append(userHtml);
    document.getElementById("chat-bar-bottom").scrollIntoView(true);
}

function sendButton() {
    var form = document.getElementById("myForm");
    var formData = new FormData(form);
  
    fetch(form.action, {
      method: form.method,
      body: formData
    }).then(function(response) {
      // Обработка ответа от сервера
      console.log(response);
    }).catch(function(error) {
      // Обработка ошибок
      console.error(error);
    });
  
    getResponse();
}