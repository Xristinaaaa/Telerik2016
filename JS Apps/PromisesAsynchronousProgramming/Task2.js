(function () {
    var popupDiv = document.getElementById('popup');
    popupDiv.innerHTML='<p>Watch out!</p>';

    var promise = new Promise(function (resolve, reject) {
        setTimeout(function () {
            resolve('https://www.google.com');
        }, 2000);
    });

    promise
        .then(function (link) {
            document.location=link;
        });
})();