var CinerchApp = {}; // Create namespace for the app

// Models
// Movie Suggestion model
CinerchApp.MovieSuggestion = Backbone.Model.extend({});

// Movie Suggestion collection - calls GET Movie API to fetch all movie names
CinerchApp.MovieSuggestions = Backbone.Collection.extend({
    model: CinerchApp.MovieSuggestion,
    url: function () {
        return Configuration.ServiceRoot + '/movie';
    }
});

// Map Model (Google map)
CinerchApp.Map = Backbone.Model.extend({
    defaults: function () {
        return {
            markers: [],
            infoWindow: null
        }
    },
    initialize: function (options) {
        _.bindAll(this, 'addSingleMarker');
        this.infoWindow = new google.maps.InfoWindow;

        this.markers = [];
        this.locationMarkerMap = {};
        this.mapCanvas = options.mapCanvas;
        this.mapOptions = {
            center: new google.maps.LatLng(37.7833, -122.4167),
            zoom: 12
        };
        google.maps.event.addDomListener(window, 'load', this.initMap());
    },
    initMap: function () {
        this.map = new google.maps.Map(this.mapCanvas, this.mapOptions);
    },
    hasMarkers: function () {
        return this.markers.length > 0;
    },
    addSingleMarker: function (locationId, locationName, position, funFacts) {
        var marker = new google.maps.Marker({
            position: position,
            map: this.map,
            draggable: false,
            animation: google.maps.Animation.DROP,
            title: locationName
        });

        var currentContext = this;

        google.maps.event.addListener(marker, 'click', function () {
            currentContext.setInfoWindowContent(locationId, funFacts);
        });

        this.markers.push(marker);
        this.locationMarkerMap[locationId] = marker;
    },
    addMarkers: function (locations) {
        var currentMapModel = this;
        $.each(locations, function (index, value) {
            setTimeout(function () {
                currentMapModel.addSingleMarker(value.id, value.name, value.position, value.funFacts);
            }, index * 250);
        });
    },
    deleteAllMarkers: function () {
        this.setAllMap(null);
        this.markers = [];
        locationMarkerMap = {};
    },
    setAllMap: function (map) {
        for (var i = 0; i < this.markers.length; i++) {
            this.markers[i].setMap(map);
        }
    },
    setInfoWindowContent: function (locationId, content) {
        if (this.locationMarkerMap[locationId]) {

            if (content.length > 0) {
                var marker = this.locationMarkerMap[locationId];

                var htmlContent = '<div class = "MarkerPopUp" style="width: 300px; height:100px"><div id="locationTitle">' + marker.title + '</div><div class = "MarkerContext">' + content + '</div></div>';
                this.infoWindow.setContent(htmlContent);
                this.infoWindow.open(this.map, marker);
            }
            else {
                this.infoWindow.close();
            }
                
        }
    }
});

// Movie Model - fetches movie information by calling GET movie/{id} web API
CinerchApp.Movie = Backbone.Model.extend({
    urlRoot: Configuration.ServiceRoot + '/movie',
    defaults: function () {
        return {
            id: 0,
            Title: '',
            ReleaseYear: 0,
            ProductionCompany: '',
            Distributor: '',
            Writer: '',
            Director: '',
            Actor1: '',
            Actor2: '',
            Actor3: ''
        }
    }
});

// Movie collection
CinerchApp.MovieCollection = Backbone.Collection.extend({
    model: CinerchApp.Movie
});

// Location Model
CinerchApp.Location = Backbone.Model.extend({
    defaults: {
        LocationId: 0,
        Longitude: 0.0,
        Latitude: 0.0,
        Name: '',
        ZipCode: 0,
        FunFacts: ''
    }
});

// Collection of movie locations 
// Fetches movie locations by calling GET movielocations/{id} web API
CinerchApp.MovieLocationCollection = Backbone.Collection.extend({
    initialize: function (models, options) {
        this.id = options.id;
    },
    url: function () {
        return Configuration.ServiceRoot + '/movielocations/' + this.id;
    },
    model: CinerchApp.Location
});
