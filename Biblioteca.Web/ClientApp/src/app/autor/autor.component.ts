import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-autor',
    templateUrl: './autor.component.html'
})
/** Autor component*/
export class AutorComponent {

  public autores: Autor[];
    /** Autor ctor */
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Autor[]>(baseUrl + 'api/autor').subscribe(result => {
      this.autores = result;
      console.log(result);
    }, error => console.error(error));
  }
}


interface Autor {
  id: number;
  nombre: string;
  apellidos: string;
  fechaNacimiento: Date;
  nombreCompleto: string;
}
