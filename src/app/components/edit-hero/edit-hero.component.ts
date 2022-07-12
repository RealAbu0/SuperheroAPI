import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { SuperHero } from 'src/app/models/super-hero';
import { SuperHeroService } from 'src/app/services/super-hero.service';


@Component({
  selector: 'app-edit-hero',
  templateUrl: './edit-hero.component.html',
  styleUrls: ['./edit-hero.component.scss']
})
export class EditHeroComponent implements OnInit {
  @Input() hero?: SuperHero; 
  @Output() heroesUpdated = new EventEmitter<SuperHero[]>();
  constructor(private superheroService: SuperHeroService) { }

  ngOnInit(): void {
  }

  UpdateHero(hero: SuperHero){
    this.superheroService.UpdateHero(hero).subscribe((heroes: SuperHero[]) => this.heroesUpdated.emit(heroes));
  }

  DeleteHero(hero: SuperHero){
    this.superheroService.DeleteHero(hero).subscribe((heroes: SuperHero[]) => this.heroesUpdated.emit(heroes));
  }

  CreateHero(hero: SuperHero){
    this.superheroService.CreateHero(hero).subscribe((heroes: SuperHero[]) => this.heroesUpdated.emit(heroes));
  }

}
