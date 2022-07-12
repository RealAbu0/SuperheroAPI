import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { SuperHero } from '../models/super-hero';

@Injectable({
  providedIn: 'root'
})
export class SuperHeroService {

  private url = "Superhero";
  constructor(private http: HttpClient) { }

  public getAllSuperheroes(): Observable<SuperHero[]>{
    return this.http.get<SuperHero[]>(`${environment.apiURL}/${this.url}`);
  }
    
  public UpdateHero(hero: SuperHero): Observable<SuperHero[]>{
    return this.http.put<SuperHero[]>(`${environment.apiURL}/${this.url}`, hero);
  }

  public DeleteHero(hero: SuperHero): Observable<SuperHero[]>{
    return this.http.delete<SuperHero[]>(`${environment.apiURL}/${this.url}/${hero.superheroID}`);
  }
    
  public  CreateHero(hero: SuperHero): Observable<SuperHero[]>{
    return this.http.post<SuperHero[]>(`${environment.apiURL}/${this.url}`, hero);
  }
  
    
    
 }

