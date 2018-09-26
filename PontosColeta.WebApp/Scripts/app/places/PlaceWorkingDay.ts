
export class PlaceWorkingDay {
    private static daysOfWeek = ["Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado"];
    constructor(public DayOfWeek: number) { }

    StartTime: Date;

    EndTime: Date;

    get Name() {
        return PlaceWorkingDay.daysOfWeek[this.DayOfWeek];
    }

}
