function checkScore() { 
    var rows = document.querySelectorAll("#score-form tbody tr");
    rows.forEach(function (row) {
        // Lấy giá trị của class max-score
        var maxScore = row.querySelector(".max-score").innerText;

        // Lấy giá trị của class score
        var score = row.querySelector(".score").value;

        // Sử dụng giá trị đã lấy được
        if (score <= maxScore && score >=0 && score <10) {
            row.querySelector(".note").innerHTML = "";
        } else {
            row.querySelector(".note").innerHTML = "*";
        }
        if (row.querySelector(".note").innerText == "*") {
            document.querySelector(".btn-submit").disabled = true;
        } else {
            document.querySelector(".btn-submit").disabled = false;
        }
    });
}
