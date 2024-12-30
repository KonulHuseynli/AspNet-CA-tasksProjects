function handle(delta) {
    var time = 1000;
    var distance = 1600;

    $('html, body').stop().animate({
        scrollTop: $(window).scrollTop() - (distance * delta)
    }, time );
}





function myFunction() {
  var x = document.getElementById("menu-links");
  if (x.style.display === "none") {
    x.style.display = "block";
  } else {
    x.style.display = "none";
  }
}
