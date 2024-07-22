import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Eventt } from '../models/eventt/eventt';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventserviceService {

  baseUrl = `${environment.ApiURL}/eventt`;

  constructor(private http: HttpClient) { }

  //POST
  postEvent(event: Eventt) {
    return this.http.post<Eventt>(`${this.baseUrl}`, event);
  }

  //GET
  getAllEvent(): Observable<Eventt[]> {
    return this.http.get<Eventt[]>(`${this.baseUrl}`);
  }

  //GET(id)
  getEventById(id: number): Observable<Eventt> {
    return this.http.get<Eventt>(`${this.baseUrl}/${id}`);
  }

  // DELETE(id)
  deleteEvent(eventId: number) {
    return this.http.delete<Eventt>(`${this.baseUrl}/${eventId}`);
  }

  // PUT
  putEvent(event: Eventt) {
    return this.http.put<Eventt>(`${this.baseUrl}`, event);
  }
}
