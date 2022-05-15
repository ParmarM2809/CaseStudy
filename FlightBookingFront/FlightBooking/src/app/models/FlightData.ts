export class FlightData {
    
        id: number = 0;
        startPoint:string = '' ;
        endPoint:string = '';
        price: number = 0;
        isAvailable: boolean = true;
        isDiscountAvailable: boolean = true ;
        airlineName: string = '';
        contactName : string= '';
        contactNumber:string = '';
        scheduledDate : Date = new Date;
}