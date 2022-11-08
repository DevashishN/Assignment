$(function () {
    GetSummary();
});

function GetSummary() {

    getData().then((response) => {
        if (response) {
            console.log(response);
            summaryTable(response);
        }

    }).catch((error) => {
        console.error(error);
        toastr.error('');
    });
}

function getData() {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "GET",
            url: "/Admin/FetchStudentResults",
            data: null,
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

function summaryTable(studentSummary) {
    var table = $("table#studentInfoTable");
    var tbody = "";
    if (studentSummary) {
        for (var indexStudent = 0; indexStudent < studentSummary.length; indexStudent++) {
            let results = studentSummary[indexStudent].ResultList;
            let numResults = results.length;
            for (var resultIndex = 0; resultIndex < numResults; resultIndex++) {
                if (resultIndex == 0) {
                    var status = "";
                    if (studentSummary[indexStudent].Status == 1) {
                        status = "Waiting";
                    }
                    else if (studentSummary[indexStudent].Status == 2) {
                        status = "Approved";
                    }
                    else {
                        status = "Rejected";
                    }
                    tbody += `<tr>

                    <td rowspan='${numResults}'>${indexStudent + 1}</td>
                    <td rowspan='${numResults}'>${studentSummary[indexStudent].FirstName}</td>
                    <td rowspan='${numResults}'>${studentSummary[indexStudent].LastName}</td>
                    <td>${results[resultIndex].Subject.SubjectName}</td>
                    <td>${results[resultIndex].SubjectGrade}</td>
                    <td rowspan='${numResults}'>${studentSummary[indexStudent].TotalScore}</td>
                    <td rowspan='${numResults}'>${status}</td>
                    </tr>`;
                }
                else {
                    tbody += `<tr>
                    <td>${results[resultIndex].Subject.SubjectName}</td>
                    <td>${results[resultIndex].SubjectGrade}</td>
                    </tr>`;
                }
            }
        }
    }
    else {
        tbody = "<tr colspan='7'>No students found</tr>";
    }
    table.append(tbody);
}