import Vue from 'vue';
import { Place } from './Place';
import 'bingmaps';

let map: Microsoft.Maps.Map;

const vue = new Vue({
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
    created: () => {
        loadMap();
    }
});

function loadMap() {
    try {
        map = new Microsoft.Maps.Map("#map", {});
    } catch (e) {
        console.log(e);
        setTimeout(loadMap, 500);
    }
}

