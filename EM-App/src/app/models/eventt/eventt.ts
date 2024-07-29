export class Eventt {

    constructor() {
        this.id = 0;
        this.title = '';
        this.description = '';
        this.eventDate = new Date;
        this.eventHour = '';
        this.eventMinute = '';
        this.place = '';
    }

    id: number;
    title: string;
    description: string;
    eventDate: Date;
    eventHour: string;
    eventMinute:string;
    place: string;
}