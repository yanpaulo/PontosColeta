import Vue from 'vue';
import Component from 'vue-class-component';
import { Place } from './Place';

@Component({ name: "edit-places", template: "#template" })
class EditPlaces extends Vue {
    title = "Teste";
    place: Place;

    
}

const El = Vue.extend({
    el: "#app"
});