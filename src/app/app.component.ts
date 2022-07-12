import { Component } from '@angular/core';
import { SuperHero } from './models/super-hero';
import { SuperHeroService } from './services/super-hero.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'superhero-api';
  heroes: SuperHero[] =[];

  HeroToEdit?: SuperHero;
  columnsToDisplay = ['Name', 'SuperheroName', 'City', 'button'];

  constructor(private superheroService: SuperHeroService){}

  ngOnInit(){
    this.superheroService.getAllSuperheroes().subscribe(
      (result: SuperHero[]) => (this.heroes = result));
  }

  InitNewHero(){
    
  }

  EditHero(hero: SuperHero){
    this.HeroToEdit = hero;
  }
}
