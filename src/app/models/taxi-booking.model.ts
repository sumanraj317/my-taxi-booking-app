export interface TaxiBooking {
    id?: string;
    userId: string;
    pickupLocation: string;
    dropLocation: string;
    pickupTime: Date;
    status?: string;
  }
  