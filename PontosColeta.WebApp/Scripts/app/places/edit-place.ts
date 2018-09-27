import 'bingmaps';
import Vue from 'vue';
import axios from 'axios';
import { Place } from './Place';
import { Address } from './Address';

class Application {
    map: Microsoft.Maps.Map;

    vue = new Vue({
        el: "#app",
        data: {
            place: new Place(),
            loading: true
        },
        methods: {
            submit: (e: Event) => this.formSubmitted(e)
        },
        computed: {
            overlayStyle: function () {
                return { height: this.loading ? '100%' : '0' };
            }
        },
        created: () => this.loadMap()
    });

    get place() { return this.vue.place; }

    vueCreated() {
        this.loadMap();
    }

    loadStarted() {
        this.vue.loading = true;
    }

    loadFinished() {
        this.vue.loading = false;
    }

    formSubmitted(event: Event) {
        if (!$(event.srcElement as Element).valid()) return;
        if (!this.place.LocationWKT) {
            alert("Você deve selecionar um local no mapa.");
        }
        this.loadStarted();

        axios.post("/api/Places", this.place)
            .then(response => window.location.href = "/Places")
            .catch(response => console.log(response))
            .then(() => this.loadFinished());
    }

    mapClicked(args: Microsoft.Maps.IMouseEventArgs) {
        let location = args.location;
        console.log("Click: ");
        console.log(location);

        this.setLocation(location);
        this.searchAddress(location);
    }

    suggestionSelected(result: Microsoft.Maps.ISuggestionResult) {
        let addr = result.address;
        console.log("Suggestion selected: ");
        console.log(result);

        this.setView(result.bestView);
        this.setAddres(addr);
        this.setLocation(result.location);
    }

    // #region Load
    private loadMap() {
        try {
            this.map = new Microsoft.Maps.Map("#map", {});
            Microsoft.Maps.loadModule(["Microsoft.Maps.WellKnownText", "Microsoft.Maps.AutoSuggest", "Microsoft.Maps.Search"], () => this.modulesLoaded());
        } catch (e) {
            console.log(e);
            setTimeout(() => this.loadMap(), 500);
        }
    }

    private modulesLoaded() {
        try {
            Microsoft.Maps.Events.addHandler(this.map, "click", (e) => this.mapClicked(e as Microsoft.Maps.IMouseEventArgs));
            this.loadAutoSuggest();
            this.loadFinished();
        } catch (e) {
            console.log(e);
        }
    }

    private loadAutoSuggest() {
        try {
            let options: Microsoft.Maps.IAutosuggestOptions = {
                countryCode: "BR",
                map: this.map
            };
            let manager = new Microsoft.Maps.AutosuggestManager(options);
            manager.attachAutosuggest("#mapSearch", "#mapSearchContainer", (s) => this.suggestionSelected(s));
        } catch (e) {
            console.log(e);
        }
    }
    // #endregion

    private searchAddress(location: Microsoft.Maps.Location) {
        let searchManager = new Microsoft.Maps.Search.SearchManager(this.map);
        let reverseGeocodeRequestOptions: Microsoft.Maps.Search.ReverseGeocodeRequestOptions = {
            location: location,
            callback: (result, userData) => {
                this.setAddres(result.address);
                this.setView(result.bestView);
            }
        };
        searchManager.reverseGeocode(reverseGeocodeRequestOptions);
    }

    private setAddres(addr: Microsoft.Maps.IAddress) {
        let address = {
            Adress1: addr.addressLine,
            Adress2: addr.district,
            State: addr.adminDistrict,
            City: addr.locality,
            PostalCode: addr.postalCode
        } as Address;
        this.place.Address = address;
    }

    private setLocation(location: Microsoft.Maps.Location) {
        this.map.entities.clear();

        let pin = new Microsoft.Maps.Pushpin(location);
        this.map.entities.push(pin);
        this.place.LocationWKT = Microsoft.Maps.WellKnownText.write(pin);
    }

    setView(view: Microsoft.Maps.LocationRect) {
        this.map.setView({
            bounds: view
        });
    }
    
}

let app = new Application();