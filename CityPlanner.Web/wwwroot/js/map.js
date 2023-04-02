function initMap(id, buildingX, buildingY, nearPointsData) {

    // Create a new map object
    var map = new google.maps.Map(document.getElementById(id), {
        center: { lat: buildingY, lng: buildingX },
        zoom: 12,
        styles: [
            {
                "featureType": "administrative",
                "elementType": "labels.text.fill",
                "stylers": [
                    {
                        "color": "#444444"
                    }
                ]
            },
            {
                "featureType": "landscape",
                "elementType": "all",
                "stylers": [
                    {
                        "color": "#f2f2f2"
                    }
                ]
            },
            {
                "featureType": "poi",
                "elementType": "all",
                "stylers": [
                    {
                        "visibility": "off"
                    }
                ]
            },
            {
                "featureType": "road",
                "elementType": "all",
                "stylers": [
                    {
                        "saturation": -100
                    },
                    {
                        "lightness": 45
                    }
                ]
            },
            {
                "featureType": "road.highway",
                "elementType": "all",
                "stylers": [
                    {
                        "visibility": "simplified"
                    }
                ]
            },
            {
                "featureType": "road.arterial",
                "elementType": "labels.icon",
                "stylers": [
                    {
                        "visibility": "off"
                    }
                ]
            },
            {
                "featureType": "transit",
                "elementType": "all",
                "stylers": [
                    {
                        "visibility": "off"
                    }
                ]
            },
            {
                "featureType": "water",
                "elementType": "all",
                "stylers": [
                    {
                        "color": "#46bcec"
                    },
                    {
                        "visibility": "on"
                    }
                ]
            }
        ]
    });

    // Define the coordinates of the address you want to mark
    var addressLatLng = new google.maps.LatLng(buildingY, buildingX);
    // var addressLatLng = new google.maps.LatLng(48.688293, 21.2853491);

    // Create a new marker object with the address coordinates
    var marker = new google.maps.Marker({
        position: addressLatLng,
        map: map,
        icon: {
            url: "../icons/map_red.svg",
            scaledSize: new google.maps.Size(40, 40)
        }
    });

    // Define the center of the circle (in this case, the Googleplex)
    var center = new google.maps.LatLng(buildingY, buildingX);

    // Define the radius of the circle in meters
    var radius = 1000;

    // Create a new circle object with the center and radius
    var circle = new google.maps.Circle({
        center: center,
        radius: radius,
        map: map,
        fillColor: "#007aff",
        fillOpacity: 0.2,
        strokeWeight: 0
    });

    // Auto zoom to fit the circle on the map
    var bounds = circle.getBounds();
    map.fitBounds(bounds);

    console.log(nearPointsData)
    nearPointsData.forEach(point => {
        new google.maps.Marker({
            position: new google.maps.LatLng(point.y, point.x),
            map: map,
            icon: {
                url: "../icons/map_blue.svg",
                scaledSize: new google.maps.Size(15, 15)
            }
        })
    })
}
