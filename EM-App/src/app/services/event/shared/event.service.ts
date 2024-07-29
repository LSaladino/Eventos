import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, take } from 'rxjs';
import { environment } from 'src/app/environment/environment.prod';
import { Eventt } from 'src/app/models/eventt/eventt';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  baseUrl = `${environment.ApiURL}/event`;

  constructor(private http: HttpClient) { }

  //POST
  postEvent(event: Eventt) {
    return this.http.post<Eventt>(`${this.baseUrl}`, event ).pipe(take(1));
  }

  //GET
  getAllEvent(): Observable<Eventt[]> {
    let data =  this.http.get<Eventt[]>(`${this.baseUrl}`).pipe(take(1));
    return data;
  }

  //GET(id)
  getEventById(id: number): Observable<Eventt> {
    return this.http.get<Eventt>(`${this.baseUrl}/${id}`).pipe(take(1));
  }

  // DELETE(id)
  deleteEvent(eventId: number) {
    return this.http.delete<Eventt>(`${this.baseUrl}/${eventId}`).pipe(take(1));
  }

  // PUT
  putEvent(event: Eventt) {
    return this.http.put<Eventt>(`${this.baseUrl}`, {

      id: event.id,
      title: event.title,
      description: event.description,
      eventDate: event.eventDate,
      eventHour: event.eventHour,
      place: event.place

    }).pipe(take(1));
  }


}
