import Vue from 'vue';
import { Place } from './Place';
const vue = new Vue({
    el: "#app",
    data: {
        place: new Place()
    },
    methods: {
        teste(event: Event) {
            if (!$(event.srcElement as Element).valid()) {
                event.preventDefault();
                return;
            }
        }
    }
});

