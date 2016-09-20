
(function () {
    var location = document.getElementById('location'),
        clock = document.getElementById('clock');

    if (!navigator.geolocation) {
        location.innerHTML = '<p>Geolocation is not supported by your browser</p>';
        return;
    }

    function getLocation() {
        return new Promise(function (resolve, reject) {
            navigator.geolocation.getCurrentPosition(
                function (position) {
                    resolve(position);
                },
                function (error) {
                    reject(error);
                }
            );
        });
    }

    function parseCoords(locationPosition) {
        if (locationPosition.coords) {
            return {
                latitude: locationPosition.coords.latitude,
                longitude: locationPosition.coords.longitude
            };
        }
        else {
            throw new Error('No coordinates.');
        }
    }

    function createLocationImage(coordsObj) {
        var img = document.createElement('img'),
            imgSrc = 'http://maps.googleapis.com/maps/api/staticmap?center=' + coordsObj.latitude + ',' + coordsObj.longitude + '&zoom=13&size=500x500&sensor=false';

        img.setAttribute('src', imgSrc);

        location.appendChild(img);
    }

    getLocation()
        .then(parseCoords)
        .then(createLocationImage);

    setInterval(function () {
        var currentDate = new Date();
        clock.innerHTML = currentDate.getHours() + ':' + currentDate.getMinutes() + ':' + currentDate.getSeconds();
    }, 1000);
})();