$(".content").hide();
$(".header").css("font-style","italic");

$(".header").click(function (event) {
    event.preventDefault();
    $header = $(this);
    $content = $header.next();
    $content.slideToggle(500, function () {
        $header.text(function(){
            return $content.is(":visible") ? "Hide description" : "See description";
        });
    });
});