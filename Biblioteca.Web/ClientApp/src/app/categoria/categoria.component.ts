import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-categoria',
    templateUrl: './categoria.component.html'
})
/** Categoria component*/
export class CategoriaComponent {
    /** Categoria ctor */
  public categorias: Categoria[];
  /** Autor ctor */
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Categoria[]>(baseUrl + 'api/categoria').subscribe(result => {
      this.categorias = result;
      console.log(result);
    }, error => console.error(error));
  }
}

interface Categoria {
  id: number;
  nombre: string;
  descripcion: string;
}
