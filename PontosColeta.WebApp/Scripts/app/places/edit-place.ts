import Vue from 'vue';
import { Place } from './Place';
import 'bingmaps';

class Application {
    map: Microsoft.Maps.Map;

    vue = new Vue({
        el: "#app",
        data: {
            place: new Place()
        },
        methods: {
            submit(event: Event) {
                if (!$(event.srcElement as Element).valid()) return;
                console.log(this.place);
            }
        },
        created: () => { this.loadMap() }
    });

    loadMap() {
        try {
            this.map = new Microsoft.Maps.Map("#map", {});
            Microsoft.Maps.Events.addHandler(this.map, "click", this.mapClicked);
            Microsoft.Maps.loadModule('Microsoft.Maps.WellKnownText', {});
        } catch (e) {
            console.log(e);
            setTimeout(() => this.loadMap(), 500);
        }
    }

    mapClicked(args: Microsoft.Maps.IMouseEventArgs) {
        console.log(args.location);
        console.log(args.point);

        try {
            let loc = new Microsoft.Maps.Pushpin(args.location);
            console.log(Microsoft.Maps.WellKnownText.write(loc));
        } catch (e) {
            console.log(e);
        }
    }
}

let app = new Application();