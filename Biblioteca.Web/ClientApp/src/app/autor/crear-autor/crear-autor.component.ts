import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-crear-autor',
    templateUrl: './crear-autor.component.html'
})
/** CrearAutor component*/
export class CrearAutorComponent {

  autor: FormGroup;
  resAutor: any;
  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {
    this.autor = new FormGroup(
      {
        'nombre': new FormControl('', [Validators.required, Validators.maxLength(50)]),
        'apellidos': new FormControl('', [Validators.required, Validators.maxLength(50)]),
        'fechaNacimiento': new FormControl('', [Validators.required])
      }
    );
  }

  guardarAutor() {

    this.http.post(this.baseUrl + 'api/autor', this.autor)
      .subscribe(result => {
        console.log(result);
        this.resAutor = result;
    }, error => console.error(error));
  }
}
