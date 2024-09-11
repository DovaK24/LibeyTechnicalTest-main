import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { Province } from "src/app/entities/province";

@Injectable({
	providedIn: "root",
})

export class ProvinceService {
    private baseUri = `${environment.pathLibeyTechnicalTest}Province`;
	constructor(private http: HttpClient) {}
    
    getByRegion(regionCode: string): Observable<Province[]> {
        console.log(regionCode);
        const uri = `${this.baseUri}/${regionCode}`;
        return this.http.get<Province[]>(uri);
      }
}