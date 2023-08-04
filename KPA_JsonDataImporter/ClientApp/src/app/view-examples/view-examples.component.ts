import { Component } from '@angular/core';
import { map } from 'rxjs/operators';
import { ExampleDataService, ExampleModel } from "../services/example-data.service"

@Component({
  selector: 'app-view-examples',
  templateUrl: './view-examples.component.html'
})

export class ViewExamplesComponent {
  public examples: ExampleModel[] = [];

  constructor(private exampleDataService: ExampleDataService) {
    this.exampleDataService.getExamples().subscribe(result => {
      this.examples = result;
    }, error => console.error(error));
  }
}
