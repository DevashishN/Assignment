$(function () {
    let form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });
});

function registerResult() {
    var subject1 = parseInt($("#subject1").val());
    var grade1 = $("#grade1").val();
    var subject2 = parseInt($("#subject2").val());
    var grade2 = $("#grade2").val();
    var subject3 = parseInt($("#subject3").val());
    var grade3 = $("#grade3").val();


    if ((subject1 == subject2) || (subject1 == subject3) || (subject2 == subject3)) {
        toastr.error('You selected the same subject twice');
        return false;
    }

   

    var obj1 = {
        resultList: [{
            Subject: { SubjectId: subject1 },
            SubjectGrade: grade1
            },
            {
                Subject: { SubjectId: subject2 },
                SubjectGrade: grade2
            },
            {
                Subject: { SubjectId: subject3 },
                SubjectGrade: grade3
            }
    ]};

    sendData(obj1).then((response) => {
        //alert(response.result);
        if (response.result) {
            toastr.success("Results successfully entered");
            window.location.href = response.url;
        }
        else {
            toastr.error("Please provide appropriate result details");
            
        }
    })
        .catch((error) => {
            toastr.error("Something went wrong, Please try again!");
        });
}

function sendData(userResult) {
    //console.log( userResult);
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "/Result/EnterResult",
            data:userResult,
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