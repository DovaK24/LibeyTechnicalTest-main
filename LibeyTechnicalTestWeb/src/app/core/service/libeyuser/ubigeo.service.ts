import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { Ubigeo } from "src/app/entities/ubigeo";

@Injectable({
	providedIn: "root",
})

export class UbigeoService {
    private baseUri = `${environment.pathLibeyTechnicalTest}Ubigeo`;

	constructor(private http: HttpClient) {}
    
    getByProvinceAndRegion(provinceCode: string, regionCode: string): Observable<Ubigeo[]> {
        const uri = `${this.baseUri}/${provinceCode}/${regionCode}`;
        return this.http.get<Ubigeo[]>(uri);
      }
}