import { Component, OnInit } from '@angular/core';
import { BookingService } from '../../services/booking.service';
import { TaxiBooking } from '../../models/taxi-booking.model';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-booking-history',
  templateUrl: './booking-history.component.html',
  styleUrls: ['./booking-history.component.css'],
})
export class BookingHistoryComponent implements OnInit {
  bookings: TaxiBooking[] = [];
  isLoading = false;
  error: string | null = null;

  constructor(
    private bookingService: BookingService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.isLoading = true;
    const user = this.authService.login;
    if (!user) {
      return;
    }

    this.bookingService.getUserBookings('someUserId').subscribe({
      next: (bookings: TaxiBooking[]) => {
        this.bookings = bookings;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Error fetching bookings', err);
        this.error = err.message || 'An unknown error occurred!';
        this.isLoading = false;
      },
    });
  }
}

