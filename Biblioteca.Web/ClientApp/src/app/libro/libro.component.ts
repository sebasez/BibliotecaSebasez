import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-libro',
    templateUrl: './libro.component.html'
})
/** Libro component*/
export class LibroComponent {
  public libros: Libro[];
  /** Autor ctor */
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Libro[]>(baseUrl + 'api/libro').subscribe(result => {
      this.libros = result;
      console.log(result);
    }, error => console.error(error));
  }
}

interface Libro {
  id: number;
  nombreLibro: string;
  isbn: string;
  autorId: number;
  categoriaId: number;
}
