


function returnZeroForMinus(number) {
    if (number < 0) {
        return 0;
    }
}

function randomColorCode() {
    var dataArray = [];
    var j = 0;
    dataArray[j] = "#00558F;";
    j++;
    dataArray[j] = "#5cb85c;";
    j++;
    dataArray[j] = "#f0ad4e;";
    j++;
    dataArray[j] = "#d9534f;";
    j++;
    //dataArray[j] = "#337ab7;";
    //j++;
    dataArray[j] = "#583b7d;";
    j++;
    dataArray[j] = "#4fd5d6;";
    j++;
    dataArray[j] = "#400d12;";
    j++;

    var l = dataArray[Math.floor(Math.random() * dataArray.length)];
    return l;
}





function countTableColumnValueTotals(columnNumber, tableName) {
    //var tableName = "#callTagTatTable tr";
    var total = 0;
    var countTableRow = $(tableName).length;

    for (var i = 1; i < countTableRow; i++) {
        var cellValue = parseInt($(tableName).eq(i).find("td:nth-child(" + columnNumber + ")").text());
        total = total + cellValue;
    }

    return total;
}


function sumCumulative(columnNumber, tableName) {


    var total = parseInt($(tableName).eq(1).find("td:nth-child(7)").text());
    var cellValue = parseInt($(tableName).eq(1).find("td:nth-child(" + columnNumber + ")").text());
    var result = 0;

    if (cellValue > 0) {
        result = (cellValue / total) * 100;
    }

    //alert(result);
    return (Math.round(result));
    //return result;
}



function disableSubmitDiv() {
    //$("#submitButtonDiv *").attr("disabled", "disabled").off('click'); //Code for disable all element under this div
    $('#submitButtonDiv :input').attr('disabled', true); //Code for disable only input type under this div
}

function enableSubmitDiv() {
    $('#submitButtonDiv :input').removeAttr('disabled');
}


//function resetSubmitButton(divName, buttonId, onclickFunction) {
//    document.getElementById(divName).innerHTML = " <input type='button' id=" + buttonId + " value='Done'  onclick = 'sa()' "/>";
//}


function searchTableByMultipleColumn(table_id) {
    var q = document.getElementById("searchField");
    var words = q.value.toLowerCase().split(" ");
    var table = document.getElementById(table_id);
    var ele;
    for (var r = 1; r < table.rows.length; r++) {
        ele = table.rows[r].innerHTML.replace(/<[^>]+>/g, "");
        var displayStyle = 'none';
        for (var i = 0; i < words.length; i++) {
            if (ele.toLowerCase().indexOf(words[i]) >= 0)
                displayStyle = '';
            else {
                displayStyle = 'none';
                break;
            }
        }
        table.rows[r].style.display = displayStyle;
    }
}


function reloadPage() {

    document.location.reload(true);
}

function getFirstDayOfCurrentMonth() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();

    if (dd < 10) {
        dd = '0' + dd;
    }

    if (mm < 10) {
        mm = '0' + mm;
    }

    today = yyyy + '-' + mm + '-' + '01';
    return today;
}

function getCurrentDate() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();

    if (dd < 10) {
        dd = '0' + dd;
    }

    if (mm < 10) {
        mm = '0' + mm;
    }

    today = yyyy + '-' + mm + '-' + dd;
    return today;
}

function setCurrentDate() {
    var currentDate = getCurrentDate();
    var diagonosisDateField = document.getElementById("currentDateField");
    diagonosisDateField.value = currentDate;
}

function setCurrentDateNew() {
    var currentDate = getCurrentDate();
    var diagonosisDateField = document.getElementById("endDateField");
    diagonosisDateField.value = currentDate;
}




function checkDateValidation(smallerDate, biggerDate) {
    var source = "";

    var smallerDateArray = smallerDate.split("/");
    var biggerDateArray = biggerDate.split("/");

    var sDay = smallerDateArray[1];
    var bDay = biggerDateArray[1];

    var sMonth = smallerDateArray[0];
    var bMonth = biggerDateArray[0];

    var sYear = smallerDateArray[2];
    var bYear = biggerDateArray[2];

    var isBigger = true;

    if (sYear > bYear) {
        isBigger = false;
        source = "Year";
    } else if (sYear == bYear) {
        if (sMonth > bMonth) {
            isBigger = false;
            source = "Month";
        } else if (sMonth == bMonth) {
            if (sDay > bDay) {
                isBigger = false;
                source = "Day";
            }
        }
    }

    return isBigger;
}



function clearAllData() {
    $('.container').find('input:text').val('');
    $('.container textarea').val('');
    $("select").each(function () { this.selectedIndex = 0 });
    $('.container').find('input[type=checkbox]').prop("checked", false);
    //$('.container').find('input:file').val('');


}


function returnZeroForNull(value) {
    if (value == null) {
        return 0;
    } else {
        return value;
    }
}



function returnBlankForNull(value) {
    if (value == null) {
        return "";
    } else {
        return value;
    }
}


function nameOfMonth(m) {
    if (m == 1) {
        m = "January";
    } else if (m == 2) {
        m = "February";
    } else if (m == 3) {
        m = "March";
    } else if (m == 4) {
        m = "April";
    } else if (m == 5) {
        m = "May";
    } else if (m == 6) {
        m = "June";
    } else if (m == 7) {
        m = "July";
    } else if (m == 8) {
        m = "August";
    } else if (m == 9) {
        m = "September";
    } else if (m == 10) {
        m = "October";
    } else if (m == 11) {
        m = "November";
    } else if (m == 12) {
        m = "December";
    }

    return m;
}

function JSONDateWithTime(dateStr) {
    jsonDate = dateStr;
    var d = new Date(parseInt(jsonDate.substr(6)));


    var m, day;
    m = d.getMonth() + 1;
    if (m < 10)
        m = '0' + m;
    if (d.getDate() < 10)
        day = '0' + d.getDate();
    else
        day = d.getDate();

    //------- This code shouldn't be deleted----------------------
        m = nameOfMonth(m);
        var formattedDate = day + " " + m + ", " + d.getFullYear();
    //------------------------------------------------------------

    //var formattedDate = m + "/" + day + "/" + d.getFullYear();

    formattedDate = formattedDate;
    return formattedDate;
}



//function loadUserName() {
//    var x = "";
//    $.ajax({
//        type: "POST",
//        url: '@Url.Action("LoadUserName", "Home")',
//        contentType: "application/json; charset=utf-8",
//        data: JSON.stringify({ "X": x }),
//        dataType: "json",
//        success: function (data) {
//            if (data == null || data == "null" || data == "") {
//                var url = $("#GoLogInPage").val();
//                location.href = url;
//            } else {
//                document.getElementById("userName").innerHTML = data;
//                document.getElementById("userIconDiv").innerHTML = "<img style='width:14px; height:14px;' src='~/Content/Image/userIcon.png' />";

//            }
//        }
//    });

//}


