$(function () {
    let form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });
});

function signIn() {
    var emailAddress = $("#emailAddress").val(); // read email address input
    var password = $("#password").val(); // read password input
    // create object to map LoginModel
    var authObj = { Email: emailAddress, Password: password };
   // alert(emailAddress);
  
    sendData(authObj).then((response) => {
        //alert(response.result);
        if (response.result) {
            toastr.success("Welcome!");
            //window.location.href = response.url;
        }
        else {
            toastr.error("Incorrect credentials");
            //alert("Incorrect credentials");
        }
    })
        .catch((error) => {
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