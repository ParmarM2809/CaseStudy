export class FlightData {
    
        id: number = 0;
        startPoint:string = '' ;
        endPoint:string = '';
        price: number = 0.0;
        isAvailable: boolean = true;
        isDiscountAvailable: boolean = true ;
        airlineName: string = '';
        contactName : string= '';
        contactNumber:string = '';
        scheduledDate : string = '';
        seatAvaibility : number = 0;
}

export class SearchedFlight{
        scheduledDate : Date = new Date;
        startPoint:string = '' ;
        endPoint:string = '';
        airlineName : string = '';
}

export class Booking
{
        startPoint : string = '';
        endPoint : string = '';
        total : number = 0.0;
        airlineName : string = '';
        email : string = '' ;
        seat : number = 0;
}