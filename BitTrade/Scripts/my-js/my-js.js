var navOpen = false;

function toggleNav() {
	if (navOpen) {
		closeNav();
	} else {
		openNav();
	}
	navOpen = !navOpen;
}

//function openNav() {
//	document.getElementById("myNav").style.width = "250px";
//}

//function closeNav() {
//	document.getElementById("myNav").style.width = "0";
//}
/* Toggle sidebar
	 -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- */
function openNav() {
	document.getElementById("mySidepanel").style.width = "250px";
}

function closeNav() {
	document.getElementById("mySidepanel").style.width = "0";
}