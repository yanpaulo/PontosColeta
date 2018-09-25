import Vue from 'vue';
import { Place } from './Place';
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
    }
});

