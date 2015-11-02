/// <reference path="jquery-1.10.2.js" />
/// <reference path="jquery-1.10.2.intellisense.js" />
// via IvoAtanasov's diary

$(".RateStare").on("click", function() {
    console.log("enter");
    var number = $(this).data("number");
    $("#Rate").val(number);
    for (var i = 1; i <= 6; i++) {
        if (i <= number) {
            $('#str' + i).attr("src", "/Content/Images/full_star.png");
        } else {
            $('#str' + i).attr("src", "/Content/Images/empty_star.png");
        }
    }
});

