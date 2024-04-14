// SignalR hub baðlantýsýný oluþturur
var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7123/SignalRHub").build();

// Gönderme butonunu baþlangýçta devre dýþý býrakýr
document.getElementById("sendbutton").disabled = true;

// Mesaj alma iþlemini dinler ve ekrana gösterir
connection.on("ReceiveMessage", function (user, message) {
    var currentTime = new Date();
    var currentHour = currentTime.getHours();
    var currentMinute = currentTime.getMinutes();

    // Yeni bir liste öðesi (li) oluþturur
    var li = document.createElement("li");
    // Kullanýcý adýný kalýn yazý tipiyle ekler
    var span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user;
    li.appendChild(span);
    // Mesajý ve gönderilme zamanýný liste öðesine ekler
    li.innerHTML += `: ${message} - ${currentHour}:${currentMinute}`;
    // Mesaj listesine (ul) yeni liste öðesini ekler
    document.getElementById("messagelist").appendChild(li);
});

// SignalR baðlantýsýný baþlatýr
connection.start().then(function () {
    // Baðlantý baþarýlý olduðunda gönderme butonunu etkinleþtirir
    document.getElementById("sendbutton").disabled = false;
}).catch(function (err) {
    // Hata durumunda konsola hata mesajýný yazdýrýr
    return console.error(err.toString());
});

// Gönderme butonuna týklama olayýný dinler
document.getElementById("sendbutton").addEventListener("click", function (event) {
    // Kullanýcý adý ve mesajý alýr
    var user = document.getElementById("userinput").value;
    var message = document.getElementById("messageinput").value;

    // Sunucuya SendMessage metodu aracýlýðýyla mesajý gönderir
    connection.invoke("SendMessage", user, message).catch(function (err) {
        // Hata durumunda konsola hata mesajýný yazdýrýr
        return console.error(err.toString());
    });
    // Sayfanýn yeniden yüklenmesini engeller
    event.preventDefault();
});