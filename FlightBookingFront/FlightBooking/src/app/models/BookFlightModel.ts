export class BookFlightModel{
    
        id: number = 0;
        pnrno: string = '';
        flightId: number = 0;
        userId: number = 0;
        bookedSeats: number =  0;
        startDate: Date = new Date;
        endDate: Date = new Date;
        total: number = 0;
        appliedCoupenCode: number = 0;
        isCoupenApplied: boolean = true;
        isCancelled: boolean = true;
        meal: string = ''
      
}