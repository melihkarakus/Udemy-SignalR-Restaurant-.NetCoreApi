// SignalR hub ba�lant�s�n� olu�turur
var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7123/SignalRHub").build();

// G�nderme butonunu ba�lang��ta devre d��� b�rak�r
document.getElementById("sendbutton").disabled = true;

// Mesaj alma i�lemini dinler ve ekrana g�sterir
connection.on("ReceiveMessage", function (user, message) {
    var currentTime = new Date();
    var currentHour = currentTime.getHours();
    var currentMinute = currentTime.getMinutes();

    // Yeni bir liste ��esi (li) olu�turur
    var li = document.createElement("li");
    // Kullan�c� ad�n� kal�n yaz� tipiyle ekler
    var span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user;
    li.appendChild(span);
    // Mesaj� ve g�nderilme zaman�n� liste ��esine ekler
    li.innerHTML += `: ${message} - ${currentHour}:${currentMinute}`;
    // Mesaj listesine (ul) yeni liste ��esini ekler
    document.getElementById("messagelist").appendChild(li);
});

// SignalR ba�lant�s�n� ba�lat�r
connection.start().then(function () {
    // Ba�lant� ba�ar�l� oldu�unda g�nderme butonunu etkinle�tirir
    document.getElementById("sendbutton").disabled = false;
}).catch(function (err) {
    // Hata durumunda konsola hata mesaj�n� yazd�r�r
    return console.error(err.toString());
});

// G�nderme butonuna t�klama olay�n� dinler
document.getElementById("sendbutton").addEventListener("click", function (event) {
    // Kullan�c� ad� ve mesaj� al�r
    var user = document.getElementById("userinput").value;
    var message = document.getElementById("messageinput").value;

    // Sunucuya SendMessage metodu arac�l���yla mesaj� g�nderir
    connection.invoke("SendMessage", user, message).catch(function (err) {
        // Hata durumunda konsola hata mesaj�n� yazd�r�r
        return console.error(err.toString());
    });
    // Sayfan�n yeniden y�klenmesini engeller
    event.preventDefault();
});