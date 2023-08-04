import { Component } from '@angular/core';
import { map } from 'rxjs/operators';
import { ExampleDataService } from "../services/example-data.service"


@Component({
  selector: 'app-import-json',
  templateUrl: './import-json.component.html'
})

export class ImportJsonComponent {
  fileToUpload: File | null = null;
  isCompleted: boolean = false;

  constructor(private exampleDataService: ExampleDataService) { }

  uploadFile() {
    if (this.fileToUpload !== null) {
      let test = this.exampleDataService.importJson(this.fileToUpload, this.fileToUpload.name).pipe(map(data => { })).subscribe(result => {
        this.isCompleted = true;
      });
    }
  }

  handleFileInput(e: Event) {
    let file = (e.target as HTMLInputElement).files?.[0];

    if (typeof file !== "undefined") {
      this.fileToUpload = file;
    }
  }
}
