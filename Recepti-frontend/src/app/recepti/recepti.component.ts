import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";

declare function porukaSuccess(a: string): any;

@Component({
  selector: 'app-recepti',
  templateUrl: './recepti.component.html',
  styleUrls: ['./recepti.component.css']
})
export class ReceptiComponent implements OnInit {

  title:string = 'Recepti';
  naziv:string = '';
  receptPodaci: any;
  odabraniRecept: any;
  filter_naziv: string = '';

  constructor(private httpKlijent: HttpClient) {
  }

  testirajWebApi() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Recept/GetAll").subscribe(x=>{
      this.receptPodaci = x;
    });
  }


 getReceptPodaci() {
    if (this.receptPodaci == null)
      return [];
    return this.receptPodaci.filter((x: any)=> x.naziv.length==0 || (x.naziv + " " + x.opis).toLowerCase().startsWith(this.naziv.toLowerCase()) || (x.opis + " " + x.naziv).toLowerCase().startsWith(this.naziv.toLowerCase()));
  }
  

  ngOnInit(): void {
  }

  detalji(s:any) {
    this.odabraniRecept= s;
    this.odabraniRecept.prikazi = true;
}

  snimi(){
this.httpKlijent.post(MojConfig.adresa_servera + ("/Recept/Update/") + this.odabraniRecept.id, this.odabraniRecept)
.subscribe((povratnaVrijednost:any)=>{alert("uredu.. " );});


  }

  obrisiRecept(recept: any) {
    this.httpKlijent.post(MojConfig.adresa_servera + ("/Recept/Delete/") + this.odabraniRecept.id, this.odabraniRecept)
      .subscribe((res: any) => {
        let index = this.receptPodaci.indexOf(recept);
        if (index > -1) {
          this.receptPodaci.splice(recept, 1);
          this.testirajWebApi();
        }
      })
    porukaSuccess(`Recept uspješno obrisan`)
  }
  



}
