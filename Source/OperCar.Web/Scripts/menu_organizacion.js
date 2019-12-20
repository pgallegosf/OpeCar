$(document).ready(function () {
    var heightNavBar = 160;
    if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
        heightNavBar = 0;
    }
    var menuId = localStorage.getItem("menu-organizacion-id");
       $("html,body").delay(1000).animate({
           scrollTop: $("#seccion-organizacion-" + menuId).offset().top - heightNavBar
    }, 1000);

});