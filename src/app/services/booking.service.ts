import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TaxiBooking } from '../models/taxi-booking.model';

@Injectable({
  providedIn: 'root',
})
export class BookingService {
  private apiUrl = 'http://localhost:5000/api/booking';

  constructor(private http: HttpClient) {}

  bookTaxi(booking: TaxiBooking): Observable<TaxiBooking> {
    return this.http.post<TaxiBooking>(`${this.apiUrl}/book`, booking, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
    });
  }

  getUserBookings(userId: string): Observable<TaxiBooking[]> {
    return this.http.get<TaxiBooking[]>(`${this.apiUrl}/user/${userId}`, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
    });
  }
}
