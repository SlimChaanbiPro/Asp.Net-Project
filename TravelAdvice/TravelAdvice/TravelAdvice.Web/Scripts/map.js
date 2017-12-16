var directionsDisplay;
	var directionsService = new google.maps.DirectionsService();
	var map;

	function initialize() {
		directionsDisplay = new google.maps.DirectionsRenderer();
		var tunis = new google.maps.LatLng(35.5973289, 9.8738756);
		var mapOptions = {
			zoom : 7,
			center : tunis
		};
		map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
		directionsDisplay.setMap(map);
		
		
		var input = (document.getElementById('start'));
		var searchBox = new google.maps.places.SearchBox((input));
		google.maps.event.addListener(map, 'bounds_changed', function() {
			var bounds = map.getBounds();
			searchBox.setBounds(bounds);
		});

		var input2 = (document.getElementById('end'));
		var searchBox2 = new google.maps.places.SearchBox((input2));
		google.maps.event.addListener(map, 'bounds_changed', function() {
			var bounds = map.getBounds();
			searchBox2.setBounds(bounds);
		});
	}		
	
	function calcRoute() {
		var start = document.getElementById('start').value;
		var end = document.getElementById('end').value;
		var request = {
			origin : start,
			destination : end,
			travelMode : google.maps.TravelMode.DRIVING
		};
		directionsService.route(request, function(response, status) {
			if (status == google.maps.DirectionsStatus.OK) {
				directionsDisplay.setDirections(response);
			}
		});
	}
	google.maps.event.addDomListener(window, 'load', initialize);
