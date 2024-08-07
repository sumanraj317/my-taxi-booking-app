import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BookingService } from '../../services/booking.service';
import { AuthService } from '../../services/auth.service';
import { TaxiBooking } from '../../models/taxi-booking.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css'],
})
export class BookingComponent implements OnInit {
  bookingForm: FormGroup;
  isLoading = false;
  error: string | null = null;

  constructor(
    private fb: FormBuilder,
    private bookingService: BookingService,
    private authService: AuthService,
    private router: Router
  ) {
    this.bookingForm = this.fb.group({
      pickupLocation: ['', Validators.required],
      dropLocation: ['', Validators.required],
      pickupTime: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    const user = this.authService.login;
    if (!user) {
      this.router.navigate(['/login']);
    }
  }

  onSubmit(): void {
    if (this.bookingForm.invalid) {
      return;
    }

    this.isLoading = true;
    const { pickupLocation, dropLocation, pickupTime } = this.bookingForm.value;

    const booking: TaxiBooking = {
      userId: 'someUserId', // Replace with logged-in user ID
      pickupLocation,
      dropLocation,
      pickupTime,
    };

    this.bookingService.bookTaxi(booking).subscribe({
      next: (newBooking: TaxiBooking) => {
        console.log('Booking successful!', newBooking);
        this.isLoading = false;
        this.router.navigate(['/booking-history']);
      },
      error: (err) => {
        console.error('Booking error', err);
        this.error = err.message || 'An unknown error occurred!';
        this.isLoading = false;
      },
    });
  }
}

