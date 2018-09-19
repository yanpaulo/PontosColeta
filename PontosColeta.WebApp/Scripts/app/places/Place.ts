import { Address } from "./Address";
import { PlaceWorkingDay } from "./PlaceWorkingDay";

export class Place {
    Id: number;

    Name: string;

    Location: string;

    Address: Address;

    WorkingDays: PlaceWorkingDay[];
}
