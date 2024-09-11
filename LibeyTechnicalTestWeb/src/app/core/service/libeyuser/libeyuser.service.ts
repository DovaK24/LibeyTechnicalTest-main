import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { LibeyUser } from "src/app/entities/libeyuser";
@Injectable({
	providedIn: "root",
})
export class LibeyUserService {
	constructor(private http: HttpClient) {}
	Find(documentNumber: string): Observable<LibeyUser> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
		return this.http.get<LibeyUser>(uri);
	}

	Create(libeyUser: LibeyUser): Observable<LibeyUser> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser`;
		return this.http.post<LibeyUser>(uri, libeyUser);
	}
	Update(libeyUser: LibeyUser): Observable<LibeyUser> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser`;
		return this.http.put<LibeyUser>(uri, libeyUser);
	}
	Delete(documentNumber: string): Observable<void> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
		return this.http.delete<void>(uri);
	}
}