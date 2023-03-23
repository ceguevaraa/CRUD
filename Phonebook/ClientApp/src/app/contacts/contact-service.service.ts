import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  public apiUrl = '';

  constructor(private http: HttpClient) { }

  // Contact
  getContactList(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl + 'contact');
  }

  addContact(contact: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<any>(this.apiUrl + 'contact', contact, httpOptions);
  }

  updateContact(contact: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<any>(this.apiUrl + 'contact/'+contact.Id, contact, httpOptions);
  }

  deleteContact(contactId: number): Observable<number> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<number>(this.apiUrl + 'contact/' + contactId, httpOptions);
  }
}
