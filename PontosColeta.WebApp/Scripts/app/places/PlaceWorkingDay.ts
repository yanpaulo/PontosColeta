
export class PlaceWorkingDay {
    private static daysOfWeek = ["Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado"];
    constructor(public DayOfWeek: number) { }

    IsEnabled = false;

    StartTime: string;

    EndTime: string;

    get Name() {
        return PlaceWorkingDay.daysOfWeek[this.DayOfWeek];
    }

}
