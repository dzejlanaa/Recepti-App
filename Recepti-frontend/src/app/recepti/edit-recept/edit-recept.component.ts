import {Component, Input, OnInit} from '@angular/core';
import {MojConfig} from "../../moj-config";
import {HttpClient} from "@angular/common/http";

declare function porukaSuccess(s:string):any;

@Component({
  selector: 'app-edit-recept',
  templateUrl: './edit-recept.component.html',
  styleUrls: ['./edit-recept.component.css']
})
export class EditReceptComponent implements OnInit {

  @Input()
  urediRecept: any;

  constructor(private httpKlijent: HttpClient) {
  }
  ngOnInit(): void {
  }

  snimi() {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Recept/Update/" + this.urediRecept.id, this.urediRecept).subscribe((povratnaVrijednost:any) =>{
      porukaSuccess("uredu..." + povratnaVrijednost.naziv);
      this.urediRecept.prikazi = false;
    });
  }
}
