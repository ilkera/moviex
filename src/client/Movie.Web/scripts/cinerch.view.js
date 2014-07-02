// Views

// Movie Search View - AutoComplete
CinerchApp.MovieSearchView = Backbone.View.extend({
    ENTER_KEY_CONSTANT: 13,
    initialize: function () {
        this.currentMovieId = -1;
        this.render();
        this.initializeAutoComplete();
    },
    render: function () {
        var html = _.template($('#movieSearchbox-tpl').html());
        this.$el.html(html);
    },
    initializeAutoComplete: function () {
        var currentContext = this;
        // Fetch movie suggestions
        this.collection.fetch({
            success: function () {
                 $('#autocomplete').autocomplete({
                    lookup: currentContext.collection.toJSON(),
                    onSelect: function (suggestion) {
                        currentContext.updateCurrentMovie(suggestion.data);
                    }
                }).keypress(function (e) {
                    if (e.keyCode === this.ENTER_KEY_CONSTANT) {
                        currentContext.updateCurrentMovie(suggestion.data);
                    }
                });
            }
        });
    },
    updateCurrentMovie: function (movieId) {
        if (this.currentMovieId == movieId) {
           // same movie don't do anything.
            return;
        }

        this.currentMovieId = movieId;

        // Trigger movie selected event
        this.trigger('movieSelected', movieId);
    }
});

// MapView (Google map view)
CinerchApp.MapView = Backbone.View.extend({
    initialize: function () {
        google.maps.event.addDomListener(window, 'load', this.initMap());
        this.id = 0;
        this.movieLocationCache = {};
    },
    initMap: function () {
        this.map = new CinerchApp.Map({ mapCanvas: this.el });
    },
    render: function () {
        return this;
    },
    updateMap: function () {
        var currentContext = this;
        if (currentContext.map.hasMarkers()) {
            currentContext.map.deleteAllMarkers();
        }

        var markers = [];

        // Create markers data all locations
        currentContext.collection.each(function (location) {
            var longitude = parseFloat(location.get('Longitude'));
            var latitude = parseFloat(location.get('Latitude'));
            var locationName = location.get('Name');
            var locationId = location.get('LocationId');
            var funFacts = location.get('FunFacts');

            markers.push({ id: locationId, name: locationName, position: new google.maps.LatLng(latitude, longitude), funFacts: funFacts });
        });

        currentContext.map.addMarkers(markers);
    },
    updateMovieLocations: function (movieId) {
        if (this.id == movieId) {
            return;
        }

        var movieLocations = this.movieLocationCache[movieId];
        var currentContext = this;

        if (!movieLocations) {
            movieLocations = new CinerchApp.MovieLocationCollection([], { id: movieId });
            movieLocations.fetch({
                success: function () {
                    currentContext.movieLocationCache[movieId] = movieLocations;
                    currentContext.collection = movieLocations;
                    currentContext.updateMap();
                },
                error: function () {
                    currentContext.collection.id = previousId;
                    console.log('error fetching movie id' + movieId)
                }
            });

        }
        else {
            currentContext.collection.id = movieId;
            currentContext.collection = movieLocations;
            currentContext.updateMap();
        }
    }
});


// MovieInfo View
// Details about the movie (title, release year, director..)
CinerchApp.MovieInfoView = Backbone.View.extend({
    el: "#movie_info",
    initialize: function () {
        this.listenTo(this.model, 'change', this.render);
        if (this.model.get('id') != 0) {
            this.render();
        }
    },
    render: function () {
        var html = _.template($('#movieInfo-tpl').html(), this.model.toJSON());
        this.$el.html(html);
        return this;
    }
});


// Main App view
CinerchApp.MainAppView = Backbone.View.extend({
    el: "#cinerch_app",
    initialize: function (options) {
        // Views
        this.movieSearchView = options.movieSearchView;
        this.movieInfoView = options.movieInfoView;
        this.mapView = options.mapView;

        // Events
        this.listenTo(this.movieSearchView, 'movieSelected', this.updateMovie);
    },
    updateMovie: function (movieId) {
        var movie = this.collection.get(movieId);
        var canUpdateView = true;
        var currentContext = this;

        if (!movie) {
            movie = new CinerchApp.Movie({ id: movieId });

            movie.fetch({
                success: function () {
                    currentContext.collection.add(movie);
                },
                error: function () {
                    alert('error');
                    canUpdateView = false;
                }
            });

        }
        else {
            console.log('movie already exists in the collection');
        }

        if (canUpdateView) {
            // Update Movie Info
            this.movieInfoView = new CinerchApp.MovieInfoView({ model: movie });

            // Update movie locations
            this.mapView.updateMovieLocations(movieId);
        }
    }
});
