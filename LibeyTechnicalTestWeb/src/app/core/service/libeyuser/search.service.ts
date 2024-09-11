import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SearchService {
  private searchDniSource = new BehaviorSubject<string>(''); // Almacena el DNI buscado
  currentSearchDni = this.searchDniSource.asObservable(); // Hace observable el DNI

  setSearchDni(dni: string) {
    this.searchDniSource.next(dni);
  }
}