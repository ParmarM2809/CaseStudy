export class BookFlightModel{
    
        startPoint : string = '';
        endPoint : string = '';
        id: number = 0;
        pnrno: string = '';
        flightId: number = 0;
        userId: number = 0;
        bookedSeats: number =  0;
        scheduledDate: Date = new Date;
        total: number = 0;
        appliedCoupenCode: number = 0;
        isCoupenApplied: boolean = true;
        isCancelled: boolean = true;
        meal: string = '' ;
        flightName : string = '' ;
        price : number = 0.0;
}