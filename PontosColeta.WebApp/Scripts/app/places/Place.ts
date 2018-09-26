import { Address } from "./Address";
import { PlaceWorkingDay } from "./PlaceWorkingDay";

export class Place {
    Id: number;

    Name: string;

    LocationWKT: string;

    Address = new Address();

    WorkingDays: PlaceWorkingDay[] =
        [0, 1, 2, 3, 4, 5, 6].map(n => new PlaceWorkingDay(n));
}
