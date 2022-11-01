$(function () {
    let form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });
});

function signIn() {
    var emailAddress = $("#emailAddress").val();
    var password = $("#password").val();
    var authObj = { Email: emailAddress, Password: password };

    sendData(authObj).then((response) => {
        if (response.result) {
            toastr.success("Welcome!");
            window.location = response.url;
        }
        else {
            toastr.error("Incorrect credentials");
        }
    }).catch((error) => {
        toastr.error("Unable to authenticate. Please try again!");
    });
}

function sendData(userCredential) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "/Login/Authenticate",
            data: userCredential,
            dataType: "json",
            success: function (data) {
                resolve(data)
            },
            error: function (error) {
                reject(error)
            }
        })
    });
}