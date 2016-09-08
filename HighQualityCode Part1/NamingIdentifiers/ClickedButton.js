function onButtonClick(ev, args) {
  var board= window,
      browser = board.navigator.appCodeName,
      name=browser=="Mozilla";

  if(name) {
    alert("Yes");
  } else {
    alert("No");
  }
}