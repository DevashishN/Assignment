$(function () {
    let form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });
});

function enrollStudent() {
    var firstName = $("#firstName").val();
    var lastName = $("#lastName").val();
    var address = $("#address").val();
    var phoneNumber = $("#phoneNumber").val();
    var dateOfBirth = $("#dateOfBirth").val();
    var guardianName = $("#guardianName").val();
    var emailAddress = $("#emailAddress").val(); // read email address input
    var nid = $("#nid").val();
    

    // create object to map LoginModel
    var authObj = {
        FirstName: firstName, LastName: lastName, Address: address, PhoneNumber: phoneNumber, DateOfBirth: dateOfBirth, GuardianName: guardianName,
        Email: emailAddress, NationalId: nid};
    // alert(emailAddress);

    sendData(authObj).then((response) => {
        //alert(response.result);
        if (response.result) {
            toastr.success("Application successful");
            //window.location.href = response.url;
        }
        else {
            toastr.error("User already exists");
            //alert("Incorrect credentials");
        }
    })
        .catch((error) => {
            toastr.error("Something went wrong, Please try again!");
        });
}

function sendData(userCredential) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "/Student/EnrollStudent",
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

