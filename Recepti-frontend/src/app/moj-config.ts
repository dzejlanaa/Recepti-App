import {HttpHeaders} from "@angular/common/http";

export class MojConfig{
  static adresa_servera = "https://localhost:44390";
  static http_opcije= {
      headers: new HttpHeaders({"Content-Type":"application/json"})
  };
}


