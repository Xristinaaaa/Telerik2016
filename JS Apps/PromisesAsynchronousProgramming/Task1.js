var button = document.getElementById('btn');
button.addEventListener('click', flow);

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
    } else {
        throw new Error('No coordinates.');
    }
}

function createLocationImage(coordsObj) {
    let img = document.createElement('img'),
        imgSrc = 'http://maps.googleapis.com/maps/api/staticmap?center=' + coordsObj.latitude + ',' + coordsObj.longitude + '&zoom=13&size=500x500&sensor=false',
        wrapper = document.getElementById('wrapper');

    img.setAttribute('src', imgSrc);

    wrapper.appendChild(img);
}

function flow() {
    getLocation()
        .then(parseCoords)
        .then(createLocationImage);
}